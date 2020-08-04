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
        /// Get a list of the current global trending GIFs
        /// </summary>
        /// <remarks>The trending stream is updated regularly throughout the day</remarks>
        /// <param name="limit">Maximum number of posts to retrieve</param>
        /// <param name="position">Position to start search from when using pagination</param>
        /// <returns>Result set</returns>
        public async Task<GifQueryResult> GetTrendingPostsAsync(int? limit = null, string position = null)
        {
            var @params = GetParameters(new Dictionary<string, object>
            {
                { "limit", limit },
                { "pos", position }
            });

            var requestPath = new Uri($"{BaseUrl}v1/trending").ApplyQueryParams(@params);

            return await client.GetAsync<GifQueryResult>(requestPath.ToString());
        }

        /// <summary>
        /// Get currently trending search terms
        /// </summary>
        /// <param name="limit">Maximum number of search terms to retrieve</param>
        /// <returns>Suggested search queries in provided culture</returns>
        public async Task<IEnumerable<string>> GetTrendingTermsAsync(int? limit = null)
        {
            var @params = GetParameters(new Dictionary<string, object>
            {
                { "limit", limit }
            });

            var requestPath = new Uri($"{BaseUrl}v1/autocomplete").ApplyQueryParams(@params);

            return (await client.GetAsync<SuggestionResult>(requestPath.ToString()))?.Results;
        }
    }
}
