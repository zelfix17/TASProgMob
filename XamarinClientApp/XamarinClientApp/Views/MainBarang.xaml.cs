using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinClientApp.ViewModels;
using XamarinClientApp.Models;

namespace XamarinClientApp
{
    public partial class MainBarang : ContentPage
    {
        public MainBarang()
        {
            InitializeComponent();
            this.BindingContext = new BarangViewModel();

            listBarang.ItemTapped += ListBarang_ItemTapped;
        }
        private void ListBarang_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Barang item = (Barang)e.Item;
            // Category_Edit editPage = new Category_Edit();
            //editPage.BindingContext = item;
            // Navigation.PushAsync(editPage);
        }

    }
}
