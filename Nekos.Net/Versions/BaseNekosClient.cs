using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

// ReSharper disable InconsistentNaming

namespace Nekos.Net.Versions
{
    public class BaseNekosClient
    {
        protected static async Task<T> GetResponse<T>(string destination)
        {
            using (var httpClient = new HttpClient())
            {
                var req = new HttpRequestMessage(HttpMethod.Get, destination);
                var res = await httpClient.SendAsync(req);

                if (!res.IsSuccessStatusCode)
                    throw new HttpRequestException($"Unwanted status code found: {res.StatusCode}");

                var response = await res.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(response);
            }
        }
    }
}