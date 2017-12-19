using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace nobet_takip
{
    public partial class Form3 : Form
    {
        OleDbConnection baglan = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0; data source = nobet.mdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataReader oku;
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            baglan.Open();
            komut.Connection = baglan;
            komut.CommandText = "SELECT *FROM departman";
            oku = komut.ExecuteReader();

            while (oku.Read())
            {
                comboBox1.Items.Add(oku["departman_adi"]);
            }
            baglan.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand kaydet = new OleDbCommand("insert into nobetci (nbt_adi,nbt_sadi,nbt_departmani) values" +
                    "('" + textBox1.Text + "','" + textBox2.Text +"','"+ comboBox1.Text + "')", baglan);
                baglan.Open();
                kaydet.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Kaydetme İşlemi Başarılı...","", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                MessageBox.Show("Kaydetme İşlemi Başarısız...", "",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand sil = new OleDbCommand("delete from nobetci where nbt_adi ='" + textBox1.Text + "'", baglan);
                baglan.Open();
                sil.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Silme İşlemi Başarılı...","", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                MessageBox.Show("Silme İşlemi Başarısız.Tekrar Deneyiniz...","", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
