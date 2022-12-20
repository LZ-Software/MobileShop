using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop
{
    class DBServerUtils
    {
        public static NpgsqlConnection GetDBConnection(string username, string password)
        {
            string connString = $"Host=localhost;Username={username};Password={password};Database=mirea;Port=5432;";

            NpgsqlConnection conn = new NpgsqlConnection(connString);

            return conn;
        }
    }
}
