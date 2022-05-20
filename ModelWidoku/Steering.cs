using Model;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ModelWidoku
{
    public class Steering : Controler
    {
        private readonly ModelAbstractApi _api;
        public ICommand start { get; set; }
        public ICommand stop { get; set; }
        public Steering()
        {
            _api = ModelAbstractApi.CreateApi(400);
            start = new RelayCommand(Start);
            stop = new RelayCommand(Stop);
            _startprzycisk = "Start";
            _stopprzycisk = "Stop";
        }

        private string _startprzycisk;
        private string _stopprzycisk;
        private int _ilosckulek;
        private IList _kulki;

        public IList Kulki
        {
            get => _kulki;
            set
            {
                if (value.Equals(_kulki))
                    return;
                _kulki = value;
                RaisePropertyChanged();
            }
        }


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

        public void Start()
        {
            Kulki = _api.KulkiModelu(_ilosckulek);
            _api.Start();
            StartPrzycisk = "Restart";
        }

        public void Stop()
        {
            _api.Stop();
        }
    }
}