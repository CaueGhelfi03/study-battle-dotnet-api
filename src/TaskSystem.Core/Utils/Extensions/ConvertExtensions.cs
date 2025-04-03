using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSystem.Core.Utils.Extensions
{
    public static class ConvertExtensions
    {
        public static double ToDouble(this object value)
        {
            var successfulConversion = double.TryParse(value.ToString(), CultureInfo.InvariantCulture, out double result);

            if (!successfulConversion)
                throw new Exception($"Erro ao converter {value} para double.");

            return result;
        }

        public static decimal ToDecimal(this object value)
        {
            var successfulConversion = decimal.TryParse(value.ToString(), CultureInfo.InvariantCulture, out decimal result);

            if (!successfulConversion)
                throw new Exception($"Erro ao converter {value} para decimal.");

            return result;
        }

        public static int ToInt(this object value)
        {
            var successfulConversion = int.TryParse(value.ToString(), out int result);

            if (!successfulConversion)
                throw new Exception($"Erro ao converter {value} para int.");

            return result;
        }
    }
}
