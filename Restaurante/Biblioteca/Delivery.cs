namespace Biblioteca
{
    public class Delivery : Empleado
    {
        private List<DeliveryCliente> deliveryCliente;


        public Delivery(string nombre, string apellido, string direccion, string contacto, decimal sueldo, List<DeliveryCliente> deliveryCliente) : base(nombre, apellido, direccion, contacto, sueldo)
        {
            this.DeliveryCliente = deliveryCliente;
        }

        public List<DeliveryCliente> DeliveryCliente { get => deliveryCliente; set => deliveryCliente = value; }


        public IConsumible TomarPedidoDelivery(Menu menu)
        {
            return DeliveryCliente[0].ElegirConsumible(menu);
        }

        public void AgregarALDelivery(IConsumible pedido)
        {

            DeliveryCliente[0].IncorporarPedidoAlaCuenta(pedido);
            
        }

    }
}
