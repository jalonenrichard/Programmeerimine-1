using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ball
{
    public partial class BallForm : Form
    {
        bool paused = false; // palli liikumise status, kas seisab või liigub
        int scrW = Screen.PrimaryScreen.WorkingArea.Width; // ekraani lajus
        int scrH = Screen.PrimaryScreen.WorkingArea.Height; // ekraani kõrgus
        double moveX = 0.0; // horisontaal kiirus
        double moveY = 0.0; // vertikaal kiirus
        double X = 0.0; // palli Horisontal koordinat
        double Y = 0.0; // palli Vertikal koordinaal
        double gravity = 0.1; // "maa külgetõmbejõud"
        Color col; // palli värv  
        Random rand; // lokaalse juhuarvu objekt
        int Diameter; // palli diameeter
        private int algDiameeter; // palli algne diameeter
        private bool miinimumSuurus = false;

        // Palli konstruktor
        public BallForm(int rnd)
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            rand = new Random(rnd); // lokaalse juhuarvu genereerimis objekti
            col = Color.FromArgb(rand.Next(16, 240), rand.Next(16, 240),
                rand.Next(16, 240)); // genereerime juhuskiku värvi
            Diameter = rand.Next(30, 100); // genereerime juhuskiku diametri
            algDiameeter = Diameter;
            scrW = Screen.PrimaryScreen.WorkingArea.Width; // saame kätte ja määrame ekraani lajuse
            scrH = Screen.PrimaryScreen.WorkingArea.Height; // saame kätte ja määrame ekraani kõrguse
            moveX = rand.NextDouble(); // genereerime juhuskiku palli horisontaal kiiruse
            moveY = rand.NextDouble(); // genereerime juhuskiku palli vertikaal kiiruse
            // ekraani X=0 ja Y=0 koordinaat asub üleval vasakus servas
            X = rand.NextDouble() * scrW; // genereerime juhuskiku palli algseisu X koordinaadi
            Y = rand.NextDouble() * scrH; // genereerime juhuskiku palli algseisu Y koordinaadi
        }

        private void BallForm_Paint(object sender, PaintEventArgs e)
        {
            Width = Height = Diameter; // määrame kanti lajuse ja kõrguse kuhu me joonistame palli
            Graphics g = e.Graphics; // Loome graafilise objekti 
            g.Clear(Color.Cyan); // puhastave palli kanti
            g.FillPie(new SolidBrush(col), 0, 0, Width - 1, Height - 1, 0,
                360); // Joonistame ringi täites palli jaoks genereeritud värviga
            g.DrawArc(new Pen(Color.Black, 2), 0, 0, Width - 1, Height - 1, 0,
                360); // Joonistame musta värvi ringi serva
        }

        public void Tick()
        {
            if (!paused && !moving)
            {
                moveY -= gravity; // muudame vertikaalset kiirust gravitatsiooni koefitsiendi võrra

                X += moveX; // liigutame horisontaalselt palli
                Y += moveY; // liigutame vertikaalselt palli
                Location = new Point((int) X, (int) Y); // määrame palli asukoha täisarv koordinaatidega

                if (Diameter == 30)
                {
                    miinimumSuurus = true;
                }

                //Vähenda palli suurust kui see just ei ole miinimum
                if (Diameter > 30 && !miinimumSuurus)
                {
                    Diameter--;
                    Width = Height = Diameter;
                    this.Refresh();
                    if (Diameter == 30)
                    {
                        miinimumSuurus = true;
                    }
                }

                //Suurenda pall algsuurusele kui on jõudnud miinimumini
                if (Diameter < algDiameeter && miinimumSuurus)
                {
                    Diameter++;
                    Width = Height = Diameter;
                    this.Refresh();
                    if (Diameter == algDiameeter)
                    {
                        miinimumSuurus = false;
                    }
                }

                //Check Collision
                if (X < 0) // kui läks vasakust äärest üle
                {
                    X = 0; // Tõmbame palli ekraani piiridesse tagasi
                    moveX = -moveX; // muudame horisontaal liikumis suunda vastupidiseks
                    moveX *= 0.75; // vähendame horisontaal liikumis kiirust 
                    moveY *= 0.95; // vähendame vertikaal liikumis kiirust 
                }

                if (X > Screen.PrimaryScreen.WorkingArea.Width - 1 - Width
                ) // kui läks paremast äärest üle, arvestades palli diameetrit
                {
                    X = Screen.PrimaryScreen.WorkingArea.Width - 1 - Width; // Tõmbame palli ekraani piiridesse tagasi
                    moveX = -moveX; // muudame horisontaal liikumis suunda vastupidiseks
                    moveX *= 0.75; // vähendame horisontaal liikumis kiirust 
                    moveY *= 0.95; // vähendame vertikaal liikumis kiirust 
                }

                if (Y < 0) // kui läks ülemisest äärest üle
                {
                    Y = 0; // Tõmbame palli ekraani piiridesse tagasi
                    moveY = -moveY; // muudame horisontaal liikumis suunda vastupidiseks
                    moveY *= 0.75; // vähendame horisontaal liikumis kiirust 
                    moveX *= 0.95; // vähendame vertikaal liikumis kiirust 
                }

                if (Y > Screen.PrimaryScreen.WorkingArea.Height - 1 - Height
                ) // kui läks alumisest äärest üle, arvestades palli diameetrit
                {
                    Y = Screen.PrimaryScreen.WorkingArea.Height - 1 - Height; // Tõmbame palli ekraani piiridesse tagasi
                    moveY = -moveY; // muudame horisontaal liikumis suunda vastupidiseks
                    moveY *= 0.8; // vähendame horisontaal liikumis kiirust 
                    moveX *= 0.95; // vähendame vertikaal liikumis kiirust 
                }

                // kui 
                // palli Horisontaal ja vertikaal kiirused on väiksed
                // ja aeg sekundites ei oma 3-ga jagamisel jääki
                // ja pall on ekraani alumisest servast mitte kõrgemal kui määratud kõrgus
                if (Math.Abs(moveX) < 0.1 && Math.Abs(moveY) < 0.5 && DateTime.Now.Second % 3 == 0 &&
                    Y < Screen.PrimaryScreen.WorkingArea.Height - 1 - 40)
                {
                    Bounce(); // anname pallile uue liikumise suuna ja kiiruse
                }
            }
        }

        bool moving = false;
        Point rel = new Point();

        private void BallForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Capture = false;
                moving = false;
            }
        }

        private void BallForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                rel = e.Location;
                Capture = true;
                moving = true;
            }
        }

        private void BallForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                X = Cursor.Position.X - rel.X;
                Y = Cursor.Position.Y - rel.Y;

                moveX += (X - Location.X) / 2;
                moveY += (Y - Location.Y) / 2;

                if (moveX > 2)
                    moveX = 2;
                if (moveY > 2)
                    moveY = 2;

                if (paused)
                {
                    moveX = 0;
                    moveY = 0;
                }

                Location = new Point((int) X, (int) Y);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Environment.Exit(0);
        }

        private void pauseToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            paused = pauseToolStripMenuItem.Checked;
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moveX = 0;
            moveY = 0;
        }

        private void bounceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bounce();
        }

        public void Bounce() // anname pallile uue liikumise suuna ja kiiruse
        {
            moveX = (rand.NextDouble() + rand.NextDouble()) - 1;
            moveY = -(rand.NextDouble());
            moveX *= 50;
            moveY *= 50;
            X += moveX;
            Y += moveY;
        }
    }
}