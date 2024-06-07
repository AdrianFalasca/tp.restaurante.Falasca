using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Menu
{
    public class Plato : Menu
    {
        
        private string cantidadIngredientes;
        private string tiempoPreparacion;

        public Plato(string nombre, decimal precio, string cantidadIngredientes, string tiempoPreparacion): base(nombre, precio)
        {
            
            this.CantidadIngredientes = cantidadIngredientes;
            this.TiempoPreparacion = tiempoPreparacion;
        }

        
        public string CantidadIngredientes { get => cantidadIngredientes; set => cantidadIngredientes = value; }
        public string TiempoPreparacion { get => tiempoPreparacion; set => tiempoPreparacion = value; }
    }
}
