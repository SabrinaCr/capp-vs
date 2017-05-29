using CottonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CottonApp
{
    public class GetDatabaseFazenda : IDisposable
    {
        private SQLite.Net.SQLiteConnection _conexao;

        public GetDatabaseFazenda()
        {
            var config = DependencyService.Get<IConfig>();
            _conexao = new SQLite.Net.SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DiretorioDB, "cottonapp.db3"));

            _conexao.CreateTable<Fazenda>();
        }

        public int Insert<T>(T elemento)
        {
            return _conexao.Insert(elemento);
        }

        public int Update<T>(T elemento)
        {
            return _conexao.Update(elemento);
        }

        public int Delete<T>(T elemento)
        {
            return _conexao.Delete(elemento);
        }

        public Fazenda ObterPorID(int id)
        {
            return _conexao.Table<Fazenda>().FirstOrDefault(c => c.Id == id);
        }

        public List<Fazenda> Listar()
        {
            return _conexao.Table<Fazenda>().OrderBy(c => c.Nome).ToList<Fazenda>();
        }

        public void Dispose()
        {
            _conexao.Dispose();
        }
    }
}
