using CottonApp.Models;
using CottonApp.Services;
using CottonApp.Views.FazendaPages;
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
    public class FazendaInfoContatoViewModel : BaseViewModel
    {
        private readonly ICottonAppApiService _cottonAppApiService;
        private Cliente _cliente;
        private Fazenda _fazenda;

        public Cliente Cliente
        {
            get { return _cliente; }
            set { SetProperty(ref _cliente, value); }
        }

        public Fazenda Fazenda
        {
            get { return _fazenda; }
            set { }//SetProperty(ref _fazenda, value); }
        }

        public Command<Fazenda> SaveCommand { get; }

        public FazendaInfoContatoViewModel(Fazenda fazenda)
        {
            _cottonAppApiService = DependencyService.Get<ICottonAppApiService>();
            _fazenda = fazenda;

            SaveCommand = new Command<Fazenda>(ExecuteSaveCommand);
        }

        public async void ExecuteSaveCommand(Fazenda fazenda)
        {
            string mensagem = CanExecuteSaveCommand(fazenda);
            if (mensagem.Equals(""))
            {
                await DisplayAlert("Sucesso", "Fazenda " + fazenda.Nome + " cadastrada", "OK");
                // desempilha as outras, tipo voltar pro menu
                //await App.Current.MainPage.Navigation.PopToRootAsync();
                //App.Current.MainPage = new HomePage(cliente);
                await MainPage.NavigateMasterDetail(new FazendaListaPage());
                // redireciona para tela de lista de fazendas
            }
            else
                await DisplayAlert("Ops...", mensagem, "OK");
        }

        public string CanExecuteSaveCommand(Fazenda fazenda)
        {
            string mensagem = "";
            if (fazenda.Telefone == null)
                return mensagem = "Informe um número de telefone";
            if (!_cottonAppApiService.InsertFazenda(fazenda))
                return mensagem = "Algo deu errado durante a tentativa de cadastro. Verifique os dados e tente novamente.";

            return mensagem;
        }
    }
}
