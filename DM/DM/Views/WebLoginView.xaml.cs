using DM.ID_handler;
using DM.JSON;
using DM.REST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebLoginView : ContentPage
    {
        private string current_url;

        readonly WebView webView = new WebView
        {
            Source = new UrlWebViewSource
            {
                Url = "https://api.opendota.com/login/",
            },
            VerticalOptions = LayoutOptions.FillAndExpand
        };
        public WebLoginView()
        {
            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    webView
                }
            };

            webView.Navigating += (object sender, WebNavigatingEventArgs e) =>
            {
                current_url = e.Url;
                if (current_url.Contains("https://www.opendota.com/players/"))
                {
                    Id_holder.Instance.Steam32id = current_url.Split('/')[current_url.Split('/').Length - 1];
                    App.Current.MainPage.Navigation.PopAsync();
                    App.Current.MainPage.Navigation.PushAsync(new WelcomePage());
                }
            };
        }

    }
}