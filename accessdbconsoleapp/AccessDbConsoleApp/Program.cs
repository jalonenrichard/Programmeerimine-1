using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessDbConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string constr = "Driver={Microsoft Access Driver (*.mdb)}; " +
                            "DBQ=kauplused.mdb; " +
                            "Trusted_Connection=yes";
            string lause = "SELECT Kauplus FROM Kauplused WHERE Kauplus LIKE '%SELVER%'";
            OdbcConnection cn = new OdbcConnection(constr);
            cn.Open();
            OdbcCommand cm = new OdbcCommand(lause, cn);
            OdbcDataReader reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
            }

            cn.Close();
            Console.ReadKey();
        }
    }
}