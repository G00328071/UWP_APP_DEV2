using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyWeather
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class myNote : Page
    {
        public myNote()
        {
            
            this.InitializeComponent();
            this.Loaded += MyNote_Loaded;

        }

        private async void MyNote_Loaded(object sender, RoutedEventArgs e)
        {
          var mapNotes= await App.Notes.GetMyMapNotes();
            this.DataContext = mapNotes;
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddNote));
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //sets the note itself as clickable.
            // and the event (e) is now passable to the other cs pages
           this.Frame.Navigate(typeof(AddNote), e.ClickedItem);
        }

        private void MenuFlyoutItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void MenuFlyoutItem_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Map));
        }
    }
}
