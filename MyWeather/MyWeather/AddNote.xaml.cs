using MyWeather.Notes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage.Streams;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyWeather
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddNote : Page
    {
        private bool viewing = false;
        private MyMapNote myText;
        
        public AddNote()
        {
            this.InitializeComponent();
            
        }

       

        //private async  void AddNote_Loaded(object setter, NavigationEventArgs e)
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {

            //map service token from bing maps
            Map.MapServiceToken = "TOfdeDRJwGImuiaL7W88~SlMn6bqFU6GCmOupV2lB-g~AsoKvGZZisSkTudn4cs2nwQzmGl7eS58HojnUjiskKBwBEYkH-7yUV7sRAXsADIr";
            //set map style for add note feature.
            Map.Style = MapStyle.AerialWithRoads;
            Geopoint pos;
            if (e.Parameter == null)
            {
                viewing = false;

                var location = new Geolocator();
                location.DesiredAccuracyInMeters = 50;
                var position = await location.GetGeopositionAsync();
                pos = position.Coordinate.Point;

               
            }
            else
            {

                viewing = true;

                myText =(MyMapNote)e.Parameter;
                titleTextBox.Text = myText.Title;
                noteTextBox.Text = myText.Note;
                //if viewing =true then we are in the delete mode
                // and add button content will change to delete
                // and the function will change to a delete function
                addBtn.Content = "Delete";

                var myPos = new Windows.Devices.Geolocation.BasicGeoposition();
                myPos.Latitude = myText.Latitude;
                myPos.Longitude = myText.Longitude;

                //drop a ancor pin to mark center point
                pos = new Geopoint(myPos);
                MapIcon icon = new MapIcon();
                icon.Location = pos;
                icon.NormalizedAnchorPoint = new Point(0.5, 1.0);
                icon.Title = "Note Location";
                icon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Pin.png"));
                icon.ZIndex = 0;
                Map.MapElements.Add(icon);
                Map.Center = pos;


            }

            await Map.TrySetViewAsync(pos, 14D);
        }

        public void MenuFlyoutItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(myNote));
        }

        public async void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (viewing)
            {
                //we want to delete the note
                //ask the user if they really want to delete the note
                var message = new Windows.UI.Popups.MessageDialog("Do you want to Delete!");
                message.Commands.Add(new UICommand("Delete", new UICommandInvokedHandler(this.CommandInvokedHandler)));
                message.Commands.Add(new UICommand("Cancel", new UICommandInvokedHandler(this.CommandInvokedHandler)));

                message.DefaultCommandIndex = 0;

                message.CancelCommandIndex = 1;

                await message.ShowAsync();

               
               

            }
            else
            {
                //add the note
                MyMapNote note = new MyMapNote();
                note.Title = titleTextBox.Text;
                note.Note = noteTextBox.Text;
                //date time set but not used.
                note.Created = DateTime.Now;
                //setting long,lat fro center position
                note.Latitude = Map.Center.Position.Latitude;
                note.Longitude = Map.Center.Position.Longitude;
                App.Notes.AddNote(note);

               

                this.Frame.Navigate(typeof(myNote));
            }
            
        }

        public void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(myNote));

        }

        private void CommandInvokedHandler(IUICommand command)
        {
            if (command.Label == "Delete")
            {
                App.Notes.DeleteNote(myText);
                this.Frame.Navigate(typeof(myNote));
            }

        }

      
    }
}
