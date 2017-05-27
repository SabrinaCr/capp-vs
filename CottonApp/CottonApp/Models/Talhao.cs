using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottonApp.Models
{
    public class Talhao
    {
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get;
            set;
        }

        [MaxLength(50)]
        public String Descricao
        {
            get;
            set;
        }

        public decimal Tamanho
        {
            get;
            set;
        }

        public decimal Espacamento
        {
            get;
            set;
        }

        public DateTime DataDesativacao
        {
            get;
            set;
        }

        public int FazendaId
        {
            get;
            set;
        }
    }
}
