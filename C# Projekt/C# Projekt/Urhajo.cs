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
        public List<Bolygo> Bolygok {  get; set; }


        public  Urhajo()
        {
            Keszlet = 0;
            Bolygok = [
                
                new Bolygo(1.189, "Mars", 20, 30),
                new Bolygo(7.987, "QS-138", 60, 40),
                new Bolygo(3.552, "Vánusz", 40, 40),
                new Bolygo(5.324, "Jewpiter", 50, 50),
                new Bolygo(8.167, "XH-967", 70, 20),

                new Bolygo(0, "Űr", 20, 0),
                new Bolygo(0, "Föld", 30, 100),
                ];
            JelenlegiBolygo = Bolygok[6];
            }



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
    /*
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
    */

    }
}
