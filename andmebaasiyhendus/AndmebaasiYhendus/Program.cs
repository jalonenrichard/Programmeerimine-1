using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AndmebaasiYhendus
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> peopleList = new List<string>();
            string constr = "Data Source=localhost;" +
                            "Initial Catalog=Proovibaas; " +
                            "Integrated Security=SSPI; Persist Security Info=True";
            string lause = "SELECT Eesnimi, Perenimi, Isikukood FROM Inimesed";
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = constr;
            cn.Open();
            SqlCommand cm = new SqlCommand(lause, cn);
            SqlDataReader reader = cm.ExecuteReader();
            while (reader.Read())
            {
                peopleList.Add($"{reader.GetValue(0)}, {reader.GetString(1)}, {reader.GetString(2)}");
            }

            cn.Close();

            foreach (var person in peopleList)
            {
                Console.WriteLine(person);
            }

            Console.ReadKey();
        }
    }
}