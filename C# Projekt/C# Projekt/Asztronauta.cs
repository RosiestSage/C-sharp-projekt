using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Projekt
{
    public class Asztronauta : Urhajo 
    {
        public int OxigenSzint { get; set; }
        public bool Ruha { get; set; }

        public Asztronauta()
        {
            Ruha = false;
        }
        
        
        public int Anyaggyujtes(Bolygo bolygo)
        {

            Keszlet += bolygo.UzemanyagABolygon;
            if (Keszlet > 100)
            {
                Keszlet -= Keszlet - 100;
            }
            return Keszlet;
        }

        public bool Feloltezes()
        {
            OxigenSzint = 100;
            Ruha = true;
            return true;
        }
    }
}
