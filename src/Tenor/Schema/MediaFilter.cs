using Tenor.Attributes;

namespace Tenor.Schema
{
    /// <summary>
    /// Specifies which media types to retrieve
    /// </summary>
    public enum MediaFilter
    {
        /// <summary>
        /// tinygif, gif, and mp4
        /// </summary>
        [StringValue("minimal")]Minimal,

        /// <summary>
        /// nanomp4, tinygif, tinymp4, gif, mp4, and nanogif
        /// </summary>
        [StringValue("basic")]Basic
    }
}
