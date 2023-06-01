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
    public partial class Frm_suppliershiftinfo : Form
    {
        SqlConnection con_str = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        static int id = 0;
        public Frm_suppliershiftinfo()
        {
            InitializeComponent();
            gridbind();
            clearfun();
        }

        private void btn_suppliershiftinfo_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (id == 0)
                {
                    SqlCommand cmd = new SqlCommand("insert into Supplier_Shift_Info([Supplier_Shift_Id],[Supplier_Adhaar_No],[Supplier_Milk_Type],[Duration_From],[Duration_To],[Shift])values(@supplier_shift_id,@supplier_adhaar_no,@supplier_milk_type,@duration_from,@duration_to,@shift)", con_str);
                    con_str.Open();

                    cmd.Parameters.AddWithValue("@supplier_shift_id", Convert.ToInt32(txt_suppliershiftinfo_id.Text));
                    cmd.Parameters.AddWithValue("@supplier_adhaar_no", txt_suppliershiftinfo_adharno.Text);
                    cmd.Parameters.AddWithValue("@supplier_milk_type", cmb_suppliershift_milktype.SelectedItem);
                    cmd.Parameters.AddWithValue("@duration_from", dtp_suppliershiftinfo_durationfrom.Value);
                    cmd.Parameters.AddWithValue("@duration_to", dtp_suppliershiftinfo_durationto.Value);
                    cmd.Parameters.AddWithValue("@shift", cmb_suppliershift_shift.SelectedItem);
                    cmd.ExecuteNonQuery();
                    con_str.Close();
                    MessageBox.Show("inserted sucessfully");
                    
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("update Supplier_Shift_Info set  supplier_shift_id=@supplier_shift_id, supplier_adhaar_no=@supplier_adhaar_no, supplier_milk_type=@supplier_milk_type, duration_from=@duration_from, duration_to=@duration_to, shift=@shift where supplier_shift_id = '" + id + "'", con_str);
                    con_str.Open();
                    cmd.Parameters.AddWithValue("@supplier_shift_id", id);
                    cmd.Parameters.AddWithValue("@supplier_adhaar_no", txt_suppliershiftinfo_adharno.Text);
                    cmd.Parameters.AddWithValue("@supplier_milk_type", cmb_suppliershift_milktype.SelectedItem);
                    cmd.Parameters.AddWithValue("@duration_from", dtp_suppliershiftinfo_durationfrom.Value);
                    cmd.Parameters.AddWithValue("@duration_to", dtp_suppliershiftinfo_durationto.Value);
                    cmd.Parameters.AddWithValue("@shift", cmb_suppliershift_shift.SelectedItem);
                    cmd.ExecuteNonQuery();
                    con_str.Close();
                    MessageBox.Show("Updated sucessfully..........");


                    id = 0;
                }
                gridbind();
                clearfun();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void clearfun()
        {
            cmb_suppliershift_shift.Text = "";
            txt_suppliershiftinfo_id.Text = "";
            txt_suppliershiftinfo_adharno.Text = "";
            cmb_suppliershift_milktype.Text = "";
            dtp_suppliershiftinfo_durationto.Text = "";
            dtp_suppliershiftinfo_durationfrom.Text = "";
        }

        private void btn_suppliershiftinfo_clear_Click(object sender, EventArgs e)
        {
            clearfun(); 
        }
        void gridbind()
        {
            SqlCommand cmd = new SqlCommand("SELECT [Supplier_Shift_Id],[Supplier_Adhaar_No],[Supplier_Milk_Type], [Shift] FROM Supplier_Shift_Info", con_str);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            //dgv_suppliershiftinfo.DataSource = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgv_suppliershiftinfo.Visible = true;
                dgv_suppliershiftinfo.DataSource = ds.Tables[0];
            }
            else
            {
                dgv_suppliershiftinfo.Visible = false;
            }


        }

        private void dgv_suppliershiftinfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dgv_suppliershiftinfo.Rows[e.RowIndex].Cells[2].Value);
                if (e.ColumnIndex == 0)
                {
                    SqlCommand cmd = new SqlCommand("SELECT [Supplier_Shift_Id],[Supplier_Adhaar_No],[Supplier_Milk_Type], [Shift],[Duration_From],[Duration_To] FROM Supplier_Shift_Info WHERE Supplier_Shift_Id = '" + id + "' ", con_str);
                    con_str.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    con_str.Close();
                    txt_suppliershiftinfo_id.Text = Convert.ToString(ds.Tables[0].Rows[0]["Supplier_Shift_Id"]);
                    txt_suppliershiftinfo_adharno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Supplier_Adhaar_No"]);
                    cmb_suppliershift_shift.Text = Convert.ToString(ds.Tables[0].Rows[0]["Shift"]);
                    cmb_suppliershift_milktype.Text = Convert.ToString(ds.Tables[0].Rows[0]["Supplier_Milk_Type"]);
                    dtp_suppliershiftinfo_durationfrom.Text = Convert.ToString(ds.Tables[0].Rows[0]["Duration_From"]);
                    dtp_suppliershiftinfo_durationto.Text = Convert.ToString(ds.Tables[0].Rows[0]["Duration_To"]);

                }
                else if (e.ColumnIndex == 1)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Supplier_Shift_Info WHERE Supplier_Shift_Id = '" + id + "' ", con_str);
                    con_str.Open();
                    cmd.ExecuteNonQuery();
                    con_str.Close();
                    MessageBox.Show("Deleted Successfully");
                    id = 0;
                    gridbind();

                }
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
            }
        }
    }
}
