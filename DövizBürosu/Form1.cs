using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DövizBürosu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var XmlDosya = new XmlDocument();
            XmlDosya.Load(bugun);

            string dolaralis = XmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/" +
                "BanknoteBuying").InnerXml;
            lblDolaralis.Text = dolaralis;

            string dolarsatis = XmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/" +
                "BanknoteSelling").InnerXml;
            lblDolarsatis.Text = dolarsatis;

            string euroalis = XmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/" +
                "BanknoteBuying").InnerXml;
            lblEuroalis.Text = euroalis;

            string eurosatis = XmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/" +
                "BanknoteSelling").InnerXml;
            lblEurosatis.Text = eurosatis;

        }

        private void btnDolaralis_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblDolaralis.Text;
        }

        private void btnDolarsatis_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblDolarsatis.Text;
        }

        private void btnEuroalis_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblEuroalis.Text;
        }

        private void btnEurosatis_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblEurosatis.Text;
        }

        private void btnDövizAl_Click(object sender, EventArgs e)
        {
            double kur, miktar, tutar;
            kur = Convert.ToDouble(txtKur.Text);
            miktar = Convert.ToDouble(txtMiktar.Text);
            tutar = kur * miktar;
            txtTutar.Text = tutar.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double kur = Convert.ToDouble(txtKur.Text);
            int miktar = Convert.ToInt32(txtMiktar.Text);
            
            int tutar = Convert.ToInt32(miktar / kur);
            txtTutar.Text = tutar.ToString();
            
            double kalan;
            kalan = miktar % kur;
            txtKalan.Text = kalan.ToString();
            
            
        }
    }
}
