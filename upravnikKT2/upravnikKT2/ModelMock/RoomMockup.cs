using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upravnikKT2
{
    class RoomMockup : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private string _ID;
        private string _roomType;


        public string Sifra
        {
            get
            {
                return _ID;
            }
            set
            {
                if (value != _ID)
                {
                    _ID = value;
                    OnPropertyChanged("Sifra");
                }
            }
        }

        public string Tip
        {
            get
            {
                return _roomType;
            }
            set
            {
                if (value != _roomType)
                {
                    _roomType = value;
                    OnPropertyChanged("Tip");
                }
            }
        }

       

    }
}
