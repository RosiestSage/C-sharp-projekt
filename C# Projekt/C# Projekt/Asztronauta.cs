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
        


        
        public void Anyaggyujtes()
        {

        }

        public bool Feloltezes()
        {
            OxigenSzint = 100;
            Ruha = true;
            return true;
        }
    }
}
