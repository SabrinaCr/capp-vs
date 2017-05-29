using CottonApp.Models;
using CottonApp.Services;
using CottonApp.Views.FazendaPages;
using CottonApp.Views.MainPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CottonApp.ViewModels
{
    public class FazendaViewModel : BaseViewModel
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

        public Command<Fazenda> NextCommand { get; }

        public FazendaViewModel(Cliente cliente)
        {
            _cottonAppApiService = DependencyService.Get<ICottonAppApiService>();
            _cliente = cliente;

            NextCommand = new Command<Fazenda>(ExecuteNextCommand);
        }

        private async void ExecuteNextCommand(Fazenda fazenda)
        {
            string mensagem = CanExecuteNextCommand(fazenda);

            fazenda.ClienteId = _cliente.Id;

            if (mensagem.Equals(""))
                await MainPage.NavigateMasterDetail(new FazendaInfoLocalizacaoPage(fazenda));
            else
                await DisplayAlert("Informação", mensagem, "OK");
        }

        public async void ExecuteSaveCommand(Fazenda fazenda)
        {
            string mensagem = "";
            if (mensagem.Equals(""))
                await DisplayAlert("Sucesso", "Fazenda " + fazenda.Nome + " cadastrada", "OK");
            else
                await DisplayAlert("Ops...", mensagem, "OK");
        }

        public string CanExecuteNextCommand(Fazenda fazenda)
        {
            string mensagem = "";
            if (fazenda.Nome == null || fazenda.Nome.Equals(""))
                return mensagem = "Informe o nome da fazenda";
            else if (fazenda.Hectares == 0)
                return mensagem = "Informe o tamanho da fazenda (em hectares)";

            return mensagem;
        }

        public string CanExecuteSaveCommand(Fazenda fazenda)
        {
            string mensagem = "";
            if(!_cottonAppApiService.InsertFazenda(fazenda))
                return mensagem = "Algo deu errado durante a tentativa de cadastro. Verifique os dados e tente novamente.";

            return mensagem;
        }
    }
}
