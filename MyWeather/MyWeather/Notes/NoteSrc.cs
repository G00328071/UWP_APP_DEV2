using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.IO;

namespace MyWeather.Notes
{
    public class MyMapNote
    {
        public string Title { get;  set; }
        public string Note { get; set; }
        public DateTime Created { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }




    public class NoteSrc
    {
        private ObservableCollection<MyMapNote>_myMapNote;
        const string fileName = "mapnotes.json";

        public NoteSrc()
        {
            _myMapNote = new ObservableCollection<MyMapNote>();
        }

        public async Task<ObservableCollection<MyMapNote>> GetMyMapNotes()
        {
            await ensureDataLoaded();
            return _myMapNote;

        }
        private async Task ensureDataLoaded()
        {
            if (_myMapNote.Count == 0)
                await getMapNoteDataAsync();
        }

        private async Task getMapNoteDataAsync()
        {
            if (_myMapNote.Count != 0)
                return;

            var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<MyMapNote>));
            try
            {
                using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(fileName))
                {
                    _myMapNote = (ObservableCollection<MyMapNote>)jsonSerializer.ReadObject(stream);
                }
            }
            catch
            {
                _myMapNote = new ObservableCollection<MyMapNote>();
            }
        }


        public async void AddNote(MyMapNote mapNote)
        {
            _myMapNote.Add(mapNote);
            await saveMapNote();
        }

        public async void DeleteNote(MyMapNote mapNote)
        {
            _myMapNote.Remove(mapNote);
            await saveMapNote();
        }

        private async Task saveMapNote()
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<MyMapNote>));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(fileName, CreationCollisionOption.ReplaceExisting))
            {
                jsonSerializer.WriteObject(stream, _myMapNote);
            }
        }
    }
}
