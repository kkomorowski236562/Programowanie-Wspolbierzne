using Model;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ModelWidoku
{
    public class Steering : Controler
    {
        private readonly ModelAbstractApi _api;
        public int kID;
        public int X
        {
            get
            {
                return _api.getX(kID);
            }
        }
        public int Y
        {
            get
            {
                return _api.getY(kID);
            }
        }
        public int Wielkosc
        {
            get
            {
                return _api.getWielkosc(kID);
            }
        }
        public ICommand _start { get; set; }
        public ICommand _stop { get; set; }
        public Steering()
        {
            _api = ModelAbstractApi.CreateApi(400);
            _start = new RelayCommand(StworzKulki);
            _stop = new RelayCommand(Stop);
        }

        private string _startprzycisk;
        private string _stopprzycisk;
        private int _ilosckulek;

        public string IloscZczytana
        {
            get => _ilosckulek.ToString();
            set
            {
                int pom;
                if (int.TryParse(value, out pom) && pom != 0)
                    _ilosckulek = Math.Abs(pom);
                RaisePropertyChanged(nameof(IloscZczytana));
            }
        }

        public string StartPrzycisk
        {
            get => _startprzycisk;
            set
            {
                _startprzycisk = value;
                RaisePropertyChanged("StartPrzycisk");
            }
        }

        public string StopPrzycisk
        {
            get => _stopprzycisk;
            set
            {
                _stopprzycisk = value;
                RaisePropertyChanged("StopPrzycisk");
            }
        }

        public int InputBox()
        {
            int count;
            count = Int32.Parse(IloscZczytana);
            return count;
        }

        public void StworzKulki()
        {
            _api.KulkiModelu(_ilosckulek);
        }

        public void Stop()
        {
            _api.Stop();
        }
    }
}