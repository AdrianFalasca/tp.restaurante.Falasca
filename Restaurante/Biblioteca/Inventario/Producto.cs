using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Inventario
{
    public class Producto
    {
        private string nombre;
        private int cantidad;
        private decimal precio;

        public Producto(string nombre, int cantidad, decimal precio)
        {
            this.Nombre = nombre;
            this.Cantidad = cantidad;
            this.Precio = precio;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal Precio { get => precio; set => precio = value; }
    }
}
