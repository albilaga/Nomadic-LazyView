using System;
using System.Diagnostics;

namespace Nomadic
{
    public partial class MainTabbedPage
    {
        public MainTabbedPage()
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