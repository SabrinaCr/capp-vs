using CottonApp.Models;
using CottonApp.Services;
using CottonApp.Views.FazendaPages;
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
    public class MasterViewModel : BaseViewModel
    {
        private readonly ICottonAppApiService _cottonAppApiService;
        private Cliente _cliente;

        public ObservableCollection<Cliente> Clientes { get; }

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

        public ObservableCollection<ItemMenuLateral> Itens { get; }

        public Command InsertClienteCommand { get; }
        public Command<Cliente> UpdateClienteCommand { get; }
        public Command<Cliente> ShowClienteCommand { get; }

        public Command InsertFazendaCommand { get; }
        public Command<Fazenda> ShowFazendaCommand { get; }
        
        public Command SairCommand { get; }

        public MasterViewModel(ICottonAppApiService cottonAppApiService) // ICottonAppApiService cottonAppApiService
        {
            _cottonAppApiService = cottonAppApiService;
            Cliente = new Cliente();
            InsertClienteCommand = new Command(ExecuteInsertClienteCommand);
            InsertFazendaCommand = new Command(ExecuteInsertFazendaCommand);
            ShowClienteCommand = new Command<Cliente>(ExecuteShowClienteCommand);
            UpdateClienteCommand = new Command<Cliente>(ExecuteUpdateClienteCommand);
            SairCommand = new Command(ExecuteSairCommand);

            var itens = GetItens();
            Itens = new ObservableCollection<ItemMenuLateral>();
            Itens.Clear();
            System.Diagnostics.Debug.WriteLine("FOUND {0} CLIENTES", itens.Count);
            foreach (var item in itens)
            {
                Itens.Add(item);
            }

            OnPropertyChanged(nameof(Itens));

            Title = "CottonApp";
        }

        private async void ExecuteInsertClienteCommand()
        {
            await PushAsync<ClienteViewModel>();
        }

        private async void ExecuteShowClienteCommand(Cliente cliente)
        {
            await PushAsync<ClienteViewModel>(cliente);
        }

        private async void ExecuteInsertFazendaCommand()
        {
            //await MainPage.NavigateMasterDetail(new FazendaInfoLocalizacaoPage());
            await PushAsync<FazendaViewModel>();
        }

        private async void ExecuteShowFazendaCommand(Cliente cliente)
        {
            await PushAsync<FazendaViewModel>(cliente);
        }

        private async void ExecuteUpdateClienteCommand(Cliente cliente)
        {
            Cliente c = new Cliente();
            c = cliente;
            await PushAsync<EditarPerfilViewModel>(c);
        }

        private void ExecuteSairCommand()
        {
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }

        public override async Task LoadAsync()
        {
            var itens = GetItens();
            
            System.Diagnostics.Debug.WriteLine("FOUND {0} CLIENTES", itens.Count);
            Itens.Clear();
            foreach (var item in itens)
            {
                Itens.Add(item);
            }

            OnPropertyChanged(nameof(Itens));
        }

        public List<ItemMenuLateral> GetItens()
        {
            List<ItemMenuLateral> lista = new List<ItemMenuLateral>();

            //lista.Add(new ItemMenuLateral("Cadastrar Cliente", ""));
            lista.Add(new ItemMenuLateral("Dados Pessoais", ""));
            lista.Add(new ItemMenuLateral("Cadastrar Fazenda", ""));
            lista.Add(new ItemMenuLateral("Cadastrar Talhão", ""));
            lista.Add(new ItemMenuLateral("Listar Fazendas", ""));
            lista.Add(new ItemMenuLateral("Sair", ""));

            return lista;
        }
    }
}


//private readonly ICottonAppApiService _cottonAppApiService;
//private int _cliente;

//public Cliente Cliente
//{
//    get { return _cliente; }
//    set
//    {
//        SetProperty(ref _cliente, value);
//        SearchCommand.ChangeCanExecute();
//        Clientes.Clear();
//    }
//}

//public Command SearchCommand { get; }

//public ObservableCollection<Cliente> Clientes { get; }

//public Command<Cliente> ShowContentCommand { get; }

//public EditarPerfilViewModel(ICottonAppApiService cottonAppApiService)
//{
//    _cottonAppApiService = cottonAppApiService;

//    Clientes = new ObservableCollection<Cliente>();
//    SearchCommand = new Command(ExecuteSearchCommand);
//    ShowContentCommand = new Command<Cliente>(ExecuteShowContentCommand);
//}

//private async void ExecuteShowContentCommand(Cliente content)
//{
//    //await PushAsync<ContentWebViewModel>(content);
//}


//private async void ExecuteSearchCommand()
//{
//    int id = 1;

//    var cliente = _cottonAppApiService.GetClienteById(id);

//    Clientes.Clear();
//    if (cliente == null)
//    {
//        await DisplayAlert("CottonApp", "Nenhum resultado encontrado.", "Ok");
//        return;
//    }

//    Cliente = cliente;
//}