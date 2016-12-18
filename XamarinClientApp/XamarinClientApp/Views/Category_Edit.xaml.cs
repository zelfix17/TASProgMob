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
    public partial class Category_Edit : ContentPage
    {
        public Category_Edit()
        {
            InitializeComponent();
            btnEdit.Clicked += BtnEditKategori_Clicked;
            btnDelete.Clicked += BtnDeleteKategori_Clicked;
        }

        // Define Server
        private RestClient _client = new RestClient("http://contohinventorydb.azurewebsites.net/");

        // Add Function
        private async void BtnEditKategori_Clicked(object sender, EventArgs e)
        {
            //Define Request - PUT
            var _request = new RestRequest("api/Kategori", Method.PUT);
            //Add New Kategori
            var newKategori = new Kategori
            {
                IdKategori = Convert.ToInt32(txtIdKategori.Text),
                NamaKategori = txtNamaKategori.Text
            };
            //Execute
            _request.AddBody(newKategori);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PushAsync(new MainKategori());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }
        }

        private async void BtnDeleteKategori_Clicked(object sender, EventArgs e)
        {
            //Define Request - Delete
            var _request = new RestRequest("api/Kategori{KategoriId}", Method.DELETE);
            //Execute
            _request.AddParameter("KategoriId",txtNamaKategori);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PushAsync(new MainKategori());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }
        }

        

    }
}
