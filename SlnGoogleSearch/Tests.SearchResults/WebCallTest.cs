using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using LibSearchResults.Interfaces;
using LibSearchResults;
using LibSearchResults.Data;
using System.Collections.Generic;
namespace Tests.SearchResults
{
    [TestClass]
    public class WebCallTest
    {
        private Mock<ILogger> m_ILogger;
        private IWebCall m_IWebCall;
        public WebCallTest()
        {
            m_ILogger = new Mock<ILogger>();
            m_IWebCall = new WebCall();
        }
        [TestMethod]
        public void WebCallShouldReturn10Records()
        {
            var results = m_IWebCall.GetResultsAsync(new SearchCriteria()
            {
                Url = "https://www.google.com.au"
                ,MaxResults = 10
                ,SearchKeywords = "conveyancing software"
                ,TermToAppear = "www.smokeball.com.au"
            }).Result;
            Assert.AreEqual(10, results.Count);
        }

        [TestMethod]
        public void WebCallShouldReturn50Records()
        {
            var results = m_IWebCall.GetResultsAsync(new SearchCriteria()
            {
                Url = "https://www.google.com.au"
                ,
                MaxResults = 50
                ,
                SearchKeywords = "conveyancing software"
                ,
                TermToAppear = "www.smokeball.com.au"
            }).Result;
            Assert.AreEqual(50, results.Count);
        }

        [TestMethod]
        public void WebCallShouldReturn100Records()
        {
            var results = m_IWebCall.GetResultsAsync(new SearchCriteria()
            {
                Url = "https://www.google.com.au"
                ,
                MaxResults = 100
                ,
                SearchKeywords = "conveyancing software"
                ,
                TermToAppear = "www.smokeball.com.au"
            }).Result;
            Assert.AreEqual(100, results.Count);
        }

        [TestMethod]
        public void WebCallShouldReturnCorrectIndexes()
        {
            List<string> lstAllResults = new List<string>();
            lstAllResults.Add("https://www.leapconveyancer.com.au/&amp;sa=U&amp;ved=2ahUKEwixqujU74vvAhXjHrkGHSsfB7kQFjAAegQIShAB&amp;usg=AOvVaw3lOAY3YPQxP1eSCiOKo8-M");
            lstAllResults.Add("https://www.smokeball.com.au/conveyancing.html&amp;sa=U&amp;ved=2ahUKEwixqujU74vvAhXjHrkGHSsfB7kQFjABegQIYhAB&amp;usg=AOvVaw1Bncq13b2SdLx78j6aZToX");
            lstAllResults.Add("https://www.leap.com.au/area-of-law/conveyancing/&amp;sa=U&amp;ved=2ahUKEwixqujU74vvAhXjHrkGHSsfB7kQFjACegQIXxAB&amp;usg=AOvVaw3mTK6b73eZvY9ogd4iEfKv");
            lstAllResults.Add("https://www.smokeball.com.au/index.html&amp;sa=U&amp;ved=2ahUKEwirysDI1YnvAhVTrZ4KHTa-DqgQFjADegQIWBAB&amp;usg=AOvVaw339XH2y2ZUhFrd9DNb0ehg");
            var results = m_IWebCall.GetLinkPositionsInResults(lstAllResults, "www.smokeball.com.au");
            Assert.IsTrue(results.Length > 0);
            Assert.AreEqual("2,4", results);

        }
    }
}
