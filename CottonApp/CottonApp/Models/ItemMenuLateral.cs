﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottonApp.Models
{
    public class ItemMenuLateral
    {
        public ItemMenuLateral(String Titulo, String Descricao)
        {
            this.Titulo = Titulo;
            this.Descricao = Descricao;
        }
        public String Titulo
        {
            get;
            set;
        }

        public String Descricao
        {
            get;
            set;
        }
    }
}
