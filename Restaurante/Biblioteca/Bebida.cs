using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Bebida : Producto, IConsumible
    {

        private string alcohol;

        public Bebida(string nombre, decimal precio, int cantidad, string alcohol) : base(nombre, cantidad, precio)
        {

            Alcohol = alcohol;
        }

        

   
        public string Alcohol { get => alcohol; set => alcohol = value; }

    }
}
