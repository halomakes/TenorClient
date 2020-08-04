using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tenor.Schema;
using Tenor.Utils;

namespace Tenor
{
    public partial class TenorClient
    {
        /// <summary>
        /// Tell tenor that a GIF has been shared
        /// </summary>
        /// <remarks>This helps Tenor's analytics to improve search results</remarks>
        /// <param name="id">ID of post that was shared</param>
        /// <param name="query">Query that was used when searching</param>
        public async Task RecordShareAsync(string id, string query)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("ID is required.");
            }

            var @params = GetParameters(new Dictionary<string, object>
            {
                { "q", query },
                { "id", id }
            });

            var requestPath = new Uri($"{BaseUrl}v1/autocomplete").ApplyQueryParams(@params);

            await client.GetStringAsync(requestPath.ToString());
        }

        /// <summary>
        /// Get a single post by ID
        /// </summary>
        /// <param name="id">ID of the post</param>
        /// <returns>A single post, if found</returns>
        public async Task<ImagePost> GetPostAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("ID is required.");
            }

            return (await GetPostsAsync(new List<string> { id }, 1))?.Results?.FirstOrDefault();
        }

        /// <summary>
        /// Get a collection of posts by ID
        /// </summary>
        /// <param name="ids">IDs of the posts</param>
        /// <returns>Matching posts</returns>
        public Task<GifQueryResult> GetPostsAsync(params string[] ids) => GetPostsAsync(ids);

        /// <summary>
        /// Get a collection of posts by ID
        /// </summary>
        /// <param name="ids">IDs of the posts</param>
        /// <param name="limit">Maximum # of posts to fetch</param>
        /// <returns>Matching posts</returns>
        public async Task<GifQueryResult> GetPostsAsync(IEnumerable<string> ids, int? limit = null)
        {
            var filteredIds = ids.Select(i => i?.Trim()).Where(i => !string.IsNullOrEmpty(i));

            if (!filteredIds.Any())
            {
                throw new ArgumentException("At least 1 ID must be provided.");
            }

            var idString = string.Join(",", filteredIds);

            var @params = GetParameters(new Dictionary<string, object>
            {
                { "ids", idString },
                { "limit", limit }
            });

            var requestPath = new Uri($"{BaseUrl}v1/gifs").ApplyQueryParams(@params);

            return await client.GetAsync<GifQueryResult>(requestPath.ToString());
        }
    }
}
