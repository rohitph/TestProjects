using System;
using System.Collections.Generic;
using System.Text;
using LibSearchResults.Data;
namespace LibSearchResults.Interfaces
{
    public interface IJsonReader
    {
        SearchCriteria ReadParametersFromFile();
    }
}
