using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Producto
    {
        private string nombre;
        private int cantidad;
        private decimal precio;

        

        public Producto(string nombre, int cantidad, decimal precio) 
        {
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal Precio { get => precio; set => precio = value; }
    }
}
