using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public class HelperSettings
    {
        public static string ReadString(string key)
        {
            try
            {
                System.Configuration.AppSettingsReader rd = new System.Configuration.AppSettingsReader();
                return rd.GetValue(key, typeof(String)).ToString();
            }
            catch
            {
                return string.Empty;  
            }
        }

        public static int ReadInteger(string key)
        {
            System.Configuration.AppSettingsReader rd = new System.Configuration.AppSettingsReader();
            object value = rd.GetValue(key, typeof(int));

            if (value == null)
            {
                return 0;
            }
            else
            {
                return (int)(value);
            }
        }

        public static string ReadLogPath()
        {
            string logPath = ReadString("LOG_PATH");
            if (string.IsNullOrEmpty(logPath))
            {
                logPath = Environment.CurrentDirectory + @"\";
            }
            return logPath;
        }

    }
}
