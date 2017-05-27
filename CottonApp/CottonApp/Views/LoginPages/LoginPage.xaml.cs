using CottonApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CottonApp.Views.LoginPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            Registrar.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => OnLabelClicked()),
            });
        }

        public async void EntrarClicked(object sender, EventArgs e)
        {
            var clienteTela = new Models.Cliente();
            clienteTela.Login = this.Login.Text;
            clienteTela.Senha = this.Senha.Text;

            var clienteBanco = ClienteVM.RecuperaClienteLoginEmail(clienteTela);

            if (clienteBanco != null && clienteTela.Senha.Equals(clienteBanco.Senha))
            {
                // faz login -- chama tela principal
                await this.Navigation.PushAsync(new HomePage());
            }
            else
                await DisplayAlert("Erro", "Login ou Senha Incorretos", "OK");
        }

        public void OnLabelClicked()
        {
             //this.Navigation.PopToRootAsync();
             this.Navigation.PushAsync(new ClientePage());
        }
    }
}
