using Newtonsoft.Json;

namespace Tenor.Schema
{
    /// <summary>
    /// Result returned by a search request
    /// </summary>
    public class SearchResult : GifQueryResult
    {
        /// <summary>
        /// Url to view search results in the browser
        /// </summary>
        [JsonProperty("weburl")]
        public string WebUrl { get; set; }
    }
}
