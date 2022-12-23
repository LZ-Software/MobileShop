
namespace MobileShopDesktop
{
    partial class frmPublisher
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
            this.addButton = new DevExpress.XtraEditors.SimpleButton();
            this.nameText = new DevExpress.XtraEditors.TextEdit();
            this.countryComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.loginText = new DevExpress.XtraEditors.TextEdit();
            this.firstNameText = new DevExpress.XtraEditors.TextEdit();
            this.lastNameText = new DevExpress.XtraEditors.TextEdit();
            this.passwordText = new DevExpress.XtraEditors.TextEdit();
            this.cityComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.nameText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstNameText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lastNameText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityComboBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addButton.Appearance.Options.UseFont = true;
            this.addButton.Location = new System.Drawing.Point(41, 332);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(194, 38);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Добавить";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(41, 31);
            this.nameText.Name = "nameText";
            this.nameText.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameText.Properties.Appearance.Options.UseFont = true;
            this.nameText.Properties.AutoHeight = false;
            this.nameText.Properties.NullText = "Название издателя";
            this.nameText.Size = new System.Drawing.Size(194, 37);
            this.nameText.TabIndex = 1;
            // 
            // countryComboBox
            // 
            this.countryComboBox.Location = new System.Drawing.Point(41, 246);
            this.countryComboBox.Name = "countryComboBox";
            this.countryComboBox.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countryComboBox.Properties.Appearance.Options.UseFont = true;
            this.countryComboBox.Properties.AutoHeight = false;
            this.countryComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.countryComboBox.Size = new System.Drawing.Size(194, 37);
            this.countryComboBox.TabIndex = 2;
            this.countryComboBox.SelectedValueChanged += new System.EventHandler(this.countryComboBox_SelectedValueChanged);
            // 
            // loginText
            // 
            this.loginText.Location = new System.Drawing.Point(41, 74);
            this.loginText.Name = "loginText";
            this.loginText.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginText.Properties.Appearance.Options.UseFont = true;
            this.loginText.Properties.AutoHeight = false;
            this.loginText.Properties.NullText = "Логин";
            this.loginText.Size = new System.Drawing.Size(194, 37);
            this.loginText.TabIndex = 3;
            // 
            // firstNameText
            // 
            this.firstNameText.Location = new System.Drawing.Point(41, 117);
            this.firstNameText.Name = "firstNameText";
            this.firstNameText.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstNameText.Properties.Appearance.Options.UseFont = true;
            this.firstNameText.Properties.AutoHeight = false;
            this.firstNameText.Properties.NullText = "Имя";
            this.firstNameText.Size = new System.Drawing.Size(194, 37);
            this.firstNameText.TabIndex = 4;
            // 
            // lastNameText
            // 
            this.lastNameText.Location = new System.Drawing.Point(41, 160);
            this.lastNameText.Name = "lastNameText";
            this.lastNameText.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lastNameText.Properties.Appearance.Options.UseFont = true;
            this.lastNameText.Properties.AutoHeight = false;
            this.lastNameText.Properties.NullText = "Фамилия";
            this.lastNameText.Size = new System.Drawing.Size(194, 37);
            this.lastNameText.TabIndex = 5;
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(41, 203);
            this.passwordText.Name = "passwordText";
            this.passwordText.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordText.Properties.Appearance.Options.UseFont = true;
            this.passwordText.Properties.AutoHeight = false;
            this.passwordText.Properties.NullText = "Пароль";
            this.passwordText.Size = new System.Drawing.Size(194, 37);
            this.passwordText.TabIndex = 6;
            this.passwordText.EditValueChanged += new System.EventHandler(this.passwordText_EditValueChanged);
            // 
            // cityComboBox
            // 
            this.cityComboBox.Location = new System.Drawing.Point(41, 289);
            this.cityComboBox.Name = "cityComboBox";
            this.cityComboBox.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cityComboBox.Properties.Appearance.Options.UseFont = true;
            this.cityComboBox.Properties.AutoHeight = false;
            this.cityComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cityComboBox.Size = new System.Drawing.Size(194, 37);
            this.cityComboBox.TabIndex = 7;
            // 
            // frmPublisher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 416);
            this.Controls.Add(this.cityComboBox);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.lastNameText);
            this.Controls.Add(this.firstNameText);
            this.Controls.Add(this.loginText);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.countryComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmPublisher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление издателя";
            this.Load += new System.EventHandler(this.frmPublisher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nameText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstNameText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lastNameText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityComboBox.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton addButton;
        private DevExpress.XtraEditors.TextEdit nameText;
        private DevExpress.XtraEditors.ComboBoxEdit countryComboBox;
        private DevExpress.XtraEditors.TextEdit loginText;
        private DevExpress.XtraEditors.TextEdit firstNameText;
        private DevExpress.XtraEditors.TextEdit lastNameText;
        private DevExpress.XtraEditors.TextEdit passwordText;
        private DevExpress.XtraEditors.ComboBoxEdit cityComboBox;
    }
}