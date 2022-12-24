using DevExpress.XtraEditors;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileShopDesktop
{
    class DBUtils
    {
        public static string role = "";
        public static string password = "";

        public static NpgsqlConnection GetDBConnection()
        {
            NpgsqlConnection connection = DBServerUtils.GetDBConnection(role, password);
            try
            {
                connection.Open();
            }
            catch (NpgsqlException ex)
            {
                XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
            }
            return connection;
        }
    }
}
