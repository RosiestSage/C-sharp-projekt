using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Projekt
{
    public class Urhajo : Uzemanyag
    {
        private Uzemanyag uzemanyagszint = new Uzemanyag();
        public Uzemanyag Uzemanyagszint { 
            get => uzemanyagszint; 
            set
            {
                if (value.Mennyiseg < 0 || value.Mennyiseg > 80) {
                    throw new Exception("Az üzemanyagszint max 100 hektoliteres és nem lehet minuszba tölteni");
                }
            }
        }
        public Bolygo JelenlegiBolygo { get; set; }
        public List<Bolygo> Celpontok {  get; set; }


        public bool Elindule()
        {
            if (Uzemanyagszint.Mennyiseg < 50)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Felszallas()
        {
            Console.WriteLine("");
        }

        public void Utazas()
        {
            Console.WriteLine("");
        }

        public void PalyaraAllas()
        {
            Console.WriteLine("");
        }

        public void Leszallas()
        {
            Console.WriteLine("");
        }


    }
}
