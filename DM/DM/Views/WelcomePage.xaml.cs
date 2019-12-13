using DM.JSON;
using DM.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
            WelcomeViewModel welcomeViewModel = new WelcomeViewModel();
            BindingContext = welcomeViewModel;
        }
    }
}