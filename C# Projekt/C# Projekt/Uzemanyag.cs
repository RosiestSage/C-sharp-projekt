
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace C__Projekt
{
    public class Uzemanyag
    {
        public int Mennyiseg {  get; set; }
        public int Keszlet { get; set; }
        public void Tankolas(int tankolas)
        {
            if (tankolas > Keszlet)
            {
                throw new Exception("Nincs ennyi készleten! ");
            }
            for (int i = 0; i < tankolas; i++)
            {
                if (Mennyiseg < 100)
                {
                    Console.SetCursorPosition(20, 0);
                    Mennyiseg++;
                    Console.Write($"{Mennyiseg}% ");
                    System.Threading.Thread.Sleep(100);
                }
            }
                Keszlet -= tankolas;

        }

        public bool Joertek(int tankolas)
        {
            if (tankolas > Keszlet || tankolas < 0)
            {
                return false;

            }
            else
            {
                return true;
            }
            
        }



    }
}
