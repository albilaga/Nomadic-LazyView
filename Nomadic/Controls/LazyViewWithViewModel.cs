using System.Threading.Tasks;
using Prism.Navigation;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace Nomadic.Controls
{
    public class LazyViewWithViewModel<TView, TViewModel> : LazyView<TView> where TView : View, new()
        where TViewModel : class
    {
        private readonly ActivityIndicator _loadingIndicator;
        public ContentView LoadingView { get; set; }

        public LazyViewWithViewModel()
        {
            _loadingIndicator = new ActivityIndicator
            {
                IsRunning = true
            };
            LoadingView = new ContentView
            {
                Content = new Grid
                {
                    Children =
                    {
                        _loadingIndicator
                    }
                }
            };
        }

        public override ValueTask LoadViewAsync()
        {
            var viewModel = App.Current.Container.Resolve(typeof(TViewModel));
            BindingContext = viewModel;
            return base.LoadViewAsync();
        }
    }
}