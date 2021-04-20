using Nomadic.Themes;
using Plugin.CloudFirestore;
using System;
using System.Diagnostics;
using Nomadic.Views;
using Nomadic.Views.Pages;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nomadic
{
    public partial class App : Application
    {
        public static Stopwatch Stopwatch { get; } = new Stopwatch();

        public App()
        {
            // Set Firestore settings
            // Call this only when you have've added your Google Services
            // Link => https://link.medium.com/Z7A83o3O15
            //CrossCloudFirestore.Current.Instance.FirestoreSettings = new FirestoreSettings
            //{
            //    AreTimestampsInSnapshotsEnabled = false,
            //    IsPersistenceEnabled = true
            //};

            InitializeComponent();

            // MainPage = new ContentPage
            // {
            //     Content = new LazyView<Settings>()
            // };
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            ThemeHelper.GetAppTheme();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}