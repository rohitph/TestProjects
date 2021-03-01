using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using LibSearchResults.Interfaces;
using System.IO;
using LibSearchResults.Data;
namespace LibSearchResults.Utilities
{
    public class JsonReader : IJsonReader
    {
        private string m_sFileName;
        public JsonReader(string p_sFileName)
        {
            m_sFileName = p_sFileName;
        }
        public SearchCriteria ReadParametersFromFile()
        {
            string sJsonData = File.ReadAllText(m_sFileName);
            SearchCriteria objSearchCriteria = new SearchCriteria();

            dynamic obj = JsonConvert.DeserializeObject(sJsonData);
            objSearchCriteria = new SearchCriteria();
            objSearchCriteria.Url = obj.Url;
            objSearchCriteria.MaxResults = obj.MaxResults;
            objSearchCriteria.SearchKeywords = obj.SearchKeywords;
            objSearchCriteria.TermToAppear = obj.TermToAppear;

            return objSearchCriteria;
        }
    }
}
