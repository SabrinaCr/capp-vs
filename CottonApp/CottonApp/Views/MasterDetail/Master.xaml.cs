using CottonApp.Models;
using CottonApp.Services;
using CottonApp.ViewModels;
using CottonApp.Views;
using CottonApp.Views.ClientePages;
using CottonApp.Views.FazendaPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CottonApp.Views.MainPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CottonApp.Views.MasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {
        private MasterViewModel ViewModel => BindingContext as MasterViewModel;

        public Master(Cliente cliente)
        {
            InitializeComponent();

            var cottonAppApiService = DependencyService.Get<ICottonAppApiService>();
            BindingContext = new MasterViewModel(cottonAppApiService);

            ViewModel.Cliente = cliente;
        }

        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ItemMenuLateral item = (ItemMenuLateral)e.SelectedItem;

                if (item.Titulo.Equals("Cadastrar Cliente"))
                    ViewModel.InsertClienteCommand.Execute(item);
                else if (item.Titulo.Equals("Dados Pessoais"))
                    await MainPage.MainPage.NavigateMasterDetail(new EditarPerfilPage(ViewModel.Cliente));
                else if (item.Titulo.Equals("Cadastrar Fazenda"))
                    await MainPage.MainPage.NavigateMasterDetail(new FazendaPage(ViewModel.Cliente, null));
                //ViewModel.InsertFazendaCommand.Execute(item);
                else if (item.Titulo.Equals("Listar Fazendas"))
                    await MainPage.MainPage.NavigateMasterDetail(new FazendaListaPage());
                else if (item.Titulo.Equals("Sair"))
                    ViewModel.SairCommand.Execute(item);
            }
        }
    }
}