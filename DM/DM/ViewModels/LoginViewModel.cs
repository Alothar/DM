using DM;
using DM.ID_handler;
using DM.JSON;
using DM.REST;
using DM.View;
using System;
using System.Collections;
using System.ComponentModel;
using Xamarin.Forms;

namespace DM.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public LoginViewModel()
        {

        }
        private String steam_64_id;
        public String Steam_64_id
        {
            get { return steam_64_id; }
            set
            {
                if (value.Length <= 28)
                {
                    steam_64_id = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Steam_64_id"));
                }
                else
                    App.Current.MainPage.DisplayAlert("Too Large Value", "Please enter correct ID", "OK");
            }
        }

        public Command LoginCommand => new Command(Login);

        private void Login()
        {
            RestService rest = RestService.Instance;
            
            //null or empty field validation, check weather email and password is null or empty  
            if (string.IsNullOrWhiteSpace(Steam_64_id))
                App.Current.MainPage.DisplayAlert("Empty Value", "Please enter your Steam ID", "OK");
            else if (!System.Text.RegularExpressions.Regex.IsMatch(Steam_64_id, "^[0-9]*$"))
                App.Current.MainPage.DisplayAlert("Non digits", "Please use digits only", "OK");
            else
            {
                Id_holder.Instance.Steam_32_id = Steam_64_id;
                if ((Convert.ToUInt32(Id_holder.Instance.Steam_32_id) == uint.MaxValue) || (Convert.ToUInt32(Id_holder.Instance.Steam_32_id) <= 1))
                {
                    App.Current.MainPage.DisplayAlert("Login Fail, incorrect ID values", "Please enter correct ID", "OK");
                }
                else
                {
                    ProfileObject player = rest.GetPlayerInfo(Id_holder.Instance.Steam_32_id);
                    App.Current.MainPage.DisplayAlert("Login Success", "Welcome, " + player.profile.personaname, "Ok");
                    //Navigate to Welcome page after successfully login  
                    App.Current.MainPage.Navigation.PushAsync(new WelcomePage(player));
                }
            }
        }

    }
}
