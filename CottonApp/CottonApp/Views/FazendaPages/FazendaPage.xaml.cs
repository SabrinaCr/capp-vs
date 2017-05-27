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
    public partial class FazendaPage : ContentPage
    {
        public FazendaPage()
        {
            InitializeComponent();
        }

        public async void ProximoClicked(object sender, EventArgs e)
        {
            var fazenda = new Models.Fazenda
            {
                Nome = this.Nome.Text,
                Hectares = Decimal.Parse(this.Hectares.Text),
                Observacoes = this.Observacoes.Text
            };

            // chama proxima tela
            await this.Navigation.PushAsync(new FazendaInfoLocalizacaoPage(fazenda));
        }
    }
}
