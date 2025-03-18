using CryptoViewer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryptoViewer.Data.Services
{
    public class Serialaizer
    {
        private static readonly JsonSerializerOptions _serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

        public static T? Deserialize<T>(string jsonStr)
        {
            if (jsonStr is null || jsonStr == String.Empty)
            {
                return default(T);
            }
            return JsonSerializer.Deserialize<T>(jsonStr, _serializeOptions);
        }
    }
}
