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
    public partial class FazendaInfoContatoPage : ContentPage
    {
        private FazendaInfoContatoViewModel ViewModel => BindingContext as FazendaInfoContatoViewModel;

        public Fazenda _fazenda;

        public FazendaInfoContatoPage(Fazenda fazenda)
        {
            InitializeComponent();
            _fazenda = fazenda;

            var cottonAppApiService = DependencyService.Get<ICottonAppApiService>();
            BindingContext = new FazendaInfoContatoViewModel(fazenda); // _cliente
        }

        public void SalvarClicked(object sender, EventArgs e)
        {
            if (this.Email != null)
                _fazenda.Email = this.Email.Text;
            if (this.EnderecoWeb != null)
                _fazenda.EnderecoWeb = this.EnderecoWeb.Text;
            if (this.Telefone != null)
                _fazenda.Telefone = this.Telefone.Text;

            ViewModel.Fazenda = _fazenda;
            ViewModel.SaveCommand.Execute(_fazenda);

            //using (var dados = new GetDatabaseFazenda())
            //{
            //    int inserted = dados.Insert(_fazenda);

            //    if(inserted > 0)
            //    {
            //        DisplayAlert("Nova Fazenda: " + _fazenda.Nome, "Fazenda inserida com sucesso", "OK");

            //        this.Navigation.PopToRootAsync();
            //        // mostra uma nova tela com os dados da Fazenda
            //        //this.Navigation.PushAsync(new FazendaInfoContatoPage(_fazenda));
            //    }
            //    else
            //        DisplayAlert("Ops...", "Algo deu errado durante a tentativa de cadastro. Verifique os dados e tente novamente.", "OK");
            //}
        }
    }
}
