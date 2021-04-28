using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Nomadic.Views.Pages
{
    public partial class Settings
    {
        public Settings()
        {
            InitializeComponent();
            // BindingContext = ViewModels.SettingsViewModel.Instance;
        }

        private async void SignOut_Tapped(object sender, EventArgs e)
        {
            // await Shell.Current.GoToAsync($"signout");
        }

        private async void SavedArticles_Tapped(object sender, EventArgs e)
        {
            var userId = await Helpers.DatabaseHelper.UserId();

            if (userId != null)
            {
                await Shell.Current.GoToAsync($"savedarticles");
            }
        }

        private async void NotImplemented_Tapped(object sender, EventArgs e)
        {
            // var actionSheet = await DisplayActionSheet("Not Implemented", "No", "Yes", "This feature has not been implemented. No plans are in the works. You can contribute to the project if you like 🙂. Would you like to open the project in GitHub?");
            //
            // if(actionSheet == "Yes")
            // {
            //     await Helpers.DialogsHelper.OpenBrowser("https://github.com/Elisha-Misoi/Nomadic");
            // }
        }

        private async void About_Tapped(object sender, EventArgs e)
        {
            await Helpers.DialogsHelper.OpenBrowser("https://github.com/Elisha-Misoi/Nomadic");
        }

        private async void SendFeedBack_Tapped(object sender, EventArgs e)
        {
            Helpers.DialogsHelper.ProgressDialog.Show();

            await Task.Delay(1000);

            await Helpers.DialogsHelper.SendEmail("FEEDBACK FOR NOMADIC", "", new List<string> { "e.kmisoi@outlook.com" });

            Helpers.DialogsHelper.ProgressDialog.Hide();
        }
        
        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            base.LayoutChildren(x, y, width, height);
            System.Diagnostics.Debug.WriteLine($"SW end in {GetType()}: {App.Stopwatch.ElapsedMilliseconds}");
        }
    }
}