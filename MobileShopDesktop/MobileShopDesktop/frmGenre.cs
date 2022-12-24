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
    public partial class frmGenre : DevExpress.XtraEditors.XtraForm
    {
        public frmGenre()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.appIcon;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(genreText.Text))
            {
                XtraMessageBox.Show("Заполните пустые поля", "Внимание", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    NpgsqlConnection connection = DBUtils.GetDBConnection();

                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue(genreText.Text);

                    cmd.CommandText = "CALL create_genre($1);";

                    var rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected != 0)
                    {
                        XtraMessageBox.Show("Жанр добавлен", "Успех", MessageBoxButtons.OK);
                    }
                }
                catch (NpgsqlException ex)
                {
                    XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
                }
            }
        }
    }
}