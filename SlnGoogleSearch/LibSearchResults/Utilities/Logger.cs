using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using LibSearchResults.Interfaces;
namespace LibSearchResults.Utilities
{
    public class Logger : ILogger
    {
        protected StringBuilder m_sbLogData = new StringBuilder();
        private string m_sFolderPath;
        public Logger(string p_sFolderPath)
        {
            m_sFolderPath = p_sFolderPath;
        }

        public void DumpLog()
        {
            string sFilePath = string.Concat(m_sFolderPath,@"\SearchAppLogs_", DateTime.Now.Year, "_", DateTime.Now.Month, "_", DateTime.Now.Day,".txt");
            File.WriteAllText(sFilePath, m_sbLogData.ToString());
        }

        public void Error(string p_sErrorString)
        {
            m_sbLogData.Append(string.Concat(DateTime.Now, " Error:", p_sErrorString,Environment.NewLine));
        }

        public void Info(string p_sInfoString)
        {
            m_sbLogData.Append(string.Concat(DateTime.Now, " Info:", p_sInfoString, Environment.NewLine));
        }
    }
}
