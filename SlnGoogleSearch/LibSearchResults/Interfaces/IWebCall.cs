using System.Collections.Generic;
using System.Threading.Tasks;
using LibSearchResults.Data;
namespace LibSearchResults.Interfaces
{
    public interface IWebCall
    {
        public Task<List<string>> GetResultsAsync(SearchCriteria p_SearchCriteria);
        string GetLinkPositionsInResults(List<string> p_lstResults, string p_sLinkName);
    }
}
