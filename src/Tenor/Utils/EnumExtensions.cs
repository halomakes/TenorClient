using System;
using System.Linq;
using System.Reflection;
using Tenor.Attributes;

namespace Tenor.Utils
{
    internal static class EnumExtensions
    {
        public static string GetStringValue<TEnum>(this TEnum value) where TEnum : Enum =>
            value.GetAttribute<StringValueAttribute>()?.Value ?? value?.ToString();

        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue) where TAttribute : Attribute =>
            enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()
                ?.GetCustomAttribute<TAttribute>();
    }
}
