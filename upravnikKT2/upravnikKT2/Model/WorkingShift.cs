using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upravnikKT2
{
    class WorkingShift : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private string _ime;
        private string _prezime;
        private string _id;
        private string _period;

        public string Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                if (value != _ime)
                {
                    _ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }

        public string Prezime
        {
            get
            {
                return _prezime;
            }
            set
            {
                if (value != _prezime)
                {
                    _prezime = value;
                    OnPropertyChanged("Prezime");
                }
            }
        }


        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("ID");
                }
            }
        }





        public string Period
        {
            get
            {
                return _period;
            }
            set
            {
                if (value != _period)
                {
                    _period = value;
                    OnPropertyChanged("Period");
                }
            }
        }


    }
}

