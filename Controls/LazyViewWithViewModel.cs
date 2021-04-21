using System;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace Nomadic.Controls
{
    public class LazyViewWithViewModel<TView, TViewModel> : LazyView<TView> where TView : View, new()
        where TViewModel : class
    {
        public override ValueTask LoadViewAsync()
        {
            var view = new TView();
            var viewModel = Activator.CreateInstance<TViewModel>();
            view.BindingContext = viewModel;
            Content = view;
            SetIsLoaded(true);
            return new ValueTask(Task.FromResult(true));
        }
    }
}