using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinClientApp.ViewModels;
using XamarinClientApp.Models;

namespace XamarinClientApp
{
    public partial class MainJenisMotor : ContentPage
    {
        public MainJenisMotor()
        {
            InitializeComponent();
            this.BindingContext = new JenisMotorViewModel();

            listJenisMotor.ItemTapped += ListJenisMotor_ItemTapped;
        }
        private void ListJenisMotor_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            JenisMotor item = (JenisMotor)e.Item;
            //Category_Edit editPage = new Category_Edit();
            //editPage.BindingContext = item;
            //Navigation.PushAsync(editPage);
        }

    }
}
