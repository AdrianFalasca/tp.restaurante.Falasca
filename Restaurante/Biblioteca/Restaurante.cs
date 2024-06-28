
using System.Text;



public enum SueldoEmpleado
{
    Encargado = 1000000,
    Cocinero = 800000,
    Mesero = 600000,
    Delivery = 300000
}

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
        private static decimal caja = 5000000;
        private IConsumible pedido;


        public Restaurante(List<Empleado> empleados, List<Proveedor> proveedores, List<Producto> productos, List<MesaCliente> mesasCliente, List<DeliveryCliente> deliveryCliente, Menu menu)
        {
            this.Empleados = empleados;
            this.Proveedores = proveedores;
            this.Productos = productos;
            this.MesasCliente = mesasCliente;
            this.DeliveryCliente = deliveryCliente;
            this.Menu = menu;
            
            
            
        }

        public List<Empleado> Empleados { get => empleados; set => empleados = value; }
        public List<Proveedor> Proveedores { get => proveedores; set => proveedores = value; }
        public List<Producto> Productos { get => productos; set => productos = value; }
        public List<MesaCliente> MesasCliente { get => mesasCliente; set => mesasCliente = value; }
        public List<DeliveryCliente> DeliveryCliente { get => deliveryCliente; set => deliveryCliente = value; }
        public Menu Menu { get => menu; set => menu = value; }
        public decimal Caja { get => caja; set => caja = value; }
        public IConsumible Pedido { get => pedido; set => pedido = value; }

        

        public static void AgregarDineroDeCaja(decimal cantidad)
        {
            caja += cantidad;
        }

        public static void RetirarDineroDeCaja(decimal cantidad)
        {
            
            caja -= cantidad;
            
        }


        public void CrearPlatoDelMenu(string nombre, List<Producto> productos, string tiempoPreparacion, decimal precio)
        {

            foreach (var empleado in Empleados)
            {
                if (empleado is Cocinero cocinero)
                {
                    cocinero.CrearPlato(nombre, productos, tiempoPreparacion, Menu);
                    break;
                }
            }

            LlamarPonerPrecioPlato(nombre, precio);

        }


        private void LlamarPonerPrecioPlato(string nombre, decimal precio)
        {
            foreach (var empleado in Empleados)
            {
                if (empleado is Encargado encargado)
                {
                    encargado.PonerPrecioPlato(nombre, precio, Menu);
                    break;
                }
            }
        }

        public void ModificarPlatoDelMenu(string nombreNuevo, string nombreActual, List<Producto> productos, string tiempoPreparacion, decimal precio)
        {

            foreach (var empleado in Empleados)
            {
                if (empleado is Cocinero cocinero)
                {
                    cocinero.ModificarPlato(nombreNuevo, nombreActual,  productos, tiempoPreparacion, Menu);
                    break;
                }
            }

            LlamarPonerPrecioPlato(nombreNuevo, precio);
  
        }



        public void EliminarPlatoDelMenu(string nombre)
        {
            foreach (var empleado in Empleados)
            {
                if (empleado is Cocinero cocinero)
                {
                    cocinero.EliminarPlato(nombre, Menu);
                    break;
                }
            }

        }

        public string VerMenu()
        {
            StringBuilder sb = new StringBuilder(); 
            sb.AppendLine("Menu");
            sb.AppendLine("----------");
            foreach (IConsumible consumible in Menu.Consumible)
            {
                sb.Append(consumible.Nombre);
                sb.AppendLine($"  ${consumible.Precio.ToString()}");
            }

            sb.AppendLine("---------------------------------------");
            return sb.ToString();
        }

        
        
        public bool DescontarStockAlAsignarPlatoALaMesa()
        {
            TomarPedidoPorMesero();

            if (TomarPedidoPorCocinero())
            {
                return CancelarPedido();
            }
            else
            {
                AgregarPedidoALaMesa();
                EgresarProductos();
                return false;
            }
        
        }

        public bool DescontarStockAlAsignarPlatoALDelivery()
        {
            TomarPedidoPorDelivery();

            if (TomarPedidoPorCocinero())
            {
                return CancelarPedido();
            }
            else
            {
                AgregarPedidoALDelivery();
                EgresarProductos();
                return false;
            }

        }

        private void EgresarProductos()
        {

            if (Pedido is Plato plato)
            {
                foreach (Producto productoPlato in plato.Productos)
                {
                    foreach (Producto productoStock in Productos)
                        if (productoPlato.Nombre == productoStock.Nombre)
                        {
                            productoStock.Cantidad -= 1;
                        }
                }
            }
            if (Pedido is Bebida bebida)
            {
                foreach (Producto productoStock in Productos)
                    if (bebida.Nombre == productoStock.Nombre)
                    {
                        productoStock.Cantidad -= 1;
                    }
            }
        }
        private void TomarPedidoPorMesero()
        {
            foreach (Empleado empleado in Empleados)
            {
                if (empleado is Mesero mesero)
                {
                    Pedido = mesero.TomarPedidoMesero(Menu);
                    break;
                }
            }
        }

        private void TomarPedidoPorDelivery()
        {
            foreach (Empleado empleado in Empleados)
            {
                if (empleado is Delivery delivery)
                {
                    Pedido = delivery.TomarPedidoDelivery(Menu);
                    break;
                }
            }
        }

        private bool TomarPedidoPorCocinero()
        {
            foreach (Empleado empleado in Empleados)
            {
                if (empleado is Cocinero cocinero)
                {
                    return cocinero.CocinarPlato(productos, Pedido);//no hay productos 
               
                }
            }
            return false;
        }
        private bool CancelarPedido()
        {
            foreach (Empleado empleado in Empleados)
            {
                if (empleado is Encargado encargado)
                {
                    return encargado.CancelarPedido();
                    
                }
            }
            return false;
        }

        private void AgregarPedidoALaMesa()
        {
            foreach (Empleado empleado in Empleados)
            {
                if (empleado is Mesero mesero)
                {
                    
                    mesero.AgregarALaMesa(Pedido);
                    break;
                }
            }
        }

        private void AgregarPedidoALDelivery()
        {
            foreach (Empleado empleado in Empleados)
            {
                if (empleado is Delivery delivery)
                {

                    delivery.AgregarALDelivery(Pedido);
                    break;
                }
            }
        }

        

        public string ConsultarStock()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Stock");
            foreach (Producto producto in Productos)
            {
                sb.AppendLine($"Nombre:{producto.Nombre}");
                sb.AppendLine($"Cantidad: {producto.Cantidad.ToString()}");
                sb.AppendLine($"Precio: {producto.Precio.ToString()}");
                sb.AppendLine("--------------------------------------");
                
            }
            return sb.ToString();


        }

        public string ConsultarStockPorAgotarse()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Stock por agotarse (menor a 10 unidades)");
            foreach (Producto producto in Productos)
            {
                if (producto.Cantidad < 10)
                {

                    sb.AppendLine($"Nombre:{producto.Nombre}");
                    sb.AppendLine($"Cantidad: {producto.Cantidad.ToString()}");
                    sb.AppendLine($"Precio: {producto.Precio.ToString()}");
                    sb.AppendLine("--------------------------------------");
                    
                }
                
            }         
            return sb.ToString();

        }

        public void IngresarProductos(string tipoProducto)
        {
            
            foreach (Producto producto in Productos)
            {
                if (producto.Cantidad < 1000)
                {
                    foreach (Empleado empleado in Empleados)
                    {
                        if (empleado is Encargado encargado)
                        {
                            encargado.PedirProductosAProveedores(tipoProducto, producto.Nombre, Proveedores, Productos);
                         
                        }
                    }
                }
       
            }

        }

        public string ConsultarPagadoAProveedores()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Consulta de lo que se pagó a cada proveedor");
            foreach (Proveedor proveedor in Proveedores)
            {
                sb.AppendLine($"Nombre:{proveedor.Nombre}");
                sb.AppendLine($"Pago: {proveedor.Pago.ToString()}");
                sb.AppendLine("--------------------------------------");

            }
            return sb.ToString();


        }

        public string ConsultarPlatosDisponibles()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Platos disponibles: ");
            

            foreach (var consumible in Menu.Consumible)
            {
                bool platoDisponible = true;
                if (consumible is Plato plato)
                {
                    foreach (Producto productoPlato in plato.Productos)
                    {
                        foreach (Producto productoStock in Productos)
                            if (productoPlato.Nombre == productoStock.Nombre && productoStock.Cantidad < 3)
                            {
                                platoDisponible = false;
                                break;
                            }

                        if(platoDisponible == false)
                        {
                            break;
                        }

                    }
                    if(platoDisponible == true)
                    {
                        sb.AppendLine($"Nombre:{consumible.Nombre}");
                    }
                }

            }
            sb.AppendLine("--------------------------------------");
            return sb.ToString();
        }
            
        

        public string ConsultarPlatosConUnProducto(Producto producto)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Platos con {producto.Nombre}: ");


            foreach (var consumible in Menu.Consumible)
            {
                
                if (consumible is Plato plato)
                {
                    
                    foreach (Producto productoPlato in plato.Productos)
                    {
                        if (producto.Nombre == productoPlato.Nombre)
                        {
                            sb.AppendLine($"Nombre:{consumible.Nombre}");
                            break;
                        }
                        
                    }
                       
                }

            }
            sb.AppendLine("--------------------------------------");
            return sb.ToString();
        }


        public string PagarEmpleados()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Empleados que cobraron:");
            Queue<Empleado> colaEmpleados = new Queue<Empleado>(empleados);
  
            while (colaEmpleados.Count > 0)
            {
                Empleado empleado = colaEmpleados.Dequeue(); 
                
                    decimal sueldo = CalcularSueldo(empleado);

                    if (caja > sueldo)
                    {
                        empleado.Sueldo += sueldo;
                        RetirarDineroDeCaja(sueldo);
                        sb.AppendLine($"{empleado.GetType().Name}: {empleado.Nombre}, sueldo: {sueldo}");
                    }
                    else
                    {
                        sb.AppendLine("No se pudieron pagar todos los sueldos");
                        return sb.ToString();
                    }

                    

            }
            sb.AppendLine("Se pagaron todos los sueldos");
            return sb.ToString();
        }
        private decimal CalcularSueldo(Empleado empleado)
        {
            if (empleado is Encargado)
                return (decimal)SueldoEmpleado.Encargado;
            else if (empleado is Cocinero)
                return (decimal)SueldoEmpleado.Cocinero;
            else if (empleado is Mesero)
                return (decimal)SueldoEmpleado.Mesero;
            else if (empleado is Delivery)
                return (decimal)SueldoEmpleado.Delivery;

            return 0; 
        }

        //*******************************************************************************
        public string ConsultarConsumoTotalMesasYDeliverysCerradas()
        {
            decimal totalConsumo = 0;

            totalConsumo += CalcularConsumoTotalDeliverys();
            totalConsumo += CalcularConsumoTotalMesas();

            return totalConsumo.ToString();
        }

        public decimal CalcularConsumoTotalDeliverys()
        {
            decimal totalConsumoDeliverys = 0;

            foreach (DeliveryCliente delivery in deliveryCliente)
            {
                totalConsumoDeliverys += CalcularConsumoDelivery(delivery);
            }

            return totalConsumoDeliverys;
        }

        public decimal CalcularConsumoTotalMesas()
        {
            decimal totalConsumoMesas = 0;

            foreach (MesaCliente mesa in mesasCliente)
            {
                totalConsumoMesas += CalcularConsumoMesa(mesa);
            }

            return totalConsumoMesas;
        }

        
        private decimal CalcularConsumoMesa(MesaCliente mesa)
        {
            decimal consumoMesa = 0;

            foreach (IConsumible consumible in mesa.Pedidos)
            {
                consumoMesa += consumible.Precio;
            }

            return consumoMesa;
        }

        private decimal CalcularConsumoDelivery(DeliveryCliente delivery)
        {
            decimal consumoDelivery = 0;

            foreach (IConsumible consumible in delivery.Pedidos)
            {
                consumoDelivery += consumible.Precio;
            }

            return consumoDelivery;
        }

        private void AbrirMesaYDelivery()
        {
            foreach (Empleado empleado in Empleados)
            {
                if (empleado is Delivery delivery)
                {

                    foreach (DeliveryCliente deliveryCliente in deliveryCliente)
                    {
                        deliveryCliente.Cerrada = false;
                        
                        //deliveryCliente.Pedidos = [];
                    }
                }
            }
            foreach (Empleado empleado in Empleados)
            {
                if (empleado is Mesero mesero)
                {

                    foreach (MesaCliente mesaCliente in mesasCliente)
                    {
                        mesaCliente.Cerrada = false;
                        //mesaCliente.Pedidos = [];
                    }
                }
            }
        }
        public string ConsultarConsumoTotalMesasYDeliverysAbiertas()
        {
            AbrirMesaYDelivery();
            decimal totalConsumo = 0;
            
            
            foreach (MesaCliente mesa in mesasCliente)
            {
                if (!mesa.Cerrada)
                {
                    totalConsumo += CalcularConsumoMesa(mesa);
                }
            }

            
            foreach (DeliveryCliente delivery in deliveryCliente)
            {
                if (!delivery.Cerrada)
                {
                    totalConsumo += CalcularConsumoDelivery(delivery);
                }
            }

            return totalConsumo.ToString();
        }

        public string ConsumoTotalPorMedioDePago(string medioDePago)
        {
            decimal totalConsumo = 0;

            
            foreach (MesaCliente mesa in mesasCliente)
            {
                if (mesa.MedioPago == medioDePago)
                {
                    totalConsumo += CalcularConsumoMesa(mesa);
                }
            }

            
            foreach (DeliveryCliente delivery in deliveryCliente)
            {
                if (delivery.MedioPago == medioDePago)
                {
                    totalConsumo += CalcularConsumoDelivery(delivery);
                }
            }

            return totalConsumo.ToString();
        }

        public void CalcularTop3Ventas()
        {

        }

    }






}
