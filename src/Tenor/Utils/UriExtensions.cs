using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Tenor.Utils
{
    internal static class UriExtensions
    {
        public static Uri ApplyQueryParams(this Uri uri, Dictionary<string, object> @params)
        {
            var builder = new UriBuilder(uri);
            var query = HttpUtility.ParseQueryString(builder.Query);
            foreach (var pair in @params)
            {
                if (pair.Value != null)
                {
                    switch (pair.Value)
                    {
                        case Enum e:
                            query[pair.Key] = e.GetStringValue();
                            break;
                        case CultureInfo c:
                            query[pair.Key] = c.Name;
                            break;
                        default:
                            query[pair.Key] = pair.Value?.ToString();
                            break;
                    }
                }
                else
                {
                    if (query.AllKeys.Contains(pair.Key))
                    {
                        query.Remove(pair.Key);
                    }
                }
            }
            builder.Query = query.ToString();
            return builder.Uri;
        }
    }
}
