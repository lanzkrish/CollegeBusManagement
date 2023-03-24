using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BusManagement
{
    public partial class BusSchedule : Form
    {
        public BusSchedule()
        {
            InitializeComponent();
            Loads();
        }

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BusMan;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader read;
        SqlDataAdapter drr;
        string id;
        bool Mode = true;
        bool log = LoginPage.SetValueForlog;
        string sql;

        public void Loads()
        {
            try
            {
                sql = "select * from schedule where BusNo = ' " + Bussearch.SetValueForBusno + "'";
                cmd = new SqlCommand(sql, con);
                con.Open();

                read = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();

                while (read.Read())
                {
                    dataGridView1.Rows.Add(read[1], read[2], read[3]);
                }
                con.Close();
                if (log == false)
                {
                    home.Text = "Admin Page";
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void goback_Click(object sender, EventArgs e)
        {
            this.Close();
            Bussearch bs = new Bussearch();
            bs.Show();
        }

        private void home_Click(object sender, EventArgs e)
        {
            if (log == false)
            {
                this.Close();
                AdminPage a = new AdminPage();
                a.Show();

            }
            else
            {
                this.Close();
                HomePage h = new HomePage();   
                h.Show();
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            Loads();
        }
    }
}
