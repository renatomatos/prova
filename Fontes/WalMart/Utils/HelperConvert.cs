using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public class HelperConvert
    {
        public static int ToInt(string s)
        {
            int result;
            if (int.TryParse(s, out result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }

        public static DateTime ToDateTime(string s)
        {
            DateTime result;
            if (DateTime.TryParse(s, out result))
            {
                return result;
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        public static bool IsDateTime(string s)
        {
            DateTime result;
            if (DateTime.TryParse(s, out result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidDate(DateTime date)
        {
            if ((date.Day == DateTime.MinValue.Day) && (date.Month == DateTime.MinValue.Month) && (date.Year == DateTime.MinValue.Year))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsValidDate(string date)
        {
            return IsValidDate(ToDateTime(date));
        }

        public static double ToDouble(string s)
        {
            double result;
            if (double.TryParse(s, out result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }

        public static decimal ToDecimal(string s)
        {
            decimal result;
            if (decimal.TryParse(s, out result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }

        public static float ToFloat(string s)
        {
            float result;
            if (float.TryParse(s, out result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }

        public static string ToString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            else
            {
                return value;
            }
        }

    }
}
