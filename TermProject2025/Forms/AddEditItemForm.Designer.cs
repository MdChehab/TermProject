namespace TermProject2025.Forms
{
    partial class AddEditItemForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblItemType = new System.Windows.Forms.Label();
            this.cmbItemType = new System.Windows.Forms.ComboBox();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.btnGeneratePassword = new System.Windows.Forms.Button();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtLoginName = new System.Windows.Forms.TextBox();
            this.lblLoginName = new System.Windows.Forms.Label();
            this.panelCreditCard = new System.Windows.Forms.Panel();
            this.dtpExpiration = new System.Windows.Forms.DateTimePicker();
            this.lblExpiration = new System.Windows.Forms.Label();
            this.txtBillingAddress = new System.Windows.Forms.TextBox();
            this.lblBillingAddress = new System.Windows.Forms.Label();
            this.txtCVV = new System.Windows.Forms.TextBox();
            this.lblCVV = new System.Windows.Forms.Label();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.lblCardNumber = new System.Windows.Forms.Label();
            this.txtCardholderName = new System.Windows.Forms.TextBox();
            this.lblCardholderName = new System.Windows.Forms.Label();
            this.panelIdentity = new System.Windows.Forms.Panel();
            this.dtpLicenseExp = new System.Windows.Forms.DateTimePicker();
            this.lblLicenseExp = new System.Windows.Forms.Label();
            this.dtpPassportExp = new System.Windows.Forms.DateTimePicker();
            this.lblPassportExp = new System.Windows.Forms.Label();
            this.txtSSN = new System.Windows.Forms.TextBox();
            this.lblSSN = new System.Windows.Forms.Label();
            this.txtLicenseNumber = new System.Windows.Forms.TextBox();
            this.lblLicenseNumber = new System.Windows.Forms.Label();
            this.txtPassportNumber = new System.Windows.Forms.TextBox();
            this.lblPassportNumber = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.panelSecureNote = new System.Windows.Forms.Panel();
            this.txtNoteContent = new System.Windows.Forms.TextBox();
            this.lblNoteContent = new System.Windows.Forms.Label();
            this.txtNoteTitle = new System.Windows.Forms.TextBox();
            this.lblNoteTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelLogin.SuspendLayout();
            this.panelCreditCard.SuspendLayout();
            this.panelIdentity.SuspendLayout();
            this.panelSecureNote.SuspendLayout();
            this.SuspendLayout();
            //
            // lblItemType
            //
            this.lblItemType.AutoSize = true;
            this.lblItemType.Location = new System.Drawing.Point(20, 20);
            this.lblItemType.Name = "lblItemType";
            this.lblItemType.Size = new System.Drawing.Size(60, 15);
            this.lblItemType.TabIndex = 0;
            this.lblItemType.Text = "Item Type:";
            //
            // cmbItemType
            //
            this.cmbItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemType.Location = new System.Drawing.Point(90, 17);
            this.cmbItemType.Name = "cmbItemType";
            this.cmbItemType.Size = new System.Drawing.Size(200, 23);
            this.cmbItemType.TabIndex = 1;
            this.cmbItemType.SelectedIndexChanged += new System.EventHandler(this.cmbItemType_SelectedIndexChanged);
            //
            // panelLogin
            //
            this.panelLogin.Controls.Add(this.btnGeneratePassword);
            this.panelLogin.Controls.Add(this.txtNotes);
            this.panelLogin.Controls.Add(this.lblNotes);
            this.panelLogin.Controls.Add(this.txtUrl);
            this.panelLogin.Controls.Add(this.lblUrl);
            this.panelLogin.Controls.Add(this.txtPassword);
            this.panelLogin.Controls.Add(this.lblPassword);
            this.panelLogin.Controls.Add(this.txtUsername);
            this.panelLogin.Controls.Add(this.lblUsername);
            this.panelLogin.Controls.Add(this.txtLoginName);
            this.panelLogin.Controls.Add(this.lblLoginName);
            this.panelLogin.Location = new System.Drawing.Point(20, 60);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(560, 320);
            this.panelLogin.TabIndex = 2;
            //
            // btnGeneratePassword
            //
            this.btnGeneratePassword.Location = new System.Drawing.Point(420, 90);
            this.btnGeneratePassword.Name = "btnGeneratePassword";
            this.btnGeneratePassword.Size = new System.Drawing.Size(120, 23);
            this.btnGeneratePassword.TabIndex = 10;
            this.btnGeneratePassword.Text = "Generate";
            this.btnGeneratePassword.UseVisualStyleBackColor = true;
            this.btnGeneratePassword.Click += new System.EventHandler(this.btnGeneratePassword_Click);
            //
            // lblLoginName
            //
            this.lblLoginName.AutoSize = true;
            this.lblLoginName.Location = new System.Drawing.Point(10, 10);
            this.lblLoginName.Name = "lblLoginName";
            this.lblLoginName.Size = new System.Drawing.Size(42, 15);
            this.lblLoginName.TabIndex = 0;
            this.lblLoginName.Text = "Name:";
            //
            // txtLoginName
            //
            this.txtLoginName.Location = new System.Drawing.Point(100, 7);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Size = new System.Drawing.Size(440, 23);
            this.txtLoginName.TabIndex = 1;
            //
            // lblUsername
            //
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(10, 45);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(63, 15);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username:";
            //
            // txtUsername
            //
            this.txtUsername.Location = new System.Drawing.Point(100, 42);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(440, 23);
            this.txtUsername.TabIndex = 3;
            //
            // lblPassword
            //
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(10, 80);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(60, 15);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password:";
            //
            // txtPassword
            //
            this.txtPassword.Location = new System.Drawing.Point(100, 77);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(310, 23);
            this.txtPassword.TabIndex = 5;
            //
            // lblUrl
            //
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(10, 115);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(31, 15);
            this.lblUrl.TabIndex = 6;
            this.lblUrl.Text = "URL:";
            //
            // txtUrl
            //
            this.txtUrl.Location = new System.Drawing.Point(100, 112);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(440, 23);
            this.txtUrl.TabIndex = 7;
            //
            // lblNotes
            //
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(10, 150);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(41, 15);
            this.lblNotes.TabIndex = 8;
            this.lblNotes.Text = "Notes:";
            //
            // txtNotes
            //
            this.txtNotes.Location = new System.Drawing.Point(100, 147);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(440, 150);
            this.txtNotes.TabIndex = 9;
            //
            // panelCreditCard
            //
            this.panelCreditCard.Controls.Add(this.dtpExpiration);
            this.panelCreditCard.Controls.Add(this.lblExpiration);
            this.panelCreditCard.Controls.Add(this.txtBillingAddress);
            this.panelCreditCard.Controls.Add(this.lblBillingAddress);
            this.panelCreditCard.Controls.Add(this.txtCVV);
            this.panelCreditCard.Controls.Add(this.lblCVV);
            this.panelCreditCard.Controls.Add(this.txtCardNumber);
            this.panelCreditCard.Controls.Add(this.lblCardNumber);
            this.panelCreditCard.Controls.Add(this.txtCardholderName);
            this.panelCreditCard.Controls.Add(this.lblCardholderName);
            this.panelCreditCard.Location = new System.Drawing.Point(20, 60);
            this.panelCreditCard.Name = "panelCreditCard";
            this.panelCreditCard.Size = new System.Drawing.Size(560, 320);
            this.panelCreditCard.TabIndex = 3;
            this.panelCreditCard.Visible = false;
            //
            // lblCardholderName
            //
            this.lblCardholderName.AutoSize = true;
            this.lblCardholderName.Location = new System.Drawing.Point(10, 10);
            this.lblCardholderName.Name = "lblCardholderName";
            this.lblCardholderName.Size = new System.Drawing.Size(104, 15);
            this.lblCardholderName.TabIndex = 0;
            this.lblCardholderName.Text = "Cardholder Name:";
            //
            // txtCardholderName
            //
            this.txtCardholderName.Location = new System.Drawing.Point(130, 7);
            this.txtCardholderName.Name = "txtCardholderName";
            this.txtCardholderName.Size = new System.Drawing.Size(410, 23);
            this.txtCardholderName.TabIndex = 1;
            //
            // lblCardNumber
            //
            this.lblCardNumber.AutoSize = true;
            this.lblCardNumber.Location = new System.Drawing.Point(10, 45);
            this.lblCardNumber.Name = "lblCardNumber";
            this.lblCardNumber.Size = new System.Drawing.Size(80, 15);
            this.lblCardNumber.TabIndex = 2;
            this.lblCardNumber.Text = "Card Number:";
            //
            // txtCardNumber
            //
            this.txtCardNumber.Location = new System.Drawing.Point(130, 42);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(410, 23);
            this.txtCardNumber.TabIndex = 3;
            //
            // lblCVV
            //
            this.lblCVV.AutoSize = true;
            this.lblCVV.Location = new System.Drawing.Point(10, 115);
            this.lblCVV.Name = "lblCVV";
            this.lblCVV.Size = new System.Drawing.Size(32, 15);
            this.lblCVV.TabIndex = 6;
            this.lblCVV.Text = "CVV:";
            //
            // txtCVV
            //
            this.txtCVV.Location = new System.Drawing.Point(130, 112);
            this.txtCVV.MaxLength = 4;
            this.txtCVV.Name = "txtCVV";
            this.txtCVV.Size = new System.Drawing.Size(100, 23);
            this.txtCVV.TabIndex = 7;
            //
            // lblExpiration
            //
            this.lblExpiration.AutoSize = true;
            this.lblExpiration.Location = new System.Drawing.Point(10, 80);
            this.lblExpiration.Name = "lblExpiration";
            this.lblExpiration.Size = new System.Drawing.Size(95, 15);
            this.lblExpiration.TabIndex = 4;
            this.lblExpiration.Text = "Expiration Date:";
            //
            // dtpExpiration
            //
            this.dtpExpiration.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpiration.Location = new System.Drawing.Point(130, 77);
            this.dtpExpiration.Name = "dtpExpiration";
            this.dtpExpiration.Size = new System.Drawing.Size(200, 23);
            this.dtpExpiration.TabIndex = 5;
            //
            // lblBillingAddress
            //
            this.lblBillingAddress.AutoSize = true;
            this.lblBillingAddress.Location = new System.Drawing.Point(10, 150);
            this.lblBillingAddress.Name = "lblBillingAddress";
            this.lblBillingAddress.Size = new System.Drawing.Size(91, 15);
            this.lblBillingAddress.TabIndex = 8;
            this.lblBillingAddress.Text = "Billing Address:";
            //
            // txtBillingAddress
            //
            this.txtBillingAddress.Location = new System.Drawing.Point(130, 147);
            this.txtBillingAddress.Multiline = true;
            this.txtBillingAddress.Name = "txtBillingAddress";
            this.txtBillingAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBillingAddress.Size = new System.Drawing.Size(410, 100);
            this.txtBillingAddress.TabIndex = 9;
            //
            // panelIdentity
            //
            this.panelIdentity.AutoScroll = true;
            this.panelIdentity.Controls.Add(this.dtpLicenseExp);
            this.panelIdentity.Controls.Add(this.lblLicenseExp);
            this.panelIdentity.Controls.Add(this.dtpPassportExp);
            this.panelIdentity.Controls.Add(this.lblPassportExp);
            this.panelIdentity.Controls.Add(this.txtSSN);
            this.panelIdentity.Controls.Add(this.lblSSN);
            this.panelIdentity.Controls.Add(this.txtLicenseNumber);
            this.panelIdentity.Controls.Add(this.lblLicenseNumber);
            this.panelIdentity.Controls.Add(this.txtPassportNumber);
            this.panelIdentity.Controls.Add(this.lblPassportNumber);
            this.panelIdentity.Controls.Add(this.txtAddress);
            this.panelIdentity.Controls.Add(this.lblAddress);
            this.panelIdentity.Controls.Add(this.txtPhone);
            this.panelIdentity.Controls.Add(this.lblPhone);
            this.panelIdentity.Controls.Add(this.txtEmail);
            this.panelIdentity.Controls.Add(this.lblEmail);
            this.panelIdentity.Controls.Add(this.txtFullName);
            this.panelIdentity.Controls.Add(this.lblFullName);
            this.panelIdentity.Location = new System.Drawing.Point(20, 60);
            this.panelIdentity.Name = "panelIdentity";
            this.panelIdentity.Size = new System.Drawing.Size(560, 320);
            this.panelIdentity.TabIndex = 4;
            this.panelIdentity.Visible = false;
            //
            // lblFullName
            //
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(10, 10);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(64, 15);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "Full Name:";
            //
            // txtFullName
            //
            this.txtFullName.Location = new System.Drawing.Point(130, 7);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(410, 23);
            this.txtFullName.TabIndex = 1;
            //
            // lblEmail
            //
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(10, 45);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 15);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email:";
            //
            // txtEmail
            //
            this.txtEmail.Location = new System.Drawing.Point(130, 42);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(410, 23);
            this.txtEmail.TabIndex = 3;
            //
            // lblPhone
            //
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(10, 80);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(44, 15);
            this.lblPhone.TabIndex = 4;
            this.lblPhone.Text = "Phone:";
            //
            // txtPhone
            //
            this.txtPhone.Location = new System.Drawing.Point(130, 77);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 23);
            this.txtPhone.TabIndex = 5;
            //
            // lblAddress
            //
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(10, 115);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(52, 15);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "Address:";
            //
            // txtAddress
            //
            this.txtAddress.Location = new System.Drawing.Point(130, 112);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(410, 60);
            this.txtAddress.TabIndex = 7;
            //
            // lblPassportNumber
            //
            this.lblPassportNumber.AutoSize = true;
            this.lblPassportNumber.Location = new System.Drawing.Point(10, 185);
            this.lblPassportNumber.Name = "lblPassportNumber";
            this.lblPassportNumber.Size = new System.Drawing.Size(101, 15);
            this.lblPassportNumber.TabIndex = 8;
            this.lblPassportNumber.Text = "Passport Number:";
            //
            // txtPassportNumber
            //
            this.txtPassportNumber.Location = new System.Drawing.Point(130, 182);
            this.txtPassportNumber.Name = "txtPassportNumber";
            this.txtPassportNumber.Size = new System.Drawing.Size(200, 23);
            this.txtPassportNumber.TabIndex = 9;
            //
            // lblPassportExp
            //
            this.lblPassportExp.AutoSize = true;
            this.lblPassportExp.Location = new System.Drawing.Point(10, 220);
            this.lblPassportExp.Name = "lblPassportExp";
            this.lblPassportExp.Size = new System.Drawing.Size(112, 15);
            this.lblPassportExp.TabIndex = 10;
            this.lblPassportExp.Text = "Passport Expiration:";
            //
            // dtpPassportExp
            //
            this.dtpPassportExp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPassportExp.Location = new System.Drawing.Point(130, 217);
            this.dtpPassportExp.Name = "dtpPassportExp";
            this.dtpPassportExp.Size = new System.Drawing.Size(200, 23);
            this.dtpPassportExp.TabIndex = 11;
            //
            // lblLicenseNumber
            //
            this.lblLicenseNumber.AutoSize = true;
            this.lblLicenseNumber.Location = new System.Drawing.Point(10, 255);
            this.lblLicenseNumber.Name = "lblLicenseNumber";
            this.lblLicenseNumber.Size = new System.Drawing.Size(95, 15);
            this.lblLicenseNumber.TabIndex = 12;
            this.lblLicenseNumber.Text = "License Number:";
            //
            // txtLicenseNumber
            //
            this.txtLicenseNumber.Location = new System.Drawing.Point(130, 252);
            this.txtLicenseNumber.Name = "txtLicenseNumber";
            this.txtLicenseNumber.Size = new System.Drawing.Size(200, 23);
            this.txtLicenseNumber.TabIndex = 13;
            //
            // lblLicenseExp
            //
            this.lblLicenseExp.AutoSize = true;
            this.lblLicenseExp.Location = new System.Drawing.Point(10, 290);
            this.lblLicenseExp.Name = "lblLicenseExp";
            this.lblLicenseExp.Size = new System.Drawing.Size(106, 15);
            this.lblLicenseExp.TabIndex = 14;
            this.lblLicenseExp.Text = "License Expiration:";
            //
            // dtpLicenseExp
            //
            this.dtpLicenseExp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLicenseExp.Location = new System.Drawing.Point(130, 287);
            this.dtpLicenseExp.Name = "dtpLicenseExp";
            this.dtpLicenseExp.Size = new System.Drawing.Size(200, 23);
            this.dtpLicenseExp.TabIndex = 15;
            //
            // lblSSN
            //
            this.lblSSN.AutoSize = true;
            this.lblSSN.Location = new System.Drawing.Point(10, 325);
            this.lblSSN.Name = "lblSSN";
            this.lblSSN.Size = new System.Drawing.Size(32, 15);
            this.lblSSN.TabIndex = 16;
            this.lblSSN.Text = "SSN:";
            //
            // txtSSN
            //
            this.txtSSN.Location = new System.Drawing.Point(130, 322);
            this.txtSSN.Name = "txtSSN";
            this.txtSSN.Size = new System.Drawing.Size(200, 23);
            this.txtSSN.TabIndex = 17;
            //
            // panelSecureNote
            //
            this.panelSecureNote.Controls.Add(this.txtNoteContent);
            this.panelSecureNote.Controls.Add(this.lblNoteContent);
            this.panelSecureNote.Controls.Add(this.txtNoteTitle);
            this.panelSecureNote.Controls.Add(this.lblNoteTitle);
            this.panelSecureNote.Location = new System.Drawing.Point(20, 60);
            this.panelSecureNote.Name = "panelSecureNote";
            this.panelSecureNote.Size = new System.Drawing.Size(560, 320);
            this.panelSecureNote.TabIndex = 5;
            this.panelSecureNote.Visible = false;
            //
            // lblNoteTitle
            //
            this.lblNoteTitle.AutoSize = true;
            this.lblNoteTitle.Location = new System.Drawing.Point(10, 10);
            this.lblNoteTitle.Name = "lblNoteTitle";
            this.lblNoteTitle.Size = new System.Drawing.Size(33, 15);
            this.lblNoteTitle.TabIndex = 0;
            this.lblNoteTitle.Text = "Title:";
            //
            // txtNoteTitle
            //
            this.txtNoteTitle.Location = new System.Drawing.Point(70, 7);
            this.txtNoteTitle.Name = "txtNoteTitle";
            this.txtNoteTitle.Size = new System.Drawing.Size(470, 23);
            this.txtNoteTitle.TabIndex = 1;
            //
            // lblNoteContent
            //
            this.lblNoteContent.AutoSize = true;
            this.lblNoteContent.Location = new System.Drawing.Point(10, 45);
            this.lblNoteContent.Name = "lblNoteContent";
            this.lblNoteContent.Size = new System.Drawing.Size(54, 15);
            this.lblNoteContent.TabIndex = 2;
            this.lblNoteContent.Text = "Content:";
            //
            // txtNoteContent
            //
            this.txtNoteContent.Location = new System.Drawing.Point(70, 42);
            this.txtNoteContent.Multiline = true;
            this.txtNoteContent.Name = "txtNoteContent";
            this.txtNoteContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNoteContent.Size = new System.Drawing.Size(470, 255);
            this.txtNoteContent.TabIndex = 3;
            //
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(370, 400);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(480, 400);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // AddEditItemForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panelSecureNote);
            this.Controls.Add(this.panelIdentity);
            this.Controls.Add(this.panelCreditCard);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.cmbItemType);
            this.Controls.Add(this.lblItemType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Vault Item";
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.panelCreditCard.ResumeLayout(false);
            this.panelCreditCard.PerformLayout();
            this.panelIdentity.ResumeLayout(false);
            this.panelIdentity.PerformLayout();
            this.panelSecureNote.ResumeLayout(false);
            this.panelSecureNote.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblItemType;
        private System.Windows.Forms.ComboBox cmbItemType;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Button btnGeneratePassword;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtLoginName;
        private System.Windows.Forms.Label lblLoginName;
        private System.Windows.Forms.Panel panelCreditCard;
        private System.Windows.Forms.DateTimePicker dtpExpiration;
        private System.Windows.Forms.Label lblExpiration;
        private System.Windows.Forms.TextBox txtBillingAddress;
        private System.Windows.Forms.Label lblBillingAddress;
        private System.Windows.Forms.TextBox txtCVV;
        private System.Windows.Forms.Label lblCVV;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.Label lblCardNumber;
        private System.Windows.Forms.TextBox txtCardholderName;
        private System.Windows.Forms.Label lblCardholderName;
        private System.Windows.Forms.Panel panelIdentity;
        private System.Windows.Forms.DateTimePicker dtpLicenseExp;
        private System.Windows.Forms.Label lblLicenseExp;
        private System.Windows.Forms.DateTimePicker dtpPassportExp;
        private System.Windows.Forms.Label lblPassportExp;
        private System.Windows.Forms.TextBox txtSSN;
        private System.Windows.Forms.Label lblSSN;
        private System.Windows.Forms.TextBox txtLicenseNumber;
        private System.Windows.Forms.Label lblLicenseNumber;
        private System.Windows.Forms.TextBox txtPassportNumber;
        private System.Windows.Forms.Label lblPassportNumber;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Panel panelSecureNote;
        private System.Windows.Forms.TextBox txtNoteContent;
        private System.Windows.Forms.Label lblNoteContent;
        private System.Windows.Forms.TextBox txtNoteTitle;
        private System.Windows.Forms.Label lblNoteTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
