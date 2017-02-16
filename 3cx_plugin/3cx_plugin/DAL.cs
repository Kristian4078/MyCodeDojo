using _3cx_plugin.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _3cx_plugin
{
    public static class DAL
    {
        private const string url = "http://test";             

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Object type to return</typeparam>
        /// <param name="endPoint">endpoint E.G. /Request/Table/key=value</param>
        /// <returns>List of objects that are of type T</returns>
        public static async Task<List<T>> Get<T>(string endPoint) where T : class {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string targetEndpoint = url.ToString() + endPoint.ToString();
                    var content = await client.GetStringAsync(targetEndpoint);
                    var list = JsonConvert.DeserializeObject<DataResponse<T>>(content.ToString());
                    return list as List<T>;
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
        }

        
        public static async void Post<T>(object post, string endpointOverride = null) where T : class {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    //Build Endpoint
                    string targetEndpoint = url.ToString() + "/POST/";
                    targetEndpoint += (endpointOverride == null) ? typeof(T).Name.ToLower() : endpointOverride;                                                    
                    var content = JsonConvert.SerializeObject(post);
                    var response = await client.PostAsync(targetEndpoint, new FormUrlEncodedContent(new Dictionary<string, string> { { "data", content } }));
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public static async void Put<T>(object post, string idColumnName, string endpointOverride = null) where T : class
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    //Build Endpoint
                    string targetEndpoint = url.ToString() + "/PUT/";
                    targetEndpoint += (endpointOverride == null) ? typeof(T).Name.ToLower() : endpointOverride;
                    var content = JsonConvert.SerializeObject(post);
                    var response = await client.PostAsync(targetEndpoint, new FormUrlEncodedContent(new Dictionary<string, string> { { "data", content }, { "id_column_name", idColumnName } }));
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public static async void Delete<T>(string endpointOverride, string id) where T : class
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    //Build Endpoint
                    string targetEndpoint = url.ToString() + "/PUT/";
                    targetEndpoint += (endpointOverride == null) ? typeof(T).Name.ToLower() : endpointOverride;                    
                    var response = await client.PostAsync(targetEndpoint, new FormUrlEncodedContent(new Dictionary<string, string> { { "id_column_name", id.ToString() }, { "id", id }, { } }));
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

    }
}
