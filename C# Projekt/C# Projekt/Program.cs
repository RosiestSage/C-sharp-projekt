using System.Net.Quic;

namespace C__Projekt
{
    internal class Program
    {
            static Urhajo urhajo = new Urhajo();
            static Asztronauta urhajos = new Asztronauta();
        static void Main(string[] args)
        {
            urhajo.JelenlegiBolygo = new Bolygo(0, "Föld");
            urhajo.Uzemanyagszint.Keszlet = 50;

            urhajos.Ruha = false;


            try
            {
                urhajo.Uzemanyagszint.Mennyiseg = 30;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }




            if (Eleje())
            {
                int v = -1;
                while (v != 0)
                {
                    v = Menu();
                    switch (v)
                    { 
                        case 1:
                            if (urhajos.Feloltezes() == true && urhajo.Uzemanyagszint.Mennyiseg > 50)
                            {

                            }
                            else if (urhajo.Uzemanyagszint.Mennyiseg < 50)
                            {
                                Console.Clear();
                                Console.WriteLine("Alacsony üzemanyag szint!");
                                Console.ReadKey(true);

                            }
                            else if(urhajos.Ruha == false)
                            {
                                Console.Clear();
                                Console.WriteLine("Nincs rajtad űrruha!");
                                Console.ReadKey(true);
                            }
                            break;
                        case 2:
                            Feloltozes();
                            break;
                        case 3:
                            Uzemanyagfeltöltes();
                            break;
                    }
                    //char x = Console.ReadKey(true).KeyChar;
                    //v = x - '0';
                }
            } 

        }

        static bool Eleje()
        {
            Console.Clear();
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

        static void Uzemanyagfeltöltes()
        {
            if (urhajo.Elindule() == true)
            {
                Console.Clear();
                Console.WriteLine("Van elég üzemanyag, elindulhat (ENTER)");
                Console.ReadKey(true);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("KEVÉS ÜZEMANYAG\n"
                    + $"Jelenlegi üzemanyag szint: {urhajo.Uzemanyagszint.Mennyiseg}\n"
                    + $"Betöltésre kész üzemanyag: {urhajo.Uzemanyagszint.Keszlet}");
                Console.Write("Mennyit szeretne bele tölteni? ");
                int uzemanyag = -1;
                while (urhajo.Uzemanyagszint.Joertek(uzemanyag) == false)
                {
                    try
                    {

                        uzemanyag = int.Parse(Console.ReadLine()!);
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("KEVÉS ÜZEMANYAG\n"
                            + $"Jelenlegi üzemanyag szint: {urhajo.Uzemanyagszint.Mennyiseg}\n"
                            + $"Betöltésre kész üzemanyag: {urhajo.Uzemanyagszint.Keszlet}");
                        Console.Write("Mennyit szeretne bele tölteni? ");
                    }
                }
                try
                {
                    urhajo.Uzemanyagszint.Tankolas(uzemanyag);
                }
                catch (Exception ex)
                { 
                    Console.WriteLine(ex.Message);
                }
                Console.Clear();

                Console.WriteLine("Sikeres feltöltés");
                Console.ReadKey(true);
            }

            
        }

        static void Feloltozes()
        {
            if (urhajos.Ruha == false)
            {
                Console.Clear();
                Console.WriteLine("Felveszi az űrruhát?(I/N)");
                ConsoleKey v = Console.ReadKey(true).Key;
                if (v == ConsoleKey.I)
                {
                    urhajos.Feloltezes();
                }
            }
        }
    
    }
}
