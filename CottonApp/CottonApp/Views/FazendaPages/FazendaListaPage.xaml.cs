using CottonApp.Models;
using CottonApp.Services;
using CottonApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CottonApp.Views.FazendaPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FazendaListaPage : ContentPage
    {
        private FazendaListaViewModel ViewModel => BindingContext as FazendaListaViewModel;

        public FazendaListaPage()
        {
            InitializeComponent();
            BindingContext = new FazendaListaViewModel();
            this.ListaFazendas.ItemsSource = ViewModel.Fazendas;
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ViewModel.ShowFazendaCommand.Execute(e.SelectedItem);
            }
        }
    }
}
