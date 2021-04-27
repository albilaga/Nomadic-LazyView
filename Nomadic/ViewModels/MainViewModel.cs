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
                $"{nameof(MainTabbedPage)}?{KnownNavigationParameters.CreateTab}={nameof(MainFeedPage)}" +
                $"&{KnownNavigationParameters.CreateTab}={nameof(MyInterestsPage)}" +
                $"&{KnownNavigationParameters.CreateTab}={nameof(ExplorePage)}" +
                $"&{KnownNavigationParameters.CreateTab}={nameof(LocalPage)}" +
                $"&{KnownNavigationParameters.CreateTab}={nameof(SettingsPage)}");
            if (!result.Success)
            {
                Debugger.Break();
            }
        });

        private ICommand _openTabbedPageWithoutLazyViewCommand;

        public ICommand OpenTabbedPageWithoutLazyViewCommand => _openTabbedPageWithoutLazyViewCommand ??=
            new DelegateCommand(
                async () =>
                {
                    App.Stopwatch.Restart();
                    var result = await _navigationService.NavigateAsync(
                        $"{nameof(MainTabbedPage)}?{KnownNavigationParameters.CreateTab}={nameof(MainFeedPageWithoutLazyView)}" +
                        $"&{KnownNavigationParameters.CreateTab}={nameof(MyInterestsPageWithoutLazyView)}" +
                        $"&{KnownNavigationParameters.CreateTab}={nameof(ExplorePageWithoutLazyView)}" +
                        $"&{KnownNavigationParameters.CreateTab}={nameof(LocalPageWithoutLazyView)}" +
                        $"&{KnownNavigationParameters.CreateTab}={nameof(SettingsPageWithoutLazyView)}");
                    if (!result.Success)
                    {
                        Debugger.Break();
                    }
                });

        private ICommand _openCustomTabbedPage;

        public ICommand OpenCustomTabbedPage => _openCustomTabbedPage ??= new DelegateCommand(async () =>
        {
            App.Stopwatch.Restart();
            var result = await _navigationService.NavigateAsync(
                $"{nameof(MainCustomTabPage)}?param=tes");
            if (!result.Success)
            {
                Debugger.Break();
            }
        });

        private ICommand _openStandalonePage;

        public ICommand OpenStandalonePage => _openStandalonePage ??= new DelegateCommand(async () =>
        {
            App.Stopwatch.Restart();
            var result = await _navigationService.NavigateAsync(
                $"{nameof(MainFeedPageWithoutLazyView)}?param=tes");
            if (!result.Success)
            {
                Debugger.Break();
            }
        });


        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}