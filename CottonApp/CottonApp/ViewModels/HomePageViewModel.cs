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
    public class HomePageViewModel : BaseViewModel
    {
        private readonly ICottonAppApiService _cottonAppApiService;
        public Cliente _cliente;
        public ObservableCollection<Cliente> Clientes { get; }

        public Command AboutCommand { get; }

        public Command SearchCommand { get; }

        public Command<Cliente> ShowCategoriaCommand { get; }

        public HomePageViewModel(ICottonAppApiService cottonAppApiService, Cliente cliente) // ICottonAppApiService cottonAppApiService
        {
            //_cottonAppApiService = cottonAppApiService;
            //Clientes = new ObservableCollection<Cliente>();
            //AboutCommand = new Command(ExecuteAboutCommand);
            //SearchCommand = new Command(ExecuteSearchCommand);
            //ShowCategoriaCommand = new Command<Cliente>(ExecuteShowCategoriaCommand);

            Title = cliente.Nome;
        }
    }
}
