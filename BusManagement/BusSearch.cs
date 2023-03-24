using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BusManagement
{
    public partial class Bussearch : Form
    {
        public Bussearch()
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
                sql = "select BusNo from Businfo order by BusNo";
                cmd = new SqlCommand(sql, con);
                con.Open();

                read = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();

                while (read.Read())
                {
                    dataGridView1.Rows.Add(read[0]);
                }
                con.Close();

                if (log == false)
                {
                    button3.Text = "AdminPage";
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void getID(string id)
        {
            sql = "select * from Businfo where BusNo ='" + id + "' ";

            cmd = new SqlCommand(sql, con);

            con.Open();
            read = cmd.ExecuteReader();

            while (read.Read())
            {
                txtBusno.Text = read[6].ToString();
                
            }
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Search"].Index && e.RowIndex >= 0)
            {
                Mode = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                getID(id);
                button1.Text = "Search Bus no. "+ id;
                

            }
        }

        public static string SetValueForBusno = "";


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Mode == true)
                {
                    sql = "select count(*) from schedule where BusNo ='" + txtBusno.Text + "'";
                    SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    cmd.Fill(dt);

                    if (dt.Rows[0][0].ToString() != "0")
                    {
                        SetValueForBusno = txtBusno.Text;
                        this.Close();
                        BusSchedule f4 = new BusSchedule();
                        f4.Show();
                    }
                    else
                    {
                        MessageBox.Show("Details not Found");
                    }

                }


                else
                {
                    sql = "select count(*) from schedule where BusNo ='" + txtBusno.Text + "'";
                    SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    cmd.Fill(dt);

                    if (dt.Rows[0][0].ToString() != "0")
                    {
                        SetValueForBusno = id;
                        this.Close();
                        BusSchedule f4 = new BusSchedule();
                        f4.Show();
                    }
                    else
                    {
                        MessageBox.Show("Details not Found");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            txtBusno.Clear();
            button1.Text = "Search";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (log == false)
            {
                this.Close();
                AdminPage ap = new AdminPage();
                ap.Show();  
            }
            else
            {
                this.Close();
                HomePage hp = new HomePage();
                hp.Show();
            }
            
        }

        private void Bussearch_Load(object sender, EventArgs e)
        {

        }
    }
}
