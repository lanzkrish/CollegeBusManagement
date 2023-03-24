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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
            loads();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BusMan;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader read;
        string id;
        bool Mode = true;
        string sql;
        private void loads()
        {
            try
            {
                sql = "select * from student";
                cmd= new SqlCommand(sql, con);
                con.Open();
                read = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();

                while (read.Read())
                {
                    dataGridView1.Rows.Add(read[0],read[1], read[2], read[6]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void getId(string id)
        {
            sql = "select * from student where id ='" + id + "' ";

            cmd = new SqlCommand(sql, con);

            con.Open();
            read = cmd.ExecuteReader();

            while (read.Read())
            {
                txtname.Text = read[1].ToString();
                txtreg.Text = read[2].ToString();
                txtpay.Text = read[6].ToString();
            }
            con.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminPage ap    = new AdminPage();
            ap.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtname.Clear();
            txtpay.Clear();
            txtreg.Clear();

            button1.Text = "Save";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex== dataGridView1.Columns["Edit"].Index && e.RowIndex >=0)
            {
                Mode = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                getId(id);
                button1.Text = "Update";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtname.Text;
            string pay = txtpay.Text;
            string reg = txtreg.Text;

            try
            {


                sql = "select count(*) from student where Name ='" + txtname.Text + "' and Registration ='" + txtreg.Text + "'";
                SqlDataAdapter cd = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                cd.Fill(dt);
                con.Close();
                if (dt.Rows[0][0].ToString() == "1")
                {
                    if (Mode == true)
                    {
                        sql = "update student set payment=@payment where Name=@name and Registration=@registration";
                        con.Open();
                        cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@payment", pay);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@registration", reg);

                        MessageBox.Show("Data has been recoreded");
                        cmd.ExecuteNonQuery();

                        txtname.Clear();
                        txtpay.Clear();
                        txtreg.Clear();

                        con.Close();
                        loads();
                    }
                    else
                    {
                        sql = "update student set payment=@payment where Name=@name and Registration=@registration";
                        con.Open();
                        cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@payment", pay);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@registration", reg);

                        MessageBox.Show("Data has been updated");
                        cmd.ExecuteNonQuery();

                        txtname.Clear();
                        txtpay.Clear();
                        txtreg.Clear();

                        con.Close();
                        button1.Text = "Save";
                        loads();
                    }
                }
                else
                {
                    MessageBox.Show("No Data Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
            }
            



 
    }
}
