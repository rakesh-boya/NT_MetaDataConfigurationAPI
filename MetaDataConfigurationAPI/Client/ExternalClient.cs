using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MetaDataConfigurationAPI.Client
{
    public class ExternalClient : IExternalClient
    {
        private readonly HttpClient _httpClient;
        public ExternalClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://4c60fb78-cb19-4be9-b90a-044987c370f4.mock.pstmn.io");
        }
        public async Task<string> CallExternalAPIAsync(string Entity)
        {
            return await _httpClient.GetStringAsync(Entity);
        }
    }
}
