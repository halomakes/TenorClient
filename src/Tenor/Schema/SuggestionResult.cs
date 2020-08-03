using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tenor.Schema
{
    internal class SuggestionResult
    {
        [JsonProperty("results")]
        public IEnumerable<string> Results { get; set; }
    }
}
