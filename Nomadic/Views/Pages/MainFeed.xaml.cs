using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace Nomadic.Views.Pages
{
    public partial class MainFeed
    {
        // public ICommand ScrollListCommand { get; set; }

        public MainFeed()
        {
            InitializeComponent();

            // Shell.SetNavBarIsVisible(this, false);

            // BindingContext = ViewModels.MainFeedViewModel.Instance;

            // ScrollListCommand = new Command(() =>
            // {
            //     Device.BeginInvokeOnMainThread(async () =>
            //     {
            //         var bindingContext = BindingContext as ViewModels.MainFeedViewModel;
            //         var selectedIndex = bindingContext.TabItems.IndexOf(bindingContext.CurrentTab);
            //         await scrollView.ScrollToAsync((60 * selectedIndex), (scrollView.ContentSize.Width - scrollView.Width), true);
            //     }
            //   );
            // });
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var tapped = e.Item as Models.Article;

            await Navigation.PushAsync(new WebPage(tapped));
        }
        
        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            base.LayoutChildren(x, y, width, height);
            Console.WriteLine($"SW end in {GetType()}: {App.Stopwatch.ElapsedMilliseconds}");
        }
    }
}