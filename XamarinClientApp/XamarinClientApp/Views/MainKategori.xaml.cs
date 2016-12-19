using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinClientApp.ViewModels;
using XamarinClientApp.Models;
using System.Diagnostics;

namespace XamarinClientApp
{
    public partial class MainKategori : ContentPage
    {
        public MainKategori()
        {
            InitializeComponent();
            this.BindingContext = new KategoriViewModel();          
            listKategori.ItemTapped += ListKategori_ItemTapped;
        }
        private void ListKategori_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Kategori item = (Kategori)e.Item;
            Category_Edit editPage = new Category_Edit();
            editPage.BindingContext = item;
            Navigation.PushAsync(editPage);
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new KategoriViewModel();
        }

    }
}
