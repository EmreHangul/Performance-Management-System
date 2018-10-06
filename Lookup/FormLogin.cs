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
    public partial class FormLogin : Form
    {       
        public FormLogin()
        {
            InitializeComponent();
        }
        public string yöneticiyadaçalışan;

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\user\\Desktop\\Lookup\\bin\\Debug\\Database\\Proje.mdb");

        private void FormGiriş_Load(object sender, EventArgs e)
        {
           
        }
        private string hashToSifre(string str)
        {
            double d = Convert.ToDouble(str);
            d = (d - 5) * 2;
            return d.ToString();

        }
       
        private void veriGösterYönetici()
        {
            con.Open();

            string sql = "Select * from Yönetici where [Güven ID]='" +  textBoxID.Text + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                labelsifreyönetici.Text = hashToSifre(oku["Şifre"].ToString());
            }
            con.Close();
           
        }
        private void veriGösterÇalışan()
        {
            con.Open();

            string sql = "Select * from Personel where [Güven ID]='" + textBoxID.Text + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                labelŞifreÇalışan.Text = hashToSifre(oku["Şifre"].ToString());
            }
            con.Close();
        }
        private void buttonÇalışan_Click(object sender, EventArgs e)
        {
            if (yöneticiyadaçalışan == "Yönetici")
            {
                veriGösterYönetici();

                if (labelsifreyönetici.Text == textBoxŞifre.Text)
                {
                    FormPersonnel form = new FormPersonnel();
                    form.Show();
                    this.Hide();
                }
            }
            if (yöneticiyadaçalışan == "Çalışan")
            {
                veriGösterÇalışan();

                if (labelŞifreÇalışan.Text == textBoxŞifre.Text)
                {
                    FormPerformanceGrades form = new FormPerformanceGrades();
                    form.nereden = "Çalışan";
                    form.çalışanID = textBoxID.Text;
                    form.Show();
                    this.Hide();
                }
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormPasswordChange form = new FormPasswordChange();
            form.nereden1 = "Çalışanlar Kendilerini Değiştirsin";
            if (yöneticiyadaçalışan == "Yönetici")
            {
                DialogResult result = MessageBox.Show("Lütfen bu kısmı sadece şifrenizi unuttuysanız kullanınız. Devam etmek istiyor musunuz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    form.yöneticiveyaçalışan = "Yönetici";
                    form.Show();
                }
              
            }
            else if (yöneticiyadaçalışan == "Çalışan")
            {
                DialogResult result = MessageBox.Show("Lütfen bu kısmı sadece şifrenizi unuttuysanız kullanınız. Devam etmek istiyor musunuz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    form.yöneticiveyaçalışan = "Çalışan";
                    form.Show();
                }                   
            }            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
