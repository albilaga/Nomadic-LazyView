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
        }

        private void RegionNavigationCallback(IRegionNavigationResult result)
        {
            Debug.WriteLine(result);
        }
    }
}