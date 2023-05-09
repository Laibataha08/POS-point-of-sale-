using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public int value;
        public Form2()
        {
            InitializeComponent();
        }


        public void adding_items()
        {
            readData();
        }

        public void populateGridView(string product,string saleprice, string purchaseprice,string date,string stock)
        {
            String[] row = { product,saleprice,purchaseprice,date,stock};
            dataGridView1.Rows.Add(row);
            
        }

        public void readData()
        {
            FileStream fs = new FileStream("data.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadLine();
            while (str != null)
            {
                this.value = 0;
                string readproduct = getusername(str);
                string readsaleprice = getmatricmarks(str);
                string readpurchaseprice = get1styearmarks(str);
                string readdate = getecatmarks(str);
                string readstock = getstock(str);

                populateGridView(readproduct, readsaleprice, readpurchaseprice, readdate,readstock);
                str = sr.ReadLine();
            }
            Console.WriteLine("return show");
           
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

        public string get1styearmarks(string data)
        {
            int commafound = 0;
            string read1styear = "";
            int commacount = 0;
            int idx = 0;
            while (commafound < 3 && idx < data.Length)
            {
                char c = data[idx];
                if (c == ',')
                {
                    commafound = commafound + 1;
                    commacount++;
                }
                else if (commacount == 2)
                {
                    read1styear += c;
                }
                idx = idx + 1;
            }
            return read1styear;

        }

        public string getecatmarks(string data)
        {
            int commafound = 0;
            string readecat = "";
            int commacount = 0;
            int idx = 0;
            while (commafound < 4 && idx < data.Length)
            {
                char c = data[idx];
                if (c == ',')
                {
                    commafound = commafound + 1;
                    commacount++;
                }
                else if (commacount == 3)
                {
                    readecat += c;
                }
                idx = idx + 1;
            }
            return readecat;

        }

        public string getstock(string data)
        {
            int commafound = 0;
            string readecat = "";
            int commacount = 0;
            int idx = 0;
            while (commafound < 5 && idx < data.Length)
            {
                char c = data[idx];
                if (c == ',')
                {
                    commafound = commafound + 1;
                    commacount++;
                }
                else if (commacount == 4)
                {
                    readecat += c;
                }
                idx = idx + 1;
            }
            return readecat;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            adding_items();
        }
    }
}
