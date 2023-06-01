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
    public partial class Frm_DairyInfo : Form
    {
        SqlConnection con_str = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        static int id = 0;
        public Frm_DairyInfo()
        {
            InitializeComponent();
            gridbind();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (id == 0)
                {

                    SqlCommand cmd = new SqlCommand("insert into dairy_info(dairy_name,dairy_address,dairy_contactno,dairy_email)values(@dairy_name,@dairy_address,@dairy_contactno,@dairy_email)", con_str);
                    con_str.Open();
                    cmd.Parameters.AddWithValue("@dairy_name", (txt_dairy_name.Text));
                    cmd.Parameters.AddWithValue("@dairy_email", txt_dairyinfo_email.Text);
                    cmd.Parameters.AddWithValue("@dairy_address", rchtxt_dairy_address.Text);
                    cmd.Parameters.AddWithValue("@dairy_contactno", Convert.ToInt32(txt_dairy_mobile.Text));
                    
                    cmd.ExecuteNonQuery();
                    con_str.Close();
                    MessageBox.Show("inserted sucessfully..........");
                    gridbind();

                }
                else
                {
                    //SqlCommand cmd = new SqlCommand("update dairy_info set dairy_name=@dairy_name, dairy_email=@dairy_email, dairy_address=@dairy_address, dairy_contactno=@dairy_contactno  where dairy_name = '" + id + "'", con_str);
                    //con_str.Open();
                    //cmd.Parameters.AddWithValue("@dairy_name", (txt_dairy_name.Text));
                    //cmd.Parameters.AddWithValue("@dairy_email", txt_dairyinfo_email.Text);
                    //cmd.Parameters.AddWithValue("@dairy_address", rchtxt_dairy_address.Text);
                    //cmd.Parameters.AddWithValue("@dairy_contactno", Convert.ToInt32(txt_dairy_mobile.Text));
                    //cmd.ExecuteNonQuery();
                    //con_str.Close();
                    //MessageBox.Show("Updated sucessfully..........");
                    //gridbind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void gridbind()
        {
            SqlCommand cmd = new SqlCommand("SELECT dairy_name,dairy_address,dairy_contactno,dairy_email from dairy_info ", con_str);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgv_dairyinfo.DataSource = ds.Tables[0];
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_dairyinfo_email.Text = "";
            rchtxt_dairy_address.Text = "";
            txt_dairy_mobile.Text = "";
            txt_dairy_name.Text = "";
            rchtxt_dairy_address.Text = "";
                
        }
    }
}
