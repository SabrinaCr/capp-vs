using CottonApp.Models;
using CottonApp.Services;
using CottonApp.ViewModels;
using CottonApp.Views.LoginPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CottonApp.Views.ClientePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarPerfilPage : ContentPage
    {
        private EditarPerfilViewModel ViewModel => BindingContext as EditarPerfilViewModel;

        public Cliente _cliente;

        public EditarPerfilPage(Cliente cliente)
        {
            InitializeComponent();

            var cottonAppApiService = DependencyService.Get<ICottonAppApiService>();
            BindingContext = new EditarPerfilViewModel(cottonAppApiService); // _cliente

            _cliente = cliente;
            ViewModel.Cliente = _cliente;
        }

        protected void SalvarClicked(object sender, EventArgs e)
        {
            // chama viewmodel para fazer validações e update
            var cliente = new Models.Cliente
            {
                Id = ViewModel.Cliente.Id,
                Nome = this.Nome.Text,
                Telefone = this.Telefone.Text,
                CPF = this.CPF.Text,
                Cidade = this.Cidade.Text,
                Bairro = this.Bairro.Text,
                Logradouro = this.Logradouro.Text,
                Numero = Int32.Parse(this.Numero.Text),
                UF = this.UF.Text,
                CEP = this.CEP.Text
            };

            ViewModel.UpdateClienteCommand.Execute(cliente);
        }

        protected async void ExcluirClicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Confirmar Exclusão", "Deseja realmente excluir todos os registros de sua conta?", "Sim", "Não");
            if(answer)
            {
                ViewModel.DeleteClienteCommand.Execute(ViewModel.Cliente);
                //await App.Current.MainPage.Navigation.PopToRootAsync();
                
            }
        }
    }
}
