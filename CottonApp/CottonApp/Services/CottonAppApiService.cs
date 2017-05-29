using CottonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(CottonApp.Services.CottonAppApiService))]
namespace CottonApp.Services
{
    public class CottonAppApiService : ICottonAppApiService
    {
        // usa essa classe para aplicar os métodos do banco
        GetDatabaseCliente _dataBaseCliente = new GetDatabaseCliente();
        GetDatabaseFazenda _dataBaseFazenda = new GetDatabaseFazenda();

        public List<Cliente> GetClientes()
        {
            return _dataBaseCliente.Listar();
        }

        public Cliente GetClienteById(int id)
        {
            return _dataBaseCliente.ObterPorID(id);
        }

        public Cliente GetClienteByEmail(string email)
        {
            return _dataBaseCliente.ObterPorEmail(email);
        }

        public Cliente GetClienteByLogin(string login)
        {
            Cliente c = _dataBaseCliente.ObterPorLogin(login);
            return c;
        }

        public bool UpdateCliente(Cliente cliente)
        {
            if (_dataBaseCliente.Update(cliente) <= 0)
                return false;
            return true;
        }

        public bool InsertCliente(Cliente cliente)
        {
            if (_dataBaseCliente.Insert(cliente) <= 0)
                return false;
            return true;
        }

        public bool DeleteCliente(Cliente cliente)
        {
            if (_dataBaseCliente.Delete(cliente) < 0)
                return false;
            return true;
        }

        public List<Fazenda> GetFazendas()
        {
            return _dataBaseFazenda.Listar();
        }

        public Fazenda GetFazendaById(int id)
        {
            return _dataBaseFazenda.ObterPorID(id);
        }

        public bool UpdateFazenda(Fazenda fazenda)
        {
            if (_dataBaseFazenda.Update(fazenda) <= 0)
                return false;
            return true;
        }

        public bool InsertFazenda(Fazenda fazenda)
        {
            if (_dataBaseFazenda.Insert(fazenda) <= 0)
                return false;
            return true;
        }

        public bool DeleteFazenda(Fazenda fazenda)
        {
            if (_dataBaseFazenda.Delete(fazenda) < 0)
                return false;
            return true;
        }
    }
}
