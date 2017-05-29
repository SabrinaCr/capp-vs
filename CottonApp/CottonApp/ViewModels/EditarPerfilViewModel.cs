using CottonApp.Models;
using CottonApp.Services;
using CottonApp.Views.LoginPages;
using CottonApp.Views.MainPage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CottonApp.ViewModels
{
    public class EditarPerfilViewModel : BaseViewModel
    {
        private readonly ICottonAppApiService _cottonAppApiService;
        private Cliente _cliente;

        public Cliente Cliente
        {
            get { return _cliente; }
            set
            {
                SetProperty(ref _cliente, value);
                //UpdateClienteCommand.ChangeCanExecute();
                //Clientes.Clear();
            }
        }

        public Command<Cliente> ShowClienteCommand { get; }
        public Command<Cliente> UpdateClienteCommand { get; }
        public Command<Cliente> DeleteClienteCommand { get; }

        public EditarPerfilViewModel(ICottonAppApiService cottonAppApiService)
        {
            _cottonAppApiService = cottonAppApiService;

            ShowClienteCommand = new Command<Cliente>(ExecuteShowClienteCommand);
            UpdateClienteCommand = new Command<Cliente>(ExecuteUpdateClienteCommand);
            DeleteClienteCommand = new Command<Cliente>(ExecuteDeleteClienteCommand);

            //_cliente = cliente;
            //OnPropertyChanged(nameof(_cliente));
        }

        private async void ExecuteUpdateClienteCommand(Cliente cliente)
        {
            string mensagem = CanExecuteClienteCommand(cliente);
            if (mensagem.Equals(""))
                await DisplayAlert("Sucesso!", "Seus dados pessoais estão atualizados", "OK");
            else
                await DisplayAlert("Ops...", mensagem, "OK");
        }

        public string CanExecuteClienteCommand(Cliente cliente)
        {
            string mensagem = "";
            if (cliente.Nome == null || cliente.Nome.Equals(""))
                return mensagem = "Informe seu nome";

            if (!_cottonAppApiService.UpdateCliente(cliente))
                return mensagem = "Algo deu errado durante a tentativa de atualização. Verifique seus dados e tente novamente.";

            return mensagem;
        }

        private async void ExecuteDeleteClienteCommand(Cliente cliente)
        {
            if(_cottonAppApiService.DeleteCliente(cliente))
            {
                await DisplayAlert("Informação", "A conta foi deletada com sucesso", "OK");
                App.Current.MainPage = new NavigationPage(new LoginPage());
            }
                
        }

        private async void ExecuteShowClienteCommand(Cliente cliente)
        {
            await PushAsync<ClienteViewModel>(cliente);
        }
    }
}
