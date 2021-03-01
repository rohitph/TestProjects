using System;
using System.Net;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Collections.Generic;
using LibSearchResults.Data;
using LibSearchResults.Interfaces;
using LibSearchResults.Utilities;
using System.Linq;
namespace LibSearchResults
{
    public class WebCall: IWebCall
    {
        public WebCall()
        {

        }
        //public string GetResults()
        //{
        //    testFunc();
        //    List<string> lstResults = new List<string>();
        //    WebClient client = new WebClient();

        //    var content = client.DownloadString("https://www.google.com.au/search?num=100&q=conveyancing+software");
        //    File.WriteAllText(@"C:\Rohit\TestProject\SlnGoogleSearch\results.xml", content);


        //    HtmlDocument pageDocument = new HtmlDocument();
        //    pageDocument.LoadHtml(content);
        //    var nodes = pageDocument.DocumentNode.SelectNodes("//div[contains(@class,'kCrYT')]");

        //    var testNodes = pageDocument.DocumentNode.SelectNodes("//a");
        //    foreach (HtmlNode node in nodes)
        //    {
        //        //var childNodes = node.ChildNodes;
        //        //var result = node.SelectSingleNode("a");

        //        foreach (var nodeA in node.ChildNodes)
        //        {
        //            if (nodeA.Name == "a")
        //            {
        //                string urlVal = nodeA.GetAttributeValue("href", "Not found");
        //                if (urlVal.Contains("facebook.com"))
        //                {
        //                    string sStop = "Stop";
        //                }
        //                lstResults.Add(nodeA.GetAttributeValue("href", "Not found"));
        //            }
        //        }
        //        //if (childNode != null)
        //        //{
        //        //    string sHref = childNode.GetAttributeValue("href", "Not found");
        //        //    if (sHref != "Not found")
        //        //        lstResults.Add(sHref);
        //        //}


        //    }
        //    File.WriteAllLines(@"C:\Rohit\TestProject\SlnGoogleSearch\resultUrls.txt", lstResults.ToArray());
        //    return content;
        //}

        public async Task<List<string>> GetResultsAsync(SearchCriteria p_SearchCriteria)
        {
            List<string> lstResults = new List<string>();

            WebClient client = new WebClient();

            string sSearchKeywords = p_SearchCriteria.SearchKeywords.Trim().Replace(" ", "+");
            string sUrl = string.Concat(p_SearchCriteria.Url.TrimEnd('/'), "/search?num=", p_SearchCriteria.MaxResults, "&q=", sSearchKeywords);
            var content = await client.DownloadStringTaskAsync(new Uri(sUrl));

            HtmlDocument googResultsHtml = new HtmlDocument();
            googResultsHtml.OptionOutputAsXml = true;
            googResultsHtml.LoadHtml(content);

            foreach (HtmlNode node in googResultsHtml.DocumentNode.SelectNodes("//a[@href]"))
            {
                if (node.ParentNode.Name == "div")
                {
                    string hrefValue = node.GetAttributeValue("href", string.Empty);
                    
                    if (!hrefValue.Contains("google", StringComparison.CurrentCultureIgnoreCase) && hrefValue.Contains("/url?q=http", StringComparison.CurrentCultureIgnoreCase))
                        lstResults.Add(hrefValue.Replace("/url?q=", string.Empty));

                }
            }
            return lstResults;
        }

        public string GetLinkPositionsInResults(List<string> p_lstResults, string p_sLinkName)
        {
            var lstIndexes = Extensions.IndexesWhere(p_lstResults, x => x.Contains(p_sLinkName, StringComparison.CurrentCultureIgnoreCase)).ToList();
            
            return string.Join(",", lstIndexes);

        }
        
    }
}
