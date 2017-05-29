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
    public class FazendaInfoLocalizacaoViewModel : BaseViewModel
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

        public FazendaInfoLocalizacaoViewModel(Fazenda fazenda)
        {
            _cottonAppApiService = DependencyService.Get<ICottonAppApiService>();
            _fazenda = fazenda;

            NextCommand = new Command<Fazenda>(ExecuteNextCommand);
        }

        private async void ExecuteNextCommand(Fazenda fazenda)
        {
            if (fazenda.Bairro != null)
                _fazenda.Bairro = fazenda.Bairro;
            if (fazenda.Cidade != null)
                _fazenda.Cidade = fazenda.Cidade;
            if (fazenda.UF != null)
                _fazenda.UF = fazenda.UF;

            await MainPage.NavigateMasterDetail(new FazendaInfoContatoPage(_fazenda));
        }
    }
}
