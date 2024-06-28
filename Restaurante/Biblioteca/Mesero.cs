using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Mesero : Empleado
    {
        private List<MesaCliente> mesaCliente;
        public Mesero(string nombre, string apellido, string direccion, string contacto, decimal sueldo, List<MesaCliente> mesaCliente) : base(nombre, apellido, direccion, contacto, sueldo)
        {
            this.MesaCliente = mesaCliente;
        }
        public List<MesaCliente> MesaCliente { get => mesaCliente; set => mesaCliente = value; }

        public IConsumible TomarPedidoMesero(Menu menu)
        {
           return MesaCliente[0].ElegirConsumible(menu);
        }

        public void AgregarALaMesa(IConsumible pedido)
        {

            MesaCliente[0].IncorporarPedidoAlaCuenta(pedido);
            
        }
        

       
    }
}
