using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
namespace WindowsFormsApp1
{
    public partial class Admin : Form


    {
        public static string username;
        public static string password;
        public Admin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            adding();

        }

        public void adding()
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            admin_curd user = admin_curd.getInstance();
            user.addUser(username, password);


        }

        private void purchaseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            purchase p = new purchase();
            p.Show();
          

        }

        private void reportStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            username = textBox3.Text;
            password = textBox4.Text;
            update u = new update();
                u.Show();
               
            }

        private void viewAllSellersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewsellers v = new viewsellers();
            v.Show();
        }

        private void billToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bill b = new bill();
            b.Show();
        }

        private void billsBySellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            page p = new page();
            p.Show();
        }
    }

    class admin_info
    {
        public string username;
        public string password;
    
     }

    class admin_curd {
        public static ArrayList allUsers = new ArrayList();
        private static admin_curd a;

        public string filename = "";
        public string data = "";
        public int count = 0;
        public int value = 0;

        private admin_curd()
        {

        }

        public static admin_curd getInstance()
        {
            if (a == null)
            {
                a = new admin_curd();
            }
            return a;
        }

        public void addUser(string name, string password)
        {
            admin_info u = new admin_info();
            u.username = name;
            u.password = password;
            allUsers.Add(u);

            save_records();
            this.count = this.count + 1;

            Console.WriteLine("Thanks for signing up ");

        }

        public void save_records()
        {
            for (int idx = this.value; idx < allUsers.Count; idx++)
            {
                admin_info user = (admin_info)allUsers[idx];
                this.filename = "seller.txt";
                this.data = user.username + "," + user.password;
                writeData(filename, data);


            }
        }
        
            public void writeData(string filename, string data)
            {
                FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(data);
                sw.Flush();
                sw.Close();
                fs.Close();
            Console.WriteLine("file is created");

        }

        public int verifyUser(string name, string password)
        {
            readData();
            Console.WriteLine("file read");
            Console.WriteLine(name);
            Console.WriteLine(password);


            

            int show = 0;

            Console.WriteLine("LOOP");

            for (int idx = 0; idx < allUsers.Count; idx++)
            {
                admin_info user = (admin_info)allUsers[idx];
                Console.WriteLine(user.username, user.password);

                if (name == user.username && password == user.password)
                {
                    show = 1;
                    Console.WriteLine("return show");
                }

            }
            return show;
        }


        public void readData()
        {
            value = 0;
            FileStream fs = new FileStream("seller.txt", FileMode.Open, FileAccess.Read);
            Console.WriteLine("file is reading");
            StreamReader sr = new StreamReader(fs);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadLine();

            while (str != null)
            {

                string readname = getusername(str);
                string readpassword = getmatricmarks(str);


                admin_info u = new admin_info();
                u.username = readname;
                u.password = readpassword;
                allUsers.Add(u);
                value = value + 1;

                str = sr.ReadLine();
            }

            Console.WriteLine("file end");
            sr.Close();
            fs.Close();
           
        }

        public string getusername(string data)
        {
            int commafound = 0;
            string readname = "";
            int idx = 0;
            while (commafound < 1)
            {
                char c = data[idx];
                if (c == ',')
                {

                    commafound = commafound + 1;
                }
                else
                {
                    readname = readname + c;
                }
                idx++;
            }
            return readname;

        }

        public string getmatricmarks(string data)
        {
            int commafound = 0;
            string readmatric = "";
            int idx = 0;
            int commacount = 0;
            while (commafound < 2 && idx < data.Length)
            {
                char c = data[idx];
                if (c == ',')
                {
                    commafound = commafound + 1;
                    commacount++;

                }
                else if (commacount == 1)
                {
                    readmatric += c;
                }
                idx = idx + 1;
            }
            return readmatric;

        }


    }


}

