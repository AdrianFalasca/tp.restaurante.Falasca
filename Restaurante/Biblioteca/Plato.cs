using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Plato: IConsumible
    {

        private string nombre;
        
        private decimal precio;

        private List<Producto> productos;
        //private string cantidadIngredientes;
        private string tiempoPreparacion;
        

        public Plato(string nombre, List<Producto> productos, string tiempoPreparacion, decimal precio) 
        {
            this.Nombre = nombre;
            this.Precio = precio;
            this.Productos = productos;
            this.TiempoPreparacion = tiempoPreparacion;
            
        }

        public List<Producto> Productos { get => productos; set => productos = value; }
        public string TiempoPreparacion { get => tiempoPreparacion; set => tiempoPreparacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal Precio { get => precio; set => precio = value; }
    }
}
