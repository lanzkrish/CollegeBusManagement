namespace BusManagement
{
    partial class adminsetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adminsetting));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtreg = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.textpassword = new System.Windows.Forms.Label();
            this.textusername = new System.Windows.Forms.Label();
            this.txtre = new System.Windows.Forms.Label();
            this.txtiname = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtpassword);
            this.groupBox1.Controls.Add(this.txtusername);
            this.groupBox1.Controls.Add(this.txtreg);
            this.groupBox1.Controls.Add(this.txtname);
            this.groupBox1.Controls.Add(this.textpassword);
            this.groupBox1.Controls.Add(this.textusername);
            this.groupBox1.Controls.Add(this.txtre);
            this.groupBox1.Controls.Add(this.txtiname);
            this.groupBox1.Location = new System.Drawing.Point(31, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 174);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Admin";
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(103, 138);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(100, 23);
            this.txtpassword.TabIndex = 7;
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(103, 102);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(100, 23);
            this.txtusername.TabIndex = 6;
            // 
            // txtreg
            // 
            this.txtreg.Location = new System.Drawing.Point(103, 70);
            this.txtreg.Name = "txtreg";
            this.txtreg.Size = new System.Drawing.Size(100, 23);
            this.txtreg.TabIndex = 5;
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(103, 34);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(100, 23);
            this.txtname.TabIndex = 4;
            // 
            // textpassword
            // 
            this.textpassword.AutoSize = true;
            this.textpassword.Location = new System.Drawing.Point(10, 141);
            this.textpassword.Name = "textpassword";
            this.textpassword.Size = new System.Drawing.Size(57, 15);
            this.textpassword.TabIndex = 3;
            this.textpassword.Text = "Password";
            // 
            // textusername
            // 
            this.textusername.AutoSize = true;
            this.textusername.Location = new System.Drawing.Point(10, 105);
            this.textusername.Name = "textusername";
            this.textusername.Size = new System.Drawing.Size(65, 15);
            this.textusername.TabIndex = 2;
            this.textusername.Text = "User Name";
            // 
            // txtre
            // 
            this.txtre.AutoSize = true;
            this.txtre.Location = new System.Drawing.Point(10, 70);
            this.txtre.Name = "txtre";
            this.txtre.Size = new System.Drawing.Size(87, 15);
            this.txtre.TabIndex = 1;
            this.txtre.Text = "Registration no";
            // 
            // txtiname
            // 
            this.txtiname.AutoSize = true;
            this.txtiname.Location = new System.Drawing.Point(10, 34);
            this.txtiname.Name = "txtiname";
            this.txtiname.Size = new System.Drawing.Size(39, 15);
            this.txtiname.TabIndex = 0;
            this.txtiname.Text = "Name";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 53);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(213, 286);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 59);
            this.button2.TabIndex = 2;
            this.button2.Text = "clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Edit,
            this.Delete});
            this.dataGridView1.Location = new System.Drawing.Point(358, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(503, 208);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Registration no";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "username";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "password";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 80;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForButtonValue = true;
            this.Edit.Width = 50;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            this.Delete.Width = 50;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(556, 339);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(123, 59);
            this.button3.TabIndex = 4;
            this.button3.Text = "Go Back";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // adminsetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(881, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "adminsetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtusername;
        private TextBox txtreg;
        private TextBox txtname;
        private Label textpassword;
        private Label textusername;
        private Label txtre;
        private Label txtiname;
        private TextBox txtpassword;
        private Button button1;
        private Button button2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewButtonColumn Edit;
        private DataGridViewButtonColumn Delete;
        private Button button3;
    }
}