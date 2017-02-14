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
    public class DAL
    {
        private const string url = "http://discus-api:81";
        HttpClient client = new HttpClient();       

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Object type to return</typeparam>
        /// <param name="endPoint">endpoint E.G. /Request/Table/key=value</param>
        /// <returns>List of objects that are of type T</returns>
        public async Task<List<T>> Get<T>(string endPoint) where T : class {
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

        
        public async void Post<T>(object post) where T : class {
            try
            {
                string targetEndpoint = url.ToString() + "/POST/" + typeof(T).Name;

                var content = JsonConvert.SerializeObject(post);                
                var response = await client.PostAsync(targetEndpoint, new StringContent(content));         
                Console.Read();
            }
            catch (Exception e)
            {

                throw e;
            }

        }


        
        
    }
}
