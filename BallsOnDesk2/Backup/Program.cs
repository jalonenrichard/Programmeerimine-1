using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Ball
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BallForm f = new BallForm();
            f.Show();
            
            while (true)
            {
                f.Tick();
                Application.DoEvents();
                Thread.Sleep(10);
            }
        }
    }
}
