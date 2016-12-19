using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinClientApp.MenuItem;
using XamarinClientApp.Views;

namespace XamarinClientApp
{
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }

        public MainPage()
        {

            InitializeComponent();

            menuList = new List<MasterPageItem>();

            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            var page1 = new MasterPageItem() { Title = "HOME", Icon = "home.png", TargetType = typeof(MainPageDetail) };
            var page2 = new MasterPageItem() { Title = "Create Barang", TargetType = typeof(Barang_Add) };
            var page3 = new MasterPageItem() { Title = "Create Jenis Motor", TargetType = typeof(JenisMotor_Add) };
            var page4 = new MasterPageItem() { Title = "Create Kategori", TargetType = typeof(Category_Add) };
        

            // Adding menu items to menuList
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);         

            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MainPageDetail)))
            { BarBackgroundColor = Color.FromHex("#9c3832") };
        }

        // Event for Menu Item selection, here we are going to handle navigation based
        // on user selection in menu ListView
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page))
            { BarBackgroundColor = Color.FromHex("#9c3832") };
            IsPresented = false;
        }
    }
}

