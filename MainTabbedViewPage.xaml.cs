using System;
using System.Diagnostics;
using Prism;
using Prism.Navigation;
using Xamarin.CommunityToolkit.UI.Views;

namespace Nomadic
{
    public partial class MainTabbedViewPage // : INavigationAware
    {
        private int _oldPosition;

        public MainTabbedViewPage()
        {
            InitializeComponent();
        }

        private async void TabView_OnSelectionChanged(object sender, TabSelectionChangedEventArgs e)
        {
            // if (_oldPosition == TabView.SelectedIndex)
            // {
            //     return;
            // }
            //
            // if (TabView.TabItems[_oldPosition].Content?.BindingContext is IActiveAware oldTabAware)
            // {
            //     oldTabAware.IsActive = false;
            // }
            //
            // var selectedTab = TabView.TabItems[TabView.SelectedIndex];
            //
            // if (selectedTab.Content?.BindingContext is IActiveAware newTabAware)
            // {
            //     newTabAware.IsActive = true;
            // }
            //
            //
            // if (selectedTab.Content is BaseLazyView {IsLoaded: false} lazyView)
            // {
            //     await lazyView.LoadViewAsync();
            // }
            //
            // _oldPosition = TabView.SelectedIndex;
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            base.LayoutChildren(x, y, width, height);
            Debug.WriteLine($"SW end in {GetType()}: {App.Stopwatch.ElapsedMilliseconds}");
        }

        // public void OnNavigatedFrom(INavigationParameters parameters)
        // {
        // }

        // public async void OnNavigatedTo(INavigationParameters parameters)
        // {
        //     try
        //     {
        //         if (parameters is null || parameters.Count == 0)
        //         {
        //             return;
        //         }
        //     
        //         TabView.TabItems.Clear();
        //     
        //         var index = 0;
        //         var tabs = parameters.GetValues<string>(KnownNavigationParameters.CreateTab);
        //         foreach (var tab in tabs)
        //         {
        //             var view = PrismApplicationBase.Current.Container.Resolve(typeof(object), tab) as TabViewItem;
        //             if (view is null)
        //             {
        //                 continue;
        //             }
        //     
        //             if (index == 0 && view.Content is BaseLazyView lazyView)
        //             {
        //                 await lazyView.LoadViewAsync();
        //             }
        //     
        //             // ViewModelLocator.SetAutowireViewModel(view, true);
        //             // ViewModelLocator.SetAutowireViewModel(view.Content, true);
        //             // if (PrismApplicationBase.Current.Container.Resolve(typeof(BindableBase),
        //             //     $"{tab}ViewModel") is BindableBase viewModel)
        //             // {
        //             //     view.BindingContext = viewModel;
        //             //     if (view.Content != null)
        //             //     {
        //             //         view.Content.BindingContext = viewModel;
        //             //     }
        //             // }
        //     
        //             TabView.TabItems.Add(view);
        //             index++;
        //         }
        //     }
        //     catch (Exception e)
        //     {
        //         Debug.WriteLine(e);
        //     }
        // }
    }
}