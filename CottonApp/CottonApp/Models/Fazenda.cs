using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottonApp.Models
{
    public class Fazenda
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

        [NotNull]
        public decimal Hectares
        {
            get;
            set;
        }

        [MaxLength(20), NotNull]
        public String Telefone
        {
            get;
            set;
        }

        [MaxLength(100)]
        public String Email
        {
            get;
            set;
        }

        [MaxLength(100)]
        public String EnderecoWeb
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

        [MaxLength(50)]
        public String Bairro
        {
            get;
            set;
        }

        [MaxLength(200)]
        public String Observacoes
        {
            get;
            set;
        }

        public DateTime DataDesativacao
        {
            get;
            set;
        }

        public int ClienteId
        {
            get;
            set;
        }
    }
}
