using DM.JSON;
using DM.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            ProfileViewModel welcomeViewModel = new ProfileViewModel();
            BindingContext = welcomeViewModel;
        }
    }
}