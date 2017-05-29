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
    public class UpdateFazendaViewModel : BaseViewModel
    {
        private readonly ICottonAppApiService _cottonAppApiService;
        private Fazenda _fazenda;

        public Fazenda Fazenda
        {
            get { return _fazenda; }
            set
            {
                SetProperty(ref _fazenda, value);
            }
        }

        public Command<Fazenda> UpdateFazendaCommand { get; }
        public Command<Fazenda> DeleteFazendaCommand { get; }

        public UpdateFazendaViewModel(ICottonAppApiService cottonAppApiService)
        {
            _cottonAppApiService = cottonAppApiService;

            UpdateFazendaCommand = new Command<Fazenda>(ExecuteUpdateFazendaCommand);
            DeleteFazendaCommand = new Command<Fazenda>(ExecuteDeleteFazendaCommand);

            //_cliente = cliente;
            //OnPropertyChanged(nameof(_cliente));
        }

        private async void ExecuteUpdateFazendaCommand(Fazenda fazenda)
        {
            string mensagem = CanExecuteUpdateFazendaCommand(fazenda);
            if (mensagem.Equals(""))
                await DisplayAlert("Sucesso!", "Os dados de sua fazenda estão atualizados", "OK");
            else
                await DisplayAlert("Ops...", mensagem, "OK");
        }

        public string CanExecuteUpdateFazendaCommand(Fazenda fazenda)
        {
            string mensagem = "";
            if (fazenda.Nome == null || fazenda.Nome.Equals(""))
                return mensagem = "Informe o nome da Fazenda";
            else if (fazenda.Hectares == 0)
                return mensagem = "Informe o nome da Fazenda";
            else if (fazenda.Telefone == null)
                return mensagem = "Informe um número de telefone para a fazenda";

            if (!_cottonAppApiService.UpdateFazenda(fazenda))
                return mensagem = "Algo deu errado durante a tentativa de atualização. Verifique seus dados e tente novamente.";

            return mensagem;
        }

        private async void ExecuteDeleteFazendaCommand(Fazenda fazenda)
        {
            if (_cottonAppApiService.DeleteFazenda(fazenda))
            {
                await DisplayAlert("Informação", "Fazenda deletada com sucesso", "OK");
                //await App.Current.MainPage.Navigation.PopToRootAsync();
                await MainPage.NavigateMasterDetail(new FazendaListaPage());
                //App.Current.MainPage = new NavigationPage(new FazendaListaPage());
            }

        }
    }
}
