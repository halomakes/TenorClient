using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tenor.Schema;
using Tenor.Utils;

namespace Tenor
{
    public partial class TenorClient
    {
        public async Task<SearchResults> SearchAsync(
            string query,
            int? limit = null,
            string position = null
            )
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentException("Query is required.");
            }

            var @params = GetParameters(new Dictionary<string, object>
            {
                { "q", query },
                { "limit", limit },
                { "pos", position }
            });

            var requestPath = new Uri($"{BaseUrl}v1/search").ApplyQueryParams(@params);

            return await client.GetAsync<SearchResults>(requestPath.ToString());
        }
    }
}
