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

namespace Lookup
{
    public partial class FormPersonnel : Form
    {
        public FormPersonnel()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\user\\Desktop\\Lookup\\bin\\Debug\\Database\\Proje.mdb");
        private void FormPersonel_Load(object sender, EventArgs e)
        {
            veriGösterListView();
        }
        private void veriGösterListView()
        {
            listView1.Items.Clear();
            con.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = con;
            komut.CommandText = "Select * from ProjeDatası";

            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem list = new ListViewItem();
                list.Text = oku["Personel No"].ToString();
                list.SubItems.Add(oku["Kimlik No"].ToString());
                list.SubItems.Add(oku["Departman"].ToString());
                list.SubItems.Add(oku["Görev"].ToString());
                list.SubItems.Add(oku["Güven Kıdemi"].ToString());
                list.SubItems.Add(oku["Yabancı Dil"].ToString());
                list.SubItems.Add(oku["Sınavlar"].ToString());
                list.SubItems.Add(oku["Sertifikalar"].ToString());
                list.SubItems.Add(oku["Ödüller"].ToString());
                list.SubItems.Add(oku["Eğitim Düzeyi"].ToString());
                list.SubItems.Add(oku["Doğum Tarihi"].ToString());
                list.SubItems.Add(oku["Cinsiyet"].ToString());
                list.SubItems.Add(oku["Telefon"].ToString());
                list.SubItems.Add(oku["E-Mail"].ToString());
                list.SubItems.Add(oku["Eğitim İhtiyacı"].ToString());
                listView1.Items.Add(list);
            }
            con.Close();
        }

