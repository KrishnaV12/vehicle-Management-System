using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleShowRoomCSharp
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void vehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vehicles obj = new Vehicles();
            obj.ShowDialog();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer obj1 = new Customer();
            obj1.ShowDialog();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agents obj2 = new Agents();
            obj2.ShowDialog();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseVehicle obj3 = new PurchaseVehicle();
            obj3.ShowDialog();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Vehicles obj = new Vehicles();
            obj.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Customer obj1 = new Customer();
            obj1.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Agents obj2 = new Agents();
            obj2.ShowDialog();
        }
    }
}
