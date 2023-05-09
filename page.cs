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
    public partial class page : Form

    {
        public int value = 0;
        public page()
        {
            InitializeComponent();
        }

        private void page_Load(object sender, EventArgs e)
        {
            readData();
        }

        public void populateGridView(string name, string quantity,string bill)
        {
          
            String[] row = { name, quantity,bill };
            dataGridView1.Rows.Add(row);

        }

        public void readData()
        {
            FileStream fs = new FileStream("sellerbill.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadLine();
            while (str != null)
            {
                string readproduct = getusername(str);
                string readsaleprice = getmatricmarks(str);
                string readpurchaseprice = get1styearmarks(str);

                this.value = this.value + 1;
                Console.WriteLine(this.value);
                populateGridView(readproduct,readsaleprice,readpurchaseprice);

                str = sr.ReadLine();
            }
            Console.WriteLine("products read");
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


    }
}
