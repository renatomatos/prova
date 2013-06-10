using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Utils
{
    public class HelperLog
    {
        private static object lck = new object();
        
        /// <summary>
        /// Retorna o caminho completo de um arquivo de LOG usando o PATH informato no AppSettings para a chave
        /// LOG concatenado do ano+mes+dia. O arquivo terá extensão .log
        /// </summary>
        /// <returns></returns>
        private static string FileName()
        {
            return HelperSettings.ReadLogPath() + @"\" + DateTime.Now.ToString("yyyyMMdd") + ".log";
        }
        
        public static void WriteText(string fileName, string text)
        {
            lock (lck)
            {
                StreamWriter MyStreamWriter = new StreamWriter(fileName, true);
                MyStreamWriter.WriteLine(text);
                MyStreamWriter.Close();
            }
        }

        public static void WriteText(Exception ex, string complement)
        {
            string fileName = FileName();

            WriteText(fileName, "==========================================================");
            WriteText(fileName, "Date: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
            WriteText(fileName, "Message: " + ex != null ? ex.Message : "");
            WriteText(fileName, "Complement: " + complement);
            WriteText(fileName, "InnerException: " + ex != null && ex.InnerException != null ? ex.InnerException.GetType().FullName : "");
            WriteText(fileName, "Source: " + ex != null ? ex.Source : "");
            WriteText(fileName, "StackTrace: " + ex != null ? ex.StackTrace : "");
        }

    }
}
