using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PSB
{
    class petrikkq
    {
        public int sqlcb(string a, string connectionString)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command1 = new SqlCommand(a, connection);
                SqlDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    Decimal Word1 = Convert.ToDecimal(reader1.GetValue(0));
                    id = Convert.ToInt32(Word1) - 1;
                }
                reader1.Close();
            }
            return id;
        }
    }
}
