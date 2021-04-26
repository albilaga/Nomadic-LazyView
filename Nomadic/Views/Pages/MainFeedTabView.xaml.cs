namespace Nomadic.Views.Pages
{
    public partial class MainFeedTabView 
    {
        public MainFeedTabView()
        {
            InitializeComponent();
            // LazyView.BindingContext = ViewModels.MainFeedViewModel.Instance;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            // LazyView.BindingContext = BindingContext;
        }
    }
}