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
                                Bolygo hely = new Bolygo(0, "", 0, 0);
                                while (hely.Nev != "Föld")
                                {
                                    hely = UrMenu();
                                    try
                                    {
                                        urhajo.Utazas(hely);
                                        if (hely.Nev != "Föld")
                                            hely = MasikBolygo(hely);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                        if (urhajo.Uzemanyagszint.Keszlet > 0)
                                        {
                                            Uzemanyagfeltöltes();
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Statisztika();
                                            Piros();

                                            Console.WriteLine("Nem tudsz eljutni");
                                            Eredetiszin();

                                            System.Threading.Thread.Sleep(1000);

                                        }
                                    }
                                }
                                if (hely.Nev == "Föld")
                                {

                                    Console.Clear();
                                    Kek();
                                    FelszallasAnimacio("Vissza utazás a Földre ");
                                    Eredetiszin();

                                    Console.WriteLine("Véget ért a kaland!");
                                    Console.ReadLine();
                                    v = 0;
                                    break;
                                }
                            }
                            else if (urhajo.Uzemanyagszint.Mennyiseg < 50)
                            {
                                Console.Clear();
                                Piros();
                                Console.WriteLine("Alacsony üzemanyag szint!");
                                Eredetiszin();
                                System.Threading.Thread.Sleep(1000);


                            }
                            else if(urhajos.Ruha == false)
                            {

                                Console.Clear();
                                Piros();

                                Console.WriteLine("Nincs rajtad űrruha!");
                                Eredetiszin();

                                System.Threading.Thread.Sleep(1000);

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
            Kek();

            Console.WriteLine("Nem ember ege");
            Eredetiszin();

            Console.WriteLine(" Ebben a játékban bolygók közt utazhatsz és szerezhetsz anyagmintát, viszont ha visszatérsz a földre akkor vége a játéknak, kb ennyi.");
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
            Kek();

            Console.SetCursorPosition(0, 0);
            Console.Write($"Oxigénszint: {urhajos.OxigenSzint}");
            Console.SetCursorPosition(40, 0);
            Console.Write($"Üzemanyagszint: {urhajo.Uzemanyagszint.Mennyiseg}\n");
            Console.SetCursorPosition(0, 1);
            Console.Write($"Jelenlegi tartózkodás: {urhajo.JelenlegiBolygo.Nev}");
            Console.SetCursorPosition(40, 1);
            Console.Write($"Üzemanyag készlet: {urhajo.Uzemanyagszint.Keszlet}\n");
            Console.WriteLine("----------------------------------------------------------------");
            for (int i = 0; i < 2; i++)
            {
                Console.SetCursorPosition(63, i);
                Console.Write("|");
            }
            Console.SetCursorPosition(0, 3);
            Console.WriteLine();
            Eredetiszin();

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
            if (urhajo.JelenlegiBolygo.SzuksegesUzemanyag > urhajo.Uzemanyagszint.Mennyiseg && urhajo.Uzemanyagszint.Keszlet == 0)
            {
                Console.Clear();
                Piros();
                Console.WriteLine("Nincs elég üzemanyag");
                System.Threading.Thread.Sleep(1000);
                Eredetiszin();


            }
            if (urhajo.Elindule() == true)
            {
                Zold();

                Console.Clear();
                Console.WriteLine("Van elég üzemanyag, elindulhatsz");
                System.Threading.Thread.Sleep(1000);
                Eredetiszin();


            }
            else
            {
                Tankolas();
            }
            if (urhajo.JelenlegiBolygo.SzuksegesUzemanyag > urhajo.Uzemanyagszint.Mennyiseg)
            {
                Tankolas();
            }

            
        }

        static void Tankolas()
        {
            Console.Clear();
            Piros();
            Console.WriteLine("KEVÉS ÜZEMANYAG\n");
            Eredetiszin();
            Console.WriteLine($"Jelenlegi üzemanyag szint: {urhajo.Uzemanyagszint.Mennyiseg}\n"
                + $"Betöltésre kész üzemanyag: {urhajo.Uzemanyagszint.Keszlet}");
            Console.Write("Mennyit szeretne bele tölteni? ");
            int uzemanyag = -1;
            while (urhajo.Uzemanyagszint.Joertek(uzemanyag) == false)
            {
                
                try
                {
                    uzemanyag = int.Parse(Console.ReadLine()!);
                    if (uzemanyag > urhajo.Uzemanyagszint.Keszlet)
                    {
                        Console.Clear();
                        Console.WriteLine("Nincs ennyi üzemanyagod");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        Piros();
                        Console.WriteLine("KEVÉS ÜZEMANYAG\n");
                        Eredetiszin();
                        Console.WriteLine($"Jelenlegi üzemanyag szint: {urhajo.Uzemanyagszint.Mennyiseg}\n"
                            + $"Betöltésre kész üzemanyag: {urhajo.Uzemanyagszint.Keszlet}");
                        Console.Write("Mennyit szeretne bele tölteni? ");
                    }
                }
                catch
                {
                    Console.Clear();
                    Piros();
                    Console.WriteLine("KEVÉS ÜZEMANYAG\n");
                    Eredetiszin();
                    Console.WriteLine($"Jelenlegi üzemanyag szint: {urhajo.Uzemanyagszint.Mennyiseg}\n"
                        + $"Betöltésre kész üzemanyag: {urhajo.Uzemanyagszint.Keszlet}");
                    Console.Write("Mennyit szeretne bele tölteni? ");
                }
            }


            try
            {
                Kek();
                Console.Clear();
                Console.Write("Töltöttségi szint: ");
                urhajo.Uzemanyagszint.Tankolas(uzemanyag);
                Console.SetCursorPosition(0, 0);
                Eredetiszin();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                System.Threading.Thread.Sleep(1000);

            }
            Console.Clear();
            Zold();
            Console.WriteLine("Sikeres feltöltés");
            System.Threading.Thread.Sleep(1000);
            Eredetiszin();
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
                    Zold();

                    Console.WriteLine("Sikeres felöltözés");
                    Eredetiszin();

                    System.Threading.Thread.Sleep(1000);

                }
            }
            else
            {
                Console.Clear();
                Piros();

                Console.WriteLine("Már felöltöztél!");
                Eredetiszin();

                System.Threading.Thread.Sleep(1500);

            }
        }
    
        static void Felszallas()
        {
            Kek();

            FelszallasAnimacio("Felszállás az űrbe ");
            Eredetiszin();

            Zold();
            Console.WriteLine("Sikeres felszállás!");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Kinn vagy az űrben");
            System.Threading.Thread.Sleep(1000);
            Eredetiszin();

            urhajo.Uzemanyagszint.Mennyiseg -= urhajo.Bolygok[5].SzuksegesUzemanyag;
            urhajo.JelenlegiBolygo = urhajo.Bolygok[5];

        }

        static Bolygo UrMenu()
        {
            urhajo.Bolygok[6].Tavolsag = 1.05;
            urhajo.JelenlegiBolygo = urhajo.Bolygok[5];
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
                Console.WriteLine($"6... Vissza a Földre({urhajo.Bolygok[6].Tavolsag * 1000000} km)\n");
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


        static Bolygo MasikBolygo(Bolygo bolygo)
        {
            Kek();
            FelszallasAnimacio("Utazás ");
            Eredetiszin();
            urhajo.JelenlegiBolygo = bolygo;
            Statisztika();
            Console.WriteLine($"Üdvözöllek a {bolygo.Nev} nevű bolygón!");
            Console.WriteLine("1... Anyag kutatás");
            Console.WriteLine("2... Vissza az űrbe");
            char v = Console.ReadKey(true).KeyChar;

            int k = v - '0';
            switch (k)
            {
                case 1:
                    Kek();
                    FelszallasAnimacio("Anyag kutatás ");
                    Eredetiszin();
                    urhajo.Uzemanyagszint.Keszlet = urhajos.Anyaggyujtes(bolygo);
                    Statisztika();

                    Zold();
                    Console.WriteLine("Sikeres anyag kutatás");
                    Eredetiszin();
                    Console.WriteLine($"\nGazdagabb lettél {urhajo.JelenlegiBolygo.UzemanyagABolygon} üzemanyaggal");
                    System.Threading.Thread.Sleep(3000);


                    Kek();
                    Console.WriteLine("Visszatérés az űrbe");
                    Eredetiszin();

                    System.Threading.Thread.Sleep(1000);
                    break;
            }
            try
            {
                urhajo.Utazas(urhajo.Bolygok[5]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Uzemanyagfeltöltes();
            }

            Felszallas();

            return urhajo.Bolygok[5];


        }

        static void FelszallasAnimacio(string tevekenyseg)
        {
            Console.Clear();
            Console.Write(tevekenyseg);
            for (int i = 0; i < 5; i++)
            {
                Console.Write("-");
                System.Threading.Thread.Sleep(1000);
            }
            Console.Clear();

        }

        static void Kek()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        static void Piros()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        static void Zold()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        static void Eredetiszin()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
