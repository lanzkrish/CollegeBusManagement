using Microsoft.VisualBasic.Devices;
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
    public partial class Businfo : Form
    {
        public Businfo()
        {
            InitializeComponent();
            Loads();
        }

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BusMan;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader read;
        string id;
        bool Mode = true;
        string sql;

        public void Loads()
        {
            try
            {
                sql = "select * from Businfo order by BusNo";
                cmd = new SqlCommand(sql, con);
                con.Open();

                read = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();

                while (read.Read())
                {
                    dataGridView1.Rows.Add(read[0], read[6], read[1], read[2], read[3], read[5]);
                }
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void getID(string id)
        {
            sql = "select * from Businfo where id ='" + id + "' ";

            cmd = new SqlCommand(sql, con);

            con.Open();
            read = cmd.ExecuteReader();

            while (read.Read())
            {
                txtbusno.Text = read[6].ToString();
                txtplateno.Text = read[1].ToString();
                txtdrivername.Text = read[2].ToString();
                txthelpername.Text = read[3].ToString();
                txtcapacity.Text = read[5].ToString();
            }
            con.Close();
        }

        private void Businfo_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminPage ap = new AdminPage(); 
            ap.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Busno = txtbusno.Text;
            string plateno = txtplateno.Text;
            string drivername = txtdrivername.Text;
            string helpername = txthelpername.Text;
            string capacity = txtcapacity.Text;

            if (Mode == true)
            {
                sql = "insert into Businfo(BusNo,NumberPlate, driver, helper, capacity) values(@BusNo,@NumberPlate, @driver, @helper, @capacity)";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Busno", Busno);
                cmd.Parameters.AddWithValue("@NumberPlate", plateno);
                cmd.Parameters.AddWithValue("@driver", drivername);
                cmd.Parameters.AddWithValue("@helper", helpername);
                cmd.Parameters.AddWithValue("@capacity", capacity);

                MessageBox.Show("Data has been recorded");
                cmd.ExecuteNonQuery();

                txtbusno.Clear();
                txtplateno.Clear();
                txtdrivername.Clear();
                txthelpername.Clear();
                txtcapacity.Clear();
            }
            else
            {
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                sql = "update Businfo set BusNo=@BusNo, NumberPlate=@NumberPlate,driver=@driver, helper=@helper, capacity=@capacity where id =@id ";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@BusNo", Busno);
                cmd.Parameters.AddWithValue("@NumberPlate", plateno);
                cmd.Parameters.AddWithValue("@driver", drivername);
                cmd.Parameters.AddWithValue("@helper", helpername);
                cmd.Parameters.AddWithValue("@capacity", capacity);

                MessageBox.Show("Data has been Updated");
                cmd.ExecuteNonQuery();

                txtbusno.Clear();
                txtplateno.Clear();
                txtdrivername.Clear();
                txthelpername.Clear();
                txtcapacity.Clear();

                button1.Text = "Save";
                Mode = true;
            }
            con.Close();
            Loads();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Loads();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                Mode = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                getID(id);
                button1.Text = "Update";

            }
            else if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                Mode = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                sql = "delete from Businfo where id = @id";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Records has been deleted");
                con.Close();
                Loads();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtbusno.Clear();
            txtplateno.Clear();
            txtdrivername.Clear();
            txthelpername.Clear();
            txtcapacity.Clear();

            button1.Text = "Save";
            Mode = true;
        }
    }
}
