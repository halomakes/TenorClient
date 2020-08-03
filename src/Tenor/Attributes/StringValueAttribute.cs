using System;

namespace Tenor.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class StringValueAttribute : Attribute
    {
        public StringValueAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}
