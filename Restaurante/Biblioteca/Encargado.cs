using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Biblioteca
{
    public class Encargado : Empleado
    {
        public Encargado(string nombre, string apellido, string direccion, string contacto, decimal sueldo) : base(nombre, apellido, direccion, contacto, sueldo)
        {
        }

        

        public void PonerPrecioPlato(string nombre, decimal precio, Menu menu)
        {
            for (int i = 0; i < menu.Consumible.Count; i++)
            {

                if (menu.Consumible[i].Nombre == nombre)
                {

                    menu.Consumible[i].Precio = precio;

                }
            }
        }

        public bool CancelarPedido()
        {
            return true;
        }

        public bool PedirProductosAProveedores(string tipoProducto, string nombreProducto, List<Proveedor> proveedores, List<Producto> productos)
        {
            foreach(Proveedor proveedor in proveedores)
            {
                if (proveedor.TipoProducto == tipoProducto)
                {
                    for (int i = 0; i < proveedor.Productos.Count; i++)
                    {
                        if(proveedor.Productos[i].Nombre == nombreProducto)
                        {
                            IngresarProductosPedidosAProveedores(nombreProducto, productos);
                            proveedor.Pago += 10000;
                            Restaurante.RetirarDineroDeCaja(20000);
                        }
                      
                    }
                }
            }
            return false;
        }

        private void IngresarProductosPedidosAProveedores(string nombreProducto, List<Producto> productos)
        {
            foreach (Producto producto in productos)
            {
                if (producto.Nombre == nombreProducto)
                {
                    producto.Cantidad += 1000; 

                    break;
                }

            }
        }


    }
}
