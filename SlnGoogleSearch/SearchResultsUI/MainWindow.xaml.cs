using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibSearchResults;
using LibSearchResults.Data;
using LibSearchResults.Interfaces;
namespace SearchResultsUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IWebCall p_webCall, ILogger p_logger,IJsonReader p_JsonDataReader)
        {
            InitializeComponent();
            View.GoogleSearchView objGoogleSearchView = new View.GoogleSearchView(p_webCall, p_logger, p_JsonDataReader);
            _mainFrame.Navigate(objGoogleSearchView);
        }

    }
}
