using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BusManagement
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BusMan;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader read;
        string id;
        bool Mode = true;
        bool log = true;
        string sql;

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage h1 = new HomePage();
            h1.Show();
            this.Close();
             
        }
        public static bool SetValueForlog = true;

        private void button1_Click(object sender, EventArgs e)
        {

            sql = "select count(*) from login where username='" + txtusername.Text + "' and password = '" + txtpassword.Text + "' ";
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            
            if (dt.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("Successfully Logged in");
                Mode= false;
                SetValueForlog= false;
                this.Close();
                AdminPage a1 = new AdminPage();
                a1.Show();
                
            }
            else
            {
                MessageBox.Show("user name and password is incorrect");
            }
        }
    }
}
