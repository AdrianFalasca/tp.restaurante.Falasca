using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Pedido
    {
        private IConsumible pedido;
        private string nui;

        public Pedido(IConsumible pedido, string nui)
        {
            this.Pedidox = pedido;
            this.Nui = nui;
        }

        public IConsumible Pedidox { get => pedido; set => pedido = value; }
        public string Nui { get => nui; set => nui = value; }
    }
}
