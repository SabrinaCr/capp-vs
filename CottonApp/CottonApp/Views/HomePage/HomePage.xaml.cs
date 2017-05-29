using CottonApp.Models;
using CottonApp.Services;
using CottonApp.ViewModels;
using CottonApp.Views.MasterDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CottonApp.Views.HomePage
{
    public partial class HomePage : MasterDetailPage
    {
        private HomePageViewModel ViewModel => BindingContext as HomePageViewModel;

        public HomePage(Cliente cliente)
        {
            InitializeComponent();

            var cottonAppApiService = DependencyService.Get<ICottonAppApiService>();
            BindingContext = new HomePageViewModel(cottonAppApiService, cliente);

            ViewModel._cliente = new Cliente();
            ViewModel._cliente = cliente;

            this.Master = new Master(ViewModel._cliente);
            this.Detail = new NavigationPage(new Detail());
            MainPage.MainPage.MasterDetail = this;
        }
    }
}
