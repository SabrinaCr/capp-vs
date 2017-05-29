using CottonApp.Models;
using CottonApp.Services;
using CottonApp.Views.HomePage;
using CottonApp.Views.MainPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CottonApp.ViewModels
{
    public class ClienteViewModel : BaseViewModel
    {
        private readonly ICottonAppApiService _cottonAppApiService;
        public Cliente _cliente;

        public Cliente Cliente
        {
            get { return _cliente; }
            set { SetProperty(ref _cliente, value); }
        }

        public Command<Cliente> InsertClienteCommand { get; }

        public ClienteViewModel(Cliente cliente)
        {
            _cliente = cliente;
            _cottonAppApiService = DependencyService.Get<ICottonAppApiService>();
            InsertClienteCommand = new Command<Cliente>(ExecuteInsertClienteCommand);
        }

        private async void ExecuteInsertClienteCommand(Cliente cliente)
        {
            if (_cottonAppApiService.InsertCliente(cliente))
            {
                await DisplayAlert("Bem-Vindo(a)!", "Sua conta foi criada com sucesso", "OK");
                await App.Current.MainPage.Navigation.PopToRootAsync();
                App.Current.MainPage = new HomePage(cliente);
            }   
            else
                await DisplayAlert("Ops...", "Algo deu errado durante a tentativa de cadastro. Verifique seus dados e tente novamente.", "OK");
        }

        public string CanExecuteInsertClienteCommand(Cliente cliente, string confirm)
        {
            string mensagem = "";
            if (cliente.Nome == null || cliente.Nome.Equals(""))
                return mensagem = "Informe seu nome";
            else if (cliente.Email == null || cliente.Email.Equals(""))
                return mensagem = "Informe seu email";
            else if (cliente.Email != null && !emailIsValid(cliente.Email))
                return mensagem = "Email inválido";
            else if (_cottonAppApiService.GetClienteByEmail(cliente.Email) != null)
                return mensagem = "O email informado já está em uso";
            else if (cliente.Login == null || cliente.Login.Equals(""))
                return mensagem = "Informe um login";
            else if (_cottonAppApiService.GetClienteByLogin(cliente.Login) != null)
                return mensagem = "O login informado já está sendo utilizado";
            else if (cliente.Senha == null || cliente.Senha.Equals(""))
                return mensagem = "Crie uma senha de acesso para a segurança de suas informações";
            else if (cliente.Senha != null && cliente.Senha.Length < 4)
                return mensagem = "A senha deve conter no mínimo 4 dígitos";
            else if (confirm == null || confirm.Equals(""))
                return mensagem = "Por favor, confirme a senha";
            else if (!cliente.Senha.Equals(confirm))
                return mensagem = "As senhas não conferem";

            return mensagem;
        }

        public bool emailIsValid(string email)
        {
            if (!email.Contains("@") && !email.Contains("."))
                return false;
            return true;
        }
    }
}
