using Tenor.Attributes;

namespace Tenor.Schema
{
    /// <summary>
    /// Used to specify parental guidance level for returned content
    /// </summary>
    public enum ContentFilter
    {
        /// <summary>
        /// G-Rated content only
        /// </summary>
        [StringValue("high")] High,

        /// <summary>
        /// G and PG content only
        /// </summary>
        [StringValue("medium")] Medium,

        /// <summary>
        /// G, PG, and PG-13 content only
        /// </summary>
        [StringValue("low")] Low,

        /// <summary>
        /// G, PG, PG-13, and R content
        /// </summary>
        [StringValue("off")] Off
    }
}
