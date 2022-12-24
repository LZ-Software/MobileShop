
namespace MobileShopDesktop
{
    partial class frmEditPublisher
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
            DevExpress.XtraEditors.TableLayout.ItemTemplateBase itemTemplateBase1 = new DevExpress.XtraEditors.TableLayout.ItemTemplateBase();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition1 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement1 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition1 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.editButton = new DevExpress.XtraEditors.SimpleButton();
            this.nameText = new DevExpress.XtraEditors.TextEdit();
            this.comboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel6 = new System.Windows.Forms.Panel();
            this.publisherSearch = new DevExpress.XtraEditors.SearchControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.publisherListBox = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nameText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBox.Properties)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.publisherSearch.Properties)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.publisherListBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.editButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.nameText, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(284, 44);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 141);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // editButton
            // 
            this.editButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editButton.Appearance.Options.UseFont = true;
            this.editButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editButton.Location = new System.Drawing.Point(3, 95);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(194, 43);
            this.editButton.TabIndex = 0;
            this.editButton.Text = "Изменить";
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // nameText
            // 
            this.nameText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameText.Location = new System.Drawing.Point(3, 3);
            this.nameText.Name = "nameText";
            this.nameText.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameText.Properties.Appearance.Options.UseFont = true;
            this.nameText.Properties.AutoHeight = false;
            this.nameText.Size = new System.Drawing.Size(194, 40);
            this.nameText.TabIndex = 1;
            // 
            // comboBox
            // 
            this.comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox.Location = new System.Drawing.Point(3, 49);
            this.comboBox.Name = "comboBox";
            this.comboBox.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox.Properties.Appearance.Options.UseFont = true;
            this.comboBox.Properties.AutoHeight = false;
            this.comboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBox.Size = new System.Drawing.Size(194, 40);
            this.comboBox.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.publisherSearch);
            this.panel6.Location = new System.Drawing.Point(41, 44);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(223, 46);
            this.panel6.TabIndex = 12;
            // 
            // publisherSearch
            // 
            this.publisherSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.publisherSearch.Location = new System.Drawing.Point(0, 0);
            this.publisherSearch.Name = "publisherSearch";
            this.publisherSearch.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.publisherSearch.Properties.Appearance.Options.UseFont = true;
            this.publisherSearch.Properties.AutoHeight = false;
            this.publisherSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.publisherSearch.Size = new System.Drawing.Size(223, 46);
            this.publisherSearch.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.publisherListBox);
            this.panel4.Location = new System.Drawing.Point(41, 93);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(223, 90);
            this.panel4.TabIndex = 11;
            // 
            // publisherListBox
            // 
            this.publisherListBox.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.publisherListBox.Appearance.Options.UseFont = true;
            this.publisherListBox.CheckMode = DevExpress.XtraEditors.CheckMode.Single;
            this.publisherListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.publisherListBox.ItemHeight = 45;
            this.publisherListBox.Location = new System.Drawing.Point(0, 0);
            this.publisherListBox.MinimumSize = new System.Drawing.Size(223, 83);
            this.publisherListBox.Name = "publisherListBox";
            this.publisherListBox.Size = new System.Drawing.Size(223, 90);
            this.publisherListBox.TabIndex = 1;
            itemTemplateBase1.Columns.Add(tableColumnDefinition1);
            templatedItemElement1.Appearance.Hovered.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            templatedItemElement1.Appearance.Hovered.Options.UseFont = true;
            templatedItemElement1.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            templatedItemElement1.Appearance.Normal.Options.UseFont = true;
            templatedItemElement1.Appearance.Pressed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            templatedItemElement1.Appearance.Pressed.Options.UseFont = true;
            templatedItemElement1.Appearance.Selected.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            templatedItemElement1.Appearance.Selected.Options.UseFont = true;
            templatedItemElement1.FieldName = "DisplayMember";
            templatedItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement1.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement1.Text = "DisplayMember";
            templatedItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            itemTemplateBase1.Elements.Add(templatedItemElement1);
            itemTemplateBase1.Name = "template1";
            itemTemplateBase1.Rows.Add(tableRowDefinition1);
            this.publisherListBox.Templates.Add(itemTemplateBase1);
            this.publisherListBox.SelectedValueChanged += new System.EventHandler(this.publisherListBox_SelectedValueChanged);
            // 
            // frmEditPublisher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 220);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmEditPublisher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Изменить издателя";
            this.Load += new System.EventHandler(this.frmEditPublisher_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nameText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBox.Properties)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.publisherSearch.Properties)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.publisherListBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton editButton;
        private DevExpress.XtraEditors.TextEdit nameText;
        private DevExpress.XtraEditors.ComboBoxEdit comboBox;
        private System.Windows.Forms.Panel panel6;
        private DevExpress.XtraEditors.SearchControl publisherSearch;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.CheckedListBoxControl publisherListBox;
    }
}