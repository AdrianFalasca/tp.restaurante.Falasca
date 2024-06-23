using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Encargado : Empleado
    {
        public Encargado(string nombre, string apellido, string direccion, string contacto, decimal sueldo) : base(nombre, apellido, direccion, contacto, sueldo)
        {
        }

        public IConsumible PonerPrecioPlato(decimal precio, IConsumible plato)
        {
            plato.Precio = precio;
            return plato;
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

        public void CancelarPedido()
        {

        }

        public void PedirProductosAProveedores(string nombreProducto, List<Proveedor> proveedores, List<Producto> productos)
        {
            foreach(Proveedor proveedor in proveedores)//crear escenario donde un proveedor no tenga un producto
            {
                if (proveedor.TipoProducto == nombreProducto)
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
    }
}
