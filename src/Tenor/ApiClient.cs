using JsonNet.ContractResolvers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tenor
{
    class ApiClient
    {
        protected static JsonSerializerSettings settings;

        protected HttpClient httpClient;

        static ApiClient()
        {
            settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Include,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                ContractResolver = new PrivateSetterCamelCasePropertyNamesContractResolver()
            };
            settings.Converters.Add(new StringEnumConverter());
        }

        public ApiClient()
        {
            httpClient = new HttpClient();
        }

        public ApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, endpoint))
            {
                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                var stream = await response.Content.ReadAsStreamAsync();

                if (response.IsSuccessStatusCode)
                {
                    return DeserializeJsonResponse<T>(stream);
                }

                throw new TenorException
                {
                    StatusCode = (int)response.StatusCode,
                    ResponseContent = await StreamToStringAsync(stream),
                    Endpoint = endpoint
                };
            }
        }

        public async Task<string> GetStringAsync(string endpoint)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, endpoint))
            {
                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                var stream = await response.Content.ReadAsStreamAsync();

                if (response.IsSuccessStatusCode)
                {
                    return await StreamToStringAsync(stream);
                }

                throw new TenorException
                {
                    StatusCode = (int)response.StatusCode,
                    ResponseContent = await StreamToStringAsync(stream),
                    Endpoint = endpoint
                };
            }
        }

        public async Task<T> PostAsync<T>(string endpoint, T content)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, endpoint))
            {
                request.Content = CreateHttpContent(content);
                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                var stream = await response.Content.ReadAsStreamAsync();

                if (response.IsSuccessStatusCode)
                {
                    return DeserializeJsonResponse<T>(stream);
                }

                throw new TenorException
                {
                    StatusCode = (int)response.StatusCode,
                    ResponseContent = await StreamToStringAsync(stream),
                    Endpoint = endpoint
                };
            }
        }

        public async Task<S> PostAsync<T, S>(string endpoint, T content)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, endpoint))
            {
                request.Content = CreateHttpContent(content);
                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                var stream = await response.Content.ReadAsStreamAsync();

                if (response.IsSuccessStatusCode)
                {
                    return DeserializeJsonResponse<S>(stream);
                }

                throw new TenorException
                {
                    StatusCode = (int)response.StatusCode,
                    ResponseContent = await StreamToStringAsync(stream),
                    Endpoint = endpoint
                };
            }
        }

        public async Task PostNoResponseAsync<TInput>(string endpoint, TInput content)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, endpoint))
            {
                request.Content = CreateHttpContent(content);
                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                var stream = await response.Content.ReadAsStreamAsync();

                if (response.IsSuccessStatusCode)
                {
                    return;
                }

                throw new TenorException
                {
                    StatusCode = (int)response.StatusCode,
                    ResponseContent = await StreamToStringAsync(stream),
                    Endpoint = endpoint
                };
            }
        }

        public async Task PutNoResponseAsync<TInput>(string endpoint, TInput content)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Put, endpoint))
            {
                request.Content = CreateHttpContent(content);
                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                var stream = await response.Content.ReadAsStreamAsync();

                if (response.IsSuccessStatusCode)
                {
                    return;
                }

                throw new TenorException
                {
                    StatusCode = (int)response.StatusCode,
                    ResponseContent = await StreamToStringAsync(stream),
                    Endpoint = endpoint
                };
            }
        }

        public async Task<TOutput> PutAsync<TInput, TOutput>(string endpoint, TInput content)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Put, endpoint))
            {
                request.Content = CreateHttpContent(content);
                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                var stream = await response.Content.ReadAsStreamAsync();

                if (response.IsSuccessStatusCode)
                {
                    return DeserializeJsonResponse<TOutput>(stream);
                }

                throw new TenorException
                {
                    StatusCode = (int)response.StatusCode,
                    ResponseContent = await StreamToStringAsync(stream),
                    Endpoint = endpoint
                };
            }
        }

        public async Task<TModel> PutAsync<TModel>(string endpoint, TModel content)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Put, endpoint))
            {
                request.Content = CreateHttpContent(content);
                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                var stream = await response.Content.ReadAsStreamAsync();

                if (response.IsSuccessStatusCode)
                {
                    return DeserializeJsonResponse<TModel>(stream);
                }

                throw new TenorException
                {
                    StatusCode = (int)response.StatusCode,
                    ResponseContent = await StreamToStringAsync(stream),
                    Endpoint = endpoint
                };
            }
        }

        public async Task DeleteAsync(string endpoint)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Delete, endpoint))
            {
                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                var stream = await response.Content.ReadAsStreamAsync();

                if (response.IsSuccessStatusCode)
                {
                    return;
                }

                throw new TenorException
                {
                    StatusCode = (int)response.StatusCode,
                    ResponseContent = await StreamToStringAsync(stream),
                    Endpoint = endpoint
                };
            }
        }

        protected HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, settings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        protected virtual T DeserializeJsonResponse<T>(Stream stream)
        {
            if (stream == null || stream.CanRead == false)
            {
                return default;
            }

            using (var sr = new StreamReader(stream))
            using (var jtr = new JsonTextReader(sr))
            {
                var js = new JsonSerializer();
                var searchResult = js.Deserialize<T>(jtr);
                return searchResult;
            }
        }

        private static async Task<string> StreamToStringAsync(Stream stream)
        {
            string content = null;

            if (stream != null)
            {
                using (var sr = new StreamReader(stream))
                {
                    content = await sr.ReadToEndAsync();
                }
            }

            return content;
        }
    }
}