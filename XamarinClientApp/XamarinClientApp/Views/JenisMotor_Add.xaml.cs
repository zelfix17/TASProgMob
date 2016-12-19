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
    public partial class JenisMotor_Add : ContentPage
    {
        public JenisMotor_Add()
        {
            InitializeComponent();
            btnTambahJenisMotor.Clicked += BtnTambahJenisMotor_Clicked;
        }

        // Define Server
        private RestClient _client = new RestClient("http://zelfixbackend.azurewebsites.net/");

        // Add Function
        private async void BtnTambahJenisMotor_Clicked(object sender, EventArgs e)
        {
            //Define Request - POST
            var _request = new RestRequest("api/JenisMotor", Method.POST);

            //Add New Kategori
            var newJenisMotor = new JenisMotor { NamaMerk = txtNamaMerk.Text, NamaJenisMotor = txtNamaJenisMotor.Text };

            _request.AddBody(newJenisMotor);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PushAsync(new MainJenisMotor());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }
        }
    }
}
