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
    public partial class bill : Form

    {
        public ArrayList allitems = new ArrayList();
        public static int billvalue;
        public int value;
        public string data = "";
        public string filename = "";
        public bill()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            billing();


        }

        public void populateGridView(string item, string quantity, int billvalue)
        {
            string bill_value = billvalue.ToString();

            String[] row = {item,quantity,bill_value};
            dataGridView1.Rows.Add(row);

        }

        public void billing()
        {
            string item = textBox2.Text;
            string quantity = textBox1.Text;
            int q = int.Parse(quantity);

            readData();

            for (int idx = 0; idx < allitems.Count; idx++)
            {
                items_info u = (items_info)allitems[idx];
                
                if (item == u.name)
                {
                    billvalue = 0;
                    billvalue = q * u.purchaseprice;
                    u.stock = u.stock + q;
                    populateGridView(item, quantity, billvalue);
                        save_records();
                }
            }
            
        }


        public void save_records()
        {
            StreamWriter strm = File.CreateText("data.txt");
            strm.Flush();
            strm.Close();

            for (int idx = 0 ; idx < allitems.Count; idx++)
            {
                items_info user = (items_info)allitems[idx];
                this.filename = "data.txt";
                string saleprice = user.saleprice.ToString();
                string purchaseprice = user.purchaseprice.ToString();
                string stock = user.stock.ToString();
                this.data = user.name + "," +saleprice + "," + purchaseprice + "," + user.date + "," + stock;
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
                value = value + 1;

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

    }

    class items_info {

        public string name;
        public int saleprice;
        public int purchaseprice;
        public string date;
        public int stock;  
    }

}
