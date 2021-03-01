using System.ComponentModel;
using LibSearchResults.Data;
using System.Windows.Input;
using System;
using LibSearchResults.Interfaces;
using System.Collections.Generic;
namespace SearchResultsUI.ViewModel
{
    public class GoogleSearchViewModel : INotifyPropertyChanged
    {
        #region "Member Variables"
        private IWebCall m_IWebCall;
        private ILogger m_Logger;
        private SearchCriteria m_SearchCriteria;
        private ICommand m_GetCommand;
        private string m_Results;
        #endregion "Member Variables"
        public GoogleSearchViewModel(IWebCall p_webCall, ILogger p_Logger, IJsonReader p_JsonReader)
        {
            m_IWebCall = p_webCall;
            m_Logger = p_Logger;

            m_SearchCriteria = p_JsonReader.ReadParametersFromFile();

        }
        public ICommand GetCommand
        {
            get
            {
                if (m_GetCommand == null)
                {
                    m_GetCommand = new GetData(
                        p => this.GetDataCall()
                        );
                }
                return m_GetCommand;
            }
            set
            {
                m_GetCommand = value;
            }
        }
        private async void GetDataCall()
        {
            try
            {
                SearchCriteria objSearchCriteria = new SearchCriteria()
                {
                    Url = this.Url
                   ,
                    MaxResults = this.MaxResults
                   ,
                    SearchKeywords = this.SearchKeywords
                   ,
                    TermToAppear = this.TermToAppear
                };
                var lstAllResults = await m_IWebCall.GetResultsAsync(objSearchCriteria);

                lstAllResults.ForEach(x => m_Logger.Info(x));
                m_Logger.Info("**************************************");

                Results = m_IWebCall.GetLinkPositionsInResults(lstAllResults, objSearchCriteria.TermToAppear);
                m_Logger.Info(string.Concat("Indexes: ", Results));
                m_Logger.DumpLog();
            }
            catch(Exception ex)
            {
                m_Logger.Error(string.Concat("Error", ex.Message));
                throw;
            }
        }

        #region "Properties"
        public string Url
        {
            get { return m_SearchCriteria.Url; }
            set
            {
                if (m_SearchCriteria.Url != value)
                {
                    m_SearchCriteria.Url = value;
                    OnPropertyChange("Url");

                }
            }
        }

        public int MaxResults
        {
            get { return m_SearchCriteria.MaxResults; }
            set
            {
                if (m_SearchCriteria.MaxResults != value)
                {
                    m_SearchCriteria.MaxResults = value;
                    OnPropertyChange("MaxResults");

                }
            }
        }

        public string SearchKeywords
        {
            get { return m_SearchCriteria.SearchKeywords; }
            set
            {
                if (m_SearchCriteria.SearchKeywords != value)
                {
                    m_SearchCriteria.SearchKeywords = value;
                    OnPropertyChange("SearchKeywords");

                }
            }
        }

        public string TermToAppear
        {
            get { return m_SearchCriteria.TermToAppear; }
            set
            {
                if (m_SearchCriteria.TermToAppear != value)
                {
                    m_SearchCriteria.TermToAppear = value;
                    OnPropertyChange("TermToAppear");

                }
            }
        }

        public string Results
        {
            get { return m_Results; }
            set
            {
                if (m_Results != value)
                {
                    m_Results = value;
                    OnPropertyChange("Results");

                }
            }
        }
        #endregion "Properties"


        public event PropertyChangedEventHandler PropertyChanged;

        
        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private class GetData : ICommand
        {
            private readonly Action<object> m_execute;
  
            public GetData(Action<object> execute)
            {
                m_execute = execute;
            }
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                m_execute(parameter);


            }

        }
    }
}
