using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tenor.Schema;
using Tenor.Utils;

namespace Tenor
{
    public partial class TenorClient
    {
        /// <summary>
        /// Get related search suggestions to your current query
        /// </summary>
        /// <param name="query">Current query</param>
        /// <param name="limit">Maximum number of suggestions</param>
        /// <returns>Suggested search queries in provided culture</returns>
        public async Task<IEnumerable<string>> GetSearchSuggestionsAsync(string query, int? limit = null)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentException("Query is required.");
            }

            var @params = GetParameters(new Dictionary<string, object>
            {
                { "q", query },
                { "limit", limit }
            });

            var requestPath = new Uri($"{BaseUrl}v1/search_suggestions").ApplyQueryParams(@params);

            return (await client.GetAsync<SuggestionResult>(requestPath.ToString()))?.Results;
        }

        /// <summary>
        /// Get autocomplete suggestions for a partial query
        /// </summary>
        /// <param name="query">Partial query</param>
        /// <param name="limit">Maximum number of suggestions to retrieve</param>
        /// <returns>Suggested search queries in provided culture</returns>
        public async Task<IEnumerable<string>> GetAutocompleteSuggestionsAsync(string query, int? limit = null)
        {
            if (string.IsNullOrEmpty(query))
            {
                return new List<string>();
            }

            var @params = GetParameters(new Dictionary<string, object>
            {
                { "q", query },
                { "limit", limit }
            });

            var requestPath = new Uri($"{BaseUrl}v1/autocomplete").ApplyQueryParams(@params);

            return (await client.GetAsync<SuggestionResult>(requestPath.ToString()))?.Results;
        }
    }
}
