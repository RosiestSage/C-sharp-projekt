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
        public int SzuksegesUzemanyag { get; set; }
        public int UzemanyagABolygon { get; set; }
        public Bolygo(double tavolsag, string nev, int szukseges, int uzemanyagabolygon) 
        {
            Tavolsag = tavolsag;
            Nev = nev;
            SzuksegesUzemanyag = szukseges;
            UzemanyagABolygon = uzemanyagabolygon;
        } 
    }
}
