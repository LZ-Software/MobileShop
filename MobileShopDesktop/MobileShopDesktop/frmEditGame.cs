using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileShopDesktop
{
    public partial class frmEditGame : DevExpress.XtraEditors.XtraForm
    {
        private string base64ImageOriginal;
        private string base64Image;
        int g_id;

        public frmEditGame()
        {
            InitializeComponent();
        }

        private void frmEditGame_Load(object sender, EventArgs e)
        {
            genreSearch.Client = genreListBox;
            gameSearch.Client = gameListBox;

            NpgsqlConnection connection = DBUtils.GetDBConnection();

            NpgsqlCommand cmd_game = new NpgsqlCommand();
            cmd_game.Connection = connection;

            cmd_game.CommandText = "SELECT name FROM game;";

            try
            {
                using (NpgsqlDataReader reader = cmd_game.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(reader.GetOrdinal("name"));
                            gameListBox.Items.Add(name);
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
            }
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

        private void chooseGameButton_Click(object sender, EventArgs e)
        {
            genreListBox.UnCheckAll();

            NpgsqlConnection connection = DBUtils.GetDBConnection();

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue(gameListBox.SelectedItem.ToString());

            cmd.CommandText = "SELECT * FROM get_game_by_title($1);";

            try
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            g_id = reader.GetInt32(reader.GetOrdinal("g_id"));
                            nameText.Text = reader.GetString(reader.GetOrdinal("g_name"));
                            publisherComboBox.SelectedItem = reader.GetString(reader.GetOrdinal("p_name"));
                            priceText.Text = reader.GetDouble(reader.GetOrdinal("price")).ToString();
                            descriptionText.Text = reader.GetString(reader.GetOrdinal("g_description"));
                            var date = reader.GetDateTime(reader.GetOrdinal("release_date")).Date.ToString();
                            dateReleasePicker.Text = date;
                            dateReleasePicker.SelectedText = date;
                            string genre = reader.GetString(reader.GetOrdinal("genres"));
                            base64Image = reader.GetString(reader.GetOrdinal("image_base64"));

                            Bitmap image = imageConverter.Base64StringToBitmap(base64Image);
                            pictureBox.Image = image;

                            List<string> genres = genre.Split(',').ToList();


                            var list = genreListBox.Items.ToList().ToList();
                            for (int j = 0; j < genres.Count; j++)
                            {
                                for (int i = 0; i < list.Count(); i++)
                                {
                                    var a = list.ElementAt(i).Value.ToString().Trim();

                                    if (a.Equals(genres.ElementAt(j).Trim()))
                                    {
                                        genreListBox.SetItemChecked(i, true);

                                    }
                                }
                            }

                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                XtraMessageBox.Show($"{ex.Message}", "Внимание", MessageBoxButtons.OK);
            }

            imageButton.Enabled = true;
            changeButton.Enabled = true;
        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            
            dlg.Title = "Open Image";
            dlg.Filter = "Image files|*.jpg;*.jpeg;*.png;*.gif;";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Bitmap image = new Bitmap(dlg.FileName);
                pictureBox.Image = image;

                base64Image = imageConverter.ImageToBase64String(image);
            }

            dlg.Dispose();

        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(base64Image) && !String.IsNullOrEmpty(nameText.Text) && !String.IsNullOrEmpty(priceText.Text) && publisherComboBox.SelectedItem != null && dateReleasePicker.SelectedText != null && !String.IsNullOrEmpty(descriptionText.Text) && genreListBox.CheckedItemsCount != 0)
            {
                NpgsqlConnection connection = DBUtils.GetDBConnection();
                NpgsqlTransaction transaction = connection.BeginTransaction();

                // -------------------------------------------------------

                NpgsqlCommand cmd1 = new NpgsqlCommand("INSERT INTO images(image) VALUES($1) RETURNING id", connection, transaction);

                cmd1.Parameters.AddWithValue(base64Image);

                int image_id = (int) cmd1.ExecuteScalar();

                // -------------------------------------------------------

                NpgsqlCommand cmd2 = new NpgsqlCommand(
                    "UPDATE game " +
                    "SET name = $1," +
                        "description = $2," +
                        "price = $3," +
                        "publisher_id = get_publisher_id_by_title($4)," +
                        "dt_release = $5::timestamp," +
                        "image_id = $6 WHERE id = $7", connection, transaction);

                cmd2.Parameters.AddWithValue(nameText.Text.Trim());
                cmd2.Parameters.AddWithValue(descriptionText.Text.Trim());
                cmd2.Parameters.AddWithValue(float.Parse(priceText.Text, CultureInfo.InvariantCulture.NumberFormat));
                cmd2.Parameters.AddWithValue(publisherComboBox.SelectedItem.ToString());
                cmd2.Parameters.AddWithValue(dateReleasePicker.DateTime);
                cmd2.Parameters.AddWithValue(image_id);
                cmd2.Parameters.AddWithValue(g_id);

                // -------------------------------------------------------

                try
                {
                    if (cmd2.ExecuteNonQuery() != -1)
                    {
                        transaction.Commit();
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
        }
    }
}