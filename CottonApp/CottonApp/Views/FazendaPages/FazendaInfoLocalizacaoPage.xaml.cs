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
    public partial class FazendaInfoLocalizacaoPage : ContentPage
    {
        Fazenda _fazenda;

        public FazendaInfoLocalizacaoPage()
        {
            InitializeComponent();
        }

        public FazendaInfoLocalizacaoPage(Fazenda fazenda)
        {
            InitializeComponent();
            _fazenda = fazenda;
        }

        public async void ProximoClicked()
        {
            _fazenda.Cidade = this.Cidade.Text;
            _fazenda.Bairro = this.Bairro.Text;
            _fazenda.UF = this.UF.Text;

            // chama proxima tela
            await this.Navigation.PushAsync(new FazendaInfoContatoPage(_fazenda));
        }
    }
}
