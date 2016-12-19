using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinClientApp.ViewModels;
using Xamarin.Forms;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using XamarinClientApp.Models;


namespace XamarinClientApp.ViewModels
{
    public class SearchNamaKategori : BindableObject
    {
        private RestClient _client = new RestClient("http://zelfixbackend.azurewebsites.net/");

        private ObservableCollection<Barang> listBarang;
        public ObservableCollection<Barang> ListBarang
        {
            get { return listBarang; }
            set { listBarang = value; OnPropertyChanged("ListBarang"); }
        }

        public async void RefreshDataAsync(string namakategori)
        {
            var _request = new RestRequest("api/barang/?namaKategori=" + namakategori, Method.GET);
            var _response = await _client.Execute<List<Barang>>(_request);
            ListBarang = new ObservableCollection<Barang>(_response.Data);
        }
        public SearchNamaKategori(string NamaKategori)
        {
            RefreshDataAsync(NamaKategori);

        }
    }
}
