using System;
using System.Collections.Generic;

namespace Prax24._10
{
    enum Toonid
    {
        Punane,
        Sinine,
        Kollane,
        Roheline,
        Oranz,
        Must,
        Valge
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Riidelapp> riidelapid = TekitaRiidelappideList();

            foreach (var riidelapp in riidelapid)
            {
                Console.WriteLine(riidelapp.ToString());
            }

            Console.WriteLine("\n----------------\n");

            Console.WriteLine($"Lappide kogupindala: {ArvutaLappidePindalaSumma(riidelapid)}");
            Console.WriteLine($"Lappide keskmine pindala: {Riidelapp.GetKeskminePindala()}");

            Console.ReadKey();
        }

        /// <summary>
        /// Koosta riidelappidest massiiv.
        /// </summary>
        /// <returns></returns>
        private static List<Riidelapp> TekitaRiidelappideList()
        {
            List<Riidelapp> riidelapid = new List<Riidelapp>();
            Random rnd = new Random();
            Array values = Enum.GetValues(typeof(Toonid));
            for (int i = 0; i < 99; i++)
            {
                Riidelapp riidelapp = new Riidelapp(rnd.Next(99), rnd.Next(99),
                    values.GetValue(rnd.Next(values.Length)).ToString());
                riidelapid.Add(riidelapp);
            }

            return riidelapid;
        }

        /// <summary>
        /// Arvuta mõlema massiivi puhul välja seal leiduvate lappide pindalade summa
        /// </summary>
        /// <param name="riidelapid"></param>
        /// <returns></returns>
        private static double ArvutaLappidePindalaSumma(List<Riidelapp> riidelapid)
        {
            double koguPindala = 0;
            foreach (var riidelapp in riidelapid)
            {
                koguPindala += ArvutaLapiPindala(riidelapp);
            }

            return koguPindala;
        }

        private static double ArvutaLapiPindala(Riidelapp riidelapp)
        {
            return riidelapp.Laius * riidelapp.Pikkus;
        }
    }
}