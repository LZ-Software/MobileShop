
namespace MobileShopDesktop
{
    partial class frmAuth
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
            this.authButton = new DevExpress.XtraEditors.SimpleButton();
            this.passwordText = new DevExpress.XtraEditors.TextEdit();
            this.loginText = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.passwordText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginText.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // authButton
            // 
            this.authButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.authButton.Appearance.Options.UseFont = true;
            this.authButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.authButton.Location = new System.Drawing.Point(119, 304);
            this.authButton.Name = "authButton";
            this.authButton.Size = new System.Drawing.Size(211, 23);
            this.authButton.TabIndex = 7;
            this.authButton.Text = "Авторизация";
            this.authButton.Click += new System.EventHandler(this.authButton_Click);
            // 
            // passwordText
            // 
            this.passwordText.EditValue = "";
            this.passwordText.Location = new System.Drawing.Point(119, 258);
            this.passwordText.Name = "passwordText";
            this.passwordText.Properties.AutoHeight = false;
            this.passwordText.Properties.NullValuePrompt = "Пароль";
            this.passwordText.Properties.NullValuePromptShowForEmptyValue = true;
            this.passwordText.Properties.PasswordChar = '*';
            this.passwordText.Properties.ShowNullValuePromptWhenFocused = true;
            this.passwordText.Size = new System.Drawing.Size(211, 25);
            this.passwordText.TabIndex = 6;
            // 
            // loginText
            // 
            this.loginText.EditValue = "";
            this.loginText.Location = new System.Drawing.Point(119, 214);
            this.loginText.Name = "loginText";
            this.loginText.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginText.Properties.Appearance.Options.UseFont = true;
            this.loginText.Properties.AutoHeight = false;
            this.loginText.Properties.NullValuePrompt = "Логин";
            this.loginText.Properties.NullValuePromptShowForEmptyValue = true;
            this.loginText.Properties.ShowNullValuePromptWhenFocused = true;
            this.loginText.Size = new System.Drawing.Size(211, 25);
            this.loginText.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(119, 80);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(211, 47);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Авторизация";
            // 
            // frmAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 407);
            this.Controls.Add(this.authButton);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.loginText);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmAuth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            ((System.ComponentModel.ISupportInitialize)(this.passwordText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginText.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton authButton;
        private DevExpress.XtraEditors.TextEdit passwordText;
        private DevExpress.XtraEditors.TextEdit loginText;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}