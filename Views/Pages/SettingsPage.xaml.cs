namespace Nomadic.Views.Pages
{
    public partial class SettingsPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            // LazyView.LoadViewAsync();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // await LazyView.LoadViewAsync();
            // LazyView.ForceLayout();
        }
    }
}