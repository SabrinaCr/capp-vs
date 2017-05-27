using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(CottonApp.iOS.Config))]
namespace CottonApp.iOS
{
    public class Config : IConfig
    {
        private string _diretorioDB;
        public string DiretorioDB
        {
            get
            {
                if (string.IsNullOrEmpty(_diretorioDB))
                {
                    var diretorio = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    _diretorioDB = System.IO.Path.Combine(diretorio, "..", "Library");

                }
                return _diretorioDB;
            }
        }

        private SQLite.Net.Interop.ISQLitePlatform _plataforma;
        public SQLite.Net.Interop.ISQLitePlatform Plataforma
        {
            get
            {
                if (_plataforma == null)
                {
                    _plataforma = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
                }
                return _plataforma;
            }
        }

        public Config()
        {


        }
    }
}
