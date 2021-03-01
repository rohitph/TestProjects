using System;
using System.Collections.Generic;
using System.Text;

namespace LibSearchResults.Interfaces
{
    public interface ILogger
    {
        void Info(string p_sInfoString);
        void Error(string p_sErrorString);
        void DumpLog();
    }
}
