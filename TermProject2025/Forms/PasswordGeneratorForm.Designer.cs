namespace TermProject2025.Forms
{
    partial class PasswordGeneratorForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.lblLength = new System.Windows.Forms.Label();
            this.trackBarLength = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.chkUppercase = new System.Windows.Forms.CheckBox();
            this.chkLowercase = new System.Windows.Forms.CheckBox();
            this.chkNumbers = new System.Windows.Forms.CheckBox();
            this.chkSpecial = new System.Windows.Forms.CheckBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.groupBoxPresets = new System.Windows.Forms.GroupBox();
            this.btnPresetStrong = new System.Windows.Forms.Button();
            this.btnPresetMedium = new System.Windows.Forms.Button();
            this.btnPresetPIN = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnUsePassword = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBoxOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLength)).BeginInit();
            this.groupBoxPresets.SuspendLayout();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(120, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(180, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Password Generator";
            //
            // groupBoxOptions
            //
            this.groupBoxOptions.Controls.Add(this.chkSpecial);
            this.groupBoxOptions.Controls.Add(this.chkNumbers);
            this.groupBoxOptions.Controls.Add(this.chkLowercase);
            this.groupBoxOptions.Controls.Add(this.chkUppercase);
            this.groupBoxOptions.Controls.Add(this.label1);
            this.groupBoxOptions.Controls.Add(this.trackBarLength);
            this.groupBoxOptions.Controls.Add(this.lblLength);
            this.groupBoxOptions.Location = new System.Drawing.Point(20, 60);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(380, 180);
            this.groupBoxOptions.TabIndex = 1;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            //
            // lblLength
            //
            this.lblLength.AutoSize = true;
            this.lblLength.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLength.Location = new System.Drawing.Point(340, 30);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(28, 21);
            this.lblLength.TabIndex = 0;
            this.lblLength.Text = "16";
            //
            // trackBarLength
            //
            this.trackBarLength.Location = new System.Drawing.Point(80, 25);
            this.trackBarLength.Maximum = 64;
            this.trackBarLength.Minimum = 8;
            this.trackBarLength.Name = "trackBarLength";
            this.trackBarLength.Size = new System.Drawing.Size(250, 45);
            this.trackBarLength.TabIndex = 1;
            this.trackBarLength.Value = 16;
            this.trackBarLength.ValueChanged += new System.EventHandler(this.trackBarLength_ValueChanged);
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Length:";
            //
            // chkUppercase
            //
            this.chkUppercase.AutoSize = true;
            this.chkUppercase.Checked = true;
            this.chkUppercase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUppercase.Location = new System.Drawing.Point(15, 80);
            this.chkUppercase.Name = "chkUppercase";
            this.chkUppercase.Size = new System.Drawing.Size(170, 19);
            this.chkUppercase.TabIndex = 3;
            this.chkUppercase.Text = "Uppercase Letters (A-Z)";
            this.chkUppercase.UseVisualStyleBackColor = true;
            //
            // chkLowercase
            //
            this.chkLowercase.AutoSize = true;
            this.chkLowercase.Checked = true;
            this.chkLowercase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLowercase.Location = new System.Drawing.Point(15, 105);
            this.chkLowercase.Name = "chkLowercase";
            this.chkLowercase.Size = new System.Drawing.Size(165, 19);
            this.chkLowercase.TabIndex = 4;
            this.chkLowercase.Text = "Lowercase Letters (a-z)";
            this.chkLowercase.UseVisualStyleBackColor = true;
            //
            // chkNumbers
            //
            this.chkNumbers.AutoSize = true;
            this.chkNumbers.Checked = true;
            this.chkNumbers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNumbers.Location = new System.Drawing.Point(15, 130);
            this.chkNumbers.Name = "chkNumbers";
            this.chkNumbers.Size = new System.Drawing.Size(115, 19);
            this.chkNumbers.TabIndex = 5;
            this.chkNumbers.Text = "Numbers (0-9)";
            this.chkNumbers.UseVisualStyleBackColor = true;
            //
            // chkSpecial
            //
            this.chkSpecial.AutoSize = true;
            this.chkSpecial.Checked = true;
            this.chkSpecial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSpecial.Location = new System.Drawing.Point(15, 155);
            this.chkSpecial.Name = "chkSpecial";
            this.chkSpecial.Size = new System.Drawing.Size(180, 19);
            this.chkSpecial.TabIndex = 6;
            this.chkSpecial.Text = "Special Characters (!@#$...)";
            this.chkSpecial.UseVisualStyleBackColor = true;
            //
            // btnGenerate
            //
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerate.Location = new System.Drawing.Point(20, 250);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(380, 40);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate Password";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            //
            // groupBoxPresets
            //
            this.groupBoxPresets.Controls.Add(this.btnPresetPIN);
            this.groupBoxPresets.Controls.Add(this.btnPresetMedium);
            this.groupBoxPresets.Controls.Add(this.btnPresetStrong);
            this.groupBoxPresets.Location = new System.Drawing.Point(20, 300);
            this.groupBoxPresets.Name = "groupBoxPresets";
            this.groupBoxPresets.Size = new System.Drawing.Size(380, 60);
            this.groupBoxPresets.TabIndex = 3;
            this.groupBoxPresets.TabStop = false;
            this.groupBoxPresets.Text = "Presets (Director Pattern)";
            //
            // btnPresetStrong
            //
            this.btnPresetStrong.Location = new System.Drawing.Point(15, 25);
            this.btnPresetStrong.Name = "btnPresetStrong";
            this.btnPresetStrong.Size = new System.Drawing.Size(110, 25);
            this.btnPresetStrong.TabIndex = 0;
            this.btnPresetStrong.Text = "Strong";
            this.btnPresetStrong.UseVisualStyleBackColor = true;
            this.btnPresetStrong.Click += new System.EventHandler(this.btnPresetStrong_Click);
            //
            // btnPresetMedium
            //
            this.btnPresetMedium.Location = new System.Drawing.Point(135, 25);
            this.btnPresetMedium.Name = "btnPresetMedium";
            this.btnPresetMedium.Size = new System.Drawing.Size(110, 25);
            this.btnPresetMedium.TabIndex = 1;
            this.btnPresetMedium.Text = "Medium";
            this.btnPresetMedium.UseVisualStyleBackColor = true;
            this.btnPresetMedium.Click += new System.EventHandler(this.btnPresetMedium_Click);
            //
            // btnPresetPIN
            //
            this.btnPresetPIN.Location = new System.Drawing.Point(255, 25);
            this.btnPresetPIN.Name = "btnPresetPIN";
            this.btnPresetPIN.Size = new System.Drawing.Size(110, 25);
            this.btnPresetPIN.TabIndex = 2;
            this.btnPresetPIN.Text = "PIN (8 digits)";
            this.btnPresetPIN.UseVisualStyleBackColor = true;
            this.btnPresetPIN.Click += new System.EventHandler(this.btnPresetPIN_Click);
            //
            // txtPassword
            //
            this.txtPassword.Font = new System.Drawing.Font("Consolas", 12F);
            this.txtPassword.Location = new System.Drawing.Point(20, 370);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(380, 26);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // btnCopy
            //
            this.btnCopy.Location = new System.Drawing.Point(20, 410);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(120, 30);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            //
            // btnUsePassword
            //
            this.btnUsePassword.Location = new System.Drawing.Point(150, 410);
            this.btnUsePassword.Name = "btnUsePassword";
            this.btnUsePassword.Size = new System.Drawing.Size(120, 30);
            this.btnUsePassword.TabIndex = 6;
            this.btnUsePassword.Text = "Use This Password";
            this.btnUsePassword.UseVisualStyleBackColor = true;
            this.btnUsePassword.Click += new System.EventHandler(this.btnUsePassword_Click);
            //
            // btnClose
            //
            this.btnClose.Location = new System.Drawing.Point(280, 410);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 30);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // PasswordGeneratorForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 460);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUsePassword);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.groupBoxPresets);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordGeneratorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Password Generator";
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLength)).EndInit();
            this.groupBoxPresets.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.CheckBox chkSpecial;
        private System.Windows.Forms.CheckBox chkNumbers;
        private System.Windows.Forms.CheckBox chkLowercase;
        private System.Windows.Forms.CheckBox chkUppercase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarLength;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.GroupBox groupBoxPresets;
        private System.Windows.Forms.Button btnPresetPIN;
        private System.Windows.Forms.Button btnPresetMedium;
        private System.Windows.Forms.Button btnPresetStrong;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnUsePassword;
        private System.Windows.Forms.Button btnClose;
    }
}
