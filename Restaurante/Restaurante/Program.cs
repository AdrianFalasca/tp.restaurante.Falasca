using Biblioteca.Empleados;
using Biblioteca.Cliente;
using Biblioteca.Menu;
using Biblioteca.Inventario;
using System.Text;

namespace Restaurante
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Empleados
            Mesero mesero1 = new Mesero("Juan", "Alvarez", "Ministro brin 3323", "juanalvarez@hotmail.com", 600000);
            Encargado encargado1 = new Encargado("Miguel", "Fernandez", "Castro barros 33", "mfernandez@hotmail.com", 1000000);
            Cocinero cocinero1 = new Cocinero("Cristian", "Dominguez", "25 de mayo 3840", "crisdominguez@hotmail.com", 600000);
            Delivery delivery1 = new Delivery("Juan", "Perez", "Irigoyen 355", "jperez@hotmail.com", 300000);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Empleados:");
            sb.AppendLine(mesero1.Nombre);
            sb.AppendLine(mesero1.DevolverRol());
            sb.AppendLine(encargado1.Nombre);
            sb.AppendLine(encargado1.DevolverRol());
            sb.AppendLine(cocinero1.Nombre);
            sb.AppendLine(cocinero1.DevolverRol());
            sb.AppendLine(delivery1.Nombre);
            sb.AppendLine(delivery1.DevolverRol());
            sb.AppendLine("---------------------------------------");
            
            //Menú
            Bebida bebida1 = new Bebida("coca-cola", 2000, "sin alcohol");
            Bebida bebida2 = new Bebida("Cabernet", 2000, "con alcohol");
            Plato plato1 = new Plato("Milanesa con puré", 3000, "2", "20 minutos");
            Plato plato2 = new Plato("Ravioles con salsa", 3000, "3", "25 minutos");

            sb.AppendLine("Menú:");
            sb.AppendLine(bebida1.Nombre);
            sb.AppendLine(bebida2.Nombre);
            sb.AppendLine(plato1.Nombre);
            sb.AppendLine(plato2.Nombre);
            sb.AppendLine("---------------------------------------");

            //Productos en el inventario
            Producto producto1 = new Producto("papa", 100, 1000);
            Producto producto2 = new Producto("cuadril", 150, 5000);

            //Proveedores
            Proveedor proveedor1 = new Proveedor(producto1.Nombre, "tarjeta de crédito", "Sebastián Gutierrez", "1-654987-22", "del valle iberlucea 323", "Lunes");
            Proveedor proveedor2 = new Proveedor(producto2.Nombre, "efectivo", "Carlos Ferrante", "1-657964-22", "20 de septiembre 41", "Martes");

            sb.AppendLine("Productos en el inventario:");
            sb.AppendLine(producto1.Nombre);
            sb.AppendLine(producto2.Nombre);
            sb.AppendLine("---------------------------------------");
            sb.AppendLine("Proveedores:");
            sb.AppendLine(proveedor1.Nombre);
            sb.AppendLine(proveedor2.Nombre);
            sb.AppendLine("---------------------------------------");

            //Mesa
            MesaCliente mesacliente1 = new MesaCliente("15", 6);
            MesaCliente mesacliente2 = new MesaCliente("14", 4);

            sb.AppendLine("Mesas:");
            sb.AppendLine(mesacliente1.Nui);
            sb.AppendLine(mesacliente2.Nui);
            sb.AppendLine("---------------------------------------");

            Console.WriteLine(sb.ToString());
        }
    }
}