        private void veriGösterPersonelNo()
        {
            con.Open();
           
            string sql = "Select * from ProjeDatası where [Personel No]='" + textBox1.Text + "'";
            OleDbCommand komut = new OleDbCommand(sql,con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                
                labelKimlik.Text = oku["Kimlik No"].ToString();
                labelIsim.Text = oku["Personel No"].ToString();
                labelDepartment.Text = oku["Departman"].ToString();
                labelGorev.Text = oku["Görev"].ToString();
            }

            con.Close();
        }
        private void veriGösterID()
        {
            con.Open();

            string sql = "Select * from ProjeDatası where [Kimlik No]='" + textBox2.Text + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {

                labelKimlik.Text = oku["Kimlik No"].ToString();
                labelIsim.Text = oku["Personel No"].ToString();
                labelDepartment.Text = oku["Departman"].ToString();
                labelGorev.Text = oku["Görev"].ToString();

            }

            con.Close();
        }
        private void idBul()
        {
            con.Open();

            string sql = "Select * from ProjeDatası where [Personel No]='" + textBox1.Text + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                labelid.Text = oku["Kimlik No"].ToString();

            }
            con.Close();
        }
        private void veriSilProjeData()
        {
            
                if (con != null && con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string sql = "Delete * from ProjeDatası where [Kimlik No]='" + labelid.Text + "'";
                OleDbCommand komut = new OleDbCommand(sql, con);
                komut.ExecuteNonQuery();
                OleDbDataReader oku = komut.ExecuteReader();                
            
            con.Close();
            veriGösterListView();
        }
       
        private void veriSilPersonel()
        {
            con.Open();
            string sql = "Delete * from Personel where [Güven ID]='" + labelid.Text + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();

            con.Close();
        }
        private void veriSilYönetici()
        {
            con.Open();
            string sql = "Delete * from Yönetici where [Güven ID]='" + labelid.Text + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();

            con.Close();
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            FormMain form = new FormMain();
            form.Show();
            this.Hide();
        }
        private void buttonDegistir_Click(object sender, EventArgs e)
        {

        }

        private void buttonAra_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") || (textBox2.Text != ""))
            {
                FormPerformanceGrades form = new FormPerformanceGrades();
                FormInfo form2 = new FormInfo();
                veriGösterPersonelNo();
                if (labelIsim.Text == "label5")
                {
                    veriGösterID();
                }
                form2.isim = labelIsim.Text;
                form2.id = textBox2.Text;
                form2.bilgileri_degistir = true;
                form2.performans_goster = true;
                form.personelIsim = labelIsim.Text;
                form.personelId = labelKimlik.Text;
                form.personelDepartment = labelDepartment.Text;
                form.personelGorev = labelGorev.Text;
                form.degistir = true;
                form2.Show();
                this.Hide();
            }
            else if (((textBox1.Text == "") && (textBox2.Text == "")))
            {
                MessageBox.Show("Böyle bir çalışan yoktur.");
            }
        }
        private void buttonEkle_Click(object sender, EventArgs e)
        {
            FormPerformanceGrades form1 = new FormPerformanceGrades();
            form1.resimkaydetmeekle = true;
            FormInfo form = new FormInfo();
            form.performans_ekle = true;
            form.bilgileri_kaydet = true;
            form.personelEkledenGelen = "Doğru";
            form.Show();
            this.Hide();
        }  
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();         
           string sql = "Select * from ProjeDatası where [Kimlik No] like '%" + textBox2.Text + "%'";
            if (con != null && con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            
            OleDbCommand komut = new OleDbCommand(sql, con);
           komut.ExecuteNonQuery();
           OleDbDataReader oku = komut.ExecuteReader();
          
           while (oku.Read())
           {
               ListViewItem list = new ListViewItem();
               list.Text = oku["Personel No"].ToString();
               list.SubItems.Add(oku["Kimlik No"].ToString());
               list.SubItems.Add(oku["Departman"].ToString());
               list.SubItems.Add(oku["Görev"].ToString());
               list.SubItems.Add(oku["Güven Kıdemi"].ToString());
               list.SubItems.Add(oku["Yabancı Dil"].ToString());
               list.SubItems.Add(oku["Sınavlar"].ToString());
               list.SubItems.Add(oku["Sertifikalar"].ToString());
               list.SubItems.Add(oku["Ödüller"].ToString());
               list.SubItems.Add(oku["Eğitim Düzeyi"].ToString());
               list.SubItems.Add(oku["Doğum Tarihi"].ToString());
               list.SubItems.Add(oku["Cinsiyet"].ToString());
               list.SubItems.Add(oku["Telefon"].ToString());
               list.SubItems.Add(oku["E-Mail"].ToString());
               list.SubItems.Add(oku["Eğitim İhtiyacı"].ToString());
               listView1.Items.Add(list);
           }
           con.Close();              
        }
        private void buttonSil_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") || (textBox2.Text != ""))
            {

                if (textBox1.Text != "")
                {
                    idBul();
                    textBox1.Clear();
                }
                if (textBox2.Text != "")
                {
                    labelid.Text = textBox2.Text;
                    textBox2.Clear();
                }
                MessageBox.Show("Silmek İstediğinize Emin Misiniz?");
                veriSilProjeData();
                veriSilPersonel();
                veriSilYönetici();
            }
           
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (con != null && con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string sql = "Select * from ProjeDatası where [Personel No] like '%" + textBox1.Text + "%'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            listView1.Items.Clear();
            while (oku.Read())
            {
                ListViewItem list = new ListViewItem();
                list.Text = oku["Personel No"].ToString();
                list.SubItems.Add(oku["Kimlik No"].ToString());
                list.SubItems.Add(oku["Departman"].ToString());
                list.SubItems.Add(oku["Görev"].ToString());
                list.SubItems.Add(oku["Güven Kıdemi"].ToString());
                list.SubItems.Add(oku["Yabancı Dil"].ToString());
                list.SubItems.Add(oku["Sınavlar"].ToString());
                list.SubItems.Add(oku["Sertifikalar"].ToString());
                list.SubItems.Add(oku["Ödüller"].ToString());
                list.SubItems.Add(oku["Eğitim Düzeyi"].ToString());
                list.SubItems.Add(oku["Doğum Tarihi"].ToString());
                list.SubItems.Add(oku["Cinsiyet"].ToString());
                list.SubItems.Add(oku["Telefon"].ToString());
                list.SubItems.Add(oku["E-Mail"].ToString());
                list.SubItems.Add(oku["Eğitim İhtiyacı"].ToString());
                listView1.Items.Add(list);               
            }
            con.Close();            
        }

        private void buttonYoneticiSec_Click(object sender, EventArgs e)
        {
            FormNewAdmin form = new FormNewAdmin();
            form.Show();
        }

        private void kullanımKılavuzuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lütfen aramak istediğiniz personeli\n\n -->O kişinin full ismiyle (İsim+Soyisim)\n\n -->Ya da " +
                "Güven ID'si ile arayınız.\n\n Yeni Personel eklemek isterseniz 'Personel Ekle' kısmına tıklayınız.\n\n Halihazırdaki " +
                "personellerden birini yönetici yapmak isterseniz 'Yönetici Ekle" +
                "butonuna basınız.\n\n Kurumunuzdan ayrılan bir personelin bilgilerini tamamen silmek için 'Personel Sil' butonuna " +
                "basınız.\n\n Ana giriş menüsüne dönmek için 'Girişe Dön' butonuna tıklayınız.\n\n Birden çok personeller arası KIYAS yapmak için (terfi işlemleri vb. için) 'Personeller Arası Karşılaştırma " +
                "Yap' butonuna tıklayınız.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormKarşılaştırma form = new FormKarşılaştırma();
            form.topsissonucu = labelTOPSIS.Text;
            form.analizsonucu = labelANALİZ.Text;
            form.Show();
        }
    }
}
