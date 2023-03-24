using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusManagement
{
    public partial class Editview : Form
    {
        public Editview()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Bussearch b1 = new Bussearch();
            b1.Show();
        }

        private void View_Click(object sender, EventArgs e)
        {
            this.Close();
            EditBusSChedule form7= new EditBusSChedule();
            form7.Show();
        }
    }
}
