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
        }

        private void frmPublisher_Load(object sender, EventArgs e)
        {
            NpgsqlConnection connection = DBUtils.GetDBConnection();

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = "SELECT * FROM get_countries;";

            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(reader.GetOrdinal("name"));
                        comboBox.Properties.Items.Add(name);
                    }
                }
                else
                {
                    MessageBox.Show("Отрыгнуло.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if(nameText.Text == "" || comboBox.SelectedItem == null)
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
                    cmd.Parameters.AddWithValue(nameText.Text);
                    cmd.Parameters.AddWithValue(comboBox.SelectedItem);

                    cmd.CommandText = "CALL create_publisher($1, $2);";

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
    }
}