using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Mesero : Empleado
    {

        public Mesero(string nombre, string apellido, string direccion, string contacto, decimal sueldo) : base(nombre, apellido, direccion, contacto, sueldo)
        {
        }

        public void TomarPedido()
        {
           
        }

        public void AgregarPedidoALaMesa()
        {
            //for (int i = 0; i < mesa.Count; i++)
            //{
            //    if (mesa.Precio)
            //    {
            //        
            //    }
            //}

            //mesa.IncorporarPedidoAlaMesa(pedido);
        }
        public void DescontarProductos()
        {

        }
        
    }
}
