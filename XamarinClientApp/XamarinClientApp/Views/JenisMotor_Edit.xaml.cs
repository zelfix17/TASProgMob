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
    public partial class JenisMotor_Edit : ContentPage
    {
        public JenisMotor_Edit()
        {
            InitializeComponent();
            btnEdit.Clicked += BtnEditJenisMotor_Clicked;
            btnDelete.Clicked += BtnDeleteJenisMotor_Clicked;
        }

        // Define Server
        private RestClient _client = new RestClient("http://zelfixbackend.azurewebsites.net/");

        // Add Function
        private async void BtnEditJenisMotor_Clicked(object sender, EventArgs e)
        {
            //Define Request - PUT
            var _request = new RestRequest("api/JenisMotor", Method.PUT);
            //Add New Kategori
            var newKategori = new JenisMotor
            {
                IdJenisMotor = Convert.ToInt32(txtIdJenisMotor.Text),
                NamaMerk = txtNamaMerk.Text,
                NamaJenisMotor = txtNamaJenisMotor.Text
            };
            //Execute
            _request.AddBody(newKategori);
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

        private async void BtnDeleteJenisMotor_Clicked(object sender, EventArgs e)
        {
            //Define Request - Delete
            var _request = new RestRequest("api/JenisMotor/{id}", Method.DELETE);
            //Execute
            _request.AddParameter("id", txtIdJenisMotor.Text);
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
