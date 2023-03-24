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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BusManagement
{
    public partial class Students : Form
    {
        public Students()
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
                sql = "select * from student order by Name";
                cmd = new SqlCommand(sql, con);
                con.Open();

                read = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();

                while (read.Read())
                {
                    dataGridView1.Rows.Add(read[0], read[1], read[2], read[3], read[4], read[5]);
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
            sql = "select * from student where id ='" + id + "' ";

            cmd = new SqlCommand(sql, con);

            con.Open();
            read = cmd.ExecuteReader();

            while (read.Read())
            {
                txtname.Text = read[1].ToString();
                txtreg.Text = read[2].ToString();
                txtlocation.Text = read[3].ToString();
                txtcontact.Text = read[4].ToString();
                txtbusno.Text = read[5].ToString();
            }
            con.Close();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminPage ap   = new AdminPage();
            ap.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtname.Text;
            string reg = txtreg.Text;
            string location = txtlocation.Text;
            string contact = txtcontact.Text;
            string busno = txtbusno.Text;

            if (Mode == true)
            {
                sql = "insert into student(Name,registration,location,contact,BusNo) values(@Name,@registration,@location, @contact, @BusNo)";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@registration", reg);
                cmd.Parameters.AddWithValue("@location", location);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@BusNo", busno);

                MessageBox.Show("Data has been recorded");
                cmd.ExecuteNonQuery();

                txtname.Clear();
                txtreg.Clear();
                txtlocation.Clear();
                txtcontact.Clear();
                txtbusno.Clear();

            }
            else
            {
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                sql = "update student set Name=@Name, registration=@registration,location=@location,contact=@contact,BusNo=@BusNo where id =@id ";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@registration", reg);
                cmd.Parameters.AddWithValue("@location", location);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@BusNo", busno);
                cmd.Parameters.AddWithValue("@id", id);

                MessageBox.Show("Data has been Updated");
                cmd.ExecuteNonQuery();

                txtname.Clear();
                txtreg.Clear();
                txtlocation.Clear();
                txtcontact.Clear();
                txtbusno.Clear();

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
            txtlocation.Clear();
            txtcontact.Clear();
            txtbusno.Clear();

            button1.Text = "Save";
            Mode = true;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
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
                
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                sql = "delete from student where id = @id";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Records has been deleted");
                button1.Text = "Save";
                Mode = true;
                con.Close();
                Loads();
            }
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }
    }
}
