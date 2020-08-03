using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Tenor.Schema
{
    /// <summary>
    /// A media item from a post in a specified format
    /// </summary>
    public class MediaItem
    {
        /// <summary>
        /// A url to the media source
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("dims")]
        private IEnumerable<int> _dimensions { get; set; }

        /// <summary>
        /// Width and height in pixels
        /// </summary>
        public Dimensions Dimensions => new Dimensions
        {
            Width = _dimensions.FirstOrDefault(),
            Height = _dimensions.LastOrDefault()
        };

        /// <summary>
        /// Length of the media in seconds
        /// </summary>
        [JsonProperty("duration")]
        public double Duration { get; set; }

        /// <summary>
        /// A url to a preview image of the media source
        /// </summary>
        [JsonProperty("preview")]
        public string PreviewUrl { get; set; }

        /// <summary>
        /// Size of the file in bytes
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; }
    }


}
