using System.Net.Quic;

namespace C__Projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (Eleje())
            {
                int v = -1;
                while (v != 0)
                {
                    v = Menu();
                }
            } 

        }

        static bool Eleje()
        {
            Console.WriteLine("Nem ember ege\n Ebben a játékban bolygók közt utazhatsz és szerezhetsz anyagmintát, kb ennyi.");
            Console.WriteLine("\nSzeretnél elindulni? (I/N)");
            ConsoleKey v = Console.ReadKey(true).Key;
            if (v == ConsoleKey.I)
            {
                return true;
            }
            else
            { 
                return false;
            }
        }

        static int Menu()
        {
            Console.Clear();
            Console.WriteLine("1... Felszállás");
            Console.WriteLine("2... Felöltözés");
            Console.WriteLine("3... Üzemanyagszint ellenőrzés");
            Console.WriteLine("\n0... Mégse");
            char v = Console.ReadKey(true).KeyChar;
            
            return v - '0';
        }
    }
}
