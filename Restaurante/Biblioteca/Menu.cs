using System.Collections;

namespace Biblioteca
{
    public class Menu 
    {
        private List<IConsumible> consumible;

        public Menu(List<IConsumible> consumible)
        {
            this.Consumible = consumible;
        }

        public List<IConsumible> Consumible { get => consumible; set => consumible = value; }

        public void IncorporarAlMenu(IConsumible productosConsumibles)
        {
            Consumible.Add(productosConsumibles);
        }
    }
}
