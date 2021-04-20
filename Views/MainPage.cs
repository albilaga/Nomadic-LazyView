using Nomadic.Views.Pages;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace Nomadic.Views
{
    public class MainPage : ContentPage
    {
        private readonly LazyView<Settings> _settings = new LazyView<Settings>();

        public MainPage()
        {
            Content = new StackLayout
            {
                Children =
                {
                    new Button
                    {
                        Text = "Tab View",
                        Command = new Command(() =>
                        {
                            // if (App.Stopwatch.IsRunning)
                            // {
                            //     App.Stopwatch.Stop();
                            // }
            
                            App.Stopwatch.Restart();
                            Navigation.PushAsync(new MainTabbedViewPage());
                        })
                    },
                    new Button
                    {
                        Text = "Tab Page",
                        Command = new Command(() =>
                        {
                            // if (App.Stopwatch.IsRunning)
                            // {
                            //     App.Stopwatch.Restart();
                            // }
            
                            App.Stopwatch.Restart();
                            Navigation.PushAsync(new MainTabbedPage());
                        })
                    },
                }
            };
            // Content = _settings;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _settings.LoadViewAsync();
        }
    }
}   