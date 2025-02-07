using System.Net.Quic;

namespace C__Projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (Eleje())
            {
                ConsoleKey v = ConsoleKey.A;
                while (v != ConsoleKey.NumPad0 || v != ConsoleKey.D0)
                {
                    v = Menu();
                }
            }

        }

        static bool Eleje()
        {
            Console.WriteLine("Nem ember ege\n Ebben a játékban bolygók közt utazhatsz és szerezhetsz anyagmintát, kb ennyi.");
            Console.WriteLine("\nSzeretnél elindulni? (I/N)");
            ConsoleKey v = Console.ReadKey().Key;
            if (v == ConsoleKey.I)
            {
                return true;
            }
            else
            { 
                return false;
            }
        }

        static ConsoleKey Menu()
        {
            Console.Clear();
            Console.WriteLine("1... Felszállás");
            Console.WriteLine("2... Felöltözés");
            Console.WriteLine("3... Üzemanyagszint ellenőrzés");
            Console.WriteLine("\n0... Mégse");
            ConsoleKey v = Console.ReadKey().Key;
            return v;
        }
    }
}
