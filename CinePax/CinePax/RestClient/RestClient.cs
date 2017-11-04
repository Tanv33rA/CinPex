using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CinePax.Models;
using Newtonsoft.Json;

namespace CinePax.RestClient
{
    public class RestClient<T>
    {
        public async Task<List<T>> GetAsync(string uri)
        {
            using (var httoClient = new HttpClient())
            {
                var Json = await httoClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<List<T>>(Json);
            }
        }
        public async Task<bool> PostAsync(T t, string uri)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(t);
                HttpContent httpContent = new StringContent(uri);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var Result = await httpClient.PostAsync(uri, httpContent);
                return Result.IsSuccessStatusCode;
            }
        }
        public async Task<bool> PutAsync(int id, T t, string uri)
        {
            using (var httpClient = new HttpClient())
            {
                var Json = JsonConvert.SerializeObject(t);
                HttpContent httpContent = new StringContent(Json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var Result = await httpClient.PutAsync(uri + id, httpContent);
                return Result.IsSuccessStatusCode;
            }
        }

        public async Task<bool> DeleteAsync(int id, string uri, T t)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(uri + id);
                return response.IsSuccessStatusCode;
            }
        }

    }
}
