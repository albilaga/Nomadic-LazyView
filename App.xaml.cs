using Nomadic.Themes;
using System.Diagnostics;
using Nomadic.Views;
using Nomadic.Views.Pages;
using Prism.Ioc;
using Xamarin.Forms;
using Nomadic.Extensions;
using Nomadic.ViewModels;

namespace Nomadic
{
    public partial class App
    {
        public static Stopwatch Stopwatch { get; } = new();

        protected override void OnStart()
        {
            ThemeHelper.GetAppTheme();
        }

        protected override void OnSleep()
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<MainTabbedPage>();
            containerRegistry.RegisterForNavigation<MainTabbedViewPage>();
            containerRegistry.RegisterTabbedView<MainFeedTabView, MainFeedViewModel>();
            containerRegistry.RegisterTabbedView<MyInterestsTabView, InterestsViewModel>();
            containerRegistry.RegisterTabbedView<ExploreTabView, InterestsViewModel>();
            containerRegistry.RegisterTabbedView<LocalTabView, LocalViewModel>();
            containerRegistry.RegisterTabbedView<SettingsTabView, SettingsViewModel>();
            containerRegistry.RegisterForNavigation<MainFeedPage, MainFeedViewModel>();
            containerRegistry.RegisterForNavigation<MyInterestsPage, InterestsViewModel>();
            containerRegistry.RegisterForNavigation<ExplorePage, InterestsViewModel>();
            containerRegistry.RegisterForNavigation<LocalPage, LocalViewModel>();
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsViewModel>();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainPage)}");
        }

        protected override void OnResume()
        {
        }
    }
}