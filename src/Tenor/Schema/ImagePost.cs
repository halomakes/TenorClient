using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Tenor.Utils;

namespace Tenor.Schema
{
    /// <summary>
    /// A post made by a user on tenor.com
    /// </summary>
    public class ImagePost
    {
        /// <summary>
        /// Tags applied to the post
        /// </summary>
        [JsonProperty("tags")]
        public IEnumerable<string> Tags { get; set; }

        /// <summary>
        /// A short URL to view the post on tenor.com
        /// </summary>
        [JsonProperty("url")]
        public Uri ShortUrl { get; set; }

        /// <summary>
        /// An array of dictionaries with GifFormat as the key and Medium as the value
        /// </summary>
        [JsonProperty("media")]
        public IEnumerable<Dictionary<MediaType, MediaItem>> Media { get; set; }

        /// <summary>
        /// A unix timestamp representing when this post was created
        /// </summary>
        [JsonProperty("created")]
        private double _createdDate { get; set; }

        /// <summary>
        /// When the post was created
        /// </summary>
        public DateTime CreatedDate => _createdDate.ToDateTime();

        [JsonProperty("shares")]
        public int Shares { get; set; }

        /// <summary>
        /// The full URL to view the post on tenor.com
        /// </summary>
        [JsonProperty("itemurl")]
        public Uri FullUrl { get; set; }

        /// <summary>
        /// Indicates if this post contains audio
        /// </summary>
        /// <remarks>Only video formats support audio, the gif image file format can not contain audio information</remarks>
        [JsonProperty("hasaudio")]
        public bool HasAudio { get; set; }

        /// <summary>
        /// The title of the post
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Tenor result identifier
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }


}
