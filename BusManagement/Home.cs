namespace BusManagement
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage f2 = new LoginPage();
            f2.Show();
            
            
        }

        private void bustime_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bussearch f3 = new Bussearch();
            f3.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}