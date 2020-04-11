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

namespace VehicleShowRoomCSharp
{
    public partial class Agents : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jimmi\Desktop\kashipara.com_vehicleshowroomcsharp-zip\VehicleShowRoomCSharp\VehicleShowRoomCSharp\bin\Debug\vehicle.mdf;Integrated Security=True");
        public Agents()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                string str = " INSERT INTO emp(name,contact,email,addr,educ,exper,doj,position,salary) VALUES('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text  + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "'); ";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();

                //-------------------------------------------//

                string str1 = "select max(Id) from emp;";

                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Employee's Information Inserted Successfully..");
                    using (con)
                    {

                        string str2 = "SELECT * FROM emp";
                        SqlCommand cmd2 = new SqlCommand(str2, con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView1.DataSource = new BindingSource(dt, null);
                    }
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";

                }
               
            }
            catch (SqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            con.Close();
        }

        private void Agents_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'vehicleDataSet.emp' table. You can move, or remove it, as needed.
            this.empTableAdapter.Fill(this.vehicleDataSet.emp);
            con.Open();
            string str1 = "select max(id) from emp;";

            SqlCommand cmd1 = new SqlCommand(str1, con);
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
            con.Open();
                try
                {
                    string getCust = "select name,contact,email,addr,educ,exper,doj,position,salary from emp where id=" + Convert.ToInt32(textBox1.Text) + " ;";

                    SqlCommand cmd = new SqlCommand(getCust, con);
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        textBox2.Text = dr.GetValue(0).ToString();
                        textBox3.Text = dr.GetValue(1).ToString();
                        textBox4.Text = dr.GetValue(2).ToString();
                        textBox5.Text = dr.GetValue(3).ToString();
                        textBox6.Text = dr.GetValue(4).ToString();
                        textBox7.Text = dr.GetValue(5).ToString();
                        textBox8.Text = dr.GetValue(6).ToString();
                        textBox9.Text = dr.GetValue(7).ToString();
                        textBox10.Text = dr.GetValue(8).ToString();
                        
                    }
                    else
                    {
                        MessageBox.Show(" Sorry ,,This ID, " + textBox1.Text + " Transportation Booking is not Available.   ");
                        textBox1.Text = "";
                    }
                }
                catch (SqlException excep)
                {
                    MessageBox.Show(excep.Message);
                }
                con.Close();
            }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                string str = " Update emp set name='" + textBox2.Text + "',contact='" + textBox3.Text + "',email='" + textBox4.Text + "',addr='" + textBox5.Text + "',educ='" + textBox6.Text + "',exper='" + textBox7.Text + "',doj='" + textBox8.Text + "',position='" + textBox9.Text + "',salary='" + textBox10.Text + "' where id='" + textBox1.Text + "'";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();

                string str1 = "select max(id) from emp;";

                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("" + textBox2.Text + "'s Details is Updated Successfully.. ", "Important Message");
                    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\Documents\Visual Studio 2015\Projects\VehicleShowRoomCSharp\VehicleShowRoomCSharp\vehicle.mdf;Integrated Security=True"))
                    {

                        string str2 = "SELECT * FROM emp";
                        SqlCommand cmd2 = new SqlCommand(str2, con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView1.DataSource = new BindingSource(dt, null);
                    }
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
                }
                
            }
            catch (SqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                con.Open();

                string str = "DELETE FROM emp WHERE id = '" + textBox1.Text + "'";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(" Agent Record Delete Successfully");
                using (con)
                {

                    string str2 = "SELECT * FROM emp";
                    SqlCommand cmd2 = new SqlCommand(str2, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = new BindingSource(dt, null);
                }
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Please Enter employee Id..");
            }
        }
    }
}
