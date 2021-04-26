using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Prism;
using Prism.Navigation;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms.Xaml;

namespace Nomadic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainCustomTabPage : IInitializeAsync, INavigatedAware
    {
        private int _oldPosition = -1;
        private readonly IReadOnlyList<BaseLazyView> _tabViews;
        private INavigationParameters _initializeParameters;

        public MainCustomTabPage()
        {
            InitializeComponent();
            _tabViews = new BaseLazyView[]
            {
                MainFeedView,
                MyInterestView,
                ExploreView,
                LocalView,
                SettingsView
            };
        }

        private void MainFeedTab_Tapped(object sender, EventArgs e)
        {
            UpdateTab(0, new NavigationParameters());
        }

        private void MyInterestTab_Tapped(object sender, EventArgs e)
        {
            UpdateTab(1, new NavigationParameters());
        }

        private void ExploreTab_Tapped(object sender, EventArgs e)
        {
            UpdateTab(2, new NavigationParameters());
        }

        private void LocalTab_Tapped(object sender, EventArgs e)
        {
            UpdateTab(3, new NavigationParameters());
        }

        private void SettingsTab_Tapped(object sender, EventArgs e)
        {
            UpdateTab(4, new NavigationParameters());
        }

        private async Task UpdateTab(int index, INavigationParameters parameters)
        {
            if (index == _oldPosition)
            {
                return;
            }

            if (_oldPosition >= 0)
            {
                var previousTab = _tabViews[_oldPosition];

                previousTab.IsVisible = false;
                if (previousTab.BindingContext is IActiveAware oldActiveAware)
                {
                    oldActiveAware.IsActive = false;
                }
            }

            var selectedTab = _tabViews[index];
            if (!selectedTab.IsLoaded)
            {
                await selectedTab.LoadViewAsync();
                switch (selectedTab.BindingContext)
                {
                    case IInitialize initialize:
                        initialize.Initialize(_initializeParameters);
                        break;
                    case IInitializeAsync initializeAsync:
                        await initializeAsync.InitializeAsync(_initializeParameters);
                        break;
                }
            }

            if (selectedTab.BindingContext is IActiveAware activeAware)
            {
                activeAware.IsActive = true;
            }

            _oldPosition = index;
            selectedTab.IsVisible = true;
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            base.LayoutChildren(x, y, width, height);
            Debug.WriteLine($"SW end in {GetType()}: {App.Stopwatch.ElapsedMilliseconds}");
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            var activeTab = _tabViews[_oldPosition];
            if (activeTab.BindingContext is INavigatedAware navigatedAware)
            {
                navigatedAware.OnNavigatedFrom(parameters);
            }
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var activeTab = _tabViews[_oldPosition];
            if (activeTab.BindingContext is INavigatedAware navigatedAware)
            {
                navigatedAware.OnNavigatedTo(parameters);
            }
        }

        public async Task InitializeAsync(INavigationParameters parameters)
        {
            _initializeParameters = parameters;
            await UpdateTab(0, parameters);
        }
    }
}