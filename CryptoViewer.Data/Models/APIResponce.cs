using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.Data.Models
{
    public class ResponceList<T>
    {
        public IEnumerable<T> Data { get; set; }
        public long Timestamp { get; set; }
    }

    public class Responce<T>
    {
        public T Data { get; set; }
        public long Timestamp { get; set; }
    }
}
