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
            var viewModel = App.Current.Container.Resolve(typeof(TViewModel));
            BindingContext = viewModel;
            return base.LoadViewAsync();
        }
    }
}