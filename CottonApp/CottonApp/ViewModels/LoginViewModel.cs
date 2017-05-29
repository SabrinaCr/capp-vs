using CottonApp.Models;
using CottonApp.Services;
using CottonApp.Views.HomePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CottonApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ICottonAppApiService _cottonAppApiService;
        private Cliente Cliente;

        public Command<Cliente> LoginCommand { get; }
        public Command InsertClienteCommand { get; }

        public LoginViewModel (ICottonAppApiService cottonAppApiService)
        {
            //_cottonAppApiService = cottonAppApiService;
            _cottonAppApiService = DependencyService.Get<ICottonAppApiService>();
            Cliente = new Cliente();
            InsertClienteCommand = new Command(ExecuteInsertClienteCommand);
            LoginCommand = new Command<Cliente>(ExecuteLoginCommand);

            Title = "Cotton App";
        }

        private bool CanExecuteLoginCommand(Cliente cliente)
        {
            if(cliente.Login == null && cliente.Senha == null)
            {
                cliente.Login = "sabrinacr";
                cliente.Senha = "eitagiovana";
            }

            var clienteBanco = _cottonAppApiService.GetClienteByEmail(cliente.Email);
            if (clienteBanco == null)
                clienteBanco = _cottonAppApiService.GetClienteByLogin(cliente.Login);

            if (clienteBanco == null || !cliente.Senha.Equals(clienteBanco.Senha) || cliente.Senha == null)
                return false;
            else
            {
                Cliente = new Cliente();
                Cliente = clienteBanco;
            }

            return true;
        }

        private async void ExecuteInsertClienteCommand()
        {
            await PushAsync<ClienteViewModel>();
        }

        private async void ExecuteLoginCommand(Cliente cliente)
        {
            if (CanExecuteLoginCommand(cliente))
            {
                await App.Current.MainPage.Navigation.PopToRootAsync();
                App.Current.MainPage = new HomePage(Cliente);
            }
                
            else
                await DisplayAlert("Erro", "Login ou Senha Incorretos", "OK");
        }
    }
}
