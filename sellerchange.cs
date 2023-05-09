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
    public partial class sellerchange : Form

    {
        public static ArrayList allUsers = new ArrayList();
        public int count = 0;
        public string data = "";
        public string filename = "";
        public sellerchange()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            change_username();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            change_password();
        }

        public void change_password()
        {
            readData();
            
            string password = textBox4.Text;
            string newpassword = textBox6.Text;
            string confirm = textBox5.Text;
            for (int idx = 0; idx < admin_curd.allUsers.Count; idx++)
            {
                admin_info user = (admin_info)admin_curd.allUsers[idx];

                if (password == user.password && newpassword == confirm)
                {
                    user.password = newpassword;
                }
                save_records();
            }
        }

        public void change_username()
        {
            readData();
            string username = textBox1.Text;
            string newusername = textBox2.Text;
            string confirm = textBox3.Text;
            for (int idx = 0; idx < admin_curd.allUsers.Count; idx++)
            {
                admin_info user = (admin_info)admin_curd.allUsers[idx];

                if (username == user.username && newusername == confirm)
                {
                    user.username = newusername;
                }
                save_records();
        }
        }

        public void save_records()
        {
            StreamWriter strm = File.CreateText("seller.txt");
            strm.Flush();
            strm.Close();

            for (int idx = this.count; idx < admin_curd.allUsers.Count; idx++)
            {
                admin_info user = (admin_info)admin_curd.allUsers[idx];
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

        public void readData()
        {

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
