using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oxide.Core.Libraries;
using Oxide.Ext.Discord.Callbacks.Api;
using Oxide.Ext.Discord.Entities.Api;
using Oxide.Ext.Discord.Json.Serialization;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Pooling;

namespace Oxide.Ext.Discord.Rest.Requests
{
    /// <summary>
    /// Represents a REST API request that returns {T} data
    /// </summary>
    /// <typeparam name="T">Data to be returned</typeparam>
    public class Request<T> : BaseRequest
    {
        /// <summary>
        /// Callback to call if the request completed successfully
        /// </summary>
        internal Action<T> OnSuccess;

        /// <summary>
        /// Creates a REST API request that returns type of T from the response
        /// </summary>
        /// <param name="client">Client making the request</param>
        /// <param name="httpClient"><see cref="HttpClient"/> for the request</param>
        /// <param name="method">HTTP web method</param>
        /// <param name="route">Route for the request</param>
        /// <param name="data">Data being passed into the request. Null if no data is passed</param>
        /// <param name="onSuccess">Callback when the web request finishes successfully</param>
        /// <param name="onError">Callback when the web request fails to complete successfully and encounters an error</param>
        /// <param name="callback">Completed callback for the request</param>
        /// <returns>A <see cref="Request{T}"/></returns>
        public static Request<T> CreateRequest(DiscordClient client, HttpClient httpClient, RequestMethod method, string route, object data, Action<T> onSuccess, Action<RequestError> onError, BaseApiCompletedCallback callback)
        {
            Request<T> request = DiscordPool.Get<Request<T>>();
            request.Init(client, httpClient, method, route, data, onSuccess, onError, callback);
            return request;
        }
        
        /// <summary>
        /// Initializes the Request
        /// </summary>
        private void Init(DiscordClient client, HttpClient httpClient, RequestMethod method, string route, object data, Action<T> onSuccess, Action<RequestError> onError, BaseApiCompletedCallback callback)
        {
            base.Init(client, httpClient, method, route, data, onError, callback);
            OnSuccess = onSuccess;
        }

        ///<inheritdoc/>
        protected override void OnRequestSuccess(RequestResponse response)
        {
            if (OnSuccess == null)
            {
                if (Logger.IsLogging(DiscordLogLevel.Verbose))
                {
                    Logger.Verbose("Skipping Callback for {0}. No Callback specified.", typeof(T).Name);
                }
                
                return;
            }
            
            try
            {
                T data = JsonConvert.DeserializeObject<T>(response.Content, Client.Bot.JsonSettings);
                ApiSuccessCallback<T>.Start(this, data);
            }
            catch (Exception ex)
            {
                Logger.Exception("An error occured deserializing JSON response. Method: {0} Route: {1}\nResponse:\n{2}", Method, Route, response.Content, ex);
            }
        }

        ///<inheritdoc/>
        protected override void EnterPool()
        {
            base.EnterPool();
            OnSuccess = null;
        }
    }
}