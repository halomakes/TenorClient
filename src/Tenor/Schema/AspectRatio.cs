using Tenor.Attributes;

namespace Tenor.Schema
{
    /// <summary>
    /// Specifies what aspect ratio of content should be returned
    /// </summary>
    public enum AspectRatio
    {
        /// <summary>
        /// No constraint on aspect ratio
        /// </summary>
        [StringValue("all")] All,

        /// <summary>
        /// Aspect ratios between 0.42 and 2.36
        /// </summary>
        [StringValue("wide")] Wide,

        /// <summary>
        /// Aspect ratios between .56 and 1.78
        /// </summary>
        [StringValue("standard")] Standard
    }
}
