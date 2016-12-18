using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinClientApp.Views
{
    public partial class MainPageDetail : ContentPage
    {
        public MainPageDetail()
        {

            InitializeComponent();
            //this.BackgroundImage = "gladiator.png";
            this.BackgroundColor = Color.FromHex("#9c3832");
            btnViewBarang.Clicked += BtnViewBarang_Clicked;
            btnViewJenisMotor.Clicked += BtnViewJenisMotor_Clicked;
            btnViewKategori.Clicked += BtnViewKategori_Clicked;
        }
        public void BtnViewBarang_Clicked(Object sender, EventArgs e)
        {
            MainBarang goToBarang = new MainBarang();
            Navigation.PushAsync(goToBarang);
        }

        public void BtnViewJenisMotor_Clicked(Object sender, EventArgs e)
        {
            MainJenisMotor goToJenisMotor = new MainJenisMotor();
            Navigation.PushAsync(goToJenisMotor);
        }

        public void BtnViewKategori_Clicked(Object sender, EventArgs e)
        {
            MainKategori goToKategori = new MainKategori();
            Navigation.PushAsync(goToKategori);
        }
    }
}
