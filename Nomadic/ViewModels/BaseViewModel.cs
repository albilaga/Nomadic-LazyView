using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Mvvm;

namespace Nomadic.ViewModels
{
    public class BaseViewModel : BindableBase
    {
        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
}