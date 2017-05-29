using CottonApp.Services;
using CottonApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CottonApp.Views.MainPage
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel ViewModel => BindingContext as MainViewModel;
        public static MasterDetailPage MasterDetail { get; set; }

        public async static Task NavigateMasterDetail(Page page)
        {
            MasterDetail.IsPresented = false;
            await MasterDetail.Detail.Navigation.PushAsync(page);
        }

        public MainPage()
        {
            InitializeComponent();

            var monkeyHubApiService = DependencyService.Get<ICottonAppApiService>();
            BindingContext = new MainViewModel(monkeyHubApiService);

            //this.Master = new Master();
            //this.Detail = new NavigationPage(new Detail());
            //App.MasterDetail = this;
        }
    }
}
