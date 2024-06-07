using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Menu
{
    public class Bebida : Menu
    {
        
        private string alcohol;

        public Bebida(string nombre, decimal precio, string alcohol) : base(nombre, precio)
        {
            
            this.Alcohol = alcohol;
        }

        
        public string Alcohol { get => alcohol; set => alcohol = value; }
    }
}
