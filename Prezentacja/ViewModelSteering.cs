using Model;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModel
{
    public class MainViewModelSteering : ViewModel
    {
        public ICommand Start { get; set; }
        public ICommand Stop { get; set; }

        public MainViewModelSteering() : this(ModelController.CreateLayer()) { }
        public MainViewModelSteering(ModelController modelAbstractApi)
        {
            ModelLayer = modelAbstractApi;
            Start = new RelayCommand(() => start());
            Stop = new RelayCommand(() => stop());
            _Kulki = modelAbstractApi.GetModels();
            _ilosckulek = 5;
            _startprzycisk = "Start";
            _stopprzycisk = "Stop";
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

        public void start()
        {
            ModelLayer.Add_Ball(InputBox());
            ModelLayer.Start();
            StartPrzycisk = "Restart";
        }
        public void stop()
        {
            ModelLayer.Stop();
            StartPrzycisk = "Start";
        }
        private ModelController ModelLayer;
        public ObservableCollection<Model1> _Kulki;
    }


}
