using CottonApp.Models;
using CottonApp.Services;
using CottonApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CottonApp.Views.FazendaPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FazendaPage : ContentPage
    {
        private FazendaViewModel ViewModel => BindingContext as FazendaViewModel;

        public Cliente _cliente;
        public Fazenda _fazenda;

        public FazendaPage(Cliente cliente, Fazenda fazenda)
        {
            InitializeComponent();

            var cottonAppApiService = DependencyService.Get<ICottonAppApiService>();
            BindingContext = new FazendaViewModel(cliente); // _cliente

            ViewModel.Cliente = cliente;
            ViewModel.Fazenda = fazenda;
        }

        public async void ProximoClicked(object sender, EventArgs e)
        {
            if (this.Hectares.Text == null)
                this.Hectares.Text = "0";

            var fazenda = new Models.Fazenda
            {
                Nome = this.Nome.Text,
                Hectares = Decimal.Parse(this.Hectares.Text),
                Observacoes = this.Observacoes.Text
            };

            // chama proxima tela
            ViewModel.NextCommand.Execute(fazenda);

            //await this.Navigation.PushAsync(new FazendaInfoLocalizacaoPage(fazenda));
        }
    }
}
