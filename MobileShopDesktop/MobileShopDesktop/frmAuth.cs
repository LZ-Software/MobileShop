using DevExpress.XtraEditors;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileShopDesktop
{
    public partial class frmAuth : DevExpress.XtraEditors.XtraForm
    {
        public frmAuth()
        {
            InitializeComponent();
        }

        private void authButton_Click(object sender, EventArgs e)
        {
            string login = this.loginText.Text;
            string password = this.passwordText.Text;
            DBUtils.role = login.ToLower();
            DBUtils.password = password;

            login = login.Trim();
            password = password.Trim();

            NpgsqlConnection connection = DBUtils.GetDBConnection();

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue(login);
            cmd.Parameters.AddWithValue(password);

            cmd.CommandText = "SELECT * FROM auth_user_get_id($1, $2);";

            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    frmMain main = new frmMain(login);
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Пользователь не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}