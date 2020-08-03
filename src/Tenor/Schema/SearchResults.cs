using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tenor.Schema
{
    /// <summary>
    /// Result returned by a search request
    /// </summary>
    public class SearchResults
    {
        /// <summary>
        /// Url to view search results in the browser
        /// </summary>
        [JsonProperty("weburl")]
        public string WebUrl { get; set; }

        /// <summary>
        /// Collection of results matching search criteria
        /// </summary>
        [JsonProperty("results")]
        public IEnumerable<ImagePost> Results { get; set; }

        /// <summary>
        /// Sequence ID used to fetch next page of results
        /// </summary>
        [JsonProperty("next")]
        public string NextPositionId { get; set; }
    }
}
