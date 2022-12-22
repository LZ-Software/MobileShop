using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShopDesktop
{
    class DBUtils
    {
        public static string role = "";
        public static string password = "";

        public static NpgsqlConnection GetDBConnection()
        {
            NpgsqlConnection connection = DBServerUtils.GetDBConnection(role, password);
            connection.Open();

            return connection;
        }
    }
}
