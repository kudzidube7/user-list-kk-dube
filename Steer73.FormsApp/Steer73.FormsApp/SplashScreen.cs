using Steer73.FormsApp.Views;
using Xamarin.Forms;

namespace Steer73.FormsApp
{
    public class SplashScreen : ContentPage
    {
        Image splashImage;

        public SplashScreen()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var splash = new AbsoluteLayout();

            splashImage = new Image
            {
                Source = "Steer73.png",
                WidthRequest = 150,
                HeightRequest = 150
            };

            AbsoluteLayout.SetLayoutFlags(splashImage, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(splashImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            splash.Children.Add(splashImage);

            this.BackgroundColor = Color.FromHex("#429de3");
            this.Content = splash;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await splashImage.ScaleTo(1, 2000);
            await splashImage.ScaleTo(0.5, 1500, Easing.Linear);
            await splashImage.ScaleTo(1.5, 1200, Easing.Linear);
            Application.Current.MainPage = new NavigationPage(new UsersView());

        }
    }
}
