using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.Data.Exceptions
{
    internal class HttpClientBadRequestException:Exception
    {
        public HttpClientBadRequestException() : base() { }
        public HttpClientBadRequestException(string message) : base(message) { }
        public HttpClientBadRequestException(string message, Exception innerException) : base(message, innerException) { }
    }
}
