using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using XamarinClientApp.Models;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using Xamarin.Forms;

namespace XamarinClientApp.ViewModels
{
    public class SearchNamaBarang : BindableObject
    {
        private RestClient _client = new RestClient("http://zelfixbackend.azurewebsites.net/");

        private ObservableCollection<Barang> listBarang;
        public ObservableCollection<Barang> ListBarang
        {
            get { return listBarang; }
            set { listBarang = value; OnPropertyChanged("ListBarang"); }
        }

        public async void RefreshDataAsync(string NamaBarang)
        {
            RestRequest _request = new RestRequest("api/barang/?namaBarang=" + NamaBarang, Method.GET);

            var _response = await _client.Execute<List<Barang>>(_request);
            ListBarang = new ObservableCollection<Barang>(_response.Data);
        }
        public SearchNamaBarang(string NamaBarang)
        {

            RefreshDataAsync(NamaBarang);

        }
    }
}