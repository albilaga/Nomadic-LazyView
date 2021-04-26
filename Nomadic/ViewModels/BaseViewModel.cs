using System.ComponentModel;
using System.Runtime.CompilerServices;
using Nomadic.Controls;
using Prism.Mvvm;
using Xamarin.Forms;

namespace Nomadic.ViewModels
{
    public class BaseViewModel : BindableBase
    {
        private bool _initialized;

        public bool Initialized
        {
            get => _initialized;
            set => SetProperty(ref _initialized, value);
        }

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