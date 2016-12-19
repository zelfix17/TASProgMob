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
    public partial class Barang_Edit : ContentPage
    {
        public Barang_Edit()
        {
            InitializeComponent();
            btnEdit.Clicked += BtnEditBarang_Clicked;
            btnDelete.Clicked += BtnDeleteBarang_Clicked;
        }

        // Define Server
        private RestClient _client = new RestClient("http://zelfixbackend.azurewebsites.net/");

        // Add Function
        private async void BtnEditBarang_Clicked(object sender, EventArgs e)
        {
            //Define Request - PUT
            var _request = new RestRequest("api/Barang", Method.PUT);
            //Add New Kategori
            var newBarang = new Barang
            {
                IdBarang = Convert.ToInt32(txtIdBarang.Text),
                NamaBarang = txtNamaBarang.Text,
                HargaBarang = Convert.ToInt32(txtHargaBarang.Text),
                StokBarang = Convert.ToInt32(txtStokBarang.Text),
                TglBeli = Convert.ToDateTime(txtTglBeli.Text),
                IdKategori = Convert.ToInt32(txtIdKategori.Text),
                IdJenisMotor = Convert.ToInt32(txtIdJenisMotor.Text)
            };
            //Execute
            _request.AddBody(newBarang);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }
        }

        private async void BtnDeleteBarang_Clicked(object sender, EventArgs e)
        {
            //Define Request - Delete
            var _request = new RestRequest("api/Barang/{id}", Method.DELETE);
            //Execute
            _request.AddParameter("id", txtIdBarang.Text);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }
        }
    }
}
