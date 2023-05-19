//Cliente

using System;
using System.Collections.Generic;
using System.Text;

namespace Banco
{
    internal class Cliente
    {
        public int id{ get; set;}
        public string nombre{ get; set;}
        public Cliente(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}