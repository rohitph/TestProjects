using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SearchResultsUI.ViewModel;
using LibSearchResults.Interfaces;
using LibSearchResults.Data;
using System.Collections.Generic;
using LibSearchResults.Utilities;
using LibSearchResults;
using System.Threading.Tasks;
using System.Windows.Input;
namespace Tests.SearchResults.ViewModel
{
    [TestClass]
    public class GoogleSearchViewModelTest
    {
        private GoogleSearchViewModel m_viewModel;
        private Mock<IWebCall> m_IWebCall;
        private Mock<ILogger> m_ILogger;
        private Mock<IJsonReader> m_IJsonDataReader;
        public GoogleSearchViewModelTest()
        {
            m_IWebCall = new Mock<IWebCall>();
            m_ILogger = new Mock<ILogger>();
            m_IJsonDataReader = new Mock<IJsonReader>();

            SearchCriteria objSearchCriteria = new SearchCriteria()
            {
                Url = "https://www.google.com.au"
               ,
                MaxResults = 10
               ,
                SearchKeywords = "conveyancing software"
               ,
                TermToAppear = "www.smokeball.com.au"
            };

            m_IWebCall.Setup(x => x.GetResultsAsync(objSearchCriteria)).ReturnsAsync(() => new List<string> { "www.smokeball.com.au", "www.leap.com.au" });

            m_IWebCall.Setup(x => x.GetLinkPositionsInResults(new List<string> { "www.smokeball.com.au", "www.leap.com.au" }, "www.smokeball.com.au")).Returns(new string("3,4"));

            m_IJsonDataReader.Setup(x => x.ReadParametersFromFile()).Returns(objSearchCriteria);
            //new SearchCriteria()
            //{
            //    Url = "https://www.google.com.au"
            //    ,MaxResults = 100
            //    ,SearchKeywords = "conveyancing software"
            //    ,TermToAppear = "www.smokeball.com.au"
            //});

            m_viewModel = new GoogleSearchViewModel(m_IWebCall.Object, m_ILogger.Object, m_IJsonDataReader.Object);
            ICommand ic = m_viewModel.GetCommand;
            ic.Execute(this);
        }

        [TestMethod]
        public void ShouldLoadParameters()
        {
            Assert.IsNotNull(m_viewModel.Url);
            Assert.IsNotNull(m_viewModel.MaxResults);
            Assert.IsNotNull(m_viewModel.SearchKeywords);
            Assert.IsNotNull(m_viewModel.TermToAppear);
        }

        [TestMethod]
        public void ShouldLoadResultsData()
        {
            Assert.IsNotNull(m_viewModel.Results);
            
        }

    }
}
