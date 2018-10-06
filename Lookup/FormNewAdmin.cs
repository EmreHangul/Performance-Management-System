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
    public partial class FormNewAdmin : Form
    {
        public FormNewAdmin()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\user\\Desktop\\Lookup\\bin\\Debug\\Database\\Proje.mdb");

        private string hashToSifre(string str)
        {
            double d = Convert.ToDouble(str);
            d = (d - 5) * 2;
            return d.ToString();

        }
        private string SifreToHash(string str)
        {
            double d = Convert.ToDouble(str);
            d = (d / 2) + 5;
            return d.ToString();

        }
        private void FormYoneticiEkle_Load(object sender, EventArgs e)
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
                listView1.Items.Add(list);

            }

            con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (con != null && con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string sql = "Select * from ProjeDatası where [Personel No] like '%" + textBox2.Text + "%'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            listView1.Items.Clear();
            while (oku.Read())
            {
                ListViewItem list = new ListViewItem();
                list.Text = oku["Personel No"].ToString();
                list.SubItems.Add(oku["Kimlik No"].ToString());
                listView1.Items.Add(list);
            }
            con.Close();
        
    }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (con != null && con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string sql = "Select * from ProjeDatası where [Kimlik No] like '%" + textBox1.Text + "%'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            listView1.Items.Clear();
            while (oku.Read())
            {
                ListViewItem list = new ListViewItem();
                list.Text = oku["Personel No"].ToString();
                list.SubItems.Add(oku["Kimlik No"].ToString());
                listView1.Items.Add(list);
            }
            con.Close();
        }
        private void idBul()
        {
                con.Open();

            string sql = "Select * from ProjeDatası where [Personel No]='" + textBox2.Text + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
              
                labelid.Text=oku["Kimlik No"].ToString();
             
            }
            con.Close();
        }
        private void sifreBul()
        {
            
                con.Open();
            

            string sql = "Select * from Personel where [Güven ID]='" + labelid.Text + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                labelSifre.Text = hashToSifre((oku["Şifre"].ToString()));

            }
            con.Close();
        }
        private void yoneticiEkle()
        {
            bool yoneticiMi = zatenYonetici();
            if (yoneticiMi == false)
            {
                con.Open();

                string sql = "Insert into Yönetici([Güven ID],[Şifre]) values(@id,@şifre)";
                OleDbCommand komut = new OleDbCommand(sql, con);
                komut.Parameters.AddWithValue("@id", labelid.Text);
                komut.Parameters.AddWithValue("@şifre", SifreToHash(labelSifre.Text));
                komut.ExecuteNonQuery();
                MessageBox.Show("Kaydedildi.");
                con.Close();
            }
            else if (yoneticiMi == true)
            {
                MessageBox.Show("Bu kişi zaten bir yöneticidir.");
            }
           
        }
        private bool zatenYonetici()
        {
            string str = "";
            con.Open();
            
            string sql = "Select * from Yönetici where [Güven ID]='" + labelid.Text + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                str = hashToSifre((oku["Şifre"].ToString()));

            }
            con.Close();
            if (str == "")
            {
                return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Yönetici Olarak Kaydetmek İstediğinize Emin Misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (textBox1.Text != "")
                {
                    labelid.Text = textBox1.Text;
                }
                else
                {
                    if (textBox2.Text != "")
                    {
                        idBul();
                    }
                }
                if (labelid.Text == "labelid")
                {
                    MessageBox.Show("Lütfen girdiğiniz değerleri tekrar kontrol ediniz.");
                }
                else if ((labelid.Text != "labelid") && (labelid.Text != ""))
                {
                    sifreBul();
                    yoneticiEkle();
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
        }
    }
}
