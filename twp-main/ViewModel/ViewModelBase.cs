using System;
using System.ComponentModel;
using Model;
using System.Runtime.CompilerServices;


namespace ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private ModelApi modelApi;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
