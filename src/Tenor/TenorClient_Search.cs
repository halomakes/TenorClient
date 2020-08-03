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
        /// Perform a search for GIFs by keywords
        /// </summary>
        /// <param name="query">Query to search on</param>
        /// <param name="limit">Maximum number of posts to retrieve</param>
        /// <param name="position">Position to start search from when using pagination</param>
        /// <returns>Result set</returns>
        public async Task<SearchResult> SearchAsync(string query, int? limit = null, string position = null)
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

            return await client.GetAsync<SearchResult>(requestPath.ToString());
        }

        /// <summary>
        /// Search for GIFs by tag
        /// </summary>
        /// <param name="category">Category to search by</param>
        /// <param name="limit">Maximum number of posts to retrieve</param>
        /// <param name="position">Position to start search from when using pagination</param>
        /// <returns>Result set</returns>
        public async Task<SearchResult> SearchAsync(Category category, int? limit = null, string position = null)
        {
            if (category == null)
            {
                throw new ArgumentException("Category is required.");
            }

            var @params = GetParameters(new Dictionary<string, object>
            {
                { "tag", category.SearchTerm },
                { "limit", limit },
                { "pos", position }
            });

            var requestPath = new Uri($"{BaseUrl}v1/search").ApplyQueryParams(@params);

            return await client.GetAsync<SearchResult>(requestPath.ToString());
        }

        /// <summary>
        /// Get random GIFs matching a search query
        /// </summary>
        /// <param name="query">Query to search on</param>
        /// <param name="limit">Maximum number of posts to retrieve</param>
        /// <param name="position">Position to start search from when using pagination</param>
        /// <returns>Result set</returns>
        public async Task<GifQueryResult> GetRandomPostsAsync(string query, int? limit = null, string position = null)
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

            var requestPath = new Uri($"{BaseUrl}v1/random").ApplyQueryParams(@params);

            return await client.GetAsync<GifQueryResult>(requestPath.ToString());
        }
    }
}
