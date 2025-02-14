using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Projekt
{
    public class Bolygo
    {
        public string Nev {  get; set; }
        public double Tavolsag { get; set; }
        public Bolygo(double tavolsag, string nev) 
        {
            Tavolsag = tavolsag;
            Nev = nev;
        } 
    }
}
