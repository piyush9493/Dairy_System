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
    public partial class Frm_Staffinfo : Form
    {
        SqlConnection con_str = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        static int id = 0;
        //string mode = "add";
        public Frm_Staffinfo()
        {
            InitializeComponent();
            gridbind();
            clearfun();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearfun();
        }

        private void btn_staffinfo_save_Click(object sender, EventArgs e)
        {

            try
            {
                if (id == 0)
                {

                    SqlCommand cmd = new SqlCommand("insert into Staff_Details(Staff_Adhaar_No, Staff_Name, Staff_Address, Staff_Area, Staff_village, Staff_city, Staff_Mobile_No)values(@Staff_Adhaar_No, @Staff_Name, @Staff_Address, @Staff_Area, @Staff_village, @Staff_city, @Staff_Mobile_No)", con_str);
                    con_str.Open();
                    cmd.Parameters.AddWithValue("@Staff_Adhaar_No", Convert.ToInt32(txt_staff_adhar.Text));
                    cmd.Parameters.AddWithValue("@Staff_Name", txt_staff_name.Text);
                    cmd.Parameters.AddWithValue("@Staff_Address", rchtxt_staff_address.Text);
                    cmd.Parameters.AddWithValue("@Staff_Area", txt_staff_area.Text);
                    cmd.Parameters.AddWithValue("@Staff_village", txt_staff_village.Text);
                    cmd.Parameters.AddWithValue("@Staff_city", txt_staff_city.Text);
                    cmd.Parameters.AddWithValue("@Staff_Mobile_No", Convert.ToInt32(txt_staff_mobile.Text));
                    cmd.ExecuteNonQuery();
                    con_str.Close();
                    MessageBox.Show("inserted sucessfully..........");
                    


                }
                else
                {
                    SqlCommand cmd = new SqlCommand("update Staff_Details set  Staff_Name=@Staff_Name, Staff_Address=@Staff_Address, Staff_Area=@Staff_Area, Staff_village=@Staff_village, Staff_city=@Staff_city, Staff_Mobile_No=@Staff_Mobile_No where Staff_Adhaar_No = '" + id + "'", con_str);
                    con_str.Open();
                    cmd.Parameters.AddWithValue("@Staff_Adhaar_No", id);
                    cmd.Parameters.AddWithValue("@Staff_Name", txt_staff_name.Text);
                    cmd.Parameters.AddWithValue("@Staff_Address", rchtxt_staff_address.Text);
                    cmd.Parameters.AddWithValue("@Staff_Area", txt_staff_area.Text);
                    cmd.Parameters.AddWithValue("@Staff_village", txt_staff_village.Text);
                    cmd.Parameters.AddWithValue("@Staff_city", txt_staff_city.Text);
                    cmd.Parameters.AddWithValue("@Staff_Mobile_No", Convert.ToInt32(txt_staff_mobile.Text));
                    cmd.ExecuteNonQuery();
                    con_str.Close();
                    MessageBox.Show("Updated sucessfully..........");
                    

                    id = 0;
                }
                gridbind();
                clearfun();


            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void gridbind()
        {
            SqlCommand cmd = new SqlCommand("SELECT Staff_name, Staff_Mobile_No, Staff_Adhaar_No from Staff_Details ", con_str);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            //dgv_staffinfo.DataSource = ds.Tables[0];

            if (ds.Tables[0].Rows.Count > 0)
            {
                dgv_staffinfo.Visible = true;
                dgv_staffinfo.DataSource = ds.Tables[0];
            }
            else
            {
                dgv_staffinfo.Visible = false;
            }

        }

        void clearfun()
        {
            txt_staff_adhar.Text = "";
            txt_staff_area.Text = "";
            txt_staff_city.Text = "";
            txt_staff_mobile.Text = "";
            txt_staff_name.Text = "";
            txt_staff_village.Text = "";
            rchtxt_staff_address.Text = "";
        }

        private void dgv_staffinfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dgv_staffinfo.Rows[e.RowIndex].Cells[4].Value);
                if (e.ColumnIndex == 0)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Staff_name, Staff_Address, Staff_Area, Staff_village, Staff_city, Staff_Mobile_No, Staff_Adhaar_No from Staff_Details WHERE Staff_Adhaar_No = '" + id + "' ", con_str);
                    con_str.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    con_str.Close();
                    txt_staff_area.Text = Convert.ToString(ds.Tables[0].Rows[0]["Staff_Area"]);
                    txt_staff_city.Text = Convert.ToString(ds.Tables[0].Rows[0]["Staff_city"]);
                    txt_staff_mobile.Text = Convert.ToString(ds.Tables[0].Rows[0]["Staff_Mobile_No"]);
                    txt_staff_name.Text = Convert.ToString(ds.Tables[0].Rows[0]["Staff_Name"]);
                    txt_staff_village.Text = Convert.ToString(ds.Tables[0].Rows[0]["Staff_village"]);
                    rchtxt_staff_address.Text = Convert.ToString(ds.Tables[0].Rows[0]["Staff_Address"]);
                    txt_staff_adhar.Text = Convert.ToString(ds.Tables[0].Rows[0]["Staff_Adhaar_No"]);
                    txt_staff_adhar.Enabled = false;
                }
                else if (e.ColumnIndex == 1)
                {
                    //id = Convert.ToInt32(dgv_staffinfo.Rows[e.RowIndex].Cells[4].Value);
                    //if(Mes)
                    SqlCommand cmd = new SqlCommand("DELETE FROM Staff_Details WHERE Staff_Adhaar_No = '" + id + "' ", con_str);
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

        private void Frm_Staffinfo_Load(object sender, EventArgs e)
        {

        }
    }
}
