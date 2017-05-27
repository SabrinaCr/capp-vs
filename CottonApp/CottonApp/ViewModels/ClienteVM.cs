using CottonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottonApp.ViewModels
{
    public class ClienteVM
    {
        public static Cliente RecuperaClienteLoginEmail(Cliente c)
        {
            var db = new AcessoDadosCliente();
            Cliente cliente = db.ObterPorLogin(c.Login);

            if (cliente == null)
                cliente = db.ObterPorEmail(c.Email);

            return cliente;
        }

        public void salvar()
        {
            
        }
    }
}
