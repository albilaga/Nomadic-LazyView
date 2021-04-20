using System;
using System.Diagnostics;
using Xamarin.CommunityToolkit.UI.Views;

namespace Nomadic
{
    public partial class MainTabbedViewPage
    {
        public MainTabbedViewPage()
        {
            InitializeComponent();
        }

        private void TabView_OnSelectionChanged(object sender, TabSelectionChangedEventArgs e)
        {
        }
        
        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            base.LayoutChildren(x, y, width, height);
            Debug.WriteLine($"SW end in {GetType()}: {App.Stopwatch.ElapsedMilliseconds}");
        }
    }
}