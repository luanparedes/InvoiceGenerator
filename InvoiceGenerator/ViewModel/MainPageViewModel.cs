using InvoiceGenerator.View;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace InvoiceGenerator.ViewModel
{
    public class MainPageViewModel
    {
        #region Constants

        private const string APP_PATH = "InvoiceGenerator.View.";

        #endregion

        #region Variables and Properties

        Frame _contentFrame;

        #endregion

        #region Constructor

        public MainPageViewModel()
        {

        }

        #endregion

        #region Handlers

        public void MainNavigationTabs_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected == true)
            {
                _contentFrame.Navigate(typeof(SettingsPage));
            }
            else if (args.SelectedItemContainer != null)
            {
                NavigationViewItem navItem = args.SelectedItem as NavigationViewItem;
                Type pageType = Type.GetType(APP_PATH + (string)navItem.Tag);
                
                if(pageType != null)
                    _contentFrame.Navigate(pageType);
            }
        }

        public void ContentFrame_Loaded(object sender, RoutedEventArgs e)
        {
            _contentFrame = sender as Frame;
            _contentFrame.Navigate(typeof(Aba1Page));
        }

        #endregion
    }
}
