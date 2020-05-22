using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upravnikKT2
{
    public class Lekar : INotifyPropertyChanged
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
        private string _jmbg;
        private string _id;
        private string _email;
        private string _telefon;
        private string _datum_rodjenja;
        private string _odeljenje;
        private string _prostorija;
        private string _ocena;

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

        public string JMBG
        {
            get
            {
                return _jmbg;
            }
            set
            {
                if (value != _jmbg)
                {
                    _jmbg = value;
                    OnPropertyChanged("JMBG");
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

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        public string Telefon
        {
            get
            {
                return _telefon;
            }
            set
            {
                if (value != _telefon)
                {
                    _telefon = value;
                    OnPropertyChanged("Telefon");
                }
            }
        }

        public string Datum_rodjenja
        {
            get
            {
                return _datum_rodjenja;
            }
            set
            {
                if (value != _datum_rodjenja)
                {
                    _datum_rodjenja = value;
                    OnPropertyChanged("Datum_rodjenja");
                }
            }
        }

        public string Odeljenje
        {
            get
            {
                return _odeljenje;
            }
            set
            {
                if (value != _odeljenje)
                {
                    _odeljenje = value;
                    OnPropertyChanged("Odeljenje");
                }
            }
        }

        public string Prostorija
        {
            get
            {
                return _prostorija;
            }
            set
            {
                if (value != _prostorija)
                {
                    _prostorija = value;
                    OnPropertyChanged("Prostorija");
                }
            }
        }

        public string Ocena
        {
            get
            {
                return _ocena;
            }
            set
            {
                if (value != _ocena)
                {
                    _ocena = value;
                    OnPropertyChanged("Ocena");
                }
            }
        }


    }
}
