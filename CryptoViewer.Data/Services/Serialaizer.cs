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
            return JsonSerializer.Deserialize<T>(jsonStr, _serializeOptions);
        }

        public static IEnumerable<Candle> DesirealizeToCandlesFromAnnamedArray(string jsonStr)
        {
            var result = JsonSerializer.Deserialize<dynamic[]>(jsonStr) ?? throw new ArgumentNullException();
            
            List<Candle> candles = new List<Candle>();
            foreach (var candle in result)
            {
                candles.Add(new Candle()
                {
                    Timestemp = candle[0].GetInt64(),
                    Open = double.Parse(candle[1].GetString(), System.Globalization.CultureInfo.InvariantCulture),
                    High = double.Parse(candle[2].GetString(), System.Globalization.CultureInfo.InvariantCulture),
                    Low = double.Parse(candle[3].GetString(), System.Globalization.CultureInfo.InvariantCulture),
                    Close = double.Parse(candle[4].GetString(), System.Globalization.CultureInfo.InvariantCulture)
                });
            };

            return candles;
        }
    }
}
