using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Empleados
{
    public class Encargado : Empleado
    {
        public Encargado(string nombre, string apellido, string direccion, string contacto, decimal sueldo) : base(nombre, apellido, direccion, contacto, sueldo)
        {
        }

        public override string DevolverRol()
        {
            return "Soy el encargado";
        }
    }
}
