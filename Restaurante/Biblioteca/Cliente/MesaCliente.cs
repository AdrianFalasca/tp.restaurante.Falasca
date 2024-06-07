using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Cliente
{
    public class MesaCliente
    {
        private string nui;
        private int capacidad;

        public MesaCliente(string nui, int capacidad)
        {
            this.Nui = nui;
            this.Capacidad = capacidad;
        }

        public string Nui { get => nui; set => nui = value; }
        public int Capacidad { get => capacidad; set => capacidad = value; }
    }
}
