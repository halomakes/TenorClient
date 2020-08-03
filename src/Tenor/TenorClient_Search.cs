using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Tenor.Schema;
using Tenor.Utils;

namespace Tenor
{
    public partial class TenorClient
    {
        public async Task<SearchResults> SearchAsync(
            string query,
            CultureInfo locale = null,
            ContentFilter? contentFilter = null,
            MediaFilter? mediaFilter = null,
            AspectRatio? aspectRatio = null,
            int? limit = null,
            string position = null
            )
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentException("Query is required.");
            }

            var args = new Dictionary<string, object>
            {
                { "key", apiKey },
                { "q", query },
                { "locale", locale },
                { "contentfilter", contentFilter },
                { "media_filter", mediaFilter },
                { "ar_range", aspectRatio },
                { "limit", limit },
                { "pos", position }
            };

            var requestPath = new Uri($"{baseUrl}v1/search").ApplyQueryParams(args);

            return await client.GetAsync<SearchResults>(requestPath.ToString());
        }
    }
}
