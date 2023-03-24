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
    public partial class adminsetting : Form
    {
        public adminsetting()
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
        string sql;

        public void Loads()
        {
            try
            {
                sql = "select * from login";
                cmd = new SqlCommand(sql, con);
                con.Open();

                read = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();

                while (read.Read())
                {
                    dataGridView1.Rows.Add(read[0],read[1], read[2], read[3], read[4]);
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
            sql = "select * from login where id ='" + id + "' ";

            cmd = new SqlCommand(sql, con);

            con.Open();
            read = cmd.ExecuteReader();

            while (read.Read())
            {
                txtname.Text = read[1].ToString();
                txtreg.Text = read[2].ToString();
                txtusername.Text = read[3].ToString();
                txtpassword.Text = read[4].ToString();
            }
            con.Close();
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
                sql = "delete from login where id = @id";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Records has been deleted");
                con.Close();
                Loads();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtname.Text;
            string reg  = txtreg.Text;
            string username = txtusername.Text;
            string password = txtpassword.Text;

            if (Mode == true)
            {
                sql = "insert into login(Name,registration,username,password) values(@Name,@registration,@username,@password)";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@registration", reg);
                cmd.Parameters.AddWithValue("@password",password );

                MessageBox.Show("Data has been recorded");
                cmd.ExecuteNonQuery();

                txtname.Clear();
                txtreg.Clear();
                txtusername.Clear();
                txtpassword.Clear();
            }
            else
            {
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                sql = "update login set Name=@Name, registration=@registration,username=@username, password=@password where id =@id ";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@registration", reg);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@id", id);

                MessageBox.Show("Data has been Updated");
                cmd.ExecuteNonQuery();

                txtname.Clear();
                txtreg.Clear();
                txtusername.Clear();
                txtpassword.Clear();

                button1.Text = "Save";
                Mode = true;
            }
            con.Close();
            Loads();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtname.Clear();
            txtreg.Clear();
            txtusername.Clear();
            txtpassword.Clear();

            button1.Text = "Save";
            Mode = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminPage ap = new AdminPage();
            ap.Show();
        }
    }
}
