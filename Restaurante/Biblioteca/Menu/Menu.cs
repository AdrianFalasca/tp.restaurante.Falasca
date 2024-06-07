namespace Biblioteca.Menu
{
    public class Menu
    {
        private string nombre;
        private decimal precio;

        public Menu(string nombre, decimal precio)
        {
            this.Nombre = nombre;
            this.Precio = precio;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public decimal Precio { get => precio; set => precio = value; }
    }
}
