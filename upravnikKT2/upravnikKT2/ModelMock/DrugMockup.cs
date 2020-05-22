using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upravnikKT2
{
    public class DrugMockup : INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private string _naziv;
        private string _sifra;
        private string _kolicina;
        private string _status;
        private string _sastojci;
        private string _alternativa;


        public event PropertyChangedEventHandler PropertyChanged;

        public string Naziv
        {
            get
            {
                return _naziv;
            }
            set
            {
                if (value != _naziv)
                {
                    _naziv = value;
                    OnPropertyChanged("Naziv");
                }
            }
        }

        public string Sifra
        {
            get
            {
                return _sifra;
            }
            set
            {
                if (value != _sifra)
                {
                    _sifra = value;
                    OnPropertyChanged("Prezime");
                }
            }
        }

        public string Kolicina
        {
            get
            {
                return _kolicina;
            }
            set
            {
                if (value != _kolicina)
                {
                    _kolicina = value;
                    OnPropertyChanged("JMBG");
                }
            }
        }

        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                if (value != _status)
                {
                    _status = value;
                    OnPropertyChanged("Status");
                }
            }
        }

        public string Sastojci
        {
            get
            {
                return _sastojci;
            }
            set
            {
                if (value != _sastojci)
                {
                    _sastojci = value;
                    OnPropertyChanged("Sastojci");
                }
            }
        }

        public string Alternativa
        {
            get
            {
                return _alternativa;
            }
            set
            {
                if (value != _alternativa)
                {
                    _alternativa = value;
                    OnPropertyChanged("Alternativa");
                }
            }
        }

        
    }
}
