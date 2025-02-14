using System.Net.Quic;

namespace C__Projekt
{
    internal class Program
    {
            static Urhajo urhajo = new Urhajo();
            static Asztronauta urhajos = new Asztronauta();
        static void Main(string[] args)
        {
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
                            if (urhajos.Ruha == true && urhajo.Uzemanyagszint.Mennyiseg >= 50)
                            {
                                Felszallas();
                                UrMenu();
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

        static void Statisztika()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write($"Oxigénszint: {urhajos.OxigenSzint}");
            Console.SetCursorPosition(30, 0);
            Console.Write($"Üzemanyagszint: {urhajo.Uzemanyagszint.Mennyiseg}\n");
            Console.SetCursorPosition(0, 1);
            Console.Write($"Jelenlegi tartózkodás: {urhajo.JelenlegiBolygo.Nev}");
            Console.SetCursorPosition(30, 1);
            Console.Write($"Üzemanyag készlet: {urhajo.Uzemanyagszint.Keszlet}\n");
            Console.WriteLine("------------------------------------------------------");
            for (int i = 0; i < 2; i++)
            {
                Console.SetCursorPosition(53, i);
                Console.Write("|");
            }
            Console.SetCursorPosition(0, 3);
            Console.WriteLine();
        }


        static int Menu()
        {
            Console.Clear();
            Statisztika();
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
                    Console.Clear();
                    Console.WriteLine("Sikeres felöltözés");
                    Console.ReadKey(true);

                }
            }
        }
    
        static void Felszallas()
        {
            Console.Clear();
            for (int i = 0; i < 5; i++)
            {
                Console.Write("-");
                System.Threading.Thread.Sleep(1000);
            }
            Console.Clear();
            Console.WriteLine("Sikeres felszállás!");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Kinn vagy az űrben");
            System.Threading.Thread.Sleep(1000);
        }

        static Bolygo UrMenu()
        {
            urhajo.Bolygok[6].Tavolsag = 1.05;
            urhajo.JelenlegiBolygo = urhajo.Bolygok[6];
            List<int> elfogadhato = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };
            int bolgyo = -1;
            while (!elfogadhato.Contains(bolgyo))
            {
                Console.Clear();
                Statisztika();
                Console.WriteLine("Hova tova?");
                Console.WriteLine($"1... Mars({urhajo.Bolygok[0].Tavolsag * 1000000} km)");
                Console.WriteLine($"2... QS-138({urhajo.Bolygok[1].Tavolsag * 1000000} km)");
                Console.WriteLine($"3... Vánusz({urhajo.Bolygok[2].Tavolsag * 1000000} km)");
                Console.WriteLine($"4... Jewpiter({urhajo.Bolygok[3].Tavolsag * 1000000} km)");
                Console.WriteLine($"5... XH-967({urhajo.Bolygok[4].Tavolsag * 1000000} km)\n");
                Console.WriteLine($"6... XH-967({urhajo.Bolygok[6].Tavolsag * 1000000} km)\n");
                char v = Console.ReadKey(true).KeyChar;
                bolgyo = v - '0';
            
            }


            switch (bolgyo)
            {
                case 1:
                    return urhajo.Bolygok[0];
                case 2:
                    return urhajo.Bolygok[1];
                case 3:
                    return urhajo.Bolygok[2];
                case 4:
                    return urhajo.Bolygok[3];
                case 5:
                    return urhajo.Bolygok[4];
                case 6:
                    return urhajo.Bolygok[6];
            }
            return urhajo.Bolygok[5];
        }

    }
}
