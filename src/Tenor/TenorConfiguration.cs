using System;
using System.Globalization;
using Tenor.Schema;

namespace Tenor
{
    public class TenorConfiguration
    {
        public Uri BaseUrl { get; set; } = new Uri("https://api.tenor.com/");
        public string ApiKey { get; set; }
        public CultureInfo Locale { get; set; }
        public ContentFilter? ContentFilter { get; set; }
        public MediaFilter? MediaFilter { get; set; }
        public AspectRatio? AspectRatio { get; set; }
    }
}
