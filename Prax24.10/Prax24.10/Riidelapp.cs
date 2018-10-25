namespace Prax24._10
{
    /// <summary>
    /// Koosta klass riidelapi andmete hoidmiseks: pikkus, laius, toon
    /// </summary>
    class Riidelapp
    {
        public double Pikkus { get; }
        public double Laius { get; }
        public string Toon { get; }

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

        /// <summary>
        /// Koosta riidelapi klassile staatiline käsklus näitamaks loodud riidelappide keskmist pindala.
        /// Lappide puudumisel väärtuseks -1. Lisa vajalikud staatilised muutujad (lappide arv, kogupindala)
        /// </summary>
        /// <param name="pikkus"></param>
        /// <param name="laius"></param>
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