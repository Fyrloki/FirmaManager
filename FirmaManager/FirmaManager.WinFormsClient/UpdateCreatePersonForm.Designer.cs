
namespace FirmaManager.WinFormsClient
{
    partial class UpdateCreatePersonForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblBirthdayValue = new System.Windows.Forms.Label();
            this.lblGenderValue = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.dtpBirthdate = new System.Windows.Forms.DateTimePicker();
            this.lblBirthdate = new System.Windows.Forms.Label();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblPersonnumber = new System.Windows.Forms.Label();
            this.lblPersonnumberValue = new System.Windows.Forms.Label();
            this.txtPersonnumber = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStrip});
            this.statusStrip1.Location = new System.Drawing.Point(0, 189);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(391, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusStrip
            // 
            this.statusStrip.ForeColor = System.Drawing.Color.Red;
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(118, 17);
            this.statusStrip.Text = "Error message is here";
            this.statusStrip.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(195, 163);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Tag = "btnCancel";
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(100, 163);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(89, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Tag = "btnOk";
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.Button_Click);
            // 
            // lblBirthdayValue
            // 
            this.lblBirthdayValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBirthdayValue.AutoSize = true;
            this.lblBirthdayValue.Location = new System.Drawing.Point(128, 129);
            this.lblBirthdayValue.Name = "lblBirthdayValue";
            this.lblBirthdayValue.Size = new System.Drawing.Size(92, 15);
            this.lblBirthdayValue.TabIndex = 10;
            this.lblBirthdayValue.Text = "lblBirthdayValue";
            this.lblBirthdayValue.Visible = false;
            // 
            // lblGenderValue
            // 
            this.lblGenderValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGenderValue.AutoSize = true;
            this.lblGenderValue.Location = new System.Drawing.Point(128, 99);
            this.lblGenderValue.Name = "lblGenderValue";
            this.lblGenderValue.Size = new System.Drawing.Size(86, 15);
            this.lblGenderValue.TabIndex = 9;
            this.lblGenderValue.Text = "lblGenderValue";
            this.lblGenderValue.Visible = false;
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.BackColor = System.Drawing.Color.White;
            this.txtLastName.Location = new System.Drawing.Point(128, 8);
            this.txtLastName.MaxLength = 30;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(251, 23);
            this.txtLastName.TabIndex = 1;
            this.txtLastName.Tag = "Nachname";
            this.txtLastName.TextChanged += new System.EventHandler(this.TextBoxValueChanged);
            // 
            // lblLastName
            // 
            this.lblLastName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLastName.Location = new System.Drawing.Point(11, 11);
            this.lblLastName.MaximumSize = new System.Drawing.Size(120, 19);
            this.lblLastName.MinimumSize = new System.Drawing.Size(120, 19);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(120, 19);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "Nachname:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.BackColor = System.Drawing.Color.White;
            this.txtFirstName.Location = new System.Drawing.Point(128, 37);
            this.txtFirstName.MaxLength = 30;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(251, 23);
            this.txtFirstName.TabIndex = 2;
            this.txtFirstName.Tag = "Vorname";
            this.txtFirstName.TextChanged += new System.EventHandler(this.TextBoxValueChanged);
            // 
            // lblFirstName
            // 
            this.lblFirstName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFirstName.Location = new System.Drawing.Point(11, 39);
            this.lblFirstName.MaximumSize = new System.Drawing.Size(120, 19);
            this.lblFirstName.MinimumSize = new System.Drawing.Size(120, 19);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(120, 19);
            this.lblFirstName.TabIndex = 2;
            this.lblFirstName.Text = "Vorname:";
            // 
            // dtpBirthdate
            // 
            this.dtpBirthdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpBirthdate.Enabled = false;
            this.dtpBirthdate.Location = new System.Drawing.Point(128, 124);
            this.dtpBirthdate.MaxDate = new System.DateTime(2021, 11, 4, 0, 0, 0, 0);
            this.dtpBirthdate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpBirthdate.Name = "dtpBirthdate";
            this.dtpBirthdate.Size = new System.Drawing.Size(251, 23);
            this.dtpBirthdate.TabIndex = 5;
            this.dtpBirthdate.Value = new System.DateTime(2021, 11, 4, 0, 0, 0, 0);
            // 
            // lblBirthdate
            // 
            this.lblBirthdate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBirthdate.Location = new System.Drawing.Point(11, 128);
            this.lblBirthdate.MaximumSize = new System.Drawing.Size(120, 19);
            this.lblBirthdate.MinimumSize = new System.Drawing.Size(120, 19);
            this.lblBirthdate.Name = "lblBirthdate";
            this.lblBirthdate.Size = new System.Drawing.Size(120, 19);
            this.lblBirthdate.TabIndex = 2;
            this.lblBirthdate.Text = "Geburtsdatum:";
            // 
            // cbGender
            // 
            this.cbGender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender.Enabled = false;
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Items.AddRange(new object[] {
            "Männlich",
            "Weiblich"});
            this.cbGender.Location = new System.Drawing.Point(128, 95);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(251, 23);
            this.cbGender.TabIndex = 4;
            // 
            // lblGender
            // 
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGender.Location = new System.Drawing.Point(11, 98);
            this.lblGender.MaximumSize = new System.Drawing.Size(120, 19);
            this.lblGender.MinimumSize = new System.Drawing.Size(120, 19);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(120, 19);
            this.lblGender.TabIndex = 2;
            this.lblGender.Text = "Geschlecht:";
            // 
            // lblPersonnumber
            // 
            this.lblPersonnumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPersonnumber.Location = new System.Drawing.Point(11, 69);
            this.lblPersonnumber.MaximumSize = new System.Drawing.Size(120, 19);
            this.lblPersonnumber.MinimumSize = new System.Drawing.Size(120, 19);
            this.lblPersonnumber.Name = "lblPersonnumber";
            this.lblPersonnumber.Size = new System.Drawing.Size(120, 19);
            this.lblPersonnumber.TabIndex = 2;
            this.lblPersonnumber.Text = "Personennummer:";
            // 
            // lblPersonnumberValue
            // 
            this.lblPersonnumberValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonnumberValue.AutoSize = true;
            this.lblPersonnumberValue.Location = new System.Drawing.Point(128, 70);
            this.lblPersonnumberValue.Name = "lblPersonnumberValue";
            this.lblPersonnumberValue.Size = new System.Drawing.Size(126, 15);
            this.lblPersonnumberValue.TabIndex = 8;
            this.lblPersonnumberValue.Text = "lblPersonnumberValue";
            this.lblPersonnumberValue.Visible = false;
            // 
            // txtPersonnumber
            // 
            this.txtPersonnumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPersonnumber.BackColor = System.Drawing.Color.White;
            this.txtPersonnumber.Enabled = false;
            this.txtPersonnumber.Location = new System.Drawing.Point(128, 66);
            this.txtPersonnumber.MaxLength = 4;
            this.txtPersonnumber.Name = "txtPersonnumber";
            this.txtPersonnumber.Size = new System.Drawing.Size(251, 23);
            this.txtPersonnumber.TabIndex = 3;
            this.txtPersonnumber.Tag = "Personnumber";
            this.txtPersonnumber.TextChanged += new System.EventHandler(this.TextBoxValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.CausesValidation = false;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.79757F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.20243F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.CausesValidation = false;
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.79757F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.20243F));
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(18, 120);
            this.label1.MaximumSize = new System.Drawing.Size(88, 19);
            this.label1.MinimumSize = new System.Drawing.Size(88, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nachname:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(290, 163);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(89, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Übernehmen";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(290, 163);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(89, 23);
            this.btnCreate.TabIndex = 11;
            this.btnCreate.Tag = "btnCreate";
            this.btnCreate.Text = "Erstellen";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Visible = false;
            this.btnCreate.Click += new System.EventHandler(this.Button_Click);
            // 
            // UpdateCreatePersonForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(391, 211);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lblBirthdayValue);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblGenderValue);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dtpBirthdate);
            this.Controls.Add(this.txtPersonnumber);
            this.Controls.Add(this.lblBirthdate);
            this.Controls.Add(this.lblPersonnumberValue);
            this.Controls.Add(this.cbGender);
            this.Controls.Add(this.lblPersonnumber);
            this.Controls.Add(this.lblGender);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(393, 250);
            this.Name = "UpdateCreatePersonForm";
            this.Text = "Firma Manager";
            this.Shown += new System.EventHandler(this.UpdateCreatePersonForm_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusStrip;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblBirthdate;
        private System.Windows.Forms.DateTimePicker dtpBirthdate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblPersonnumber;
        private System.Windows.Forms.TextBox txtPersonnumber;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.Label lblPersonnumberValue;
        private System.Windows.Forms.Label lblGenderValue;
        private System.Windows.Forms.Label lblBirthdayValue;
        private System.Windows.Forms.Button btnCreate;
        public System.Windows.Forms.Label label1;
    }
}