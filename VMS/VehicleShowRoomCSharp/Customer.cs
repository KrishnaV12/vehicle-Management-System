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
using System.IO;

namespace VehicleShowRoomCSharp
{
    public partial class Customer : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Alexander\Documents\Visual Studio 2012\Projects\VMS\VehicleShowRoomCSharp\bin\Debug\vehicle.mdf;Integrated Security=True");

        public Customer()
        {
            
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "C:\\";
            open.Filter = "Image Files(*.jpg)|*.jpg|All Files(*.*)|*.*";
            open.FilterIndex = 1;
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (open.CheckFileExists)
                {

                    try
                    {
                        string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                        String correctFilename = System.IO.Path.GetFileName(open.FileName);
                        System.IO.File.Copy(open.FileName, paths + "\\cust\\" + correctFilename);
                        pictureBox1.Image = new Bitmap(open.FileName);
                        label13.Text = correctFilename;
                        label10.Text = open.FileName;
                    }
                    catch
                    {
                        MessageBox.Show("Image is Already Exists.."); 
                    }    
                   
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                string str = " INSERT INTO cust(name,mobile,email,img_name,paths,t_addr,p_addr) VALUES('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + label13.Text + "','" + label10.Text  + "','" + textBox5.Text + "','" + textBox6.Text + "'); ";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();

                //-------------------------------------------//

                string str1 = "select max(Id) from cust;";

                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Customer's Information Inserted Successfully..");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    pictureBox1.Image = null;
                    label10.Text = "";
                    label13.Text = "";
                }
                this.Close();
            }
            catch (SqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            con.Close();   
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            con.Open();
            string str1 = "select max(id) from cust;";

            SqlCommand cmd1 = new SqlCommand(str1,con);
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    textBox1.Text = "1";
                }
                else
                {
                    int a;
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    textBox1.Text = a.ToString();
                }

            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox6.Text = textBox5.Text;
        }
    }



   
}
