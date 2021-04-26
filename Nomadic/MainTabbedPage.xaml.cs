using System;
using System.Diagnostics;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace Nomadic
{
    public partial class MainTabbedPage
    {
        public MainTabbedPage()
        {
            InitializeComponent();
            this.CurrentPageChanged += Changed;
            // Changed(null, null);
        }

        private async void Changed(object sender, EventArgs e)
        {
            if (this.CurrentPage is ContentPage {Content: BaseLazyView {IsLoaded: false} lazyView})
            {
                await lazyView.LoadViewAsync();
            }
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            base.LayoutChildren(x, y, width, height);
            Debug.WriteLine($"SW end in {GetType()}: {App.Stopwatch.ElapsedMilliseconds}");
        }
    }
}