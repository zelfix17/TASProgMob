using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinClientApp.Models;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace XamarinClientApp.Views
{
    public partial class Barang_Add : ContentPage
    {
        public Barang_Add()
        {
            InitializeComponent();
            btnTambahBarang.Clicked += BtnTambahBarang_Clicked;
        }

        // Define Server
        private RestClient _client = new RestClient("http://zelfixbackend.azurewebsites.net/");

        // Add Function
        private async void BtnTambahBarang_Clicked(object sender, EventArgs e)
        {
            //Define Request - POST
            var _request = new RestRequest("api/Barang", Method.POST);

            //Add New Kategori
            var newBarang = new Barang {
                NamaBarang = txtNamaBarang.Text,
                HargaBarang = Convert.ToInt32(txtHargaBarang.Text),
                StokBarang = Convert.ToInt32(txtStokBarang.Text),
                TglBeli = Convert.ToDateTime(txtTglBeli.Text),
                IdKategori = Convert.ToInt32(txtIdKategori.Text),
                IdJenisMotor = Convert.ToInt32(txtIdJenisMotor.Text)
            };
            _request.AddBody(newBarang);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PushAsync(new MainBarang());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }
        }
    }
}
