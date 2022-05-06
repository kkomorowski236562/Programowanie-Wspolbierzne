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
            Kulki = modelAbstractApi.GetModels();
            _startprzycisk = "Start";
            _stopprzycisk = "Stop";
        }

        public string InputNum
        {
            set
            {
                number = value;
                RaisePropertyChanged(nameof(number));
            }
            get => number;
        }

        private string _startprzycisk;
        private string _stopprzycisk;

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
            if (Int32.TryParse(InputNum, out count))
            {
                count = Int32.Parse(InputNum);
                return count;
            }
            return 0;
        }

        public void start()
        {
            ModelLayer.dodaj_kulke(InputBox());
            ModelLayer.Start();
            StartPrzycisk = "Restart";
        }
        public void stop()
        {
            ModelLayer.Stop();
            StartPrzycisk = "Start";
        }
        private ModelController ModelLayer;
        private string number;
        public ObservableCollection<Model1> Kulki;
    }


}
