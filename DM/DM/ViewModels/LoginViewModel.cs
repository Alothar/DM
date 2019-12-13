using DM;
using DM.ID_handler;
using DM.JSON;
using DM.REST;
using DM.Views;
using System;
using System.Collections;
using System.ComponentModel;
using Xamarin.Forms;

namespace DM.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {

        }

        public Command LoginSteamCommand => new Command(LoginSteam);

        private void LoginSteam()
        {
            App.Current.MainPage.Navigation.PushAsync(new WebLoginView());
        }
    }
}
