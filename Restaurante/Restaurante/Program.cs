using Biblioteca;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Vista
{
    public class Program
    {
        static void Main(string[] args)
        {
            //MesaCliente
            List<IConsumible> listaConsumido = [];
            MesaCliente mesacliente1 = new MesaCliente("1", 6, listaConsumido, true, "efectivo");
            MesaCliente mesacliente2 = new MesaCliente("2", 4, listaConsumido, true, "efectivo");
            MesaCliente mesacliente3 = new MesaCliente("3", 6, listaConsumido, true, "tarjeta de crédito");
            MesaCliente mesacliente4 = new MesaCliente("4", 4, listaConsumido, true, "tarjeta de crédito");
            MesaCliente mesacliente5 = new MesaCliente("5", 6, listaConsumido, true, "efectivo");
            MesaCliente mesacliente6 = new MesaCliente("6", 4, listaConsumido, true, "efectivo");
            List<MesaCliente> mesaClientes = [mesacliente1, mesacliente2, mesacliente3, mesacliente4, mesacliente5, mesacliente6];

            //DeliveryClient
            DeliveryCliente deliverycliente1 = new DeliveryCliente("1", listaConsumido, true, "efectivo");
            DeliveryCliente deliverycliente2 = new DeliveryCliente("2", listaConsumido, true, "tarjeta de crédito");
            DeliveryCliente deliverycliente3 = new DeliveryCliente("3", listaConsumido, true, "efectivo");
            DeliveryCliente deliverycliente4 = new DeliveryCliente("4", listaConsumido, true, "tarjeta de crédito");
            DeliveryCliente deliverycliente5 = new DeliveryCliente("5", listaConsumido, true, "efectivo");
            DeliveryCliente deliverycliente6 = new DeliveryCliente("6", listaConsumido, true, "tarjeta de crédito");
            List<DeliveryCliente> deliveryClientes = [deliverycliente1, deliverycliente2, deliverycliente3, deliverycliente4, deliverycliente5, deliverycliente6];


            //Empleados
            Encargado encargado1 = new Encargado("Miguel", "Fernandez", "Castro barros 33", "mfernandez@hotmail.com", 1000000);
            Encargado encargado2 = new Encargado("Alberto", "Fernandez", "Castro barros 33", "mfernandez@hotmail.com", 1000000);
            Mesero mesero1 = new Mesero("Juan", "Alvarez", "Ministro brin 3323", "juanalvarez@hotmail.com", 600000, [mesacliente1, mesacliente2]);
            Mesero mesero2 = new Mesero("Carlos", "Alvarez", "Ministro brin 3323", "juanalvarez@hotmail.com", 600000, [mesacliente3, mesacliente4]);
            Mesero mesero3 = new Mesero("Agustín", "Alvarez", "Ministro brin 3323", "juanalvarez@hotmail.com", 600000, [mesacliente5, mesacliente6]);
            Cocinero cocinero1 = new Cocinero("Cristian", "Dominguez", "25 de mayo 3840", "crisdominguez@hotmail.com", 600000);
            Cocinero cocinero2 = new Cocinero("Andrea", "Dominguez", "25 de mayo 3840", "crisdominguez@hotmail.com", 600000);
            Delivery delivery1 = new Delivery("Juan", "Perez", "Irigoyen 355", "jperez@hotmail.com", 300000, [deliverycliente1, deliverycliente2]);
            Delivery delivery2 = new Delivery("Sebas", "Perez", "Irigoyen 355", "jperez@hotmail.com", 300000, [deliverycliente3, deliverycliente4]);
            Delivery delivery3 = new Delivery("Federico", "Perez", "Irigoyen 355", "jperez@hotmail.com", 300000, [deliverycliente5, deliverycliente6]);

            List<Empleado> empleados = [encargado1, encargado2, cocinero1, cocinero2, mesero1, mesero2, mesero3, delivery1, delivery2, delivery3];

     
            //Productos del stock
            Bebida bebida1 = new Bebida("coca-cola", 1900, 7, "sin alcohol");
            Bebida bebida2 = new Bebida("Cabernet", 4000, 150, "con alcohol");
            Producto producto1 = new Producto("carne",150, 7000);
            Producto producto2 = new Producto("Pollo", 300, 6000);
            Producto producto3 = new Producto("papa",3, 1000);
            Producto producto4 = new Producto("tomate", 9, 1200);
            Producto producto5 = new Producto("cebolla",4 , 1200);
            Producto producto6 = new Producto("pasta",500 , 1000);
            List<Producto> productos = [producto1, producto2, producto3, producto4, producto5, producto6, bebida1, bebida2];
            
            //Productos del menú
            List<Producto> productosPlato1 = [new Producto("carne", 7000), new Producto("papa", 1000)];
            List<Producto> productosPlato2 = [new Producto("pasta", 1000), new Producto("cebolla", 1200)];
            Plato plato1 = new Plato("Milanesa con puré", productosPlato1, "20 minutos", 4000);
            Plato plato2 = new Plato("Ravioles con salsa", productosPlato2, "25 minutos", 5000);
            List<IConsumible> productosMenu = [plato1, plato2, bebida1, bebida2];
            Menu menu = new Menu(productosMenu);



            //Proveedores
            Proveedor proveedor1 = new Proveedor([bebida1, bebida2], "bebidas", "a crédito", "Sebastián Gutierrez", "1-654987-22", "del valle iberlucea 323", "Lunes", 0);
            Proveedor proveedor2 = new Proveedor([producto1, producto2], "carnes", "efectivo", "Carlos Ferrante", "1-657964-22", "20 de septiembre 41", "Martes", 0);
            Proveedor proveedor3 = new Proveedor([producto3, producto4, producto5], "verduras", "a crédito", "Fernando Fernandez", "1-654987-22", "del valle iberlucea 323", "Lunes", 0);
            Proveedor proveedor4 = new Proveedor([producto6], "pastas", "efectivo", "Luz Dominguez", "1-657964-22", "20 de septiembre 41", "Martes", 0);
            List<Proveedor> proveedores = [proveedor1, proveedor2, proveedor3, proveedor4];

            
            //Restaurante
            Restaurante restaurante = new Restaurante(empleados, proveedores, productos, mesaClientes, deliveryClientes, menu);


            StringBuilder sb = new StringBuilder();

            ///////////////Ver Menú //////////////////////
            sb.AppendLine(restaurante.VerMenu());
            Console.WriteLine(sb);
            Console.ReadLine();

            ////////////////////////////ABM platos//////////////////////////////
            sb.AppendLine("Agrega estofado al menú");
            restaurante.CrearPlatoDelMenu("Estofado", [producto1, producto4], "45 min", 6000);
            sb.AppendLine(restaurante.VerMenu());
            Console.WriteLine(sb);
            Console.ReadLine();


            sb.AppendLine("Modificó spaguetti por ravioles");
            restaurante.ModificarPlatoDelMenu("Spaguetti", "Ravioles con salsa", [producto4, producto6], "35 minutos", 3000);
            sb.AppendLine(restaurante.VerMenu());
            Console.WriteLine(sb);
            Console.ReadLine();


            sb.AppendLine("Eliminó Cabernet");
            restaurante.EliminarPlatoDelMenu("Cabernet");
            sb.AppendLine(restaurante.VerMenu());
            Console.WriteLine(sb);
            Console.ReadLine();

            //////////////////Consulta de stock y stock por agotarse////////////////////////
            sb.AppendLine("Consulta de stock y stock por agotarse");
            sb.AppendLine(restaurante.ConsultarStock());
            sb.AppendLine(restaurante.ConsultarStockPorAgotarse());
            
            Console.WriteLine(sb);
            Console.ReadLine();

            ///////////////////Ingresar productos al stock//////////////////////////
            sb.AppendLine("Ingresar productos al stock (bebidas)");
            restaurante.IngresarProductos("bebidas");
            sb.AppendLine(restaurante.ConsultarStock());
            sb.AppendLine(restaurante.ConsultarStockPorAgotarse());
            
            Console.WriteLine(sb);
            Console.ReadLine();


            /////////////////Proceso de asignar plato a la mesa/////////////////////////
            sb.AppendLine("Proceso de asignar plato a la mesa");
            if (restaurante.DescontarStockAlAsignarPlatoALaMesa())
            {
                sb.AppendLine("No pudo hacer el pedido por falta de stock");
                
            }
            sb.AppendLine("Consultar stock luego de asignar plato a la mesa.");
            sb.AppendLine(restaurante.ConsultarStock());
            
            Console.WriteLine(sb);
            Console.ReadLine();

            ///////////////////Proceso de asignar plato al delivery///////////////////////////////
            sb.AppendLine("Proceso de asignar plato al delivery");
            if (restaurante.DescontarStockAlAsignarPlatoALDelivery())
            {
                sb.AppendLine("No pudo hacer el pedido por falta de stock"); 
            }
            sb.AppendLine("Consultar stock luego de asignar plato al delivery.");
            sb.AppendLine(restaurante.ConsultarStock());
            
            Console.WriteLine(sb);
            Console.ReadLine();

            ///////////Consulta platos disponibles/////////////////
            sb.AppendLine("Consulta platos disponibles");
            sb.AppendLine(restaurante.ConsultarPlatosDisponibles());
            
            Console.WriteLine(sb);
            Console.ReadLine();


            ///Consultar plato por producto//////////////
            sb.AppendLine("Consultar plato por producto");
            sb.AppendLine(restaurante.ConsultarPlatosConUnProducto(producto1));
            
            Console.WriteLine(sb);
            Console.ReadLine();

            ////////////////pagar a los empleados//////////////////////
            sb.AppendLine("pagar a los empleados");
            sb.AppendLine(restaurante.PagarEmpleados());
            
            Console.WriteLine(sb);
            Console.ReadLine();

            //////////////pago a proveedores////////////////////////
            sb.AppendLine("pago a proveedores");
            sb.AppendLine(restaurante.ConsultarPagadoAProveedores());
            restaurante.IngresarProductos("pastas");
            sb.AppendLine(restaurante.ConsultarPagadoAProveedores());
            sb.AppendLine("--------------------------------------");
            
            Console.WriteLine(sb);
            Console.ReadLine();


            //////////////////Consumo total////////////////////
            sb.AppendLine("Consumo total de mesas y deliverys cerradas:");
            sb.AppendLine(restaurante.ConsultarConsumoTotalMesasYDeliverysCerradas());
            sb.AppendLine("--------------------------------------");
            Console.WriteLine(sb);
            Console.ReadLine();

            ///////////////////Consumo delivery cerradas//////////////////
            sb.AppendLine("Consumo total de deliverys cerradas:");
            sb.AppendLine(restaurante.CalcularConsumoTotalDeliverys().ToString());
            sb.AppendLine("--------------------------------------");
            Console.WriteLine(sb);
            Console.ReadLine();

            /////////////////Consumo mesas cerradas///////////////////////
            sb.AppendLine("Consumo total de mesas cerradas:");
            sb.AppendLine(restaurante.CalcularConsumoTotalMesas().ToString());
            sb.AppendLine("--------------------------------------");
            Console.WriteLine(sb);
            Console.ReadLine();

            ////////////////Consumo total no pago(mesas abiertas todavía)//////////////
            sb.AppendLine("Consumo total no pago:");
            sb.AppendLine(restaurante.ConsultarConsumoTotalMesasYDeliverysAbiertas());
            sb.AppendLine("--------------------------------------");
            Console.WriteLine(sb);
            Console.ReadLine();

            ///////////////Consumo por medio de pago///////////
            sb.AppendLine("Consumo en efectivo:");
            sb.AppendLine(restaurante.ConsumoTotalPorMedioDePago("efectivo"));
            Console.WriteLine(sb);
            Console.ReadLine();

            sb.AppendLine("Consumo con tarjeta de credito:");
            sb.AppendLine(restaurante.ConsumoTotalPorMedioDePago("tarjeta de crédito"));
            sb.AppendLine("--------------------------------------");
            Console.WriteLine(sb);
            Console.ReadLine();

            //////////////////Top 3 de ventas //////////////////////


            Console.WriteLine(sb);


        }
    }
}
