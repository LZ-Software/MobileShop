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
    public partial class frmEditPublisher : DevExpress.XtraEditors.XtraForm
    {
        public frmEditPublisher()
        {
            InitializeComponent();
        }

        private void frmEditPublisher_Load(object sender, EventArgs e)
        {
            publisherSearch.Client = publisherListBox;

            try
            {
                NpgsqlConnection connection = DBUtils.GetDBConnection();

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT * FROM get_publishers;";

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(reader.GetOrdinal("name"));
                            publisherListBox.Items.Add(name);
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
            }
        }

        private void publisherListBox_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            try
            {
                NpgsqlConnection connection = DBUtils.GetDBConnection();

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT * FROM get_publishers;";

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(reader.GetOrdinal("name"));
                            publisherListBox.Items.Add(name);
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
            }
        }
    }
}