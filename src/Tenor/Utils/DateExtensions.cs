using System;

namespace Tenor.Utils
{
    internal static class DateExtensions
    {
        public static DateTime ToDateTime(this double unixTimeStamp) =>
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
            .AddSeconds(unixTimeStamp)
            .ToLocalTime();
    }
}
