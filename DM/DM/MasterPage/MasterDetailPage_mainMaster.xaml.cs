using DM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DM.MasterPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPage_mainMaster : ContentPage
    {
        public ListView ListView;

        public MasterDetailPage_mainMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPage_mainMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPage_mainMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPage_mainMasterMenuItem> MenuItems { get; set; }

            public MasterDetailPage_mainMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPage_mainMasterMenuItem>(new[]
                {
                    new MasterDetailPage_mainMasterMenuItem { Id = 0, Title = "Profile", TargetType= typeof(ProfilePage) },
/*                    new MasterDetailPage_mainMasterMenuItem { Id = 1, Title = "Recent Mathces", TargetType= typeof(RecentMatchesPage)},*/
                    new MasterDetailPage_mainMasterMenuItem { Id = 2, Title = "Logout", TargetType= typeof(LoginPage) }
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}