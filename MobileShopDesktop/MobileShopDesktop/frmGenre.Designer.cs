
namespace MobileShopDesktop
{
    partial class frmGenre
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
            this.genreText = new DevExpress.XtraEditors.TextEdit();
            this.addButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.genreText.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // genreText
            // 
            this.genreText.Location = new System.Drawing.Point(43, 87);
            this.genreText.Name = "genreText";
            this.genreText.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.genreText.Properties.Appearance.Options.UseFont = true;
            this.genreText.Properties.AutoHeight = false;
            this.genreText.Properties.NullText = "Жанр";
            this.genreText.Size = new System.Drawing.Size(209, 46);
            this.genreText.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addButton.Appearance.Options.UseFont = true;
            this.addButton.Location = new System.Drawing.Point(43, 140);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(209, 46);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Добавить";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // frmGenre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 267);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.genreText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmGenre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление жанра";
            ((System.ComponentModel.ISupportInitialize)(this.genreText.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit genreText;
        private DevExpress.XtraEditors.SimpleButton addButton;
    }
}