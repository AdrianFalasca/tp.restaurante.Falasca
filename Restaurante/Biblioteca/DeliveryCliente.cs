using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class DeliveryCliente
    {

        private string direccion;
        private List<IConsumible> listaDeConsumido;
        private bool cerrada;
        private string medioPago;

        public DeliveryCliente(string direccion, List<IConsumible> consumido, bool cerrada, string medioPago)
        {
            this.Direccion = direccion;
            this.Pedidos = consumido;
            this.Cerrada = cerrada;
            this.MedioPago = medioPago;
        }

        public string Direccion { get => direccion; set => direccion = value; }
        public List<IConsumible> Pedidos { get => listaDeConsumido; set => listaDeConsumido = value; }
        public bool Cerrada { get => cerrada; set => cerrada = value; }
        public string MedioPago { get => medioPago; set => medioPago = value; }

        public void IncorporarPedidoAlaCuenta(IConsumible pedido)
        {
            listaDeConsumido.Add(pedido);
            Restaurante.AgregarDineroDeCaja(pedido.Precio);

        }

        public IConsumible ElegirConsumible(Menu menu)
        {

            
            Random random = new Random();
            int index = random.Next(0, menu.Consumible.Count);
            return menu.Consumible[index];

        }
    }



   

  

    
}
