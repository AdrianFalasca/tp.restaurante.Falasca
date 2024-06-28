using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class MesaCliente
    {
        private string nui;
        private int capacidad;
        private List<IConsumible> listaDeConsumido;
        private bool cerrada;
        private string medioPago;


        public MesaCliente(string nui, int capacidad, List<IConsumible> consumido, bool cerrada, string medioPago)//la lista si está vacia no hace falta poner el contructor
        {
            this.Nui = nui;
            this.Capacidad = capacidad;
            this.listaDeConsumido = consumido;
            this.cerrada = cerrada;
            this.MedioPago = medioPago;
        }

        public string Nui { get => nui; set => nui = value; }
        public int Capacidad { get => capacidad; set => capacidad = value; }
        public List<IConsumible> Pedidos { get => listaDeConsumido; set => listaDeConsumido = value; }
        public bool Cerrada { get => cerrada; set => cerrada = value; }
        public string MedioPago { get => medioPago; set => medioPago = value; }

        public void IncorporarPedidoAlaCuenta(IConsumible pedido)
        {
            listaDeConsumido.Add(pedido);
            Restaurante.AgregarDineroDeCaja(pedido.Precio);

        }

        public IConsumible ElegirConsumible(Menu menu)//cambiarlo por una lista y usar hilos
        {
            
            Random random = new Random();
            int index = random.Next(0, menu.Consumible.Count);
            return menu.Consumible[index];


        }

    }
}
