using CottonApp.Models;
using CottonApp.Services;
using CottonApp.Views.FazendaPages;
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
    public class FazendaListaViewModel : BaseViewModel
    {
        private readonly ICottonAppApiService _cottonAppApiService;
        public Cliente _cliente;
        public Fazenda _fazenda;

        public ObservableCollection<Fazenda> Fazendas { get; }
        
        public Command<Fazenda> ShowFazendaCommand { get; }

        public Fazenda Fazenda
        {
            get { return _fazenda; }
            set
            {
                SetProperty(ref _fazenda, value);
                ShowFazendaCommand.ChangeCanExecute();
            }
        }

        public FazendaListaViewModel()
        {
            _cottonAppApiService = DependencyService.Get<ICottonAppApiService>();
            Fazendas = new ObservableCollection<Fazenda>();
            ShowFazendaCommand = new Command<Fazenda>(ExecuteShowFazendaCommand);

            var fazendas = _cottonAppApiService.GetFazendas();

            System.Diagnostics.Debug.WriteLine("FOUND {0} TAGS", fazendas.Count);
            Fazendas.Clear();
            foreach (var fazenda in fazendas)
            {
                if(fazenda.Nome != null)
                    Fazendas.Add(fazenda);
            }

            OnPropertyChanged(nameof(Fazendas));

            Title = "Fazendas";
        }

        private async void ExecuteShowFazendaCommand(Fazenda fazenda)
        {
            await MainPage.NavigateMasterDetail(new UpdateFazendaPage(fazenda));
            //await PushAsync<FazendaListaViewModel>(fazenda);
        }
    }
}
