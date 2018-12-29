using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeFairy
{
    [Serializable]
    public class ViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<Thing> thingsList;
        private ObservableCollection<Note> notesList;

        public ObservableCollection<Note> NotesList
        {
            get { return this.notesList; }
            set
            {
                if (this.notesList != value)
                {
                    this.notesList = value;
                    NotifyPropertyChanged("NotesList");
                }
                
            }
        }

        public ObservableCollection<Thing> ThingsList
        {
            get
            {
                return this.thingsList;
            }
            set
            {
                if (this.thingsList != value)
                {
                    this.thingsList = value;
                    NotifyPropertyChanged("ThingsList");
                }
            }
        }

        //为了防止报错：未实现Inotify接口的PropertyChanged属性
        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
