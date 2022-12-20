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

namespace MobileShop
{
    public partial class frmAuth : DevExpress.XtraEditors.XtraForm
    {
        public frmAuth()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.appIcon;
        }

        private void authButton_Click(object sender, EventArgs e)
        {
            string login = this.loginText.Text.Trim();
            string password = this.passwordText.Text.Trim();
/*            string password_hashed = Hash.ComputeSHA256(password).ToLower();*/

            DBUtils.role = login;
            DBUtils.password = password;

            NpgsqlConnection connection = DBUtils.GetDBConnection();

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue(login);
            cmd.Parameters.AddWithValue(password);

            cmd.CommandText = "SELECT " +
                "r.title " +
                "FROM user_login ul " +
                "JOIN person_role pr ON pr.id = ul.id " +
                "JOIN roles r ON pr.id = r.id " +
                "WHERE ul.username = $1 AND ul.password = $2";

            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string role = reader.GetString(reader.GetOrdinal("title"));

                        frmMain main = new frmMain();
                        main.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}