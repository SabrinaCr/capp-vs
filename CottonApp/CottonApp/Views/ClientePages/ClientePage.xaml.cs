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

namespace CottonApp.Views.ClientePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientePage : ContentPage
    {
        private ClienteViewModel ViewModel => BindingContext as ClienteViewModel;

        public Cliente _cliente;

        public ClientePage()
        {
            InitializeComponent();

            var cottonAppApiService = DependencyService.Get<ICottonAppApiService>();
            BindingContext = new ClienteViewModel(_cliente); // _cliente

        }

        protected void SalvarClicked(object sender, EventArgs e)
        {
            var cliente = new Models.Cliente
            {
                Nome = this.Nome.Text,
                Email = this.Email.Text,
                Login = this.Login.Text,
                Senha = this.Senha.Text
            };

            string mensagem = ViewModel.CanExecuteInsertClienteCommand(cliente, this.ConfirmarSenha.Text);
            if (mensagem.Equals(""))
            {
                ViewModel.InsertClienteCommand.Execute(cliente);
                
            }
            else
                DisplayAlert("Ops...", mensagem, "OK");


            //using (var dados = new GetDatabaseCliente())
            //{
            //    int inserted = dados.Insert(cliente);

            //    if (inserted > 0) // success maybe
            //    {
            //        DisplayAlert("Seja Bem-Vindo(a) " + cliente.Nome, "Seu usuário foi criado com sucesso", "OK");
            //        this.Navigation.PopToRootAsync();
            //    }
            //    else
            //        DisplayAlert("Ops...", "Algo deu errado durante a tentativa de cadastro. Verifique seus dados e tente novamente.", "OK");
            //    //this.Lista.ItemsSource = dados.Listar();
            //}
        }
    }
}
