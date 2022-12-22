
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.addButton = new DevExpress.XtraEditors.SimpleButton();
            this.nameText = new DevExpress.XtraEditors.TextEdit();
            this.comboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nameText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.addButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.nameText, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(43, 57);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 130);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addButton.Appearance.Options.UseFont = true;
            this.addButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addButton.Location = new System.Drawing.Point(3, 89);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(194, 38);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Добавить";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // nameText
            // 
            this.nameText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameText.Location = new System.Drawing.Point(3, 3);
            this.nameText.Name = "nameText";
            this.nameText.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameText.Properties.Appearance.Options.UseFont = true;
            this.nameText.Properties.AutoHeight = false;
            this.nameText.Size = new System.Drawing.Size(194, 37);
            this.nameText.TabIndex = 1;
            // 
            // comboBox
            // 
            this.comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox.Location = new System.Drawing.Point(3, 46);
            this.comboBox.Name = "comboBox";
            this.comboBox.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox.Properties.Appearance.Options.UseFont = true;
            this.comboBox.Properties.AutoHeight = false;
            this.comboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBox.Size = new System.Drawing.Size(194, 37);
            this.comboBox.TabIndex = 2;
            // 
            // frmPublisher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 267);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmPublisher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление издателя";
            this.Load += new System.EventHandler(this.frmPublisher_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nameText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBox.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton addButton;
        private DevExpress.XtraEditors.TextEdit nameText;
        private DevExpress.XtraEditors.ComboBoxEdit comboBox;
    }
}