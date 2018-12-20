using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame
{
    class Database : Proxy
    {
        public Database()
        {  
        }
        public double getDatabaseResponse(SqlConnection connection, int value)
        {
            string sql = "SELECT * from blocks where username = 'name'";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetInt32(1));
                        return reader.GetInt32(1);
                    }
                    return 0;
                }
            }
        }
    }
}
