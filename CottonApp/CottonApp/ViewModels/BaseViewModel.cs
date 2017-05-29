using CottonApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using CottonApp.Views.FazendaPages;
using CottonApp.Views.LoginPages;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CottonApp.Views.MainPage;
using CottonApp.Views.MasterDetail;

namespace CottonApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public async Task PushAsync<TViewModel>(params object[] args) where TViewModel : BaseViewModel
        {
            var viewModelType = typeof(TViewModel);
            var viewType = GetTypeView(viewModelType);
            ContentPage page;

            if(viewModelType.Name.Equals("CottonApp.ViewModels.EditarPerfilViewModel"))
            {
                if (viewModelType.GetTypeInfo().DeclaredConstructors.Any(c => c.GetParameters().Any(p => p.ParameterType == typeof(ICottonAppApiService))))
                {
                    var argsList = args.ToList();
                    var monkeyHubApiService = DependencyService.Get<ICottonAppApiService>();
                    argsList.Insert(0, monkeyHubApiService);
                    args = argsList.ToArray();
                }

                page = Activator.CreateInstance(viewType) as ContentPage;
                var viewModel = Activator.CreateInstance(viewModelType, args);

                if (page != null)
                {
                    page.BindingContext = viewModel;
                }
            }
            else
            {
                page = Activator.CreateInstance(viewType) as ContentPage;
            }

            await MainPage.NavigateMasterDetail(page);
            //await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public virtual Task LoadAsync()
        {
            return Task.FromResult(0);
        }

        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public async Task DisplayAlert(string title, string message, string accept, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }

        public Type GetTypeView(Type viewModelType)
        {
            var viewModelTypeName = viewModelType.Name;
            var viewModelWordLength = "ViewModel".Length;
            var viewPath = "";
            var viewTypeName = "";

            if (viewModelTypeName.Equals("ClienteViewModel") || viewModelTypeName.Equals("EditarPerfilViewModel"))
            {
                viewPath = "CottonApp.Views.ClientePages.";
                viewTypeName = $"{viewPath}{viewModelTypeName.Substring(0, viewModelTypeName.Length - viewModelWordLength)}Page";
            }
            else if(viewModelTypeName.Equals("FazendaViewModel") || viewModelTypeName.Equals("FazendaInfoContatoViewModel") || viewModelTypeName.Equals("FazendaInfoLocalizacaoViewModel"))
            {
                viewPath = "CottonApp.Views.FazendaPages.";
                viewTypeName = $"{viewPath}{viewModelTypeName.Substring(0, viewModelTypeName.Length - viewModelWordLength)}Page";
            }

            Type viewType = Type.GetType(viewTypeName);

            return viewType;
        }

    }
}
