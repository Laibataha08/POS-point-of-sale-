using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public string username ;
        public string password ;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            verification();
        }

        public void verification()
        {
            username = textBox1.Text;
            password = textBox2.Text;

            if (username == "laiba" && password == "12345")
            {
                Admin admin = new Admin();
                admin.Show();
            }

            else if (username != "laiba" && password != "12345")
            {
                verification_seller();
            }
        }

            public void verification_seller()
        {
            admin_curd user = admin_curd.getInstance();
            int show = user.verifyUser(username, password);


            if (show == 1)
            {
                seller second = new seller();
                second.Show();
            }

        }


    }
    }
