using System;

namespace Tenor
{
    public class TenorException : Exception
    {
        public int StatusCode { get; set; }
        public string Endpoint { get; set; }
        public string ResponseContent { get; set; }
    }
}
