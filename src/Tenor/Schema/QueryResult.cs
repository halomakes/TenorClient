using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tenor.Schema
{
    /// <summary>
    /// Paginated result returned for a request
    /// </summary>
    public class QueryResult
    {
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
