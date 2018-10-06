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
    public partial class FormPasswordChange : Form
    {
        public string nereden1;
        public string yöneticiveyaçalışan;
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\user\\Desktop\\Lookup\\bin\\Debug\\Database\\Proje.mdb");
        public FormPasswordChange()
        {
            InitializeComponent();
        }
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
        private void FormŞifreKaydetDeğiştir_Load(object sender, EventArgs e)
        {
            if(nereden1=="Yeni Çalışan Ekle")
            {
                label5.Visible = true;
                label6.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                button1.Visible = true;
            }
            if (nereden1 == "Çalışanlar Kendilerini Değiştirsin")
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                button2.Visible = true;
            }
        }
        private void şifreKaydetYönetici()
        {
            if ((textBox5.Text == textBox6.Text)&&(textBox2.Text==textBox3.Text))
            {
                con.Open();
                string sql = "Insert into Personel([Güven ID],[Şifre]) values(@id,@şifre)";
                OleDbCommand komut = new OleDbCommand(sql, con);
                komut.Parameters.AddWithValue("@id", textBox5.Text);
                komut.Parameters.AddWithValue("@şifre", SifreToHash(textBox2.Text));
                komut.ExecuteNonQuery();
                MessageBox.Show("Kaydedildi.");
                con.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            else if ((textBox5.Text != textBox6.Text)||(textBox2.Text!=textBox3.Text))
            {
                MessageBox.Show("Bilgileriniz uyuşmamaktadır. Lütfen tekrar giriniz.");
            }

        }
        private void şifreDeğiştirÇalışan2()
        {

                if (textBox2.Text == textBox3.Text)
                {
                    con.Open();
                    string sql = "update Personel set [Güven ID]=@id,[Şifre]=@şifre where [Güven ID]=@id";
                    OleDbCommand komut = new OleDbCommand(sql, con);
                    komut.Parameters.AddWithValue("@id", textBox4.Text);
                    komut.Parameters.AddWithValue("@şifre", SifreToHash(textBox2.Text));
                    komut.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Şifreniz değiştirildi.");

                }
                else if (textBox2.Text != textBox3.Text)
                {
                    MessageBox.Show("Bilgileriniz uyuşmamaktadır. Lütfen tekrar giriniz.");
                }

            
        }
        private void şifreDeğiştirÇalışan()
        {
            if (personelVarMi() == true)
            {
                if (textBox2.Text == textBox3.Text)
                {
                    con.Open();
                    string sql = "update Personel set [Güven ID]=@id,[Şifre]=@şifre where [Güven ID]=@id";
                    OleDbCommand komut = new OleDbCommand(sql, con);
                    komut.Parameters.AddWithValue("@id", textBox4.Text);
                    komut.Parameters.AddWithValue("@şifre", SifreToHash(textBox2.Text));
                    komut.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Şifreniz değiştirildi.");

                }
                else if (textBox2.Text != textBox3.Text)
                {
                    MessageBox.Show("Bilgileriniz uyuşmamaktadır. Lütfen tekrar giriniz.");
                }
            }
            else if (personelVarMi() == false)
            {
                MessageBox.Show("Personel bilgilerinde uyuşmazlık var. Lütfen kimlik no ve eski şifrenizi kontrol ediniz..");
            }
           
        }
        private bool personelVarMi()
        {
            string str = "";
            con.Open();

            string sql = "Select * from Personel where [Güven ID]='" + textBox4.Text + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                str = hashToSifre((oku["Şifre"].ToString()));

            }
            con.Close();
            if (str == textBox1.Text)
            {
                return true;
            }
            return false;
        }
        private bool yoneticiVarMi()
        {
            string str = "";
            con.Open();

            string sql = "Select * from Yönetici where [Güven ID]='" + textBox4.Text + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                str = hashToSifre((oku["Şifre"].ToString()));

            }
            con.Close();
            if (str == textBox1.Text)
            {
                return true;
            }
            return false;
        }
        private bool şifreDeğiştirYönetici()
        {
            bool yoneticiMi = yoneticiVarMi();
            if (yoneticiMi == true)
            {
                if (textBox2.Text == textBox3.Text)
                {
                    con.Open();
                    string sql = "update Yönetici set [Güven ID]=@id,[Şifre]=@şifre where [Güven ID]=@id";
                    OleDbCommand komut = new OleDbCommand(sql, con);
                    komut.Parameters.AddWithValue("@id", textBox4.Text);
                    komut.Parameters.AddWithValue("@şifre", SifreToHash(textBox2.Text));
                    komut.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                else if (textBox3.Text != textBox2.Text)
                {
                    MessageBox.Show("Bilgileriniz uyuşmamaktadır. Lütfen tekrar giriniz.");
                }
            }
            else if (yoneticiMi == false)
            {
                MessageBox.Show("Yönetici bilgilerinde uyuşmazlık var. Lütfen kimlik no ve eski şifrenizi kontrol ediniz.");
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (yöneticiveyaçalışan == "Yönetici")
            {
                şifreKaydetYönetici();
  
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool yoneticiKontrol;
            if ((textBox4.Text != "") && (textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != ""))
            {
                if (yöneticiveyaçalışan == "Yönetici")
                {
                    yoneticiKontrol=şifreDeğiştirYönetici();
                    if (yoneticiKontrol)
                    {
                        şifreDeğiştirÇalışan2();
                    }
                   
                }
                else if (yöneticiveyaçalışan == "Çalışan")
                {
                    şifreDeğiştirÇalışan();

                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            else
            {
                MessageBox.Show("Eksik bilgi girdiniz. Lütfen bütün boş alanları doldurunuz.");
            }
            
        }
    }
}
