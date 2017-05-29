using CottonApp.Models;
using CottonApp.Services;
using CottonApp.ViewModels;
using CottonApp.Views.ClientePages;
using CottonApp.Views.HomePage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CottonApp.Views.LoginPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel ViewModel => BindingContext as LoginViewModel;
        private Cliente _clienteTela;

        public LoginPage()
        {
            InitializeComponent();

            var cottonAppApiService = DependencyService.Get<ICottonAppApiService>();
            BindingContext = new LoginViewModel(cottonAppApiService);

            //ViewModel.InsertClienteCommand.Execute(this.Registrar);
            Registrar.GestureRecognizers.Add(new TapGestureRecognizer
            {
                //Command = new Command(() => ViewModel.InsertClienteCommand.Execute(Registrar))
                Command = new Command(() => OnLabelClicked()),
            });
        }

        public void Button_OnEntrarClicked(object sender, EventArgs e)
        {
            _clienteTela = new Cliente();
            _clienteTela.Login = this.Login.Text;
            _clienteTela.Email = this.Login.Text;
            _clienteTela.Senha = this.Senha.Text;

            ViewModel.LoginCommand.Execute(_clienteTela);
        }

        public void OnLabelClicked()
        {
             //this.Navigation.PopToRootAsync();
             this.Navigation.PushAsync(new ClientePage());
        }
    }
}

//var clienteBanco = ViewModel.RecuperaClienteLoginEmail(clienteTela);

//if (clienteBanco != null && clienteTela.Senha.Equals(clienteBanco.Senha))
//{
//    // faz login -- chama tela principal
//    await this.Navigation.PopToRootAsync(); // testar
//    await App.Current.MainPage.Navigation.PushAsync(new HomePage.HomePage());
//}
//else
//    await DisplayAlert("Erro", "Login ou Senha Incorretos", "OK");
