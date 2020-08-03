using System;
using System.Net.Http;

namespace Tenor
{
    public partial class TenorClient
    {
        private readonly ApiClient client;
        private static readonly Uri baseUrl = new Uri("https://api.tenor.com/");
        private readonly string apiKey;

        public TenorClient(string apiKey)
        {
            this.apiKey = apiKey;
            client = new ApiClient(ConfigureHttpClient());
        }

        public TenorClient(string apiKey, HttpClient httpClient)
        {
            this.apiKey = apiKey;
            client = new ApiClient(ConfigureHttpClient(httpClient));
        }

        public TenorClient(string apiKey, IHttpClientFactory clientFactory)
        {
            this.apiKey = apiKey;
            client = new ApiClient(ConfigureHttpClient(clientFactory.CreateClient()));
        }

        private static HttpClient ConfigureHttpClient(HttpClient client = null)
        {
            if (client == null)
            {
                client = new HttpClient();
            }

            client.BaseAddress = baseUrl;
            return client;
        }
    }
}
