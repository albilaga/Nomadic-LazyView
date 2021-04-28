using System.Diagnostics;
using Xamarin.Forms;

namespace Nomadic.Views.Pages
{
    public partial class Local
    {
        public Local()
        {
            InitializeComponent();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var tapped = e.Item as Models.Article;

            await Navigation.PushAsync(new WebPage(tapped));
        }
        
        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            base.LayoutChildren(x, y, width, height);
            System.Diagnostics.Debug.WriteLine($"SW end in {GetType()}: {App.Stopwatch.ElapsedMilliseconds}");
        }
    }
}