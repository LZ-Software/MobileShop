
namespace MobileShopDesktop
{
    partial class frmMain
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
            this.nameLabel = new DevExpress.XtraEditors.LabelControl();
            this.roleLabel = new DevExpress.XtraEditors.LabelControl();
            this.gameButton = new DevExpress.XtraEditors.SimpleButton();
            this.publisherButton = new DevExpress.XtraEditors.SimpleButton();
            this.changeGameButton = new DevExpress.XtraEditors.SimpleButton();
            this.changePublisherButton = new DevExpress.XtraEditors.SimpleButton();
            this.addGenreButton = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.Appearance.Options.UseFont = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 12);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(11, 30);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "1";
            // 
            // roleLabel
            // 
            this.roleLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.roleLabel.Appearance.Options.UseFont = true;
            this.roleLabel.Location = new System.Drawing.Point(14, 48);
            this.roleLabel.Name = "roleLabel";
            this.roleLabel.Size = new System.Drawing.Size(11, 30);
            this.roleLabel.TabIndex = 1;
            this.roleLabel.Text = "1";
            // 
            // gameButton
            // 
            this.gameButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gameButton.Appearance.Options.UseFont = true;
            this.gameButton.Location = new System.Drawing.Point(43, 124);
            this.gameButton.Name = "gameButton";
            this.gameButton.Size = new System.Drawing.Size(203, 46);
            this.gameButton.TabIndex = 0;
            this.gameButton.Text = "Добавить игру";
            this.gameButton.Click += new System.EventHandler(this.gameButton_Click);
            // 
            // publisherButton
            // 
            this.publisherButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.publisherButton.Appearance.Options.UseFont = true;
            this.publisherButton.Location = new System.Drawing.Point(43, 228);
            this.publisherButton.Name = "publisherButton";
            this.publisherButton.Size = new System.Drawing.Size(203, 46);
            this.publisherButton.TabIndex = 1;
            this.publisherButton.Text = "Добавить издателя";
            this.publisherButton.Click += new System.EventHandler(this.publisherButton_Click);
            // 
            // changeGameButton
            // 
            this.changeGameButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeGameButton.Appearance.Options.UseFont = true;
            this.changeGameButton.Location = new System.Drawing.Point(43, 176);
            this.changeGameButton.Name = "changeGameButton";
            this.changeGameButton.Size = new System.Drawing.Size(203, 46);
            this.changeGameButton.TabIndex = 4;
            this.changeGameButton.Text = "Изменить игру";
            // 
            // changePublisherButton
            // 
            this.changePublisherButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changePublisherButton.Appearance.Options.UseFont = true;
            this.changePublisherButton.Location = new System.Drawing.Point(43, 280);
            this.changePublisherButton.Name = "changePublisherButton";
            this.changePublisherButton.Size = new System.Drawing.Size(203, 46);
            this.changePublisherButton.TabIndex = 5;
            this.changePublisherButton.Text = "Изменить издателя";
            // 
            // addGenreButton
            // 
            this.addGenreButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addGenreButton.Appearance.Options.UseFont = true;
            this.addGenreButton.Location = new System.Drawing.Point(43, 332);
            this.addGenreButton.Name = "addGenreButton";
            this.addGenreButton.Size = new System.Drawing.Size(203, 46);
            this.addGenreButton.TabIndex = 6;
            this.addGenreButton.Text = "Добавить жанр";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 402);
            this.Controls.Add(this.addGenreButton);
            this.Controls.Add(this.changePublisherButton);
            this.Controls.Add(this.changeGameButton);
            this.Controls.Add(this.gameButton);
            this.Controls.Add(this.roleLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.publisherButton);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl nameLabel;
        private DevExpress.XtraEditors.LabelControl roleLabel;
        private DevExpress.XtraEditors.SimpleButton gameButton;
        private DevExpress.XtraEditors.SimpleButton publisherButton;
        private DevExpress.XtraEditors.SimpleButton changeGameButton;
        private DevExpress.XtraEditors.SimpleButton changePublisherButton;
        private DevExpress.XtraEditors.SimpleButton addGenreButton;
    }
}

