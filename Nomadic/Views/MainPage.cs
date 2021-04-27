using Nomadic.ViewModels;
using Prism.Navigation;
using Xamarin.Forms;

namespace Nomadic.Views
{
    public class MainPage : ContentPage
    {
        private readonly Button _tabViewButton;
        private readonly Button _tabPageButton;
        private readonly Button _customTabButton;
        private readonly Button _tabPageWithoutLazyViewButton;

        public MainPage(INavigationService navigationService)
        {
            // BindingContext = ViewModelLocator.
            var vm = new MainViewModel(navigationService);
            _tabViewButton = new Button
            {
                Text = "Tab View",
                Command = vm.OpenTabViewCommand,
            };
            _tabPageButton = new Button()
            {
                Text = "Tab Page",
                Command = vm.OpenTabPageCommand,
            };
            _customTabButton = new Button()
            {
                Text = "Custom Tab",
                Command = vm.OpenCustomTabbedPage,
            };
            _tabPageWithoutLazyViewButton = new Button()
            {
                Text = "Tab Page without lazy view",
                Command = vm.OpenTabbedPageWithoutLazyViewCommand
            };
            Content = new StackLayout
            {
                Children =
                {
                    _tabViewButton,
                    _tabPageButton,
                    _tabPageWithoutLazyViewButton,
                    _customTabButton
                }
            };
            // Content = _settings;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // _settings.LoadViewAsync();
        }

        // protected override void OnBindingContextChanged()
        // {
        //     base.OnBindingContextChanged();
        //     if (BindingContext is not MainViewModel viewModel)
        //     {
        //         return;
        //     }
        //
        //     _tabViewButton.Command = viewModel.OpenTabViewCommand;
        //     _tabPageButton.Command = viewModel.OpenTabPageCommand;
        // }
    }
}