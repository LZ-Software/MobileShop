using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShopDesktop
{
    class DBServerUtils
    {
        public static NpgsqlConnection GetDBConnection(string username, string password)
        {
            string connString = $"Host=194.87.146.57;Username={username};Password={password};Database=mobile_shop;Port=5432";

            NpgsqlConnection conn = new NpgsqlConnection(connString);

            return conn;
        }
    }
}
