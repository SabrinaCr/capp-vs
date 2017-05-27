using CottonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CottonApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientePage : ContentPage
    {
        public ClientePage()
        {
            InitializeComponent();

            //using (var dados = new AcessoDadosCliente())
            //{
            //    this.Lista.ItemsSource = dados.Listar();
            //}
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

            using (var dados = new AcessoDadosCliente())
            {
                int inserted = dados.Insert(cliente);

                if (inserted > 0) // success maybe
                {
                    DisplayAlert("Seja Bem-Vindo(a) " + cliente.Nome, "Seu usuário foi criado com sucesso", "OK");
                    this.Navigation.PopToRootAsync();
                }
                else
                    DisplayAlert("Ops...", "Algo deu errado durante a tentativa de cadastro. Verifique seus dados e tente novamente.", "OK");
                //this.Lista.ItemsSource = dados.Listar();
            }
        }
    }
}
