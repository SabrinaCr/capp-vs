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
    public partial class FazendaInfoLocalizacaoPage : ContentPage
    {
        private FazendaInfoLocalizacaoViewModel ViewModel => BindingContext as FazendaInfoLocalizacaoViewModel;

        public Cliente _cliente;
        public Fazenda _fazenda;

        public FazendaInfoLocalizacaoPage(Fazenda fazenda)
        {
            InitializeComponent();
            _fazenda = fazenda;

            var cottonAppApiService = DependencyService.Get<ICottonAppApiService>();
            BindingContext = new FazendaInfoLocalizacaoViewModel(fazenda); // _cliente
        }

        public void ProximoClicked()
        {
            if(this.Cidade != null)
                _fazenda.Cidade = this.Cidade.Text;
            if(this.Bairro != null)
                _fazenda.Bairro = this.Bairro.Text;
            if(this.UF != null)
                _fazenda.UF = this.UF.Text;

            ViewModel.NextCommand.Execute(_fazenda);
            // chama proxima tela
            //await this.Navigation.PushAsync(new FazendaInfoContatoPage(_fazenda));
        }
    }
}
