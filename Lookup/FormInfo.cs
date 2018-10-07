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
    public partial class FormInfo : Form
    {
        public string personelEkledenGelen;
        public bool bilgileri_degistir = false;
        public bool bilgileri_kaydet = false;
        public bool performans_goster = false;
        public bool performans_ekle = false;
        public string isim = "";
        public string id = "";
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\user\\Desktop\\Lookup\\bin\\Debug\\Database\\Proje.mdb");
        public FormInfo()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void kaydetBilgiler_Click(object sender, EventArgs e)
        {            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FormPersonnel form = new FormPersonnel();
            form.Show();
            this.Hide();
        }
        private bool aynıKimlikNoluElemanVarMı()
        {
            string str = "";
            if (textBox2.Text != "")
            {
                con.Open();
                string sql = "Select * from ProjeDatası where [Kimlik No]='" + textBox2.Text + "'";
                OleDbCommand komut = new OleDbCommand(sql, con);
                komut.ExecuteNonQuery();
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                   str = oku["Personel No"].ToString();
                }
                con.Close();
                if (str != "")
                {
                    return true;
                }
            }
            return false;
        }       
        private void button3_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text=="" )|| (textBox2.Text=="") || (textBox3.Text=="") || (textBox4.Text=="") || (comboBox2.Text=="") || (comboBox1.Text=="") || (comboBox3.Text=="") || (textBox12.Text=="") || (textBox9.Text=="") || (textBox13.Text==""))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
            }
            else
            {
                FormPerformanceGrades form = new FormPerformanceGrades();
                label15.Text = textBox1.Text;
                label16.Text = textBox2.Text;
                label17.Text = textBox3.Text;
                label18.Text = textBox4.Text;
                DialogResult result = MessageBox.Show("Kaydetmek İstediğinize Emin Misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if ((result == DialogResult.Yes)&&(aynıKimlikNoluElemanVarMı()==false))
                {
                    con.Open();
                    string sql = "Insert into ProjeDatası([Personel No],[Kimlik No],[Departman],[Görev],[Güven Kıdemi],[Yabancı Dil],[Sınavlar],[Sertifikalar],[Ödüller],[Eğitim Düzeyi],[Doğum Tarihi],[Cinsiyet],[Telefon],[E-Mail]) values(@no,@id,@depart, @görev,@kıdem, @ydil,@sınav,@sertifika,@odul,@egitim,@dogum,@cinsiyet,@telefon,@mail)";
                    OleDbCommand komut = new OleDbCommand(sql, con);
                    komut.Parameters.AddWithValue("@no", textBox1.Text);
                    komut.Parameters.AddWithValue("@id", textBox2.Text);
                    komut.Parameters.AddWithValue("@depart", textBox3.Text);
                    komut.Parameters.AddWithValue("@görev", textBox4.Text);
                    komut.Parameters.AddWithValue("@kıdem", textBox9.Text);
                    komut.Parameters.AddWithValue("@ydil", comboBox2.Text);
                    komut.Parameters.AddWithValue("@sınav", textBox5.Text);
                    komut.Parameters.AddWithValue("@sertifika", textBox6.Text);
                    komut.Parameters.AddWithValue("@odul", textBox7.Text);
                    komut.Parameters.AddWithValue("@egitim", comboBox1.Text);
                    komut.Parameters.AddWithValue("@dogum", dateTimePicker1.Text);
                    komut.Parameters.AddWithValue("@cinsiyet", comboBox3.Text);
                    komut.Parameters.AddWithValue("@telefon", textBox12.Text);
                    komut.Parameters.AddWithValue("@mail", textBox13.Text);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kaydedildi");
                    con.Close();                  
                }
                else if ((result == DialogResult.Yes) && (aynıKimlikNoluElemanVarMı() == true))
                {
                    MessageBox.Show("Aynı ID değerine sahip başka biri vardır. Lütfen farklı bir ID ile tekrar deneyiniz.");
                }
                }           
        }
        private void FormBilgiler_Load(object sender, EventArgs e)
        {            
        if (isim != "")
            {
                verileriGoster_Isim();
            }
            else if ((isim == "") && (id != ""))
            {
                verileriGoster_Id();
            }
            
            if (bilgileri_degistir == true)
            {
                textBox2.Enabled = false;
                button5.Visible = true;
            }
            if (bilgileri_kaydet == true)
            {
                button3.Visible = true;
                button6.Visible = true;
            }
            if (performans_ekle == true)
            {
                button1.Visible = true;

            }
            if (performans_goster == true)
            {
                button4.Visible = true;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            FormPerformanceGrades form = new FormPerformanceGrades();
            if (personelEkledenGelen == "Doğru")
            {
                form.personelEkledenGelen1 = "Doğru";
            }
            form.personelIsim = textBox1.Text;
            form.personelId = textBox2.Text;
            form.personelDepartment = textBox3.Text;
            form.personelGorev = textBox4.Text;
            form.degistir = true;
            form.Show();
            this.Hide();
        }
        private void button5_Click(object sender, EventArgs e)
        {            
            DialogResult result = MessageBox.Show("Değiştirmek İstediğinize Emin Misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                con.Open();
                string sql = "update ProjeDatası set [Personel No]=@no,[Kimlik No]=@id,[Departman] =@depart,[Görev]=@görev,[Güven Kıdemi]=@kıdem, [Yabancı Dil]=@ydil,[Sınavlar]=@sınav,[Sertifikalar]=@sertifika,[Ödüller]=@odul,[Eğitim Düzeyi]=@egitim,[Doğum Tarihi]=@dogum,[Cinsiyet]=@cinsiyet,[Telefon]=@telefon,[E-Mail]=@mail where [Kimlik No]=@id";
                OleDbCommand komut = new OleDbCommand(sql, con);
                komut.Parameters.AddWithValue("@no", textBox1.Text);
                komut.Parameters.AddWithValue("@id", textBox2.Text);
                komut.Parameters.AddWithValue("@depart", textBox3.Text);
                komut.Parameters.AddWithValue("@görev", textBox4.Text);
                komut.Parameters.AddWithValue("@kıdem", textBox9.Text);
                komut.Parameters.AddWithValue("@ydil", comboBox2.Text);
                komut.Parameters.AddWithValue("@sınav", textBox5.Text);
                komut.Parameters.AddWithValue("@sertifika", textBox6.Text);
                komut.Parameters.AddWithValue("@odul", textBox7.Text);
                komut.Parameters.AddWithValue("@egitim", comboBox1.Text);
                komut.Parameters.AddWithValue("@dogum", dateTimePicker1.Text);
                komut.Parameters.AddWithValue("@cinsiyet", comboBox3.Text);
                komut.Parameters.AddWithValue("@telefon", textBox12.Text);
                komut.Parameters.AddWithValue("@mail", textBox13.Text);
                komut.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Değiştirildi");
            }
        }
        private void verileriGoster_Isim()
        {
            con.Open();
            string sql = "Select * from ProjeDatası where [Personel No]='" + isim + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBox1.Text = oku["Personel No"].ToString();
                textBox2.Text = oku["Kimlik No"].ToString();
                textBox3.Text = oku["Departman"].ToString();
                textBox4.Text = oku["Görev"].ToString();
                textBox9.Text = oku["Güven Kıdemi"].ToString();
                comboBox2.Text = oku["Yabancı Dil"].ToString();
                textBox5.Text = oku["Sınavlar"].ToString();
                textBox6.Text = oku["Sertifikalar"].ToString();
                textBox7.Text = oku["Ödüller"].ToString();
                comboBox1.Text = oku["Eğitim Düzeyi"].ToString();
                dateTimePicker1.Text = oku["Doğum Tarihi"].ToString();
                comboBox3.Text = oku["Cinsiyet"].ToString();
                textBox12.Text = oku["Telefon"].ToString();
                textBox13.Text = oku["E-Mail"].ToString();
            }
            con.Close();
        }
        private void verileriGoster_Id()
        {
            con.Open();
            string sql = "Select * from ProjeDatası where [Kimlik No]='" + id + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {

                textBox1.Text = oku["Personel No"].ToString();
                textBox2.Text = oku["Kimlik No"].ToString();
                textBox3.Text = oku["Departman"].ToString();
                textBox4.Text = oku["Görev"].ToString();
                textBox9.Text = oku["Güven Kıdemi"].ToString();
                comboBox2.Text = oku["Yabancı Dil"].ToString();
                textBox5.Text = oku["Sınavlar"].ToString();
                textBox6.Text = oku["Sertifikalar"].ToString();
                textBox7.Text = oku["Ödüller"].ToString();
                comboBox1.Text = oku["Eğitim Düzeyi"].ToString();
                dateTimePicker1.Text = oku["Doğum Tarihi"].ToString();
                comboBox3.Text = oku["Cinsiyet"].ToString();
                textBox12.Text = oku["Telefon"].ToString();
                textBox13.Text = oku["E-Mail"].ToString();
            }
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (comboBox2.Text == "") || (textBox5.Text == "") || (textBox6.Text == "") || (textBox7.Text == "") || (comboBox1.Text == "") || (comboBox3.Text == "") || (textBox12.Text == "") ||(textBox9.Text=="")|| (textBox13.Text == ""))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
            }
            else {
                FormPerformanceGrades form = new FormPerformanceGrades();
                form.kaydet = true;
                form.personelIsim = label15.Text;
                form.personelId = label16.Text;
                form.personelDepartment = label17.Text;
                form.personelGorev = label18.Text;
                form.Show();
                this.Hide();
            }       
        }
        private void label15_Click(object sender, EventArgs e)
        {
        }
        private void button6_Click(object sender, EventArgs e)
        {
            FormPasswordChange form = new FormPasswordChange();
            form.nereden1 = "Yeni Çalışan Ekle";
            form.yöneticiveyaçalışan = "Yönetici";
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (comboBox2.Text == "") || (textBox5.Text == "") || (textBox6.Text == "") || (textBox7.Text == "") || (comboBox1.Text == "") || (comboBox3.Text == "") || (textBox12.Text == "") || (textBox9.Text=="")|| (textBox13.Text == ""))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
            }
            else
            {
                form.Show();
            }          
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (e.KeyChar == '.'))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (e.KeyChar == '.'))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
        private void textBox12_TextChanged(object sender, EventArgs e)
        {            
        }
        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (e.KeyChar == '.'))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }

