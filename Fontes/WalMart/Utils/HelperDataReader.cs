using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public class HelperDataReader
    {
        public static string GetString(System.Data.SqlClient.SqlDataReader rd, string field)
        {
            var index = rd.GetOrdinal(field);
            if (index < 0)
            {
                return string.Empty;
            }
            else
            {
                if (rd.IsDBNull(index))
                {
                    return string.Empty;
                }
                else
                {
                    return rd.GetString(index);
                }
            }
        }

        public static int GetInteger(System.Data.SqlClient.SqlDataReader rd, string field)
        {
            var index = rd.GetOrdinal(field);
            if (index < 0)
            {
                return 0;
            }
            else
            {
                if (rd.IsDBNull(index))
                {
                    return 0;
                }
                else
                {
                    return rd.GetInt32(index);
                }
            }
        }

        public static double GetDouble(System.Data.SqlClient.SqlDataReader rd, string field)
        {
            var index = rd.GetOrdinal(field);
            if (index < 0)
            {
                return 0;
            }
            else
            {
                if (rd.IsDBNull(index))
                {
                    return 0;
                }
                else
                {
                    return rd.GetDouble(index);
                }
            }
        }

        public static decimal GetDecimal(System.Data.SqlClient.SqlDataReader rd, string field)
        {
            var index = rd.GetOrdinal(field);
            if (index < 0)
            {
                return 0;
            }
            else
            {
                if (rd.IsDBNull(index))
                {
                    return 0;
                }
                else
                {
                    return rd.GetDecimal(index);
                }
            }
        }

        public static DateTime? GetDateTime(System.Data.SqlClient.SqlDataReader rd, string field)
        {
            var index = rd.GetOrdinal(field);
            if (index < 0)
            {
                return null;
            }
            else
            {
                if (rd.IsDBNull(index))
                {
                    return null;
                }
                else
                {
                    return rd.GetDateTime(index);
                }
            }
        }

        public static DateTime GetDateTimeParseNull(System.Data.SqlClient.SqlDataReader rd, string field)
        {
            if (GetDateTime(rd, field).HasValue)
            {
                return GetDateTime(rd, field).Value;
            }
            else
            {
                return DateTime.MinValue;
            }
        }
    }
}
