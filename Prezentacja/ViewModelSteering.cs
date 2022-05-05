using Model;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModel
{
    public class ViewModelSteering : ViewModel
    {
        public ICommand StartButtonClick { get; set; }

        public ViewModelSteering() : this(ModelController.CreateLayer()) { }
        public ViewModelSteering(ModelController modelAbstractApi)
        {
            ModelLayer = modelAbstractApi;
            StartButtonClick = new RelayCommand(() => ClickHandler());
            Kulki = modelAbstractApi.GetModels();
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


        private void ClickHandler()
        {
            ModelLayer.dodaj_kulke(InputBox());
            ModelLayer.Start();

        }
        private ModelController ModelLayer;
        private string number;
        public ObservableCollection<Model1> Kulki;
    }


}
