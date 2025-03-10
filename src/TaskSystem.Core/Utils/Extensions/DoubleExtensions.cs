using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSystem.Core.Utils.Extensions
{
    public static class DoubleExtensions
    {
        public static double ToDouble<T>(this object value)
        {
            return Convert.ToDouble(value);
        }
    }
}
