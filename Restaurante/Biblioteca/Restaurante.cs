using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Biblioteca
{
    public class Restaurante
    {
        private List<Empleado> empleados;
        private List<Proveedor> proveedores;
        private List<Producto> productos;
        private List<MesaCliente> mesasCliente;
        private List<DeliveryCliente> deliveryCliente;
        private Menu menu;
        private decimal caja;
        



        IConsumible plato;//revisar

      
        

        public Restaurante(List<Empleado> empleados, List<Proveedor> proveedores, List<Producto> productos, List<MesaCliente> mesasCliente, List<DeliveryCliente> deliveryCliente, Menu menu, decimal caja)
        {
            this.Empleados = empleados;
            this.Proveedores = proveedores;
            this.Productos = productos;
            this.MesasCliente = mesasCliente;
            this.DeliveryCliente = deliveryCliente;
            this.Menu = menu;
            this.Caja = caja;
            
        }

        public List<Empleado> Empleados { get => empleados; set => empleados = value; }
        public List<Proveedor> Proveedores { get => proveedores; set => proveedores = value; }
        public List<Producto> Productos { get => productos; set => productos = value; }
        public List<MesaCliente> MesasCliente { get => mesasCliente; set => mesasCliente = value; }
        public List<DeliveryCliente> DeliveryCliente { get => deliveryCliente; set => deliveryCliente = value; }
        public Menu Menu { get => menu; set => menu = value; }
        public decimal Caja { get => caja; set => caja = value; }
        


        public void CrearYAgregarPlatoAlMenu(string nombre, List<Producto> productos, string tiempoPreparacion, decimal precio)
        {
            
            
            foreach (var empleado in Empleados)
            {
                if (empleado is Cocinero cocinero)
                {
                    plato = cocinero.CrearPlato(nombre, productos, tiempoPreparacion) ;
                    break ;
                }
            }

            foreach (var empleado in Empleados)
            {
                if (empleado is Encargado encargado)
                {
                    encargado.PonerPrecioPlato(precio, plato);
                    break;
                }
            }
            menu.IncorporarAlMenu(plato);
           
        }

        public void ModificarPlatoDelMenu(string nombreNuevo, string nombreActual, List<Producto> productos, string tiempoPreparacion, Menu menu, decimal precio)
        {


            foreach (var empleado in Empleados)
            {
                if (empleado is Cocinero cocinero)
                {
                    cocinero.ModificarPlato(nombreNuevo, nombreActual,  productos, tiempoPreparacion, menu);
                    break;
                }
            }

            foreach (var empleado in Empleados)
            {
                if (empleado is Encargado encargado)
                {
                    encargado.PonerPrecioPlato(nombreNuevo, precio, menu);
                    break;
                }
            }
            

        }

        public void EliminarPlatoDelMenu(string nombre, Menu menu)
        {
            foreach (var empleado in Empleados)
            {
                if (empleado is Cocinero cocinero)
                {
                    cocinero.EliminarPlato(nombre, menu);
                    break;
                }
            }

        }

        public void HojearMenu()
        {
            
        }

        public void AsignarPlatoALaMesa()
        {
            bool bandera = false;
            foreach (Empleado empleado in Empleados)//solucionar el tema de la asignacion de mesas por mesero
            {
                if (empleado is Mesero mesero)
                {
                    mesero.TomarPedido();
                    break;
                }
            }
            foreach (Empleado empleado in Empleados)
            {
                if (empleado is Cocinero cocinero)
                {
                    bandera = cocinero.CocinarPlato();
                    break;
                }
            }

            if (bandera)//no hay productos en la validacion
                foreach (Empleado empleado in Empleados)
                {
                    if (empleado is Encargado encargado)
                    {
                        encargado.CancelarPedido();
                        break;
                    }
                }
            else//hay productos 
            {
                foreach (Empleado empleado in Empleados)
                {
                    if (empleado is Mesero mesero)
                    {
                        mesero.AgregarPedidoALaMesa();
                        mesero.DescontarProductos();
                        break;
                    }
                }
            }
            
            
        }

        /////////////////////////////Stock ////////////////////////
        public void ConsultarStock()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Stock");
            foreach (Producto producto in Productos)
            {
                sb.AppendLine(producto.Nombre);
                sb.AppendLine(producto.Cantidad.ToString());
                sb.AppendLine(producto.Precio.ToString());//lo debería imprimir en el program?
                sb.AppendLine("--------------------------------------");
                
            }
            Console.WriteLine(sb.ToString());


        }

        public List<Producto> ConsultarStockPorAgotarse()
        {
            List<Producto> lista = new List<Producto>();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Stock por agotarse");
            foreach (Producto producto in Productos)
            {
                if (producto.Cantidad < 10)
                {
                    lista.Add(producto);
                    sb.AppendLine(producto.Nombre);
                    sb.AppendLine(producto.Cantidad.ToString());
                    sb.AppendLine(producto.Precio.ToString());//lo debería imprimir en el program?
                    sb.AppendLine("--------------------------------------");
                    
                }
                
            }
            Console.WriteLine(sb.ToString());
            
            return lista;
            


        }

        public void IngresarProductos()
        {
            List<Producto> lista = ConsultarStockPorAgotarse();
            foreach (Producto producto in lista)
            {
                
                foreach (Empleado empleado in Empleados)
                {
                    if (empleado is Encargado encargado)
                    {
                        encargado.PedirProductosAProveedores(producto.Nombre, Proveedores, Productos);
                        break;
                    }
                }
            }
                    
                
            
            
            

        }




    }
}
