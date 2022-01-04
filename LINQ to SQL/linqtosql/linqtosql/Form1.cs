using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace linqtosql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbDataContext db = new dbDataContext();
            var sorgu = from kisi in db.Kisilers
                        select kisi;
            //dataGridView1.DataSource = sorgu;
            foreach (var item in sorgu)
            {
                ListViewItem list = new ListViewItem();
                list.Text = item.kisiId.ToString();
                list.SubItems.Add(item.ad);
                list.SubItems.Add(item.soyad);
                list.SubItems.Add(item.dogum_tarihi.ToString());
                list.SubItems.Add(item.il);
                list.SubItems.Add(item.ilce);
                listView1.Items.Add(list);
            }
            var sorgu_2 = from isim in db.isimlers
                          from ders in db.derslers
                          from iliski in db.iliskilers
                          where isim.ogrenci_id == iliski.ogrenci_id &&
                          ders.ders_id == iliski.ders_id &&
                          isim.ogrenci_id == int.Parse(textBox1.Text)
                          select new { isim.isim, ders.ders_adi };
            dataGridView1.DataSource = sorgu_2;
        }
    }
}
