using System;
using System.Globalization;
using Tenor.Schema;

namespace Tenor
{
    /// <summary>
    /// Configuration for Tenor API client
    /// </summary>
    public class TenorConfiguration
    {
        /// <summary>
        /// Base URL of API
        /// </summary>
        public Uri BaseUrl { get; set; } = new Uri("https://api.tenor.com/");

        /// <summary>
        /// Key to use to authenticate API requests
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Locale to use for requests
        /// </summary>
        public CultureInfo Locale { get; set; }

        /// <summary>
        /// Parental guidance level to restrict requests to
        /// </summary>
        public ContentFilter? ContentFilter { get; set; }

        /// <summary>
        /// Media content types to filter requests to
        /// </summary>
        public MediaFilter? MediaFilter { get; set; }

        /// <summary>
        /// Aspect ratio range to filter requests to
        /// </summary>
        public AspectRatio? AspectRatio { get; set; }
    }
}
