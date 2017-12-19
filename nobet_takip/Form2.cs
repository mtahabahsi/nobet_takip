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
    public partial class Form2 : Form
    {
        OleDbConnection baglan = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0; data source = nobet.mdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataReader oku;
        OleDbCommand kaydet;
        OleDbCommand sil;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                kaydet = new OleDbCommand("insert into yonetici (ad_soyad,departman,kullaniciad,kullanicisifre) " +
                    "values('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", baglan);
                baglan.Open();
                kaydet.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Kaydetme İşlemi Başarılı...", " ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                MessageBox.Show("Kaydetme İşlemi Başarısız...", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                sil = new OleDbCommand("delete from yonetici where ad_soyad ='" + textBox1.Text + "'", baglan);
                baglan.Open();
                sil.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Silme İşlemi Başarılı...", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                MessageBox.Show("Silme İşlemi Başarısız.Tekrar Deneyiniz...", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

            baglan.Open();
            komut.Connection=baglan;
            komut.CommandText = "SELECT *FROM departman";
            oku = komut.ExecuteReader();

            while (oku.Read())
            {
                comboBox1.Items.Add(oku["departman_adi"]);
            }
            baglan.Close();
        }
    }
    }


