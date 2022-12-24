using DevExpress.XtraEditors;
using Npgsql;
using System;
using System.Windows.Forms;

namespace MobileShopDesktop
{
    public partial class frmPublisher : DevExpress.XtraEditors.XtraForm
    {
        public frmPublisher()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.appIcon;
        }

        private void frmPublisher_Load(object sender, EventArgs e)
        {
            NpgsqlConnection connection = DBUtils.GetDBConnection();

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = "SELECT * FROM get_countries;";

            try
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(reader.GetOrdinal("name"));
                            countryComboBox.Properties.Items.Add(name);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Отрыгнуло.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(nameText.Text) || String.IsNullOrEmpty(loginText.Text) || String.IsNullOrEmpty(firstNameText.Text) || String.IsNullOrEmpty(lastNameText.Text) || String.IsNullOrEmpty(passwordText.Text) || countryComboBox.SelectedItem == null || cityComboBox.SelectedItem == null)
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
                    cmd.Parameters.AddWithValue(nameText.Text.Trim());
                    cmd.Parameters.AddWithValue(countryComboBox.SelectedItem);
                    cmd.Parameters.AddWithValue(loginText.Text.Trim());
                    cmd.Parameters.AddWithValue(passwordText.Text.Trim());
                    cmd.Parameters.AddWithValue(firstNameText.Text.Trim());
                    cmd.Parameters.AddWithValue(lastNameText.Text.Trim());
                    cmd.Parameters.AddWithValue(cityComboBox.SelectedItem);

                    cmd.CommandText = "CALL create_publisher($1, $2, $3, $4, $5, $6, $7);";

                    var rowAffected = cmd.ExecuteNonQuery();
                    if(rowAffected != 0)
                    {
                        XtraMessageBox.Show("Издатель добавлен", "Успех", MessageBoxButtons.OK);
                    }
                }
                catch(NpgsqlException ex)
                {
                    XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
                }
            }

        }

        private void passwordText_EditValueChanged(object sender, EventArgs e)
        {
            passwordText.Properties.PasswordChar = '\u25CF';
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                MessageBox.Show("Зажат CAPS LOCK", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void countryComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            cityComboBox.Properties.Items.Clear();
            cityComboBox.SelectedItem = null;

            NpgsqlConnection connection = DBUtils.GetDBConnection();

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue(countryComboBox.SelectedItem);

            cmd.CommandText = "SELECT * FROM get_cities_by_country($1);";


            try
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(reader.GetOrdinal("name_city"));
                            cityComboBox.Properties.Items.Add(name);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Отрыгнуло.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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