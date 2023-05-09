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
    public partial class purchase : Form

    {
        public string filename = "";
        public string data = "";

        public purchase()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Adding();

        }

        public void Adding()
        {
            string product = textBox1.Text;
            string saleprice = textBox2.Text;
            string purchaseprice = textBox3.Text;
            string date = textBox4.Text;
            string stock = textBox5.Text;

            populateGridView(product,saleprice,purchaseprice);

            this.filename = "data.txt";
            this.data = product + "," + saleprice + "," + purchaseprice + "," + date+"," + stock;
            writeData(filename, data);

        }

        public void populateGridView(string name, string sale , string purchase)
        {
            String[] row = { name, sale, purchase };
            dataGridView1.Rows.Add(row);
        }

        public void writeData(string filename, string data)
        {
            FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(data);
            sw.Flush();
            sw.Close();
            fs.Close();

        }
    }


}
