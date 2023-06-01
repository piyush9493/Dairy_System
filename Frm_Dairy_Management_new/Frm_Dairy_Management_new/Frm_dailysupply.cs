using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Frm_Dairy_Management_new
{
    public partial class Frm_dailysupply : Form
    {
        SqlConnection con_str = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public Frm_dailysupply()
        {
            InitializeComponent();
            cmb_suuplier_namefill();
            cmb_suuplier_adharnofill();
            cmb_suuplier_staffnamefill();

            fillgrid();
        }

        void fillgrid()
        {
            try
            {
                string Supp_name = cmb_dailysupply_supliername.SelectedIndex.ToString();
                SqlCommand cmd = new SqlCommand("SELECT TOP 3 [Supplier_Name],[Supply_Date],[Supplier_Adhaar_No],[Shift_Name],[Milk_Type],[QTY],[FAT],[SNF],[Rate],[Staff_Member] FROM Supplier_Transaction WHERE Supplier_Name='"+ Supp_name + "' ORDER BY Supply_Date DESC",con_str);
                con_str.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgv_dairysupply_supptransaction.Visible = true;
                    dgv_dairysupply_supptransaction.DataSource = ds.Tables[0];
                }
                else
                {
                    dgv_dairysupply_supptransaction.Visible = false;
                }
                con_str.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_suppliertransaction_save_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into Supplier_Transaction([Supplier_Name],[Supply_Date],[Supplier_Adhaar_No],[Shift_Name],[Milk_Type],[QTY],[FAT],[SNF],[Rate],[Staff_Member])values(@Supplier_Name,@Supply_Date,@Supplier_Adhaar_No,@Shift_Name,@Milk_Type,@QTY,@FAT,@SNF,@Rate,@Staff_Member)", con_str);
                con_str.Open();

                cmd.Parameters.AddWithValue("@Supplier_Name", cmb_dailysupply_supliername.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Supply_Date", dtp_suppliertransaction_date.Value);
                cmd.Parameters.AddWithValue("@Supplier_Adhaar_No", cmb_dailysupply_suplieradhar.SelectedItem.ToString());
                if (rb_dailysupplymilktypebuffalo.Checked)
                {
                    cmd.Parameters.AddWithValue("@Milk_Type", "Buffalo");

                }
                else if (rb_dailysupplymilktypecow.Checked)
                {
                    cmd.Parameters.AddWithValue("@Milk_Type", "Cow");

                }
                if (rb_dailysupplyshiftmorning.Checked)
                {
                    cmd.Parameters.AddWithValue("@Shift_Name", "MOrning");

                }
                else if (rb_dailysupplyshiftevening.Checked)
                {
                    cmd.Parameters.AddWithValue("@Shift_Name", "Evening");

                }
                cmd.Parameters.AddWithValue("@QTY", txt_suppliertransaction_qty.Text);
                cmd.Parameters.AddWithValue("@FAT", txt_suppliertransaction_fat.Text);
                cmd.Parameters.AddWithValue("@SNF", txt_suppliertransaction_snf.Text);
                cmd.Parameters.AddWithValue("@Rate", txt_suppliertransaction_rate.Text);
                cmd.Parameters.AddWithValue("@Staff_Member", cmb_dailysupply_staffmember.SelectedItem.ToString());
                cmd.ExecuteNonQuery();
                con_str.Close();
                MessageBox.Show("inserted sucessfully");
                fillgrid();
                funclear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void cmb_suuplier_namefill()
        {
            try
            {
                cmb_dailysupply_supliername.Items.Clear();
                SqlCommand cmd = new SqlCommand("SELECT Supplier_Name, COUNT(Supplier_Name) FROM Supplier_Transaction GROUP BY Supplier_Name HAVING COUNT(Supplier_Name)>0", con_str);
                con_str.Open();
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    cmb_dailysupply_supliername.Items.Add(dr["Supplier_Name"].ToString());
                }
                con_str.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Frm_dailysupply_Load(object sender, EventArgs e)
        {
            //cmb_suuplier_namefill();
            //cmb_suuplier_adharnofill();
            //cmb_suuplier_staffnamefill();
            cmb_dailysupply_staffmember.SelectedIndex = -1;
        }

        private void cmb_dailysupply_supliername_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmb_dailysupply_supliername.SelectedItem.ToString() != null)
            {
                cmb_dailysupply_suplieradhar.Text = "";
                string Supp_name = cmb_dailysupply_supliername.SelectedIndex.ToString();
                SqlCommand cmd = new SqlCommand("SELECT Staff_Member,Supplier_Adhaar_No FROM Supplier_Transaction WHERE Staff_Member='" + Supp_name + "'",con_str);
                con_str.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string suppadhar = (string)dr["Supplier_Adhaar_No"].ToString();
                }
                con_str.Close();

            }
        }
        public void cmb_suuplier_adharnofill()
        {
            try
            {
                cmb_dailysupply_suplieradhar.Items.Clear();
                SqlCommand cmd = new SqlCommand("SELECT Supplier_Adhaar_No, COUNT(Supplier_Adhaar_No) FROM Supplier_Transaction GROUP BY Supplier_Adhaar_No HAVING COUNT(Supplier_Adhaar_No)>0", con_str);
                con_str.Open();
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    cmb_dailysupply_suplieradhar.Items.Add(dr["Supplier_Adhaar_No"].ToString());
                }
                con_str.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void cmb_suuplier_staffnamefill()
        {
            try
            {
                cmb_dailysupply_staffmember.Items.Clear();
                SqlCommand cmd = new SqlCommand("SELECT Staff_Member, COUNT(Staff_Member) FROM Supplier_Transaction GROUP BY Staff_Member HAVING COUNT(Staff_Member)>0", con_str);
                con_str.Open();
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    cmb_dailysupply_staffmember.Items.Add(dr["Staff_Member"].ToString());
                }
                con_str.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtp_suppliertransaction_date_ValueChanged(object sender, EventArgs e)
        {
            if(DateTime.Today <= dtp_suppliertransaction_date.Value)
            {
                MessageBox.Show("Date is Invalid...", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtp_suppliertransaction_date.Value = DateTime.Today;
            }
        }
        public void funclear()
        {
            txt_suppliertransaction_fat.Text = "";
            txt_suppliertransaction_qty.Text = "";
            txt_suppliertransaction_rate.Text = "";
            txt_suppliertransaction_snf.Text = "";
            cmb_dailysupply_staffmember.Items.Clear();
            dtp_suppliertransaction_date = null;
            cmb_dailysupply_suplieradhar.Items.Clear();
            cmb_dailysupply_supliername.Items.Clear();
            rb_dailysupplymilktypebuffalo.Checked = false;
            rb_dailysupplymilktypecow.Checked = false;
            rb_dailysupplyshiftevening.Checked = false;
            rb_dailysupplyshiftmorning.Checked = false;


        }

        private void btn_suppliertransaction_clear_Click(object sender, EventArgs e)
        {
            funclear();
        }

    }
}
