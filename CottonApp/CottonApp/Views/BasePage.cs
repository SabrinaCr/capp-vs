using CottonApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CottonApp.Views
{
    public class BasePage : ContentPage
    {
        private BaseViewModel ViewModel => BindingContext as BaseViewModel;

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel == null) return;
            Title = ViewModel.Title;
            ViewModel.PropertyChanged += TitlePropertyChanged;
            await ViewModel.LoadAsync();
        }

        private void TitlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(ViewModel.Title)) return;

            Title = ViewModel.Title;
        }
    }
}
