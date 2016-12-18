using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinClientApp.Models;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace XamarinClientApp
{
    public partial class Category_Add : ContentPage
    {
        public Category_Add()
        {
            InitializeComponent();
            btnTambahKategori.Clicked += BtnTambahKategori_Clicked;
        }

        // Define Server
        private RestClient _client =  new RestClient("http://contohinventorydb.azurewebsites.net/");

        // Add Function
        private async void BtnTambahKategori_Clicked(object sender, EventArgs e)
        {
            //Define Request - POST
            var _request = new RestRequest("api/Kategori", Method.POST);
            
            //Add New Kategori
            var newKategori = new Kategori { NamaKategori = txtNamaKategori.Text};

            _request.AddBody(newKategori);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                   await Navigation.PushAsync(new MainKategori());
                }
             }
            catch(Exception ex)
            {
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }
        }

    }
}
