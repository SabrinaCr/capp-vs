using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CottonApp.Views.Cliente
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarPerfilPage : ContentPage
    {
        public EditarPerfilPage()
        {
            InitializeComponent();
        }

        protected void SalvarClicked(object sender, EventArgs e)
        {
            var contato = new Models.Cliente
            {
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

            using (var dados = new AcessoDadosCliente())
            {
                int updated = dados.Update(contato);

                if (updated > 0) // success maybe
                    DisplayAlert("Sucesso!" , "Seus dados pessoais estão atualizados", "OK");
                else
                    DisplayAlert("Ops...", "Algo deu errado durante a tentativa de atualização. Verifique seus dados e tente novamente.", "OK");
                //this.Lista.ItemsSource = dados.Listar();
            }
        }
    }
}
