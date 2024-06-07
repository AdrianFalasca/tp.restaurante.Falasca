using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Empleados
{
    public class Empleado
    {
        private string nombre;
        private string apellido;
        private string direccion;
        private string contacto;
        private decimal sueldo;

        public Empleado(string nombre, string apellido, string direccion, string contacto, decimal sueldo)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Direccion = direccion;
            this.Contacto = contacto;
            this.Sueldo = sueldo;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Contacto { get => contacto; set => contacto = value; }
        public decimal Sueldo { get => sueldo; set => sueldo = value; }

        public virtual string DevolverRol()
        {
            return "Roooll";
        }

    }
}
