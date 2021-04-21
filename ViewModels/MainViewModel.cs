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
                $"{nameof(MainTabbedViewPage)}?{KnownNavigationParameters.CreateTab}={nameof(MainFeedTabView)}" +
                $"&{KnownNavigationParameters.CreateTab}={nameof(MyInterestsTabView)}" +
                $"&{KnownNavigationParameters.CreateTab}={nameof(ExploreTabView)}" +
                $"&{KnownNavigationParameters.CreateTab}={nameof(LocalTabView)}" +
                $"&{KnownNavigationParameters.CreateTab}={nameof(SettingsTabView)}");
            Debug.WriteLine(result);
        });

        private ICommand _openTabbedPageCommand;

        public ICommand OpenTabPageCommand => _openTabbedPageCommand ??= new DelegateCommand(() =>
        {
            App.Stopwatch.Restart();
            _navigationService.NavigateAsync(
                $"{nameof(MainTabbedViewPage)}?{KnownNavigationParameters.CreateTab}={nameof(MainTabbedPage)}" +
                $"&{KnownNavigationParameters.CreateTab}={nameof(MyInterestsTabView)}" +
                $"&{KnownNavigationParameters.CreateTab}={nameof(ExploreTabView)}" +
                $"&{KnownNavigationParameters.CreateTab}={nameof(LocalTabView)}" +
                $"&{KnownNavigationParameters.CreateTab}={nameof(SettingsTabView)}");
        });

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}