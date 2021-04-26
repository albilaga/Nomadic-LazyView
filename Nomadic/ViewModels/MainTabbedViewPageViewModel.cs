using System.Diagnostics;
using Nomadic.Views.Pages;
using Prism.Navigation;
using Prism.Regions;
using Prism.Regions.Navigation;

namespace Nomadic.ViewModels
{
    public class MainTabbedViewPageViewModel : BaseViewModel, IInitialize
    {
        private readonly IRegionManager _regionManager;
        private readonly INavigationService _navigationService;

        public MainTabbedViewPageViewModel(INavigationService navigationService, IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _navigationService = navigationService;
        }

        public void Initialize(INavigationParameters parameters)
        {
            _regionManager.RequestNavigate(nameof(MainFeed), nameof(MainFeedTabView), RegionNavigationCallback);
            _regionManager.RequestNavigate(nameof(MyInterests), nameof(MyInterests),
                RegionNavigationCallback);
            _regionManager.RequestNavigate(nameof(Explore), nameof(Explore), RegionNavigationCallback);
            _regionManager.RequestNavigate(nameof(Local), nameof(Local), RegionNavigationCallback);
            _regionManager.RequestNavigate(nameof(Settings), nameof(Settings), RegionNavigationCallback);
        }

        private void RegionNavigationCallback(IRegionNavigationResult result)
        {
            Debug.WriteLine(result);
        }
    }
}