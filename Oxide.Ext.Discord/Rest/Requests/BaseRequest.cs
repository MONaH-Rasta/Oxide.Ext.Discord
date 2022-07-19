using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Oxide.Core.Libraries;
using Oxide.Ext.Discord.Callbacks.Api;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Entities.Api;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Helpers;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Pooling;
using Oxide.Ext.Discord.Rest.Buckets;

namespace Oxide.Ext.Discord.Rest.Requests
{
    /// <summary>
    /// Represents a base request class for REST API calls
    /// </summary>
    public abstract class BaseRequest : BasePoolable
    {
        /// <summary>
        /// ID of the request. Generated from the DateTimeOffset when the request was created
        /// </summary>
        public Snowflake Id;
        
        /// <summary>
        /// HTTP request method
        /// </summary>
        public RequestMethod Method;

        /// <summary>
        /// Current status of the request
        /// </summary>
        public RequestStatus Status;

        /// <summary>
        /// Route on the API
        /// </summary>
        public string Route;

        /// <summary>
        /// Data to be sent with the request
        /// </summary>
        public object Data;

        /// <summary>
        /// Callback to call if the request errored with the last error message
        /// </summary>
        internal Action<RequestError> OnError;
        
        /// <summary>
        /// Discord Client making the request
        /// </summary>
        internal DiscordClient Client;
        internal HttpClient HttpClient;
        internal CancellationTokenSource Source;
        internal Bucket Bucket;
        internal bool IsCancelled => Source.IsCancellationRequested;

        /// <summary>
        /// How long to wait before retrying request since there was a web exception
        /// </summary>
        private DateTimeOffset _errorResetAt;
        private ILogger _logger;

        /// <summary>
        /// Initializes the request
        /// </summary>
        protected void Init(DiscordClient client, HttpClient httpClient, RequestMethod method, string route, object data, Action<RequestError> onError)
        {
            Id = SnowflakeIdGenerator.Generate();
            Client = client;
            HttpClient = httpClient;
            Method = method;
            Route = route;
            Data = data;
            OnError = onError;
            Source = new CancellationTokenSource();
            _logger = client.Logger;
            _logger.Debug($"{nameof(BaseRequest)}.{nameof(Init)} Request Created Plugin: {{0}} Request ID: {{1}} Method: {{2}} Route: {{3}}", client.PluginName, Id, Method, route);
        }

        internal async Task WaitUntilRequestCanStart(CancellationToken token)
        {
            if (_errorResetAt > DateTimeOffset.UtcNow)
            {
                _logger.Debug($"{nameof(BaseRequest)}.{nameof(WaitUntilRequestCanStart)} Request ID: {{0}} Can't Start Request Due to Previous Error Reset Waiting For: {{1}} Seconds", Id, (_errorResetAt - DateTimeOffset.UtcNow).TotalSeconds);
                await Task.Delay(_errorResetAt - DateTimeOffset.UtcNow, token);
            }
        }

        internal void OnRequestCompleted(RequestHandler handler, RequestResponse response)
        {
            Status = RequestStatus.Completed;

            if (response.Status == RequestCompletedStatus.Success)
            {
                OnRequestSuccess(response);
            }
            else if (response.Status != RequestCompletedStatus.Cancelled)
            {
                OnRequestError(response);
            }
            
            Bucket.OnRequestCompleted(handler, response);
            
            BaseRequest request = handler.Request;
            Client.Logger.Debug($"{nameof(BaseRequest)}.{nameof(OnRequestCompleted)} Bucket ID: {{0}} Request ID: {{1}} Plugin: {{2}} Method: {{3}} Route: {{4}}", Bucket.Id, request.Id, request.Client.PluginName, request.Method, request.Route);
        }

        /// <summary>
        /// Callback for successful API Calls
        /// </summary>
        /// <param name="response">Response for the API Call</param>
        protected abstract void OnRequestSuccess(RequestResponse response);

        /// <summary>
        /// Callback for API calls that error
        /// </summary>
        /// <param name="response">Response for the error</param>
        private void OnRequestError(RequestResponse response)
        {
            ApiErrorCallback callback = DiscordPool.Get<ApiErrorCallback>();
            callback.Init(this, response);
            callback.Run();
        }

        internal void OnRequestErrored()
        {
            _errorResetAt = MathExt.Max(_errorResetAt, DateTimeOffset.UtcNow + TimeSpan.FromSeconds(1)); 
            _logger.Debug($"{nameof(BaseRequest)}.{nameof(OnRequestErrored)} Request ID: {{0}} Waiting For {{1}} Seconds", Id, (_errorResetAt - DateTimeOffset.UtcNow).TotalSeconds);
        }

        ///<inheritdoc/>
        protected override void EnterPool()
        {
            Id = default(Snowflake);
            Method = default(RequestMethod);
            Status = default(RequestStatus);
            Route = null;
            HttpClient = null;
            Data = null;
            OnError = null;
            Client = null;
            Source = null;
            Bucket = null;
            _errorResetAt = DateTimeOffset.MinValue;
            _logger = null;
        }

        ///<inheritdoc/>
        protected override void LeavePool()
        {
            Status = RequestStatus.InQueue;
        }
    }
}