using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Tenor
{
    public partial class TenorClient
    {
        private readonly ApiClient client;
        private readonly TenorConfiguration config;
        private Uri BaseUrl => config.BaseUrl;

        public TenorClient(string apiKey)
        {
            config = new TenorConfiguration { ApiKey = apiKey };
            client = new ApiClient(ConfigureHttpClient());
        }

        public TenorClient(string apiKey, HttpClient httpClient)
        {
            config = new TenorConfiguration { ApiKey = apiKey };
            client = new ApiClient(ConfigureHttpClient(httpClient));
        }

        public TenorClient(string apiKey, IHttpClientFactory clientFactory)
        {
            config = new TenorConfiguration { ApiKey = apiKey };
            client = new ApiClient(ConfigureHttpClient(clientFactory.CreateClient()));
        }

        public TenorClient(TenorConfiguration config)
        {
            this.config = config;
            client = new ApiClient(ConfigureHttpClient());
        }

        public TenorClient(TenorConfiguration config, HttpClient httpClient)
        {
            this.config = config;
            client = new ApiClient(ConfigureHttpClient(httpClient));
        }

        public TenorClient(TenorConfiguration config, IHttpClientFactory clientFactory)
        {
            this.config = config;
            client = new ApiClient(ConfigureHttpClient(clientFactory.CreateClient()));
        }

        private HttpClient ConfigureHttpClient(HttpClient client = null)
        {
            if (client == null)
            {
                client = new HttpClient();
            }

            client.BaseAddress = BaseUrl;
            return client;
        }

        private Dictionary<string, object> GetParameters(Dictionary<string, object> customParamters)
        {
            var defaultParameters = new Dictionary<string, object>
            {
                { "key", config.ApiKey },
                { "locale", config.Locale },
                { "contentfilter", config.ContentFilter },
                { "media_filter", config.MediaFilter },
                { "ar_range", config.AspectRatio },
            };
            return defaultParameters.Union(customParamters).ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}
