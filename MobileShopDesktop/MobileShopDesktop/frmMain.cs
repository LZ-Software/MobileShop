﻿using DevExpress.XtraEditors;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MobileShopDesktop
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        private string login;

        public frmMain(string login)
        {
            InitializeComponent();

            this.login = login;
            this.Icon = Properties.Resources.appIcon;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            nameLabel.Text = login;

            NpgsqlConnection connection = DBUtils.GetDBConnection();

            NpgsqlCommand cmd_name = new NpgsqlCommand();
            cmd_name.Connection = connection;
            cmd_name.Parameters.AddWithValue(login);

            cmd_name.CommandText = "SELECT * FROM get_role_by_login($1);";
            try
            {
                using (NpgsqlDataReader reader_name = cmd_name.ExecuteReader())
                {
                    if (reader_name.HasRows)
                    {
                        while (reader_name.Read())
                        {
                            roleLabel.Text = $"{reader_name.GetString(reader_name.GetOrdinal("get_role_by_login"))}";
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
            if(roleLabel.Text == "publisher" || roleLabel.Text == "user")
            {
                gameButton.Enabled = false;
                gameButton.Hide();
                changeGameButton.Enabled = false;
                changeGameButton.Hide();
                publisherButton.Enabled = false;
                publisherButton.Hide();
                publisherButton.Enabled = false;
                publisherButton.Hide();
                addGenreButton.Enabled = false;
                addGenreButton.Hide();
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void publisherButton_Click(object sender, EventArgs e)
        {
            frmPublisher publisher = new frmPublisher();
            publisher.ShowDialog();
        }

        private void gameButton_Click(object sender, EventArgs e)
        {
            frmGame game = new frmGame();
            game.ShowDialog();
        }

        private void addGenreButton_Click(object sender, EventArgs e)
        {
            frmGenre genre = new frmGenre();
            genre.ShowDialog();
        }

        private void changePublisherButton_Click(object sender, EventArgs e)
        {
            frmEditPublisher editPublisher = new frmEditPublisher();
            editPublisher.ShowDialog();
        }

        private void changeGameButton_Click(object sender, EventArgs e)
        {
            frmEditGame editGame = new frmEditGame();
            editGame.ShowDialog();
        }
    }
}
