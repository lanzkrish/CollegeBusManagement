using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusManagement
{
    public partial class AdminPage : Form
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginPage.SetValueForlog =true;
            HomePage h1= new HomePage();
            h1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Editview f1= new Editview();
            f1.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Businfo bf= new Businfo();
            bf.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            adminsetting ads = new adminsetting();
            ads.Show();
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Students f1= new Students();
            f1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Payment f10  = new Payment();
            f10.Show();
        }
    }
}
