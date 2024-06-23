using Biblioteca;
using System.Collections;
using System.Text;

namespace Vista
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            //Empleados
            Mesero mesero1 = new Mesero("Juan", "Alvarez", "Ministro brin 3323", "juanalvarez@hotmail.com", 600000);
            Mesero mesero2 = new Mesero("Carlos", "Alvarez", "Ministro brin 3323", "juanalvarez@hotmail.com", 600000);
            Mesero mesero3 = new Mesero("Agustín", "Alvarez", "Ministro brin 3323", "juanalvarez@hotmail.com", 600000);
            Encargado encargado1 = new Encargado("Miguel", "Fernandez", "Castro barros 33", "mfernandez@hotmail.com", 1000000);
            Encargado encargado2 = new Encargado("Alberto", "Fernandez", "Castro barros 33", "mfernandez@hotmail.com", 1000000);
            Cocinero cocinero1 = new Cocinero("Cristian", "Dominguez", "25 de mayo 3840", "crisdominguez@hotmail.com", 600000);
            Cocinero cocinero2 = new Cocinero("Andrea", "Dominguez", "25 de mayo 3840", "crisdominguez@hotmail.com", 600000);
            Delivery delivery1 = new Delivery("Juan", "Perez", "Irigoyen 355", "jperez@hotmail.com", 300000);
            Delivery delivery2 = new Delivery("Sebas", "Perez", "Irigoyen 355", "jperez@hotmail.com", 300000);
            Delivery delivery3 = new Delivery("Federico", "Perez", "Irigoyen 355", "jperez@hotmail.com", 300000);

            List<Empleado> empleados = [mesero1, mesero2, mesero3, encargado1, encargado2, cocinero1, cocinero2, delivery1, delivery2, delivery3];

     
            //Productos
            
            
            Bebida bebida1 = new Bebida("coca-cola", 1900, 7, "sin alcohol");
            Bebida bebida2 = new Bebida("Cabernet", 4000, 150, "con alcohol");
            Producto producto1 = new Producto("carne",150, 7000);
            Producto producto2 = new Producto("papa",9, 1000);
            Producto producto3 = new Producto("salsa",2, 1200);
            Producto producto4 = new Producto("ravioles",500, 2000);
            List<Producto> productos = [producto1, producto2, producto3, producto4, bebida1, bebida2];
            
            
            List<Producto> productosPlato = [producto1, producto2];
            
            Plato plato1 = new Plato("Milanesa con puré", [producto1, producto2], "20 minutos", 4000);
            Plato plato2 = new Plato("Ravioles con salsa", [producto3, producto4], "25 minutos", 5000);
            List<IConsumible> productosMenu = [plato1, plato2, bebida1, bebida2];
            Menu menu = new Menu(productosMenu);



            //Proveedores
            ///Luego distingar las lista de prod del provee de la lista de prod del restaurante
            Proveedor proveedor1 = new Proveedor(productos, producto1.Nombre, "a crédito", "Sebastián Gutierrez", "1-654987-22", "del valle iberlucea 323", "Lunes");
            Proveedor proveedor2 = new Proveedor(productos, producto2.Nombre, "efectivo", "Carlos Ferrante", "1-657964-22", "20 de septiembre 41", "Martes");
            Proveedor proveedor3 = new Proveedor(productos, producto3.Nombre, "a crédito", "Sebastián Gutierrez", "1-654987-22", "del valle iberlucea 323", "Lunes");
            Proveedor proveedor4 = new Proveedor(productos, producto4.Nombre, "efectivo", "Carlos Ferrante", "1-657964-22", "20 de septiembre 41", "Martes");
            List<Proveedor> proveedores = [proveedor1, proveedor2, proveedor3, proveedor4];


            //MesaCliente
            List<IConsumible> listaConsumido = [];
            MesaCliente mesacliente1 = new MesaCliente("1", 6, listaConsumido);
            MesaCliente mesacliente2 = new MesaCliente("2", 4, listaConsumido);
            MesaCliente mesacliente3 = new MesaCliente("3", 6, listaConsumido);
            MesaCliente mesacliente4 = new MesaCliente("4", 4, listaConsumido);
            MesaCliente mesacliente5 = new MesaCliente("5", 6, listaConsumido);
            MesaCliente mesacliente6 = new MesaCliente("6", 4, listaConsumido);
            List<MesaCliente> mesaClientes = [mesacliente1, mesacliente2, mesacliente3, mesacliente4, mesacliente5, mesacliente6];

            //DeliveryClient
            DeliveryCliente deliverycliente1 = new DeliveryCliente("1");
            DeliveryCliente deliverycliente2 = new DeliveryCliente("2");
            DeliveryCliente deliverycliente3 = new DeliveryCliente("3");
            DeliveryCliente deliverycliente4 = new DeliveryCliente("4");
            DeliveryCliente deliverycliente5 = new DeliveryCliente("5");
            DeliveryCliente deliverycliente6 = new DeliveryCliente("6");
            List<DeliveryCliente> deliveryClientes = [deliverycliente1, deliverycliente2, deliverycliente3, deliverycliente4, deliverycliente5, deliverycliente6];

            //listaPedidos 
            //List<Pedido> pedidos = new List<Pedido>();


            //Rest
            Restaurante restaurante = new Restaurante(empleados, proveedores, productos, mesaClientes, deliveryClientes, menu, 5000000);

           

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Menu");
            foreach (IConsumible consumible in restaurante.Menu.Consumible)
            {
                sb.AppendLine(consumible.Nombre);
                sb.AppendLine(consumible.Precio.ToString());
            }
            restaurante.CrearYAgregarPlatoAlMenu("Estofado", [producto1, producto2], "45 min", 6000);
            sb.AppendLine("---------------------------------------");

            foreach (IConsumible consumible in restaurante.Menu.Consumible)
            {
                sb.AppendLine(consumible.Nombre);
                sb.AppendLine(consumible.Precio.ToString());
            }
            sb.AppendLine("---------------------------------------");

            restaurante.ModificarPlatoDelMenu("Spaguetti", "Ravioles con salsa", [producto1, producto2], "35 minutos",  restaurante.Menu, 3000);
            foreach (IConsumible consumible in restaurante.Menu.Consumible)
            {
                sb.AppendLine(consumible.Nombre);
                sb.AppendLine(consumible.Precio.ToString());
            }

            sb.AppendLine("---------------------------------------");

            restaurante.EliminarPlatoDelMenu("Cabernet", restaurante.Menu);
            foreach (IConsumible consumible in restaurante.Menu.Consumible)
            {
                sb.AppendLine(consumible.Nombre);
                sb.AppendLine(consumible.Precio.ToString());
            }

            sb.AppendLine("---------------------------------------");

            Console.WriteLine(sb.ToString());

            restaurante.ConsultarStock();
            restaurante.ConsultarStockPorAgotarse();
            restaurante.IngresarProductos();
            restaurante.ConsultarStock();
            restaurante.ConsultarStockPorAgotarse();


        }
    }
}
