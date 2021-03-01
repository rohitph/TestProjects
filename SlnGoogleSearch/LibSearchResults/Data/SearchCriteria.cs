using System;
using System.Collections.Generic;
using System.Text;

namespace LibSearchResults.Data
{
    public class SearchCriteria
    {
        public string Url { get; set; }
        public int MaxResults { get; set; }
        public string SearchKeywords { get; set; }
        public string TermToAppear { get; set; }
    }
}
