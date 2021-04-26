using System.Linq;
using Xamarin.Forms;

namespace Nomadic.Views.Pages
{
    public partial class Explore
    {
        public Explore()
        {
            InitializeComponent();
            // BindingContext = ViewModels.InterestsViewModel.Instance;
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (collectionView.SelectedItem != null)
            {
                var selected = e.CurrentSelection.FirstOrDefault() as Models.Interest;

                // ViewModels.InterestsViewModel.Instance.CurrentItem = new Models.Tab { Title = selected.Title };

                await Shell.Current.GoToAsync($"interestarticles");

                collectionView.SelectedItem = null;
            }
        }
    }
}
