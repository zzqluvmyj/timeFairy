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
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
