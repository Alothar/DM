using DM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DM.MasterPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPage_main : MasterDetailPage
    {
        public MasterDetailPage_main()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MasterDetailPage_mainMasterMenuItem item = e.SelectedItem as MasterDetailPage_mainMasterMenuItem;
            if (item == null)
                return;
            if(item.TargetType.Equals(typeof(LoginPage)))
                App.Current.MainPage = new LoginPage();

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}