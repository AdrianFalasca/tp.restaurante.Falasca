using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class DeliveryCliente
    {

        private string nui;
        

        public DeliveryCliente(string nui)
        {
            Nui = nui;
           
        }

        public string Nui { get => nui; set => nui = value; }
    }
}
