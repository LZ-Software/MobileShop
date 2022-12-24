using DevExpress.XtraEditors;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileShopDesktop
{
    public partial class frmGame : DevExpress.XtraEditors.XtraForm
    {
        string base64Image;

        private const int EM_GETLINECOUNT = 0xba;
        [DllImport("user32", EntryPoint = "SendMessageA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);

        public frmGame()
        {
            InitializeComponent();
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            genreSearch.Client = genreListBox;

            NpgsqlConnection connection = DBUtils.GetDBConnection();

            NpgsqlCommand cmd_genres = new NpgsqlCommand();
            cmd_genres.Connection = connection;
            NpgsqlCommand cmd_publishers = new NpgsqlCommand();
            cmd_publishers.Connection = connection;

            cmd_genres.CommandText = "SELECT * FROM get_genres;";
            cmd_publishers.CommandText = "SELECT * FROM get_publishers;";

            try
            {
                using (NpgsqlDataReader reader = cmd_genres.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(reader.GetOrdinal("name"));
                            genreListBox.Items.Add(name);
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
                using (NpgsqlDataReader reader = cmd_publishers.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(reader.GetOrdinal("p_name"));
                            publisherComboBox.Properties.Items.Add(name);
                        }
                    }
                }

            }
            catch (NpgsqlException ex)
            {
                XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var numberOfLines = SendMessage(descriptionText.Handle.ToInt32(), EM_GETLINECOUNT, 0, 0);
            this.descriptionText.Height = (descriptionText.Font.Height + 2) * numberOfLines;
        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image files|*.jpg;*.jpeg;*.png;*.gif;";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Bitmap image = new Bitmap(dlg.FileName);
                    pictureBox.Image = image;

                    base64Image = imageConverter.ImageToBase64String(image);
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(base64Image) && !String.IsNullOrEmpty(nameText.Text) && !String.IsNullOrEmpty(priceText.Text) && publisherComboBox.SelectedItem != null && dateReleasePicker.SelectedText != null && !String.IsNullOrEmpty(descriptionText.Text) && genreListBox.CheckedItemsCount != 0)
            {

                NpgsqlConnection connection = DBUtils.GetDBConnection();
                NpgsqlTransaction transaction = connection.BeginTransaction();

                // -------------------------------------------------------

                NpgsqlCommand cmd1 = new NpgsqlCommand("CALL create_game($1, $2, $3, $4, $5::DATE, $6);", connection,transaction);

                cmd1.Connection = connection;
                cmd1.Parameters.AddWithValue(nameText.Text.Trim());
                cmd1.Parameters.AddWithValue(descriptionText.Text.Trim());
                cmd1.Parameters.AddWithValue(float.Parse(priceText.Text, CultureInfo.InvariantCulture.NumberFormat));
                cmd1.Parameters.AddWithValue(publisherComboBox.SelectedItem.ToString());
                cmd1.Parameters.AddWithValue(dateReleasePicker.SelectedText);
                cmd1.Parameters.AddWithValue(base64Image);

                try
                {
                    cmd1.ExecuteNonQuery();
                }
                catch (NpgsqlException ex)
                {
                    XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
                }

                // -------------------------------------------------------

                for (int i = 0; i < genreListBox.CheckedItemsCount; i++)
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand($"INSERT INTO game_genre(game_id, genre_id) " +
                                                           $"VALUES" +
                                                           $"(get_game_id_by_title($1), get_genre_id_by_title($2));", connection, transaction);
                    
                    cmd2.Parameters.AddWithValue(nameText.Text.Trim());
                    cmd2.Parameters.AddWithValue(genreListBox.CheckedItems[i].ToString());

                    try
                    {
                        if (cmd2.ExecuteNonQuery() != -1)
                        {
                        }
                        else
                        {
                            transaction.Rollback();
                            transaction.Dispose();
                            return;
                        }
                    }
                    catch (NpgsqlException ex)
                    {
                        XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
                        transaction.Rollback();
                        transaction.Dispose();
                    }
                }
                transaction.Commit();
                // -------------------------------------------------------
            }
        }
    }
}