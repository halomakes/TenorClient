using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;

namespace Tenor.Schema
{
    /// <summary>
    /// Result when requesting a list of categories
    /// </summary>
    public class CategoryResult
    {
        [JsonProperty("locale")]
        private string _locale { get; set; }

        /// <summary>
        /// Culture that results are in
        /// </summary>
        /// <returns></returns>
        public CultureInfo GetLocale()
        {
            try
            {
                return CultureInfo.GetCultureInfo(_locale);
            }
            catch (CultureNotFoundException)
            {
                return null;
            }
        }

        /// <summary>
        /// Available categories
        /// </summary>
        [JsonProperty("tags")]
        public IEnumerable<Category> Categories { get; set; }
    }
}
