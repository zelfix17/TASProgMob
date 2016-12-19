using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinClientApp.ViewModels;
using XamarinClientApp.Models;
using XamarinClientApp.Views;

namespace XamarinClientApp
{
    public partial class MainBarang : ContentPage
    {
        public MainBarang()
        {
            InitializeComponent();
            this.BindingContext = new BarangViewModel();

            listBarang.ItemTapped += ListBarang_ItemTapped;
            btnSearchBarang.Clicked += BtnSearchBarang_Clicked;
            btnSearchKategori.Clicked += BtnSearchKategori_Clicked;
        }
        private void ListBarang_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Barang item = (Barang)e.Item;
            Barang_Edit editPage = new Barang_Edit();
            editPage.BindingContext = item;
            Navigation.PushAsync(editPage);
        }

        void BtnSearchBarang_Clicked(object sender, EventArgs e)
        {
            this.BindingContext = new SearchNamaBarang(txtSearch.Text);
        }

        void BtnSearchKategori_Clicked(object sender, EventArgs e)
        {
            this.BindingContext = new SearchNamaKategori(txtSearch.Text);
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new BarangViewModel();
        }
    }
}
