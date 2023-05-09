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
using System.Collections;

namespace WindowsFormsApp1
{
    public partial class bill_seller : Form
    {

        public ArrayList allitems = new ArrayList();
        public static int billvalue;
        public int value;
        public string data = "";
        public string filename = "";
        public int totalquantity = 0;
        public int totalbill = 0;
        public bill_seller()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            billby_seller();
        }

        public void billby_seller()
        {

            string sellername = textBox4.Text;
            string item = textBox2.Text;
            string quantity = textBox3.Text;
            int q = int.Parse(quantity);
            string adding = textBox5.Text;
            string notadding = textBox6.Text;

           if(adding == "yes") {
            
             for (int idx = 0; idx < allitems.Count; idx++)
            {
                items_info u = (items_info)allitems[idx];
                    Console.WriteLine("array loop start");
                    if (item == u.name)
                {
                    Console.WriteLine("calculation");
                    billvalue = 0;
                    billvalue = q * u.saleprice;
                    u.stock = u.stock - q;
                    totalquantity = totalquantity + q;
                    totalbill = totalbill + billvalue;
                    Console.WriteLine(item,quantity);
                    populateGridView(item, quantity);

                    }

            }
            }

           
            string totalq = totalquantity.ToString();
            string totalamount = totalbill.ToString();
            textBox1.Text = totalamount;

            if(notadding == "yes")
            {
                save_records(sellername, totalq, totalamount);
            }  
        }




        public void save_records(string ss , string qq, string tm)
        {
           
                this.filename = "sellerbill.txt";
                this.data = ss + "," + qq + "," + tm;
                writeData(filename, data);

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

        public void populateGridView(string item, string quantity)
        {

            String[] row = { item, quantity};
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
                string readproduct = getusername(str);
                string readsaleprice = getmatricmarks(str);
                string readpurchaseprice = get1styearmarks(str);
                string readdate = getecatmarks(str);
                string readstock = getstock(str);

                int saleprice = int.Parse(readsaleprice);
                int purchaseprice = int.Parse(readpurchaseprice);
                int stock = int.Parse(readstock);

                items_info u = new items_info();
                u.name = readproduct;
                u.saleprice = saleprice;
                u.purchaseprice = purchaseprice;
                u.date = readdate;
                u.stock = stock;

                allitems.Add(u);
                this.value = this.value + 1;
                Console.WriteLine(this.value);

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

        private void bill_seller_Load(object sender, EventArgs e)
        {
            readData();
        }
    }

}
