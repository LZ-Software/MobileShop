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

        private string publisherNameOriginal;

        public frmEditPublisher()
        {
            InitializeComponent();
        }

        private void frmEditPublisher_Load(object sender, EventArgs e)
        {
            publisherSearch.Client = publisherListBox;

            NpgsqlConnection connection = DBUtils.GetDBConnection();

            NpgsqlCommand cmd_p = new NpgsqlCommand();
            NpgsqlCommand cmd_c = new NpgsqlCommand();

            cmd_p.Connection = connection;
            cmd_c.Connection = connection;
            try
            {
                cmd_p.CommandText = "SELECT * FROM get_publishers;";

                using (NpgsqlDataReader reader = cmd_p.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(reader.GetOrdinal("p_name"));
                            publisherListBox.Items.Add(name);
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
            }

            try
            {
                cmd_c.CommandText = "SELECT * FROM get_countries;";

                using (NpgsqlDataReader reader = cmd_c.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(reader.GetOrdinal("name"));
                            comboBox.Properties.Items.Add(name);
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
            }
        }

        private void publisherListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            nameText.Text = null;
            comboBox.SelectedItem = null;

            try
            {
                NpgsqlConnection connection = DBUtils.GetDBConnection();

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue(publisherListBox.SelectedItem.ToString());

                cmd.CommandText = "SELECT * FROM get_publisher_by_title($1);";

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string p_name = reader.GetString(reader.GetOrdinal("p_name"));
                            string c_name = reader.GetString(reader.GetOrdinal("c_name"));
                            nameText.Text = p_name;
                            comboBox.SelectedItem = c_name;
                            publisherNameOriginal = p_name;
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(nameText.Text) && !String.IsNullOrEmpty(comboBox.SelectedItem.ToString()))
            {
                try
                {
                    NpgsqlConnection connection = DBUtils.GetDBConnection();

                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue(nameText.Text.Trim());
                    cmd.Parameters.AddWithValue(comboBox.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue(publisherNameOriginal);

                    cmd.CommandText = "CALL update_publisher($1, $2, $3);";

                    var rowAffected = cmd.ExecuteNonQuery();

                    if (rowAffected != 0)
                    {
                        XtraMessageBox.Show("Издатель успешно изменен", "Успех", MessageBoxButtons.OK);
                    }
                }
                catch (NpgsqlException ex)
                {
                    XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
                }
            }
            else
            {
                XtraMessageBox.Show("Заполните пустые поля", "Внимание", MessageBoxButtons.OK);
            }

        }
    }
}