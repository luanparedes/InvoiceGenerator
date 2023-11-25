using InvoiceGenerator.View;
using System;
using System.Collections.Generic;
using Windows.Storage;
using Windows.Storage.Pickers;
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

        private IReadOnlyList<StorageFile> _files;
        private Frame _contentFrame;

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

        public async void Button_Click(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker();

            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            
            picker.FileTypeFilter.Add(".xlsx");
            picker.FileTypeFilter.Add(".xlsm");
            picker.FileTypeFilter.Add(".xlsb");
            picker.FileTypeFilter.Add(".xltx");

            _files = await picker.PickMultipleFilesAsync();
        }

        #endregion
    }
}
