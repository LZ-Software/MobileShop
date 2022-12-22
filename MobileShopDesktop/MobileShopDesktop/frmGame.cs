using DevExpress.XtraEditors;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = "SELECT * FROM get_genres;";

            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(reader.GetOrdinal("name"));
                        genreListBox.Items.Add(name);
                    }
                }
                else
                {
                    MessageBox.Show("Отрыгнуло.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var numberOfLines = SendMessage(descriptionText.Handle.ToInt32(), EM_GETLINECOUNT, 0, 0);
            this.descriptionText.Height = (descriptionText.Font.Height + 2) * numberOfLines;
        }

        private string ImageToBase64String(Bitmap img)
        {
            using (var ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return Convert.ToBase64String(ms.ToArray());
            }
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

                    base64Image = ImageToBase64String(image);
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(base64Image) && !String.IsNullOrEmpty(nameText.Text) && !String.IsNullOrEmpty(priceText.Text) && !String.IsNullOrEmpty(publisherText.Text) && dateReleasePicker.SelectedText != null && !String.IsNullOrEmpty(descriptionText.Text) && genreListBox.CheckedItemsCount != 0)
            {

            }
        }
    }
}