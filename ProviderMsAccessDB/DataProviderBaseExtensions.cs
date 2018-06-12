using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderMsAccessDB
{
    internal static class DataProviderBaseExtensions
    {
        public static object GetValueOrDBNull(this object a)
        {
            return (a == null) ? (object)DBNull.Value : a;
        }

        public static T GetValue<T>(this object a)
        {
            return (a is DBNull || a == null) ? default(T) : (T)a;
        }

        public static T GetValue<T>(this object a, T defaultValue)
        {
            return (!(a is T)) ? defaultValue : (T)a;
        }

        public static bool IsNullOrDBNull(this object a)
        {
            return (a == null || a is DBNull);
        }

        public static bool IsNotNullOrDBNullAndIs<T>(this object a)
        {
            return (a != null && !(a is DBNull) && a is T);
        }

        public static string ObjectToCurrencyString(object val)
        {
            CultureInfo ci = new CultureInfo("de-DE");

            return (val != null && val is decimal) ?
                Convert.ToDecimal(val).ToString("C", ci.NumberFormat) :
                decimal.Zero.ToString("C", ci.NumberFormat);
        }
    }
}
