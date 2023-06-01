using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frm_Dairy_Management_new
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {

        }

        private void dairyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_DairyInfo a = new Frm_DairyInfo();
            a.Show();
            a.MdiParent = this;
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Staffinfo a = new Frm_Staffinfo();
            a.Show();
            a.MdiParent = this;
        }

        private void suplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Supplierinfo a = new Frm_Supplierinfo();
            a.Show();
            a.MdiParent = this;
        }

        private void supplierScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_suppliershiftinfo a = new Frm_suppliershiftinfo();
            a.Show();
            a.MdiParent = this;
        }

        private void rateCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ratecard a = new Frm_ratecard();
            a.Show();
            a.MdiParent = this;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dailyDispatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Dispatchdetails a = new Frm_Dispatchdetails();
            a.Show();
            a.MdiParent= this;
        }

        private void dailySupplyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_dailysupply a = new Frm_dailysupply();
            a.Show();
            a.MdiParent = this;
        }

        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
