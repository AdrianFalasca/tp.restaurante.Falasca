using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class MesaCliente
    {
        private string nui;
        private int capacidad;
        private List<IConsumible> listaDeConsumido;
        //un estado acá que sea abierto/cerrado
        //ver los enum

        public MesaCliente(string nui, int capacidad, List<IConsumible> consumido)//la lista si está vacia no hace falta poner el contructor
        {
            this.Nui = nui;
            this.Capacidad = capacidad;
            this.listaDeConsumido = consumido;
        }

        public string Nui { get => nui; set => nui = value; }
        public int Capacidad { get => capacidad; set => capacidad = value; }
        public List<IConsumible> Pedidos { get => listaDeConsumido; set => listaDeConsumido = value; }

        public void IncorporarPedidoAlaMesa(IConsumible pedido)
        {
            listaDeConsumido.Add(pedido);
        }

        public void ElegirConsumible()
        {

        }

    }
}
