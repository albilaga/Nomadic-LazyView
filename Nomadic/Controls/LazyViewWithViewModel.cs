using System.ComponentModel;
using System.Threading.Tasks;
using Nomadic.ViewModels;
using Prism.Navigation;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace Nomadic.Controls
{
    public class LazyViewWithViewModel<TView, TViewModel> : LazyView<TView> where TView : View, new()
        where TViewModel : BaseViewModel
    {
        private readonly ActivityIndicator _loadingIndicator;
        public ContentView LoadingView { get; set; }

        private View _view;
        private BaseViewModel _viewModel;

        public LazyViewWithViewModel()
        {
            // _loadingIndicator = new ActivityIndicator
            // {
            //     IsRunning = true
            // };
            // LoadingView = new ContentView
            // {
            //     Content = new Grid
            //     {
            //         Children =
            //         {
            //             _loadingIndicator
            //         }
            //     }
            // };
            // Content = LoadingView;
        }

        public override ValueTask LoadViewAsync()
        {
            var viewModel = App.Current.Container.Resolve(typeof(TViewModel)) as BaseViewModel;
            BindingContext = viewModel;
            // if (BindingContext is IInitializeAsync initializeAsync)
            // {
            //     await initializeAsync.InitializeAsync(new NavigationParameters());
            // }
            // viewModel.PropertyChanged += OnPropertyChanged;
            return base.LoadViewAsync();
            // _view = new TView();
            // _view.SetBinding(View.IsVisibleProperty, nameof(BaseViewModel.Initialized));
            // _view.BindingContext = this.BindingContext;
            // // this.Content = (View) _view;
            // this.SetIsLoaded(true);
            // return new ValueTask((Task) Task.FromResult<bool>(true));

            // await base.LoadViewAsync();
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(BaseViewModel.Initialized) && BindingContext is BaseViewModel
            {
                Initialized: true
            })
            {
                Content = _view;
            }
        }

        // public void Dispose()
        // {
        //     base.Dispose();
        // }
    }
}