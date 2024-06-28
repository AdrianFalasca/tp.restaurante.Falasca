using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Proveedor
    {
        private List<Producto> productos;
        private string tipoProducto;
        private string medioDePago;
        private string nombre;
        private string cuit;
        private string direccion;
        private string diaDeEntrega;
        private decimal pago;

        public Proveedor(List<Producto> productos, string tipoProducto, string medioDePago, string nombre, string cuit, string direccion, string diaDeEntrega, decimal pago)
        {
            this.Productos = productos;
            this.TipoProducto = tipoProducto;
            this.MedioDePago = medioDePago;
            this.Nombre = nombre;
            this.Cuit = cuit;
            this.Direccion = direccion;
            this.DiaDeEntrega = diaDeEntrega;
            this.pago = pago;
        }

        public List<Producto> Productos { get => productos; set => productos = value; }
        public string TipoProducto { get => tipoProducto; set => tipoProducto = value; }
        public string MedioDePago { get => medioDePago; set => medioDePago = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Cuit { get => cuit; set => cuit = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string DiaDeEntrega { get => diaDeEntrega; set => diaDeEntrega = value; }

        public decimal Pago { get => pago; set => pago = value; }
    }
}
