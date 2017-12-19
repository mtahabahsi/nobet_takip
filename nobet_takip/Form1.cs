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
    public partial class Form1 : Form
    {
        OleDbConnection baglan = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0; data source = nobet.mdb");
        ListBox liste = new ListBox();
        private void nobetci_oku()
        {

            OleDbCommand veri = new OleDbCommand("select * from nobetci", baglan);
            OleDbDataReader oku = null;
            baglan.Open();
            oku = veri.ExecuteReader();
            listView1.Items.Clear();
            while (oku.Read())
            {
                ListViewItem kayit = new ListViewItem(oku["id"].ToString());
                kayit.SubItems.Add(oku["nbt_adi"].ToString());
                kayit.SubItems.Add(oku["nbt_sadi"].ToString());
                listView1.Items.Add(kayit);
            }
            oku.Close();
            baglan.Close();
        }

      
       
        private void yonetici_oku()
        {
            try
            {
                OleDbCommand veri = new OleDbCommand("select * from yonetici", baglan);
                OleDbDataReader oku = null;
                baglan.Open();
                oku = veri.ExecuteReader();
                listView3.Items.Clear();
                while (oku.Read())
                {
                    ListViewItem kayit = new ListViewItem(oku["id"].ToString());
                    kayit.SubItems.Add(oku["ad_soyad"].ToString());
                    kayit.SubItems.Add(oku["departman"].ToString());
                    listView3.Items.Add(kayit);
                }
                oku.Close();
                baglan.Close();
            }
            catch
            {

            }
        }
            private void bossaat_oku()
        {
            try
            {
                if (baglan.State == ConnectionState.Closed) baglan.Open();
                OleDbCommand veri = new OleDbCommand("SELECT saat FROM bos_saatler where yonetici_id=" + listView3.SelectedItems[0].SubItems[0].Text + " and tarih='" + dateTimePicker1 .Text + "'", baglan);
                OleDbDataReader oku = null;
                oku = veri.ExecuteReader();
                liste.Items.Clear();
                while (oku.Read())
                {
                    liste.Items.Add(oku.GetString(0).ToString());
                }
                oku.Close();
                baglan.Close();
            }
            catch
            {
              
            }
        }
            
            public void listele()
            {
                try
                {
                    button1.BackColor = Color.Transparent;
                    button2.BackColor = Color.Transparent;
                    button3.BackColor = Color.Transparent;
                    button4.BackColor = Color.Transparent;
                    button5.BackColor = Color.Transparent;
                    button6.BackColor = Color.Transparent;
                    button7.BackColor = Color.Transparent;
                    button8.BackColor = Color.Transparent;
                    button9.BackColor = Color.Transparent;
                    button10.BackColor = Color.Transparent;
                    button11.BackColor = Color.Transparent;
                    button12.BackColor = Color.Transparent;
                    
                    liste.Items.Clear();
                    bossaat_oku();
                    int sayac = liste.Items.Count;
                    string deger = null;
                    for (int i = 0; i < sayac; i++)
                    {

                        if (liste.Items[i].ToString() == button1.Text)
                        {
                            deger = liste.Items[i].ToString();
                            button1.BackColor = Color.DimGray;

                        }

                        else if (liste.Items[i].ToString() == button2.Text)
                        {
                            deger = liste.Items[i].ToString();
                            button2.BackColor = Color.DimGray;

                        }

                        else if (liste.Items[i].ToString() == button3.Text)
                        {
                            deger = liste.Items[i].ToString();
                            button3.BackColor = Color.DimGray;

                        }
                        else if (liste.Items[i].ToString() == button4.Text)
                        {
                            deger = liste.Items[i].ToString();
                            button4.BackColor = Color.DimGray;

                        }
                        else if (liste.Items[i].ToString() == button5.Text)
                        {
                            deger = liste.Items[i].ToString();
                            button5.BackColor = Color.DimGray;

                        }
                        else if (liste.Items[i].ToString() == button6.Text)
                        {
                            deger = liste.Items[i].ToString();
                            button6.BackColor = Color.DimGray;
                        }
                        else if (liste.Items[i].ToString() == button7.Text)
                        {
                            deger = liste.Items[i].ToString();
                            button7.BackColor = Color.DimGray;

                        }

                        else if (liste.Items[i].ToString() == button8.Text)
                        {
                            deger = liste.Items[i].ToString();
                            button8.BackColor = Color.DimGray;

                        }
                        else if (liste.Items[i].ToString() == button9.Text)
                        {
                            deger = liste.Items[i].ToString();
                            button9.BackColor = Color.DimGray;

                        }
                        else if (liste.Items[i].ToString() == button10.Text)
                        {
                            deger = liste.Items[i].ToString();
                            button10.BackColor = Color.DimGray;

                        }
                        else if (liste.Items[i].ToString() == button11.Text)
                        {
                            deger = liste.Items[i].ToString();
                            button11.BackColor = Color.DimGray;

                        }
                        else if (liste.Items[i].ToString() == button12.Text)
                        {
                            deger = liste.Items[i].ToString();
                            button12.BackColor = Color.DimGray;

                        }
                    }
                    textBox4.Text = listView3.SelectedItems[0].SubItems[1].Text;
                    bossaat_oku();
                }
                catch
                {


                }
            }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            textBox1.Text = dateTimePicker1.Text;
            nobetci_oku();
            yonetici_oku();
         

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox3.Text = listView1.SelectedItems[0].SubItems[1].Text + " " + listView1.SelectedItems[0].SubItems[2].Text;
            }
            catch 
            {
               
            }
           
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //yonetici_oku();
           // bossaat_oku();
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            listele();

        }

        private void button37_Click(object sender, EventArgs e)
        {
            textBox2.Text = label13.Text;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            textBox2.Text = label14.Text;
        }

        private void button38_Click(object sender, EventArgs e)
        {
            textBox2.Text = label14.Text;
        }

        private void button50_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = button2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = button1.Text;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text = button7.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Text = button8.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox2.Text = button9.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox2.Text = button10.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox2.Text = button11.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox2.Text = button12.Text;
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox2.Text = button17.Text;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox2.Text = button21.Text;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox2.Text = button24.Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox2.Text = button14.Text;
        }
        private void button15_Click(object sender, EventArgs e)
        {
            textBox2.Text = button15.Text;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = dateTimePicker1.Text;
            listele();
        }

        string nbtid;
        

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                OleDbCommand veri = new OleDbCommand("SELECT nbt_id FROM bos_saatler where yonetici_id=" + listView3.SelectedItems[0].SubItems[0].Text + " and tarih='" + dateTimePicker1.Text + "' and saat='" + button1.Text + "'", baglan);

                OleDbDataReader oku = null;
                baglan.Open();
                oku = veri.ExecuteReader();
                // liste.Items.Clear();
                while (oku.Read())
                {
                    nbtid = oku.GetString(0);
                }
                oku.Close();
                baglan.Close();

                OleDbCommand veri2 = new OleDbCommand("SELECT nbt_adi,nbt_sadi FROM nobetci where id=" + nbtid + "", baglan);

                OleDbDataReader oku2 = null;
                baglan.Open();
                oku2 = veri2.ExecuteReader();
                // liste.Items.Clear();
                while (oku2.Read())
                {
                   
                    label2.Text = oku2.GetString(0) + " " + oku2.GetString(1);
                }
                oku2.Close();
                baglan.Close();


            }
            catch
            {


            }
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                OleDbCommand veri = new OleDbCommand("SELECT nbt_id FROM bos_saatler where yonetici_id=" + listView3.SelectedItems[0].SubItems[0].Text + " and tarih='" + dateTimePicker1.Text + "' and saat='" + button2.Text + "'", baglan);

                OleDbDataReader oku = null;
                baglan.Open();
                oku = veri.ExecuteReader();
                // liste.Items.Clear();
                while (oku.Read())
                {
                    nbtid = oku.GetString(0);
                }
                oku.Close();
                baglan.Close();

                OleDbCommand veri2 = new OleDbCommand("SELECT nbt_adi,nbt_sadi FROM nobetci where id=" + nbtid + "", baglan);

                OleDbDataReader oku2 = null;
                baglan.Open();
                oku2 = veri2.ExecuteReader();
                // liste.Items.Clear();
                while (oku2.Read())
                {

                    label2.Text = oku2.GetString(0) + " " + oku2.GetString(1);
                }
                oku2.Close();
                baglan.Close();


            }
            catch
            {


            }
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                OleDbCommand veri = new OleDbCommand("SELECT nbt_id FROM bos_saatler where yonetici_id=" + listView3.SelectedItems[0].SubItems[0].Text + " and tarih='" + dateTimePicker1.Text + "' and saat='" + button3.Text + "'", baglan);

                OleDbDataReader oku = null;
                baglan.Open();
                oku = veri.ExecuteReader();
                // liste.Items.Clear();
                while (oku.Read())
                {
                    nbtid = oku.GetString(0);
                }
                oku.Close();
                baglan.Close();

                OleDbCommand veri2 = new OleDbCommand("SELECT nbt_adi,nbt_sadi FROM yonetici where id=" + nbtid + "", baglan);

                OleDbDataReader oku2 = null;
                baglan.Open();
                oku2 = veri2.ExecuteReader();
                // liste.Items.Clear();
                while (oku2.Read())
                {

                    label2.Text = oku2.GetString(0) + " " + oku2.GetString(1);
                }
                oku2.Close();
                baglan.Close();


            }
            catch
            {


            }
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                OleDbCommand veri = new OleDbCommand("SELECT nbt_id FROM bos_saatler where yonetici_id=" + listView3.SelectedItems[0].SubItems[0].Text + " and tarih='" + dateTimePicker1.Text + "' and saat='" + button4.Text + "'", baglan);

                OleDbDataReader oku = null;
                baglan.Open();
                oku = veri.ExecuteReader();
                // liste.Items.Clear();
                while (oku.Read())
                {
                    nbtid = oku.GetString(0);
                }
                oku.Close();
                baglan.Close();

                OleDbCommand veri2 = new OleDbCommand("SELECT nbt_adi,nbt_sadi FROM yonetici where id=" + nbtid + "", baglan);

                OleDbDataReader oku2 = null;
                baglan.Open();
                oku2 = veri2.ExecuteReader();
                // liste.Items.Clear();
                while (oku2.Read())
                {

                    label2.Text = oku2.GetString(0) + " " + oku2.GetString(1);
                }
                oku2.Close();
                baglan.Close();


            }
            catch
            {


            }
        }

        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                OleDbCommand veri = new OleDbCommand("SELECT nbt_id FROM bos_saatler where yonetici_id=" + listView3.SelectedItems[0].SubItems[0].Text + " and tarih='" + dateTimePicker1.Text + "' and saat='" + button5.Text + "'", baglan);

                OleDbDataReader oku = null;
                baglan.Open();
                oku = veri.ExecuteReader();
                // liste.Items.Clear();
                while (oku.Read())
                {
                    nbtid = oku.GetString(0);
                }
                oku.Close();
                baglan.Close();

                OleDbCommand veri2 = new OleDbCommand("SELECT nbt_adi,nbt_sadi FROM yonetici where id=" + nbtid + "", baglan);

                OleDbDataReader oku2 = null;
                baglan.Open();
                oku2 = veri2.ExecuteReader();
                // liste.Items.Clear();
                while (oku2.Read())
                {

                    label2.Text = oku2.GetString(0) + " " + oku2.GetString(1);
                }
                oku2.Close();
                baglan.Close();


            }
            catch
            {


            }
        }

        private void button6_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                OleDbCommand veri = new OleDbCommand("SELECT nbt_id FROM bos_saatler where yonetici_id=" + listView3.SelectedItems[0].SubItems[0].Text + " and tarih='" + dateTimePicker1.Text + "' and saat='" + button6.Text + "'", baglan);

                OleDbDataReader oku = null;
                baglan.Open();
                oku = veri.ExecuteReader();
                // liste.Items.Clear();
                while (oku.Read())
                {
                    nbtid = oku.GetString(0);
                }
                oku.Close();
                baglan.Close();

                OleDbCommand veri2 = new OleDbCommand("SELECT nbt_adi,nbt_sadi FROM yonetici where id=" + nbtid + "", baglan);

                OleDbDataReader oku2 = null;
                baglan.Open();
                oku2 = veri2.ExecuteReader();
                // liste.Items.Clear();
                while (oku2.Read())
                {

                    label2.Text = oku2.GetString(0) + " " + oku2.GetString(1);
                }
                oku2.Close();
                baglan.Close();


            }
            catch
            {


            }
        }

        private void button7_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                OleDbCommand veri = new OleDbCommand("SELECT nbt_id FROM bos_saatler where yonetici_id=" + listView3.SelectedItems[0].SubItems[0].Text + " and tarih='" + dateTimePicker1.Text + "' and saat='" + button7.Text + "'", baglan);

                OleDbDataReader oku = null;
                baglan.Open();
                oku = veri.ExecuteReader();
                // liste.Items.Clear();
                while (oku.Read())
                {
                    nbtid = oku.GetString(0);
                }
                oku.Close();
                baglan.Close();

                OleDbCommand veri2 = new OleDbCommand("SELECT nbt_adi,nbt_sadi FROM nobetci where id=" + nbtid + "", baglan);

                OleDbDataReader oku2 = null;
                baglan.Open();
                oku2 = veri2.ExecuteReader();
                // liste.Items.Clear();
                while (oku2.Read())
                {

                    label2.Text = oku2.GetString(0) + " " + oku2.GetString(1);
                    
                }
                listele();
                oku2.Close();
                baglan.Close();


            }
            catch
            {


            }

        }

        private void button8_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                OleDbCommand veri = new OleDbCommand("SELECT nbt_id FROM bos_saatler where yonetici_id=" + listView3.SelectedItems[0].SubItems[0].Text + " and tarih='" + dateTimePicker1.Text + "' and saat='" + button8.Text + "'", baglan);

                OleDbDataReader oku = null;
                baglan.Open();
                oku = veri.ExecuteReader();
                // liste.Items.Clear();
                while (oku.Read())
                {
                    nbtid = oku.GetString(0);
                }
                oku.Close();
                baglan.Close();

                OleDbCommand veri2 = new OleDbCommand("SELECT nbt_adi,nbt_sadi FROM nobetci where id=" + nbtid + "", baglan);

                OleDbDataReader oku2 = null;
                baglan.Open();
                oku2 = veri2.ExecuteReader();
                // liste.Items.Clear();
                while (oku2.Read())
                {

                    label2.Text = oku2.GetString(0) + " " + oku2.GetString(1);
                }
                oku2.Close();
                baglan.Close();


            }
            catch
            {


            }
        }

        private void button9_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                OleDbCommand veri = new OleDbCommand("SELECT nbt_id FROM bos_saatler where yonetici_id=" + listView3.SelectedItems[0].SubItems[0].Text + " and tarih='" + dateTimePicker1.Text + "' and saat='" + button9.Text + "'", baglan);

                OleDbDataReader oku = null;
                baglan.Open();
                oku = veri.ExecuteReader();
                // liste.Items.Clear();
                while (oku.Read())
                {
                    nbtid = oku.GetString(0);
                }
                oku.Close();
                baglan.Close();

                OleDbCommand veri2 = new OleDbCommand("SELECT nbt_adi,nbt_sadi FROM nobetci where id=" + nbtid + "", baglan);

                OleDbDataReader oku2 = null;
                baglan.Open();
                oku2 = veri2.ExecuteReader();
                // liste.Items.Clear();
                while (oku2.Read())
                {

                    label2.Text = oku2.GetString(0) + " " + oku2.GetString(1);
                }
                oku2.Close();
                baglan.Close();


            }
            catch
            {


            }
        }

        private void button10_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                OleDbCommand veri = new OleDbCommand("SELECT nbt_id FROM bos_saatler where yonetici_id=" + listView3.SelectedItems[0].SubItems[0].Text + " and tarih='" + dateTimePicker1.Text + "' and saat='" + button10.Text + "'", baglan);

                OleDbDataReader oku = null;
                baglan.Open();
                oku = veri.ExecuteReader();
                // liste.Items.Clear();
                while (oku.Read())
                {
                    nbtid = oku.GetString(0);
                }
                oku.Close();
                baglan.Close();

                OleDbCommand veri2 = new OleDbCommand("SELECT nbt_adi,nbt_sadi FROM nobetci where id=" + nbtid + "", baglan);

                OleDbDataReader oku2 = null;
                baglan.Open();
                oku2 = veri2.ExecuteReader();
                // liste.Items.Clear();
                while (oku2.Read())
                {

                    label2.Text = oku2.GetString(0) + " " + oku2.GetString(1);
                }
                oku2.Close();
                baglan.Close();


            }
            catch
            {


            }
        }

        private void button11_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                OleDbCommand veri = new OleDbCommand("SELECT nbt_id FROM bos_saatler where yonetici_id=" + listView3.SelectedItems[0].SubItems[0].Text + " and tarih='" + dateTimePicker1.Text + "' and saat='" + button11.Text + "'", baglan);

                OleDbDataReader oku = null;
                baglan.Open();
                oku = veri.ExecuteReader();
                // liste.Items.Clear();
                while (oku.Read())
                {
                    nbtid = oku.GetString(0);
                }
                oku.Close();
                baglan.Close();

                OleDbCommand veri2 = new OleDbCommand("SELECT nbt_adi,nbt_sadi FROM yonetici where id=" + nbtid + "", baglan);

                OleDbDataReader oku2 = null;
                baglan.Open();
                oku2 = veri2.ExecuteReader();
                // liste.Items.Clear();
                while (oku2.Read())
                {

                    label2.Text = oku2.GetString(0) + " " + oku2.GetString(1);
                }
                oku2.Close();
                baglan.Close();


            }
            catch
            {


            }
        }

        private void button12_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                OleDbCommand veri = new OleDbCommand("SELECT nbt_id FROM bos_saatler where yonetici_id=" + listView3.SelectedItems[0].SubItems[0].Text + " and tarih='" + dateTimePicker1.Text + "' and saat='" + button12.Text + "'", baglan);

                OleDbDataReader oku = null;
                baglan.Open();
                oku = veri.ExecuteReader();
                // liste.Items.Clear();
                while (oku.Read())
                {
                    nbtid = oku.GetString(0);
                }
                oku.Close();
                baglan.Close();

                OleDbCommand veri2 = new OleDbCommand("SELECT nbt_adi,nbt_sadi FROM nobetci where id=" + nbtid + "", baglan);

                OleDbDataReader oku2 = null;
                baglan.Open();
                oku2 = veri2.ExecuteReader();
                // liste.Items.Clear();
                while (oku2.Read())
                {

                    label2.Text = oku2.GetString(0) + " " + oku2.GetString(1);
                }
                oku2.Close();
                baglan.Close();


            }
            catch
            {


            }
        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //Veritabanında tarihe göre günlük arama kodları

            if (baglan.State == ConnectionState.Closed) baglan.Open();
            string sorgu = "select * from yonetici where ad_soyad like'" + textBox5.Text + "%'";
            OleDbCommand komut = new OleDbCommand(sorgu, baglan);
            OleDbDataReader oku = komut.ExecuteReader();
            listView3.Items.Clear();
            while (oku.Read())
            {
                   ListViewItem kayit = new ListViewItem(oku["id"].ToString());
                    kayit.SubItems.Add(oku["ad_soyad"].ToString());
                    kayit.SubItems.Add(oku["departman"].ToString());
                    listView3.Items.Add(kayit);
            
            
            }
            baglan.Close();
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //Veritabanında tarihe göre günlük arama kodları

            if (baglan.State == ConnectionState.Closed) baglan.Open();
            string sorgu = "select * from nobetci where nbt_adi like'" + textBox6.Text + "%'";
            OleDbCommand komut = new OleDbCommand(sorgu, baglan);
            OleDbDataReader oku = komut.ExecuteReader();
            listView1.Items.Clear();
            while (oku.Read())
            {
                ListViewItem kayit = new ListViewItem(oku["id"].ToString());
                kayit.SubItems.Add(oku["nbt_adi"].ToString());
                kayit.SubItems.Add(oku["nbt_sadi"].ToString());
                listView1.Items.Add(kayit);


            }
            baglan.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            saatlbl.Text = DateTime.Now.ToLongTimeString();
        }

        private void button49_Click_1(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == ""))
                {
                    MessageBox.Show("Lütfen Boş Metin Kutusu Bırakmayınız...");
                }
                else
                {
                    if (baglan.State == ConnectionState.Closed) baglan.Open();
                    string sorgu = "SELECT * FROM bos_saatler where yonetici_id=" + listView3.SelectedItems[0].SubItems[0].Text + " and tarih='" + dateTimePicker1.Text + "' and saat='" + textBox2.Text + "'";
                    OleDbCommand komut = new OleDbCommand(sorgu, baglan);
                    OleDbDataReader oku = komut.ExecuteReader();
                    if (oku.Read())
                    {
                        MessageBox.Show("Lütfen Farklı Bir Nöbet Saati Seçiniz..."," ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglan.Close();
                    }

                    else
                    {
                        if (baglan.State == ConnectionState.Closed) baglan.Open();
                        OleDbCommand kaydet = new OleDbCommand("insert into bos_saatler (yonetici_id,saat,nbt_id,tarih) values('" + listView3.SelectedItems[0].SubItems[0].Text + "','" + textBox2.Text + "','" + listView1.SelectedItems[0].SubItems[0].Text + "','" + textBox1.Text + "')", baglan);
                        kaydet.ExecuteNonQuery();
                        baglan.Close();
                        bossaat_oku();
                        listele();
                        MessageBox.Show("Yeni Nöbet Eklendi...", " ",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    }
                       bossaat_oku();
                }
            }
            catch { }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand sil = new OleDbCommand("delete from bos_saatler where yonetici_id=" + listView3.SelectedItems[0].SubItems[0].Text + " and tarih='" + dateTimePicker1.Text + "' and saat='" + textBox2.Text + "'", baglan);
                baglan.Open();
                sil.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Silme İşlemi Başarılı...", " ",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                listele();
                
            }
            catch
            {
                MessageBox.Show("Silme İşlemi Başarısız.Tekrar Deneyiniz..."," ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox2.Text = button16.Text;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox2.Text = button18.Text;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox2.Text = button19.Text;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            textBox2.Text = button25.Text;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox2.Text = button23.Text;
        }

        private void button22_Click(object sender, EventArgs e)
        {

            textBox2.Text = button22.Text;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox2.Text = button20.Text;
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
