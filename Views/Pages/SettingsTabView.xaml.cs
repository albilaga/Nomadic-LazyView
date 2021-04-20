namespace Nomadic.Views.Pages
{
    public partial class SettingsTabView
    {
        public SettingsTabView()
        {
            InitializeComponent();
            LazyView.BindingContext = ViewModels.SettingsViewModel.Instance;
            // LazyView. ();
        }
    }
}