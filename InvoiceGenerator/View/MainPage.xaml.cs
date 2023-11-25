using InvoiceGenerator.ViewModel;
using Windows.UI.Xaml.Controls;

namespace InvoiceGenerator
{
    public sealed partial class MainPage : Page
    {
        MainPageViewModel ViewModel = new MainPageViewModel();

        public MainPage()
        {
            this.InitializeComponent();
            DataContext = ViewModel;
        }
    }
}
