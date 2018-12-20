using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame
{
    public interface Proxy
    {
        double getDatabaseResponse(SqlConnection connection,int value);
    }
}
