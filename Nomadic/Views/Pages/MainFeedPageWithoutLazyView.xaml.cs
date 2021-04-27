using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nomadic.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainFeedPageWithoutLazyView : ContentPage
    {
        public MainFeedPageWithoutLazyView()
        {
            InitializeComponent();
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            base.LayoutChildren(x, y, width, height);
            Debug.WriteLine($"SW end in {GetType()}: {App.Stopwatch.ElapsedMilliseconds}");
        }
    }
}