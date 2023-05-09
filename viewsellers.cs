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
    public partial class viewsellers : Form
    {
        public viewsellers()
        {
            InitializeComponent();
        }

        private void viewsellers_Load(object sender, EventArgs e)
        {
            readData();
        }


        public void populateGridView(string product, string saleprice)
        {
            String[] row = { product, saleprice };
            dataGridView1.Rows.Add(row);

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

                populateGridView(readname, readpassword);

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
