using System;
using System.Collections.Generic;
using System.Text;

namespace Prax24._10
{
    class Riidelapp
    {
        public double Pikkus { get; set; }
        public double Laius { get; set; }
        public string Toon { get; set; }

        private static double KeskminePindala { get; set; }
        private static int LappideCount { get; set; }
        private static double LappidePindala { get; set; }

        public Riidelapp(double pikkus, double laius, string toon)
        {
            Pikkus = pikkus;
            Laius = laius;
            Toon = toon;
            LappideKeskminePindala(pikkus, laius);
        }

        public override string ToString()
        {
            return $"[Pikkus: {Pikkus}, Laius: {Laius}, Toon: {Toon}]";
        }

        private static void LappideKeskminePindala(double pikkus, double laius)
        {
            LappideCount++;
            LappidePindala += pikkus * laius;
            KeskminePindala = LappidePindala / LappideCount;
        }

        public static double GetKeskminePindala()
        {
            return KeskminePindala;
        }
    }
}