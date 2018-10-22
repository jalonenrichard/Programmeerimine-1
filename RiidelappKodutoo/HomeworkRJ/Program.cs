using System;

namespace HomeworkRJ
{
    class Program
    {
        static void Main(string[] args)
        {
            Riidelapp riidelapp = new Riidelapp();
            riidelapp.Laius = 25;
            riidelapp.Pikkus = 20;
            riidelapp.Varvus = "sinine";

            Console.WriteLine(riidelapp);
            Console.WriteLine($"Pindala: {ArvutaPindala(riidelapp)}");
            riidelapp.PoolitaLapp();
            Console.WriteLine($"Poolitatud lapp: {riidelapp}");
            Console.WriteLine($"Uus poolitatud lapp: {riidelapp.PoolitatudUusRiidelapp()}");
            riidelapp.PoolitaLappProtsentuaalselt(75);
            Console.WriteLine($"75% lapp: {riidelapp}");
            Console.ReadKey();
        }

        /// <summary>
        /// Lisa käsklus lapi pindala arvutamiseks
        /// </summary>
        /// <param name="riidelapp">riidelapp, mida poolitada</param>
        /// <returns>riidelapi pindala</returns>
        private static double ArvutaPindala(Riidelapp riidelapp)
        {
            return riidelapp.Laius * riidelapp.Pikkus;
        }
    }
}