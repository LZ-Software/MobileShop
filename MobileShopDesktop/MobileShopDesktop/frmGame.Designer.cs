﻿
namespace MobileShopDesktop
{
    partial class frmGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraEditors.TableLayout.ItemTemplateBase itemTemplateBase3 = new DevExpress.XtraEditors.TableLayout.ItemTemplateBase();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition3 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement3 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition3 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.descriptionText = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.descriptionLabel = new DevExpress.XtraEditors.LabelControl();
            this.nameLabel = new DevExpress.XtraEditors.LabelControl();
            this.nameText = new DevExpress.XtraEditors.TextEdit();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.priceLabel = new DevExpress.XtraEditors.LabelControl();
            this.priceText = new DevExpress.XtraEditors.TextEdit();
            this.publisherLabel = new DevExpress.XtraEditors.LabelControl();
            this.publisherText = new DevExpress.XtraEditors.TextEdit();
            this.dateReleaseLabel = new DevExpress.XtraEditors.LabelControl();
            this.dateReleasePicker = new DevExpress.XtraEditors.DateEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imageButton = new DevExpress.XtraEditors.SimpleButton();
            this.addButton = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox = new DevExpress.XtraEditors.PictureEdit();
            this.panel4 = new System.Windows.Forms.Panel();
            this.genreListBox = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.genreSearch = new DevExpress.XtraEditors.SearchControl();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.genreLabel = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nameText.Properties)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.publisherText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateReleasePicker.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateReleasePicker.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox.Properties)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.genreListBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genreSearch.Properties)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.18447F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.81553F));
            this.tableLayoutPanel1.Controls.Add(this.dateReleaseLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.publisherLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.priceText, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.priceLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.nameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nameText, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.publisherText, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dateReleasePicker, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(30, 168);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(309, 184);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Location = new System.Drawing.Point(271, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 150);
            this.panel1.TabIndex = 1;
            // 
            // descriptionText
            // 
            this.descriptionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.descriptionText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.descriptionText.Location = new System.Drawing.Point(3, 3);
            this.descriptionText.Multiline = true;
            this.descriptionText.Name = "descriptionText";
            this.descriptionText.Size = new System.Drawing.Size(239, 40);
            this.descriptionText.TabIndex = 2;
            this.descriptionText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.75281F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.24719F));
            this.tableLayoutPanel2.Controls.Add(this.descriptionText, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(454, 168);
            this.tableLayoutPanel2.MaximumSize = new System.Drawing.Size(245, 276);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.17483F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.82517F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(245, 46);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descriptionLabel.Appearance.Options.UseFont = true;
            this.descriptionLabel.Appearance.Options.UseTextOptions = true;
            this.descriptionLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.descriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionLabel.Location = new System.Drawing.Point(3, 3);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(100, 40);
            this.descriptionLabel.TabIndex = 3;
            this.descriptionLabel.Text = "Описание";
            // 
            // nameLabel
            // 
            this.nameLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.Appearance.Options.UseFont = true;
            this.nameLabel.Appearance.Options.UseTextOptions = true;
            this.nameLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameLabel.Location = new System.Drawing.Point(3, 3);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(78, 40);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Название";
            // 
            // nameText
            // 
            this.nameText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameText.Location = new System.Drawing.Point(87, 3);
            this.nameText.Name = "nameText";
            this.nameText.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameText.Properties.Appearance.Options.UseFont = true;
            this.nameText.Properties.AutoHeight = false;
            this.nameText.Size = new System.Drawing.Size(219, 40);
            this.nameText.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.descriptionLabel, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(342, 168);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(106, 46);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // priceLabel
            // 
            this.priceLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priceLabel.Appearance.Options.UseFont = true;
            this.priceLabel.Appearance.Options.UseTextOptions = true;
            this.priceLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.priceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.priceLabel.Location = new System.Drawing.Point(3, 49);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(78, 40);
            this.priceLabel.TabIndex = 2;
            this.priceLabel.Text = "Стоимость";
            // 
            // priceText
            // 
            this.priceText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.priceText.Location = new System.Drawing.Point(87, 49);
            this.priceText.Name = "priceText";
            this.priceText.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priceText.Properties.Appearance.Options.UseFont = true;
            this.priceText.Properties.AutoHeight = false;
            this.priceText.Properties.Mask.EditMask = "([0-9]*[.])?[0-9]+";
            this.priceText.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.priceText.Size = new System.Drawing.Size(219, 40);
            this.priceText.TabIndex = 3;
            // 
            // publisherLabel
            // 
            this.publisherLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.publisherLabel.Appearance.Options.UseFont = true;
            this.publisherLabel.Appearance.Options.UseTextOptions = true;
            this.publisherLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.publisherLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.publisherLabel.Location = new System.Drawing.Point(3, 95);
            this.publisherLabel.Name = "publisherLabel";
            this.publisherLabel.Size = new System.Drawing.Size(78, 40);
            this.publisherLabel.TabIndex = 4;
            this.publisherLabel.Text = "Издатель";
            // 
            // publisherText
            // 
            this.publisherText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.publisherText.Location = new System.Drawing.Point(87, 95);
            this.publisherText.Name = "publisherText";
            this.publisherText.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.publisherText.Properties.Appearance.Options.UseFont = true;
            this.publisherText.Properties.AutoHeight = false;
            this.publisherText.Size = new System.Drawing.Size(219, 40);
            this.publisherText.TabIndex = 5;
            // 
            // dateReleaseLabel
            // 
            this.dateReleaseLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateReleaseLabel.Appearance.Options.UseFont = true;
            this.dateReleaseLabel.Appearance.Options.UseTextOptions = true;
            this.dateReleaseLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dateReleaseLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateReleaseLabel.Location = new System.Drawing.Point(3, 141);
            this.dateReleaseLabel.Name = "dateReleaseLabel";
            this.dateReleaseLabel.Size = new System.Drawing.Size(78, 40);
            this.dateReleaseLabel.TabIndex = 6;
            this.dateReleaseLabel.Text = "Дата";
            // 
            // dateReleasePicker
            // 
            this.dateReleasePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateReleasePicker.EditValue = null;
            this.dateReleasePicker.Location = new System.Drawing.Point(87, 141);
            this.dateReleasePicker.Name = "dateReleasePicker";
            this.dateReleasePicker.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateReleasePicker.Properties.Appearance.Options.UseFont = true;
            this.dateReleasePicker.Properties.AutoHeight = false;
            this.dateReleasePicker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateReleasePicker.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateReleasePicker.Size = new System.Drawing.Size(219, 40);
            this.dateReleasePicker.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.imageButton);
            this.panel2.Location = new System.Drawing.Point(114, 493);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(225, 46);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.addButton);
            this.panel3.Location = new System.Drawing.Point(114, 545);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(225, 46);
            this.panel3.TabIndex = 6;
            // 
            // imageButton
            // 
            this.imageButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageButton.Appearance.Options.UseFont = true;
            this.imageButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageButton.Location = new System.Drawing.Point(0, 0);
            this.imageButton.Name = "imageButton";
            this.imageButton.Size = new System.Drawing.Size(225, 46);
            this.imageButton.TabIndex = 0;
            this.imageButton.Text = "Добавить изображение";
            this.imageButton.Click += new System.EventHandler(this.imageButton_Click);
            // 
            // addButton
            // 
            this.addButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addButton.Appearance.Options.UseFont = true;
            this.addButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addButton.Location = new System.Drawing.Point(0, 0);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(225, 46);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Добавить игру";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureBox.Size = new System.Drawing.Size(150, 150);
            this.pictureBox.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.genreListBox);
            this.panel4.Location = new System.Drawing.Point(116, 404);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(223, 83);
            this.panel4.TabIndex = 7;
            // 
            // genreListBox
            // 
            this.genreListBox.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.genreListBox.Appearance.Options.UseFont = true;
            this.genreListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.genreListBox.ItemHeight = 45;
            this.genreListBox.Location = new System.Drawing.Point(0, 0);
            this.genreListBox.MinimumSize = new System.Drawing.Size(223, 83);
            this.genreListBox.Name = "genreListBox";
            this.genreListBox.Size = new System.Drawing.Size(223, 83);
            this.genreListBox.TabIndex = 0;
            itemTemplateBase3.Columns.Add(tableColumnDefinition3);
            templatedItemElement3.Appearance.Hovered.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            templatedItemElement3.Appearance.Hovered.Options.UseFont = true;
            templatedItemElement3.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            templatedItemElement3.Appearance.Normal.Options.UseFont = true;
            templatedItemElement3.Appearance.Pressed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            templatedItemElement3.Appearance.Pressed.Options.UseFont = true;
            templatedItemElement3.Appearance.Selected.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            templatedItemElement3.Appearance.Selected.Options.UseFont = true;
            templatedItemElement3.FieldName = "DisplayMember";
            templatedItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement3.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement3.Text = "DisplayMember";
            templatedItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            itemTemplateBase3.Elements.Add(templatedItemElement3);
            itemTemplateBase3.Name = "template1";
            itemTemplateBase3.Rows.Add(tableRowDefinition3);
            this.genreListBox.Templates.Add(itemTemplateBase3);
            // 
            // genreSearch
            // 
            this.genreSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.genreSearch.Location = new System.Drawing.Point(0, 0);
            this.genreSearch.Name = "genreSearch";
            this.genreSearch.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.genreSearch.Properties.Appearance.Options.UseFont = true;
            this.genreSearch.Properties.AutoHeight = false;
            this.genreSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.genreSearch.Size = new System.Drawing.Size(223, 46);
            this.genreSearch.TabIndex = 8;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.genreLabel);
            this.panel5.Location = new System.Drawing.Point(30, 355);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(81, 46);
            this.panel5.TabIndex = 9;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.genreSearch);
            this.panel6.Location = new System.Drawing.Point(116, 355);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(223, 46);
            this.panel6.TabIndex = 10;
            // 
            // genreLabel
            // 
            this.genreLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.genreLabel.Appearance.Options.UseFont = true;
            this.genreLabel.Appearance.Options.UseTextOptions = true;
            this.genreLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.genreLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.genreLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.genreLabel.Location = new System.Drawing.Point(0, 0);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(81, 46);
            this.genreLabel.TabIndex = 0;
            this.genreLabel.Text = "Жанр";
            // 
            // frmGame
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 620);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmGame";
            this.Text = "Добавление игры";
            this.Load += new System.EventHandler(this.frmGame_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nameText.Properties)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.publisherText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateReleasePicker.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateReleasePicker.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox.Properties)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.genreListBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genreSearch.Properties)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox descriptionText;
        private DevExpress.XtraEditors.LabelControl nameLabel;
        private DevExpress.XtraEditors.TextEdit nameText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.LabelControl descriptionLabel;
        private DevExpress.XtraEditors.LabelControl publisherLabel;
        private DevExpress.XtraEditors.TextEdit priceText;
        private DevExpress.XtraEditors.LabelControl priceLabel;
        private DevExpress.XtraEditors.TextEdit publisherText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.LabelControl dateReleaseLabel;
        private DevExpress.XtraEditors.DateEdit dateReleasePicker;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton imageButton;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.SimpleButton addButton;
        private DevExpress.XtraEditors.PictureEdit pictureBox;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.CheckedListBoxControl genreListBox;
        private DevExpress.XtraEditors.SearchControl genreSearch;
        private System.Windows.Forms.Panel panel5;
        private DevExpress.XtraEditors.LabelControl genreLabel;
        private System.Windows.Forms.Panel panel6;
    }
}