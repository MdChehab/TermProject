namespace TermProject2025.Forms
{
    partial class MainForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstVaultItems = new System.Windows.Forms.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colType = new System.Windows.Forms.ColumnHeader();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnPasswordGenerator = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblAutoLock = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNotificationCount = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            //
            // splitContainer1
            //
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            //
            // splitContainer1.Panel1
            //
            this.splitContainer1.Panel1.Controls.Add(this.btnLogout);
            this.splitContainer1.Panel1.Controls.Add(this.btnPasswordGenerator);
            this.splitContainer1.Panel1.Controls.Add(this.btnDeleteItem);
            this.splitContainer1.Panel1.Controls.Add(this.btnEditItem);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddItem);
            this.splitContainer1.Panel1.Controls.Add(this.lstVaultItems);
            //
            // splitContainer1.Panel2
            //
            this.splitContainer1.Panel2.Controls.Add(this.panelDetails);
            this.splitContainer1.Size = new System.Drawing.Size(1000, 550);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 0;
            //
            // lstVaultItems
            //
            this.lstVaultItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colType,
            this.colDate});
            this.lstVaultItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstVaultItems.FullRowSelect = true;
            this.lstVaultItems.Location = new System.Drawing.Point(0, 0);
            this.lstVaultItems.Name = "lstVaultItems";
            this.lstVaultItems.Size = new System.Drawing.Size(400, 450);
            this.lstVaultItems.TabIndex = 0;
            this.lstVaultItems.UseCompatibleStateImageBehavior = false;
            this.lstVaultItems.View = System.Windows.Forms.View.Details;
            this.lstVaultItems.SelectedIndexChanged += new System.EventHandler(this.lstVaultItems_SelectedIndexChanged);
            this.lstVaultItems.DoubleClick += new System.EventHandler(this.lstVaultItems_DoubleClick);
            //
            // colName
            //
            this.colName.Text = "Name";
            this.colName.Width = 200;
            //
            // colType
            //
            this.colType.Text = "Type";
            this.colType.Width = 100;
            //
            // colDate
            //
            this.colDate.Text = "Modified";
            this.colDate.Width = 95;
            //
            // btnAddItem
            //
            this.btnAddItem.Location = new System.Drawing.Point(10, 460);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(80, 30);
            this.btnAddItem.TabIndex = 1;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            //
            // btnEditItem
            //
            this.btnEditItem.Location = new System.Drawing.Point(95, 460);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(80, 30);
            this.btnEditItem.TabIndex = 2;
            this.btnEditItem.Text = "Edit Item";
            this.btnEditItem.UseVisualStyleBackColor = true;
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            //
            // btnDeleteItem
            //
            this.btnDeleteItem.Location = new System.Drawing.Point(180, 460);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(80, 30);
            this.btnDeleteItem.TabIndex = 3;
            this.btnDeleteItem.Text = "Delete";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            //
            // btnPasswordGenerator
            //
            this.btnPasswordGenerator.Location = new System.Drawing.Point(10, 495);
            this.btnPasswordGenerator.Name = "btnPasswordGenerator";
            this.btnPasswordGenerator.Size = new System.Drawing.Size(165, 30);
            this.btnPasswordGenerator.TabIndex = 4;
            this.btnPasswordGenerator.Text = "Password Generator";
            this.btnPasswordGenerator.UseVisualStyleBackColor = true;
            this.btnPasswordGenerator.Click += new System.EventHandler(this.btnPasswordGenerator_Click);
            //
            // btnLogout
            //
            this.btnLogout.Location = new System.Drawing.Point(180, 495);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(80, 30);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            //
            // panelDetails
            //
            this.panelDetails.AutoScroll = true;
            this.panelDetails.BackColor = System.Drawing.SystemColors.Window;
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.Location = new System.Drawing.Point(0, 0);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Padding = new System.Windows.Forms.Padding(10);
            this.panelDetails.Size = new System.Drawing.Size(596, 550);
            this.panelDetails.TabIndex = 0;
            //
            // statusStrip1
            //
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblAutoLock,
            this.lblNotificationCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 550);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1000, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            //
            // lblAutoLock
            //
            this.lblAutoLock.Name = "lblAutoLock";
            this.lblAutoLock.Size = new System.Drawing.Size(100, 17);
            this.lblAutoLock.Text = "Auto-lock in: 5:00";
            //
            // lblNotificationCount
            //
            this.lblNotificationCount.Name = "lblNotificationCount";
            this.lblNotificationCount.Size = new System.Drawing.Size(80, 17);
            this.lblNotificationCount.Text = "Notifications: 0";
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 572);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyPass - Vault";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lstVaultItems;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnPasswordGenerator;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblAutoLock;
        private System.Windows.Forms.ToolStripStatusLabel lblNotificationCount;
    }
}
