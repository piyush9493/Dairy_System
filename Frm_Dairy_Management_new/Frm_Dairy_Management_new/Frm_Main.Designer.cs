namespace Frm_Dairy_Management_new
{
    partial class Frm_Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mastersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dairyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rateCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailySupplyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyDispatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recivablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mastersToolStripMenuItem,
            this.informationToolStripMenuItem,
            this.transactionsToolStripMenuItem,
            this.accountsToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(767, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mastersToolStripMenuItem
            // 
            this.mastersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dairyToolStripMenuItem,
            this.staffToolStripMenuItem,
            this.suplierToolStripMenuItem});
            this.mastersToolStripMenuItem.Name = "mastersToolStripMenuItem";
            this.mastersToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.mastersToolStripMenuItem.Text = "Masters";
            // 
            // dairyToolStripMenuItem
            // 
            this.dairyToolStripMenuItem.Name = "dairyToolStripMenuItem";
            this.dairyToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.dairyToolStripMenuItem.Text = "Dairy";
            this.dairyToolStripMenuItem.Click += new System.EventHandler(this.dairyToolStripMenuItem_Click);
            // 
            // staffToolStripMenuItem
            // 
            this.staffToolStripMenuItem.Name = "staffToolStripMenuItem";
            this.staffToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.staffToolStripMenuItem.Text = "Staff";
            this.staffToolStripMenuItem.Click += new System.EventHandler(this.staffToolStripMenuItem_Click);
            // 
            // suplierToolStripMenuItem
            // 
            this.suplierToolStripMenuItem.Name = "suplierToolStripMenuItem";
            this.suplierToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.suplierToolStripMenuItem.Text = "Suplier";
            this.suplierToolStripMenuItem.Click += new System.EventHandler(this.suplierToolStripMenuItem_Click);
            // 
            // informationToolStripMenuItem
            // 
            this.informationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rateCardToolStripMenuItem,
            this.supplierScheduleToolStripMenuItem});
            this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
            this.informationToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.informationToolStripMenuItem.Text = "Information";
            // 
            // rateCardToolStripMenuItem
            // 
            this.rateCardToolStripMenuItem.Name = "rateCardToolStripMenuItem";
            this.rateCardToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.rateCardToolStripMenuItem.Text = "Rate Card";
            this.rateCardToolStripMenuItem.Click += new System.EventHandler(this.rateCardToolStripMenuItem_Click);
            // 
            // supplierScheduleToolStripMenuItem
            // 
            this.supplierScheduleToolStripMenuItem.Name = "supplierScheduleToolStripMenuItem";
            this.supplierScheduleToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.supplierScheduleToolStripMenuItem.Text = "Supplier Schedule";
            this.supplierScheduleToolStripMenuItem.Click += new System.EventHandler(this.supplierScheduleToolStripMenuItem_Click);
            // 
            // transactionsToolStripMenuItem
            // 
            this.transactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dailySupplyToolStripMenuItem,
            this.dailyDispatchToolStripMenuItem});
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.transactionsToolStripMenuItem.Text = "Transactions";
            // 
            // dailySupplyToolStripMenuItem
            // 
            this.dailySupplyToolStripMenuItem.Name = "dailySupplyToolStripMenuItem";
            this.dailySupplyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dailySupplyToolStripMenuItem.Text = "Daily Supply";
            this.dailySupplyToolStripMenuItem.Click += new System.EventHandler(this.dailySupplyToolStripMenuItem_Click);
            // 
            // dailyDispatchToolStripMenuItem
            // 
            this.dailyDispatchToolStripMenuItem.Name = "dailyDispatchToolStripMenuItem";
            this.dailyDispatchToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dailyDispatchToolStripMenuItem.Text = "Daily Dispatch";
            this.dailyDispatchToolStripMenuItem.Click += new System.EventHandler(this.dailyDispatchToolStripMenuItem_Click);
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paymentsToolStripMenuItem,
            this.recivablesToolStripMenuItem});
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.accountsToolStripMenuItem.Text = "Accounts";
            // 
            // paymentsToolStripMenuItem
            // 
            this.paymentsToolStripMenuItem.Name = "paymentsToolStripMenuItem";
            this.paymentsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.paymentsToolStripMenuItem.Text = "Payments";
            this.paymentsToolStripMenuItem.Click += new System.EventHandler(this.paymentsToolStripMenuItem_Click);
            // 
            // recivablesToolStripMenuItem
            // 
            this.recivablesToolStripMenuItem.Name = "recivablesToolStripMenuItem";
            this.recivablesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.recivablesToolStripMenuItem.Text = "Recivables";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.logoutToolStripMenuItem.Text = "Logout";
            // 
            // Frm_Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mastersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dairyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rateCardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supplierScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailySupplyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyDispatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recivablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
    }
}

