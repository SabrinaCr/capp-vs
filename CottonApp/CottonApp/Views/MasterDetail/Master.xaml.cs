using CottonApp.Models;
using CottonApp.Views;
using CottonApp.Views.Cliente;
using CottonApp.Views.FazendaPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CottonApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();

            this.ItemsMenuLateral.ItemsSource = getItens();
            this.ItemsMenuLateral.ItemSelected += async (sender, e) =>
            {
                ItemMenuLateral item = (ItemMenuLateral)e.SelectedItem;

                if(item.Titulo.Equals("Cadastrar Cliente"))
                    await App.NavigateMasterDetail(new ClientePage());
                else if(item.Titulo.Equals("Editar Perfil Cliente"))
                    await App.NavigateMasterDetail(new EditarPerfilPage());
                else if (item.Titulo.Equals("Cadastrar Fazenda"))
                    await App.NavigateMasterDetail(new FazendaPage());
            };
        }

        public List<ItemMenuLateral> getItens()
        {
            List<ItemMenuLateral> lista = new List<ItemMenuLateral>();

            lista.Add(new ItemMenuLateral("Cadastrar Cliente", ""));
            lista.Add(new ItemMenuLateral("Editar Perfil Cliente", ""));
            lista.Add(new ItemMenuLateral("Cadastrar Fazenda", ""));
            lista.Add(new ItemMenuLateral("Cadastrar Talhão", ""));
            
            return lista;
        }
    }
}
