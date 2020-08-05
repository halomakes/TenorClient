using System.Runtime.Serialization;

namespace Tenor.Schema
{
    /// <summary>
    /// Represents a media format/size
    /// </summary>
    public enum MediaType
    {
        /// <summary>
        /// High quality GIF format, largest file size available
        /// </summary>
        /// <remarks>Use this size for GIF shares on desktop</remarks>
        [EnumMember(Value = "gif")] Gif,

        /// <summary>
        /// Small reduction in size of the GIF format
        /// </summary>
        /// <remarks>Use this size for GIF previews on desktop</remarks>
        [EnumMember(Value = "mediumgif")] MediumGif,

        /// <summary>
        /// Reduced size of the GIF format
        /// </summary>
        /// <remarks>Use this size for GIF previews and shares on mobile</remarks>
        [EnumMember(Value = "tinygif")] TinyGif,

        /// <summary>
        /// Smallest size of the GIF format
        /// </summary>
        /// <remarks>Use this size for GIF previews on mobile</remarks>
        [EnumMember(Value = "nanogif")] NanoGif,

        /// <summary>
        /// High quality GIF format, largest file size available
        /// </summary>
        /// <remarks>Use this size for GIF shares on desktop</remarks>
        [EnumMember(Value = "gif_transparent")] TransparentGif,

        /// <summary>
        /// Small reduction in size of the GIF format
        /// </summary>
        /// <remarks>Use this size for GIF previews on desktop</remarks>
        [EnumMember(Value = "mediumgif_transparent")] TransparentMediumGif,

        /// <summary>
        /// Reduced size of the GIF format
        /// </summary>
        /// <remarks>Use this size for GIF previews and shares on mobile</remarks>
        [EnumMember(Value = "tinygif_transparent")] TransparentTinyGif,

        /// <summary>
        /// Smallest size of the GIF format
        /// </summary>
        /// <remarks>Use this size for GIF previews on mobile</remarks>
        [EnumMember(Value = "nanogif_transparent")] TransparentNanoGif,

        /// <summary>
        /// Highest quality video format, largest of the video formats, but smaller than GIF
        /// </summary>
        /// <remarks>Use this size for MP4 previews and shares on desktop</remarks>
        [EnumMember(Value = "mp4")] Mp4,

        /// <summary>
        /// Highest quality video format, larger in size than mp4
        /// </summary>
        /// <remarks>Use this size for mp4 shares if you want the video clip to run a few times rather than only once</remarks>
        [EnumMember(Value = "loopedmp4")] LoopedMp4,

        /// <summary>
        /// Reduced size of the mp4 format
        /// </summary>
        /// <remarks>Use this size for mp4 previews and shares on mobile</remarks>
        [EnumMember(Value = "tinymp4")] TinyMp4,

        /// <summary>
        /// Smallest size of the mp4 format
        /// </summary>
        /// <remarks>Use this size for mp4 previews on mobile</remarks>
        [EnumMember(Value ="nanomp4")]NanoMp4,

        /// <summary>
        /// Lower quality video format, smaller in size than MP4
        /// </summary>
        /// <remarks>Use this size for webm previews and shares on desktop</remarks>
        [EnumMember(Value = "webm")] WebM,

        /// <summary>
        /// Reduced size of the webm format
        /// </summary>
        /// <remarks>Use this size for GIF shares on mobile</remarks>
        [EnumMember(Value = "tinywebm")] TinyWebM,

        /// <summary>
        /// Smallest size of the webm format
        /// </summary>
        /// <remarks>Use this size for GIF previews on mobile</remarks>
        [EnumMember(Value = "nanowebm")] NanoWebM,

        /// <summary>
        /// Transparent webp image
        /// </summary>
        [EnumMember(Value = "webp_transparent")]TransparentWebP,

        /// <summary>
        /// Smaller transparent webp image
        /// </summary>
        [EnumMember(Value ="tinywebp_transparent")]TinyTransparentWebP,

        /// <summary>
        /// Smallest transparent webp image
        /// </summary>
        [EnumMember(Value = "nanowebp_transparent")]NanoTransparentWebP
    }
}
