namespace HomeworkRJ
{
    /// <summary>
    /// Koosta klass riidelapi andmete hoidmiseks: pikkus, laius, toon
    /// </summary>
    class Riidelapp
    {
        public double Pikkus { get; set; }
        public double Laius { get; set; }
        public string Varvus { get; set; }

        /// <summary>
        /// Lisa käsklus lapi andmete väljatrükiks
        /// </summary>
        /// <returns>riidelapi andmed</returns>
        public override string ToString()
        {
            return $"[Pikkus: {Pikkus}, Laius: {Laius}, Varvus: {Varvus}]";
        }

        /// <summary>
        /// Lisa meetod (alamprogramm) lapi poolitamiseks: pikem külg tehakse poole lühemaks.
        /// </summary>
        public void PoolitaLapp()
        {
            if (Laius > Pikkus)
                Laius /= 2;
            else
                Pikkus /= 2;
        }

        /// <summary>
        /// Poolitamise meetod lisaks algse lapi poolitamisele väljastab ka uue samasuguse algsest poole väiksema eksemplari.
        /// </summary>
        /// <returns>poolitatud riidelapp</returns>
        public Riidelapp PoolitatudUusRiidelapp()
        {
            PoolitaLapp();
            Riidelapp riidelapp = new Riidelapp();
            riidelapp.Pikkus = Pikkus;
            riidelapp.Laius = Laius;
            riidelapp.Varvus = Varvus;
            return riidelapp;
        }

        /// <summary>
        /// Lisa teine poolitusmeetod, kus saab määrata, mitme protsendi peale lõigatakse pikem külg
        /// </summary>
        /// <param name="protsent">protsent, mille peale loigata</param>
        public void PoolitaLappProtsentuaalselt(double protsent)
        {
            if (Laius > Pikkus)
                Laius = protsent / 100 * Laius;
            else
                Pikkus = protsent / 100 * Pikkus;
        }
    }
}