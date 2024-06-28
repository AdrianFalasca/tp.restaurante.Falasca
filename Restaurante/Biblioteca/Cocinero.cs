using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Cocinero : Empleado
    {
        public Cocinero(string nombre, string apellido, string direccion, string contacto, decimal sueldo) : base(nombre, apellido, direccion, contacto, sueldo)
        {
        }

        public void CrearPlato(string nombre, List<Producto> productos, string tiempoPreparacion, Menu menu)
        {
            Plato plato = new Plato(nombre, productos,  tiempoPreparacion, 0);
            menu.IncorporarAlMenu(plato);
            
        }

        public void ModificarPlato(string nombreAModificar, string  nombreActual, List<Producto> productos, string tiempoPreparacion,  Menu menu)
        {
            
            for (int i = 0; i < menu.Consumible.Count; i++)
            {
                
                if (menu.Consumible[i].Nombre == nombreActual && menu.Consumible[i] is Plato plato)
                {

                    plato.TiempoPreparacion = tiempoPreparacion;
                    plato.Productos = productos;
                    plato.Nombre = nombreAModificar;
                    

                }
            }

        }
        public void EliminarPlato(string nombre, Menu menu)
        {
            
            for (int i = 0; i < menu.Consumible.Count; i++)
            {
                
                if (menu.Consumible[i].Nombre == nombre)
                {
                    
                    menu.Consumible.RemoveAt(i);
                   
                }
            }
        }


        public bool CocinarPlato(List<Producto> productosStock, IConsumible pedido)
        {
            

            if (pedido is Plato plato)
            {
                foreach (Producto productoPlato in plato.Productos) 
                { 
                    foreach(Producto productoStock in productosStock)
                        if(productoPlato.Nombre == productoStock.Nombre && productoStock.Cantidad < 2)
                        {
                            return true;
                        }
                }
            }
            if(pedido is Bebida bebida)
            {
                foreach (Producto productoStock in productosStock)
                    if (bebida.Nombre == productoStock.Nombre && productoStock.Cantidad < 1)
                    {
                        return true;
                    }
            }
            return false;
           
        }
    }
}
