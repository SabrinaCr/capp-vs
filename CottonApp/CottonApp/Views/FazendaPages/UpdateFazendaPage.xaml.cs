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
    public partial class UpdateFazendaPage : ContentPage
    {
        private UpdateFazendaViewModel ViewModel => BindingContext as UpdateFazendaViewModel;

        Fazenda _fazenda;
        Cliente _cliente;

        public UpdateFazendaPage(Fazenda fazenda)
        {
            InitializeComponent();

            var cottonAppApiService = DependencyService.Get<ICottonAppApiService>();
            BindingContext = new UpdateFazendaViewModel(cottonAppApiService);

            _fazenda = fazenda;
            ViewModel.Fazenda = _fazenda;
        }

        protected void SalvarClicked(object sender, EventArgs e)
        {
            if (this.Hectares == null)
                this.Hectares.Text = "0";
            // chama viewmodel para fazer validações e update
            var fazenda = new Models.Fazenda
            {
                Id = ViewModel.Fazenda.Id,
                Nome = this.Nome.Text,
                Telefone = this.Telefone.Text,
                Hectares = Decimal.Parse(this.Hectares.Text),
                Cidade = this.Cidade.Text,
                Bairro = this.Bairro.Text,
                UF = this.UF.Text,
                Email = this.Email.Text,
                EnderecoWeb = this.EnderecoWeb.Text,
                Observacoes = this.Observacoes.Text,
                ClienteId = _fazenda.ClienteId
            };

            ViewModel.UpdateFazendaCommand.Execute(fazenda);
        }

        protected async void ExcluirClicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Confirmar Exclusão", "Deseja realmente excluir todos os registros desta fazenda?", "Sim", "Não");
            if (answer)
            {
                ViewModel.DeleteFazendaCommand.Execute(ViewModel.Fazenda);
            }
        }
    }
}
