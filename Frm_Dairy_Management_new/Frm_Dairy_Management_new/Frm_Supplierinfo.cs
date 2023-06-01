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
    public partial class Frm_Supplierinfo : Form
    {
        SqlConnection con_str = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        static int id = 0;
        public Frm_Supplierinfo()
        {
            InitializeComponent();
            gridbind();
            clearfun();
        }

        void clearfun()
        {
            txt_supplier_adhar.Text = "";
            txt_supplier_name.Text = "";
            txt_supplier_area.Text = "";
            txt_supplier_bankaccountno.Text = "";
            txt_supplier_bankbranch.Text = "";
            txt_supplier_bankifsc.Text = "";
            txt_supplier_bankname.Text = "";
            txt_supplier_mobile.Text = "";
            rchtxt_supplier_address.Text = "";
            txt_supplier_village.Text = "";
        }
        private void btn_supplierinfo_save_Click(object sender, EventArgs e)
        {

            try
            {
                if (id == 0)
                {


                    SqlCommand cmd = new SqlCommand("insert into Supplier_Details(Supplier_Adhaar_No, Supplier_Name, Supplier_Address, Supplier_Area, Supplier_Village, Supplier_Bank_Name, Supplier_Bank_Branch, Supplier_Bank_AC_NO, Supplier_Bank_IFSC_NO, Supplier_Mobile_NO)values(@Supplier_Adhaar_No, @Supplier_Name, @Supplier_Address, @Supplier_Area, @Supplier_Village, @Supplier_Bank_Name, @Supplier_Bank_Branch, @Supplier_Bank_AC_NO, @Supplier_Bank_IFSC_NO, @Supplier_Mobile_NO);", con_str);
                    con_str.Open();
                    cmd.Parameters.AddWithValue("@Supplier_Adhaar_No", Convert.ToInt32(txt_supplier_adhar.Text));
                    cmd.Parameters.AddWithValue("@Supplier_Name", txt_supplier_name.Text);
                    cmd.Parameters.AddWithValue("@Supplier_Address", rchtxt_supplier_address.Text);
                    cmd.Parameters.AddWithValue("@Supplier_Area", txt_supplier_area.Text);
                    cmd.Parameters.AddWithValue("@Supplier_Village", txt_supplier_village.Text);
                    cmd.Parameters.AddWithValue("@Supplier_Bank_Name", txt_supplier_bankname.Text);
                    cmd.Parameters.AddWithValue("@Supplier_Bank_Branch", txt_supplier_bankbranch.Text);
                    cmd.Parameters.AddWithValue("@Supplier_Bank_AC_NO", Convert.ToInt32(txt_supplier_bankaccountno.Text));
                    cmd.Parameters.AddWithValue("@Supplier_Bank_IFSC_NO", (txt_supplier_bankifsc.Text));
                    cmd.Parameters.AddWithValue("@Supplier_Mobile_NO", Convert.ToInt32(txt_supplier_mobile.Text));
                    cmd.ExecuteNonQuery();
                    con_str.Close();
                    MessageBox.Show("Inserted sucessfully");
                    
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("update Supplier_Details set  Supplier_Name=@Supplier_Name, Supplier_Address=@Supplier_Address, Supplier_Area=@Supplier_Area, Supplier_Village=@Supplier_Village, Supplier_Bank_Name=@Supplier_Bank_Name, Supplier_Bank_Branch=@Supplier_Bank_Branch, Supplier_Bank_AC_NO=@Supplier_Bank_AC_NO, Supplier_Bank_IFSC_NO=@Supplier_Bank_IFSC_NO, Supplier_Mobile_NO=@Supplier_Mobile_NO where Supplier_Adhaar_No = '" + id + "'", con_str);
                    con_str.Open();
                    cmd.Parameters.AddWithValue("@Supplier_Adhaar_No",id);
                    cmd.Parameters.AddWithValue("@Supplier_Name", txt_supplier_name.Text);
                    cmd.Parameters.AddWithValue("@Supplier_Address", rchtxt_supplier_address.Text);
                    cmd.Parameters.AddWithValue("@Supplier_Area", txt_supplier_area.Text);
                    cmd.Parameters.AddWithValue("@Supplier_Village", txt_supplier_village.Text);
                    cmd.Parameters.AddWithValue("@Supplier_Bank_Name", txt_supplier_bankname.Text);
                    cmd.Parameters.AddWithValue("@Supplier_Bank_Branch", txt_supplier_bankbranch.Text);
                    cmd.Parameters.AddWithValue("@Supplier_Bank_AC_NO", Convert.ToString(txt_supplier_bankaccountno.Text));
                    cmd.Parameters.AddWithValue("@Supplier_Bank_IFSC_NO", (txt_supplier_bankifsc.Text));
                    cmd.Parameters.AddWithValue("@Supplier_Mobile_NO", Convert.ToInt32(txt_supplier_mobile.Text));
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

        private void btn_supplierinfo_clear_Click(object sender, EventArgs e)
        {
           clearfun();
        }
        void gridbind()
        {
            SqlCommand cmd = new SqlCommand("SELECT Supplier_Adhaar_No, Supplier_Name, Supplier_Mobile_NO FROM Supplier_Details ", con_str);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgv_supplierinfo.Visible = true;
                dgv_supplierinfo.DataSource = ds.Tables[0];
            }
            else
            {
                dgv_supplierinfo.Visible = false;
            }

        }

        private void dgv_supplierinfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dgv_supplierinfo.Rows[e.RowIndex].Cells[2].Value); 
            if(e.ColumnIndex == 0)
            {
                SqlCommand cmd = new SqlCommand("SELECT Supplier_Adhaar_No, Supplier_Name, Supplier_Address, Supplier_Area, Supplier_Village, Supplier_Bank_Name, Supplier_Bank_Branch, Supplier_Bank_AC_NO, Supplier_Bank_IFSC_NO, Supplier_Mobile_NO FROM Supplier_Details WHERE Supplier_Adhaar_No = '" + id + "' ", con_str);
                con_str.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                con_str.Close();
                txt_supplier_mobile.Text = Convert.ToString(ds.Tables[0].Rows[0]["Supplier_Mobile_NO"]);
                txt_supplier_name.Text = Convert.ToString(ds.Tables[0].Rows[0]["Supplier_Name"]);
                txt_supplier_adhar.Text = Convert.ToString(ds.Tables[0].Rows[0]["Supplier_Adhaar_No"]);
                rchtxt_supplier_address.Text = Convert.ToString(ds.Tables[0].Rows[0]["Supplier_Address"]);
                txt_supplier_area.Text = Convert.ToString(ds.Tables[0].Rows[0]["Supplier_Area"]);
                txt_supplier_village.Text = Convert.ToString(ds.Tables[0].Rows[0]["Supplier_Village"]);
                txt_supplier_bankname.Text = Convert.ToString(ds.Tables[0].Rows[0]["Supplier_Bank_Name"]);
                txt_supplier_bankbranch.Text = Convert.ToString(ds.Tables[0].Rows[0]["Supplier_Bank_Branch"]);
                txt_supplier_bankaccountno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Supplier_Bank_AC_NO"]);
                txt_supplier_bankifsc.Text = Convert.ToString(ds.Tables[0].Rows[0]["Supplier_Bank_IFSC_NO"]);

                txt_supplier_adhar.Enabled = false;
            }
            else if(e.ColumnIndex == 1)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Supplier_Details WHERE Supplier_Adhaar_No = '" + id + "' ", con_str);
                con_str.Open();
                cmd.ExecuteNonQuery();
                con_str.Close();
                MessageBox.Show("Deleted Successfully");
                id = 0;
                gridbind();
            }

        }
    }
}
