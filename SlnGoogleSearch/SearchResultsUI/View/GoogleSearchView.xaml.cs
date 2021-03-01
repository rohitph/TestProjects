using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibSearchResults.Data;
using LibSearchResults.Interfaces;
using SearchResultsUI.ViewModel;
namespace SearchResultsUI.View
{
    /// <summary>
    /// Interaction logic for GoogleSearchView.xaml
    /// </summary>
    public partial class GoogleSearchView : UserControl
    {
        private readonly GoogleSearchViewModel m__GoogleSearchViewModel;

        public GoogleSearchView(IWebCall p_webCall, ILogger p_Logger, IJsonReader p_JsonDataReader)
        {
            
            InitializeComponent();
            m__GoogleSearchViewModel = new GoogleSearchViewModel(p_webCall,p_Logger, p_JsonDataReader);
            DataContext = m__GoogleSearchViewModel;
        }

    }
}
