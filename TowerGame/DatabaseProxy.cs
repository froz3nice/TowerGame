using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame
{
    class DatabaseProxy : Proxy
    {
        public double getDatabaseResponse(SqlConnection connection, int value)
        {
            Database db = new Database();
            return db.getDatabaseResponse(connection,value);
        }
    }

}
