using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottonApp.Models
{
    public class Cliente
    {
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get;
            set;
        }

        [MaxLength(50), NotNull]
        public String Nome
        {
            get;
            set;
        }

        [MaxLength(100), NotNull]
        public String Email
        {
            get;
            set;
        }

        [MaxLength(100), NotNull]
        public String Login
        {
            get;
            set;
        }

        [NotNull]
        public String Senha
        {
            get;
            set;
        }

        [MaxLength(20)]
        public String Telefone
        {
            get;
            set;
        }

        [MaxLength(100)]
        public String Cidade
        {
            get;
            set;
        }

        [MaxLength(3)]
        public String UF
        {
            get;
            set;
        }

        [MaxLength(15)]
        public String CEP
        {
            get;
            set;
        }

        [MaxLength(100)]
        public String Logradouro
        {
            get;
            set;
        }

        public int Numero
        {
            get;
            set;
        }

        [MaxLength(50)]
        public String Bairro
        {
            get;
            set;
        }

        [MaxLength(15)]
        public String CPF
        {
            get;
            set;
        }

        public DateTime DataDesativacao
        {
            get;
            set;
        }

        public override string ToString()
        {
            return string.Format("Nome={0}, Email={1}, Telefone={2}", Nome, Email, Telefone);
        }
    }
}
