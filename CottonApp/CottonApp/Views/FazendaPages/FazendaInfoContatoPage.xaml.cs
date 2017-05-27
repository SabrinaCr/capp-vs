using CottonApp.Models;
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
    public partial class FazendaInfoContatoPage : ContentPage
    {
        Fazenda _fazenda;

        public FazendaInfoContatoPage()
        {
            InitializeComponent();
        }

        public FazendaInfoContatoPage(Fazenda fazenda)
        {
            InitializeComponent();
            _fazenda = fazenda;
        }

        public void SalvarClicked(object sender, EventArgs e)
        {
            _fazenda.Email = this.Email.Text;
            _fazenda.EnderecoWeb = this.EnderecoWeb.Text;
            _fazenda.Telefone = this.Telefone.Text;

            using (var dados = new AcessoDadosFazenda())
            {
                int inserted = dados.Insert(_fazenda);

                if(inserted > 0)
                {
                    DisplayAlert("Nova Fazenda: " + _fazenda.Nome, "Fazenda inserida com sucesso", "OK");

                    this.Navigation.PopToRootAsync();
                    // mostra uma nova tela com os dados da Fazenda
                    //this.Navigation.PushAsync(new FazendaInfoContatoPage(_fazenda));
                }
                else
                    DisplayAlert("Ops...", "Algo deu errado durante a tentativa de cadastro. Verifique os dados e tente novamente.", "OK");
            }
        }
    }
}
