using CottonApp.Models;
using CottonApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CottonApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ICottonAppApiService _cottonAppApiService;
        public Cliente cliente;
        public ObservableCollection<Cliente> Clientes { get; }

        public Command AboutCommand { get; }

        public Command SearchCommand { get; }

        public Command<Cliente> ShowCategoriaCommand { get; }

        public MainViewModel(ICottonAppApiService cottonAppApiService) // ICottonAppApiService cottonAppApiService
        {
            //_cottonAppApiService = cottonAppApiService;
            //Clientes = new ObservableCollection<Cliente>();
            //AboutCommand = new Command(ExecuteAboutCommand);
            //SearchCommand = new Command(ExecuteSearchCommand);
            //ShowCategoriaCommand = new Command<Cliente>(ExecuteShowCategoriaCommand);

            Title = "CottonApp";
        }

        // executar comandos da tela principal
        //private async void ExecuteSearchCommand()
        //{
        //    await PushAsync<SearchViewModel>();
        //}

        //private async void ExecuteShowCategoriaCommand(Cliente tag)
        //{
        //    await PushAsync<CategoriaViewModel>(tag);
        //}

        //private async void ExecuteAboutCommand()
        //{
        //    await PushAsync<AboutViewModel>();
        //}

        //public override async Task LoadAsync()
        //{
        //    var tags = await _monkeyHubApiService.GetTagsAsync();

        //    System.Diagnostics.Debug.WriteLine("FOUND {0} TAGS", tags.Count);
        //    Tags.Clear();
        //    foreach (var tag in tags)
        //    {
        //        Tags.Add(tag);
        //    }

        //    OnPropertyChanged(nameof(Tags));
        //}
    }
}
