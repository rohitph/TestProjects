using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibSearchResults.Utilities;
using LibSearchResults.Data;
namespace Tests.SearchResults
{
    [TestClass]
    public class JsonDataTest
    {
        private SearchCriteria m_FetchedParamaters;
        public JsonDataTest()
        {
            JsonReader objJsonReader = new JsonReader(@"C:\Rohit\TestProject\SlnGoogleSearch\parameters.json");
            m_FetchedParamaters = objJsonReader.ReadParametersFromFile();
        }
        [TestMethod]
        public void ShouldLoadUrlParameter()
        {
            Assert.AreEqual("https://www.google.com.au", m_FetchedParamaters.Url);
        }

        [TestMethod]
        public void ShouldLoadMaxResultsParameter()
        {

            Assert.AreEqual(100, m_FetchedParamaters.MaxResults);
        }

        [TestMethod]
        public void ShouldLoadSearchKeywordsParameter()
        {

            Assert.AreEqual("conveyancing software", m_FetchedParamaters.SearchKeywords);
        }

        [TestMethod]
        public void ShouldLoadTermToAppearParameter()
        {

            Assert.AreEqual("www.smokeball.com.au", m_FetchedParamaters.TermToAppear);
        }
    }
}
