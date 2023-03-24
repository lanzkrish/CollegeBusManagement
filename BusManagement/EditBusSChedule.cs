using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusManagement
{
    public partial class EditBusSChedule : Form
    {
        public EditBusSChedule()
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void Load1()
        {
            try
            {
                sql = "select * from schedule where BusNo = '" + id + "' ";
                cmd = new SqlCommand(sql, con);
                con.Open();

                read = cmd.ExecuteReader();
                dataGridView2.Rows.Clear();


                while (read.Read())
                {
                    dataGridView2.Rows.Add(read[0], read[2], read[3]);

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
            sql = "select * from schedule where id ='" + id + "' ";

            cmd = new SqlCommand(sql, con);

            con.Open();
            read = cmd.ExecuteReader();

            while (read.Read())
            {
                txtbusno.Text = read[1].ToString();
                txtlocation.Text = read[2].ToString();
                txttiming.Text = read[3].ToString();

            }
            con.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Select"].Index && e.RowIndex >= 0)
            {
                
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                
                Load1();
            }
        }
      

        private void button2_Click(object sender, EventArgs e)
        {
            txtbusno.Clear();
            txtlocation.Clear();
            txttiming.Clear();
            Mode = true;
            button1.Text = "Save";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string busnos =txtbusno.Text;
            string locations =txtlocation.Text;
            string timings =txttiming.Text;
           
            if(Mode == true)
            {
                sql = "select count(*) from Businfo where id ='" + txtbusno.Text + "'";
                SqlDataAdapter cd = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                cd.Fill(dt);
                con.Close();
                if (dt.Rows[0][0].ToString() == "1")
                {
                    sql = "insert into schedule(BusNo,location,timing) values(@BusNo,@location,@timing)";
                    con.Open();
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@BusNo", busnos);
                    cmd.Parameters.AddWithValue("@location", locations);
                    cmd.Parameters.AddWithValue("@timing", timings);


                    MessageBox.Show("Data has been recorded");
                    cmd.ExecuteNonQuery();
                    con.Close();
                    txtbusno.Clear();
                    txtlocation.Clear();
                    txttiming.Clear();

                }
                else
                {
                    Mode = false;
                    MessageBox.Show("Bus no " + txtbusno.Text + " not Found");
                }
                
                

            }
            else
            {
                id = dataGridView2.CurrentRow.Cells[0].Value.ToString();

                sql = "update schedule set BusNo=@BusNo, location=@location, timing=@timing where id=@id";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@BusNo", busnos);
                cmd.Parameters.AddWithValue("@location", locations);
                cmd.Parameters.AddWithValue("@timing", timings);
                cmd.Parameters.AddWithValue("@id", id);

                MessageBox.Show("Data has been updated");
                button1.Text = "Save";
                cmd.ExecuteNonQuery();
                con.Close();
                txtbusno.Clear();
                txtlocation.Clear();
                txttiming.Clear();
                Mode = true;

            }


            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView2.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                Mode = false;
#pragma warning disable CS8601 // Possible null reference assignment.
                id = dataGridView2.CurrentRow.Cells[0].Value.ToString();
#pragma warning restore CS8601 // Possible null reference assignment.
                getID(id);
                button1.Text = "Update Bus no. " + id;
            }
            else if (e.ColumnIndex == dataGridView2.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                Mode = false;
                id = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                sql = "delete from schedule where id = @id";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Records has been deleted");
                con.Close();
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Load1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminPage ap = new AdminPage();
            ap.Show();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
