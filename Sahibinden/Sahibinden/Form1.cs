using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Sahibinden
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\BAŞAKŞEHİR\\Desktop\\2023-2024 Ders Çalışmaları\\NTP\\Sahibinden\\AracBilgileri.mdb");
        public void Goruntule() 
        {
            baglan.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("SELECT * FROM AracBilgi", baglan);
            DataTable dt = new DataTable();
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            OleDbCommand komut = new OleDbCommand("Insert into AracBilgi (Marka,Model,Yakit,VitesTipi,Kilometre,KapiSayisi) Values ('" + comboBox1.Text + "','" + textBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            Goruntule();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Goruntule();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            comboBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            OleDbCommand komut = new OleDbCommand("Update AracBilgi Set Marka='" + comboBox1.Text + "',Yakit='" + comboBox2.Text + "',VitesTipi='" + comboBox3.Text + "' Where Model='" + textBox1.Text + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            Goruntule();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            OleDbCommand komut = new OleDbCommand("Delete From AracBilgi Where Model='" + textBox1.Text + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            Goruntule();
        }
    }
}
