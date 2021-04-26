using System.Diagnostics;
using System.Windows.Input;
using Nomadic.Views.Pages;
using Prism.Commands;
using Prism.Navigation;

namespace Nomadic.ViewModels
{
    public class MainViewModel
    {
        private readonly INavigationService _navigationService;

        private ICommand _openTabViewCommand;

        public ICommand OpenTabViewCommand => _openTabViewCommand ??= new DelegateCommand(async () =>
        {
            App.Stopwatch.Restart();
            var result = await _navigationService.NavigateAsync(
                $"{nameof(MainTabbedViewPage)}");
            if (!result.Success)
            {
                Debugger.Break();
            }
        });

        private ICommand _openTabbedPageCommand;

        public ICommand OpenTabPageCommand => _openTabbedPageCommand ??= new DelegateCommand(async () =>
        {
            App.Stopwatch.Restart();
            var result = await _navigationService.NavigateAsync(
                $"{nameof(MainTabbedPage)}?{KnownNavigationParameters.CreateTab}={nameof(MainTabbedPage)}" +
                $"&{KnownNavigationParameters.CreateTab}={nameof(MyInterestsPage)}" +
                $"&{KnownNavigationParameters.CreateTab}={nameof(ExplorePage)}" +
                $"&{KnownNavigationParameters.CreateTab}={nameof(LocalPage)}" +
                $"&{KnownNavigationParameters.CreateTab}={nameof(SettingsPage)}");
            if (!result.Success)
            {
                Debugger.Break();
            }
        });

        private ICommand _openCustomTabbedPage;

        public ICommand OpenCustomTabbedPage => _openCustomTabbedPage ??= new DelegateCommand(() =>
        {
            App.Stopwatch.Restart();
            _navigationService.NavigateAsync(
                $"{nameof(MainCustomTabPage)}?param=tes");
        });

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}