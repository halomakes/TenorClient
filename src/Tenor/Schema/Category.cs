using Newtonsoft.Json;
using System;

namespace Tenor.Schema
{
    /// <summary>
    /// A category that can be searched on
    /// </summary>
    public class Category
    {
        /// <summary>
        /// The english search term that corresponds to the category
        /// </summary>
        [JsonProperty("searchterm")]
        public string SearchTerm { get; set; }

        /// <summary>
        /// The search url to request if the user selects the category
        /// </summary>
        [JsonProperty("path")]
        public Uri SearchUri { get; set; }

        /// <summary>
        /// A url to the media source for the category’s example GIF
        /// </summary>
        [JsonProperty("image")]
        public Uri ImageUri { get; set; }

        /// <summary>
        /// Category name to overlay over the image
        /// </summary>
        /// <remarks>The name will be translated to match the locale of the corresponding request</remarks>
        [JsonProperty("name")]
        public string LocalizedName { get; set; }
    }
}
