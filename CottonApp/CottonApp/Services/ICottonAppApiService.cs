using CottonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottonApp.Services
{
    public interface ICottonAppApiService
    {
        // Metodos de Acesso a Dados do Banco
        Cliente GetClienteById(int id);
        List<Cliente> GetClientes();
        Cliente GetClienteByEmail(string email);
        Cliente GetClienteByLogin(string login);
        bool InsertCliente(Cliente cliente);
        bool UpdateCliente(Cliente cliente);
        bool DeleteCliente(Cliente cliente);

        Fazenda GetFazendaById(int id);
        List<Fazenda> GetFazendas();
        bool InsertFazenda(Fazenda fazenda);
        bool UpdateFazenda(Fazenda fazenda);
        bool DeleteFazenda(Fazenda fazenda);

        //Task<List<Fazenda>> GetContentsByFilterAsync(string filter);
    }
}
