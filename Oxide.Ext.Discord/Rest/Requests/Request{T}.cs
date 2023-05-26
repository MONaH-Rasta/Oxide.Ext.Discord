using System;
using System.Net.Http;
using Newtonsoft.Json;
using Oxide.Core.Libraries;
using Oxide.Ext.Discord.Entities.Api;
using Oxide.Ext.Discord.Interfaces.Promises;
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
        private IPendingPromise<T> _promise;

        /// <summary>
        /// Creates a REST API request that returns type of T from the response
        /// </summary>
        /// <param name="pluginPool"><see cref="DiscordPluginPool"/> for the request</param>
        /// <param name="client">Client making the request</param>
        /// <param name="httpClient"><see cref="HttpClient"/> for the request</param>
        /// <param name="method">HTTP web method</param>
        /// <param name="route">Route for the request</param>
        /// <param name="data">Data being passed into the request. Null if no data is passed</param>
        /// <returns>A <see cref="Request{T}"/></returns>
        public new static Request<T> CreateRequest(DiscordPluginPool pluginPool, DiscordClient client, HttpClient httpClient, RequestMethod method, string route, object data, IPendingPromise<T> promise)
        {
            Request<T> request = pluginPool.Get<Request<T>>();
            request.Init(client, httpClient, method, route, data);
            request._promise = promise;
            return request;
        }

        ///<inheritdoc/>
        protected override void OnRequestSuccess(RequestResponse response)
        {
            try
            {
                T data = JsonConvert.DeserializeObject<T>(response.Content, Client.Bot.JsonSettings);
                _promise.Resolve(data);
            }
            catch (Exception ex)
            {
                Logger.Exception("An error occured deserializing JSON response. Method: {0} Route: {1}\nResponse:\n{2}", Method, Route, response.Content, ex);
            }
        }

        protected override void OnRequestError(RequestResponse response)
        {
            _promise.Finally(response.Error.LogError);
            _promise.Reject(response.Error);
        }

        ///<inheritdoc/>
        protected override void EnterPool()
        {
            base.EnterPool();
            _promise = null;
        }
    }
}