using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DUWENINK.Core.Infrastructure;
using Newtonsoft.Json;
using RestSharp;

namespace DUWENINK.Core.Services
{
    public class RequestHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TGetRequestResult"></typeparam>
        /// <param name="getRequest"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public static async Task<T> GetResponseAsync<T, TGetRequestResult>(TGetRequestResult getRequest ,Method method= Method.GET) where TGetRequestResult : GetRequestResult
        {
           
            var request = new RestRequest(method);
            var client = new RestClient(getRequest.Url);
            //if (getRequest.Data != null) {
            //    request.AddParameter("undefined", JsonConvert.SerializeObject(getRequest),ParameterType.RequestBody);
            //}
            request.AddHeader("cache-control", "no-cache");
            var response = await client.ExecuteTaskAsync(request);
            return JsonConvert.DeserializeObject<T>(response.StatusCode == HttpStatusCode.OK ? response.Content : null);
        }
        public static async Task<T> GetTResponseAsync<T,K, TGetRequestResult>(TGetRequestResult getRequest, Method method = Method.GET) where TGetRequestResult : GetRequestResult<K>
        {

            var request = new RestRequest(method);
            var client = new RestClient(getRequest.Url);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            if (getRequest.Data != null)
            {
                request.AddParameter("undefined", JsonConvert.SerializeObject(getRequest.Data), ParameterType.RequestBody);
            }
            
            var response = await client.ExecuteTaskAsync(request);
            return JsonConvert.DeserializeObject<T>(response.StatusCode == HttpStatusCode.OK ? response.Content : null);
        }

    }
}
