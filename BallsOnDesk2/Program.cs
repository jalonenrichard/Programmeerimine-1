using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Ball
{
    public static class Program
    {   
        // NB!! Programmi peatamiseks tuleb hiire kursoriga tabada üks pallidest ja vajutada paremale hiire nuppule
        // menüüst valida "close"

        public static void Main(string[] args)
        {   int ballcount = 5;                             // pallidee arv 
            Random rnd= new Random(Environment.TickCount); // loome programmi jaoks ühtse juhuarvu generaatori
            BallForm[] balls = new BallForm[ballcount];    // loome pall objektide massiivi 

            for (int i = 0; i < ballcount; i++) { balls[i] = new BallForm(rnd.Next()); } // Loome pallid ja paneme nad massiivi
            foreach (BallForm b in balls) { b.Bounce(); }  // Lükkame iga palli juhuslikus suunas ja juhusliku kiirusega
            foreach (BallForm b in balls) { b.Show(); }    // Lubame näidata igat palli ekraanil
            while (true)                                   // Pallide liikumise tsükkel
            {
                foreach (BallForm b in balls) b.Tick();    // Arvutame ümber iga palli koordinaati ja kiirust masiivis
                Application.DoEvents();                    // Toimetave ekraanile muudatused
                Thread.Sleep(10);                          // Jääme magama 10 millisekundiks
            }
        }
    }
}
