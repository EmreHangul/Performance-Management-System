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
using System.Threading;

namespace Lookup
{
    public partial class FormTOPSIS : Form
    {
        public FormTOPSIS()
        {
            InitializeComponent();
        }
        public int count1 = 0;
        public int count2 = 0;
        public string isim = "";
        public string TOPSISsonuc;
        public string Performanssonuc;
        public string personelID;
        public string personelNo;
        public string performansSonucuTOPSISSayfası;

        public double yetkinlik1;
        public double yetkinlik2;
        public double yetkinlik3;
        public double yabancıdil;
        public double ödüller;
        public double kıdem;
        public double eğitimdüzeyi;
        public double sınavlar;
        public double sertifikalar;

        public double yetkinlik1ağırlık = 0;
        public double yetkinlik2ağırlık = 0;
        public double yetkinlik3ağırlık = 0;
        public double kıdemağırlık = 0;
        public double eğitimdurumuağırlık = 0;
        public double sınavlarağırlık = 0;
        public double sertifikalarağırlık = 0;
        public double yabancıdilağırlık = 0;
        public double ödüllerağırlık = 0;

        public double yetkinlik1değer;
        public double yetkinlik2değer;
        public double yetkinlik3değer;
        public double kıdemdeğer;
        public double eğitimdurumudeğer;
        public double sınavlardeğer;
        public double sertifikalardeğer;
        public double yabancıdildeğer;
        public double ödüllerdeğer;

        public double kararanalizisonucu;
        public double twoDec;

        public bool agırlıklardogrumu;
        public bool yeniKayit;
        public string personelEkledenGelen2;
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\user\\Desktop\\Lookup\\bin\\Debug\\Database\\Proje.mdb");

        private void TOPSIS_Load(object sender, EventArgs e)
        {
            string str = "str";
            con.Open();
            string s1 = "Select * from GenelBilgiler where [Kimlik No]='" + personelID + "'";
            OleDbCommand komut1 = new OleDbCommand(s1, con);
            komut1.ExecuteNonQuery();
            OleDbDataReader oku = komut1.ExecuteReader();

            while (oku.Read())
            {
                str = oku["Personel No"].ToString();
            }
            con.Close();
            Thread.Sleep(100);

            if (str == "str")
            {
                con.Open();
                string sql = "Insert into GenelBilgiler([Kimlik No]) values (@kimlikno)";
                OleDbCommand komut = new OleDbCommand(sql, con);
                komut.Parameters.AddWithValue("@kimlikno", personelID);
                komut.ExecuteNonQuery();
                con.Close();
            }
            Thread.Sleep(100);
            textBox1.Text = TOPSISsonuc;
            boşata();
            Thread.Sleep(100);
            projeDatasıOku();
            GenelBilgilerOku();

            button1.Visible = false;
            button2.Visible = false;

            if (textBox7.Text == "")
            {
                button2.Visible = true;
                button1.Visible = false;
                yeniKayit = true;
            }
            else if (textBox7.Text != "")
            {
                button1.Visible = true;
                button2.Visible = false;
                yeniKayit = false;
            }
            kararAnalizi();
            labelTOPSIS.Text = textBox1.Text;
            labelANALİZ.Text = textBox2.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FormPerformanceGrades form = new FormPerformanceGrades();
            form.Show();
            this.Hide();
        }
        private void projeDatasıOku()
        {
            con.Open();
            string sql = "Select * from ProjeDatası where [Kimlik No]='" + personelID + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                textBox12.Text = oku["Personel No"].ToString();
                textBox11.Text = oku["Kimlik No"].ToString();
                textBox16.Text = oku["Güven Kıdemi"].ToString();
                textBox3.Text = oku["Eğitim Düzeyi"].ToString();
                textBox5.Text = oku["Sınavlar"].ToString();
                textBox6.Text = oku["Sertifikalar"].ToString();
                textBox4.Text = oku["Yabancı Dil"].ToString();
                textBox10.Text = oku["Ödüller"].ToString();
            }
            con.Close();
        }
        private void GenelBilgilerOku()
        {
            con.Open();
            string sql = "Select * from GenelBilgiler where [Kimlik No]='" + personelID + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {

                if (oku["Kıdemi Yeterli"].ToString() == "-1")
                {
                    checkBox22.Checked = true;
                }
                else if (oku["Kıdemi Yeterli"].ToString() == "0")
                {
                    checkBox22.Checked = false;
                }
                if (oku["Kıdemi Yetersiz"].ToString() == "-1")
                {
                    checkBox25.Checked = true;
                }
                else if (oku["Kıdemi Yetersiz"].ToString() == "0")
                {
                    checkBox25.Checked = false;
                }

                if (oku["Eğitim Aldı"].ToString() == "-1")
                {
                    checkBox1.Checked = true;
                }
                else if (oku["Eğitim Aldı"].ToString() == "0")
                {
                    checkBox1.Checked = false;
                }
                if (oku["Eğitim Almadı"].ToString() == "-1")
                {
                    checkBox2.Checked = true;
                }
                else if (oku["Eğitim Almadı"].ToString() == "0")
                {
                    checkBox2.Checked = false;
                }
                if (oku["Sınavlar Aldı"].ToString() == "-1")
                {
                    checkBox15.Checked = true;
                }
                else if (oku["Sınavlar Aldı"].ToString() == "0")
                {
                    checkBox15.Checked = false;
                }
                if (oku["Sınavlar Almadı"].ToString() == "-1")
                {
                    checkBox16.Checked = true;
                }
                else if (oku["Sınavlar Almadı"].ToString() == "0")
                {
                    checkBox16.Checked = false;
                }
                if (oku["Sertifikalar Aldı"].ToString() == "-1")
                {
                    checkBox17.Checked = true;
                }
                else if (oku["Sertifikalar Aldı"].ToString() == "0")
                {
                    checkBox17.Checked = false;
                }
                if (oku["Sertifikalar Almadı"].ToString() == "-1")
                {
                    checkBox18.Checked = true;
                }
                else if (oku["Sertifikalar Almadı"].ToString() == "0")
                {
                    checkBox18.Checked = false;
                }
                textBox7.Text = oku["Yetenek Hedefi 1"].ToString();
                textBox8.Text = oku["Yetenek Hedefi 2"].ToString();
                textBox9.Text = oku["Yetenek Hedefi 3"].ToString();
                comboBox1.Text = oku["Yetenek 1 Açıklama"].ToString();
                comboBox2.Text = oku["Yetenek 2 Açıklama"].ToString();
                comboBox3.Text = oku["Yetenek 3 Açıklama"].ToString();
                comboBox4.Text = oku["Seviye 1"].ToString();
                comboBox5.Text = oku["Seviye 2"].ToString();
                comboBox6.Text = oku["Seviye 3"].ToString();
                textBox13.Text = oku["Seviye 1 Açıklama"].ToString();
                textBox14.Text = oku["Seviye 2 Açıklama"].ToString();
                textBox15.Text = oku["Seviye 3 Açıklama"].ToString();
                if (oku["Yetenek 1 Yetersiz"].ToString() == "-1")
                {
                    checkBox5.Checked = true;
                }
                else if (oku["Yetenek 1 Yetersiz"].ToString() == "0")
                {
                    checkBox5.Checked = false;
                }
                if (oku["Yetenek 1 Yeterli"].ToString() == "-1")
                {
                    checkBox6.Checked = true;
                }
                else if (oku["Yetenek 1 Yeterli"].ToString() == "0")
                {
                    checkBox6.Checked = false;
                }
                if (oku["Yetenek 1 Üstün Yeterli"].ToString() == "-1")
                {
                    checkBox7.Checked = true;
                }
                else if (oku["Yetenek 1 Üstün Yeterli"].ToString() == "0")
                {
                    checkBox7.Checked = false;
                }
                if (oku["Yetenek 2 Yetersiz"].ToString() == "-1")
                {
                    checkBox8.Checked = true;
                }
                else if (oku["Yetenek 2 Yetersiz"].ToString() == "0")
                {
                    checkBox8.Checked = false;
                }
                if (oku["Yetenek 2 Yeterli"].ToString() == "-1")
                {
                    checkBox9.Checked = true;
                }
                else if (oku["Yetenek 2 Yeterli"].ToString() == "0")
                {
                    checkBox9.Checked = false;
                }
                if (oku["Yetenek 2 Üstün Yeterli"].ToString() == "-1")
                {
                    checkBox10.Checked = true;
                }
                else if (oku["Yetenek 2 Üstün Yeterli"].ToString() == "0")
                {
                    checkBox10.Checked = false;
                }
                if (oku["Yetenek 3 Yetersiz"].ToString() == "-1")
                {
                    checkBox11.Checked = true;
                }
                if (oku["Yetenek 3 Yetersiz"].ToString() == "0")
                {
                    checkBox11.Checked = false;
                }
                if (oku["Yetenek 3 Yeterli"].ToString() == "-1")
                {
                    checkBox12.Checked = true;
                }
                else if (oku["Yetenek 3 Yeterli"].ToString() == "0")
                {
                    checkBox12.Checked = false;
                }
                if (oku["Yetenek 3 Üstün Yeterli"].ToString() == "-1")
                {
                    checkBox13.Checked = true;
                }
                else if (oku["Yetenek 3 Üstün Yeterli"].ToString() == "0")
                {
                    checkBox13.Checked = false;
                }
                if (oku["Yabancı Dil Yetersiz"].ToString() == "-1")
                {
                    checkBox3.Checked = true;
                }
                else if (oku["Yabancı Dil Yetersiz"].ToString() == "0")
                {
                    checkBox3.Checked = false;
                }
                if (oku["Yabancı Dil Yeterli"].ToString() == "-1")
                {
                    checkBox4.Checked = true;
                }
                else if (oku["Yabancı Dil Yeterli"].ToString() == "0")
                {
                    checkBox4.Checked = false;
                }
                if (oku["Yabancı Dil Üstün Yeterli"].ToString() == "-1")
                {
                    checkBox14.Checked = true;
                }
                else if (oku["Yabancı Dil Üstün Yeterli"].ToString() == "0")
                {
                    checkBox14.Checked = false;
                }
                if (oku["Ödüller Yok"].ToString() == "-1")
                {
                    checkBox19.Checked = true;
                }
                else if (oku["Ödüller Yok"].ToString() == "0")
                {
                    checkBox19.Checked = false;
                }
                if (oku["Ödül 1 Tane"].ToString() == "-1")
                {
                    checkBox20.Checked = true;
                }
                else if (oku["Ödül 1 Tane"].ToString() == "0")
                {
                    checkBox20.Checked = false;
                }
                if (oku["Ödül 2 ve Fazla"].ToString() == "-1")
                {
                    checkBox21.Checked = true;
                }
                else if (oku["Ödül 2 ve Fazla"].ToString() == "0")
                {
                    checkBox21.Checked = false;
                }
                textBox23.Text = oku["Y1 Ağırlık"].ToString();
                textBox24.Text = oku["Y2 Ağırlık"].ToString();
                textBox25.Text = oku["Y3 Ağırlık"].ToString();
                textBox29.Text = oku["Kıdem Ağırlık"].ToString();
                textBox30.Text = oku["Eğitim Ağırlık"].ToString();
                textBox31.Text = oku["YDil Ağırlık"].ToString();
                textBox32.Text = oku["Sınavlar Ağırlık"].ToString();
                textBox33.Text = oku["Sertifikalar Ağırlık"].ToString();
                textBox34.Text = oku["Ödüller Ağırlık"].ToString();
            }
            con.Close();
        }
        private void GenelBilgilerUpdate()
        {
            if (con != null && con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "update GenelBilgiler set [Personel No]=@no,[Kimlik No]=@kimlikno,[Güven Kıdemi]=@kıdem," +
                "[Kıdemi Yeterli]=@kıdemiyeterli,[Kıdemi Yetersiz]=@kıdemiyetersiz,[Eğitim Düzeyi]=@eğitim,[Sınavlar]" +
                "=@sınav,[Sertifikalar]=@sertifika,[Eğitim Aldı]=@ealdı,[Eğitim Almadı]=@ealmadı,[Sınavlar Aldı]=@sınavlaraldı," +
                "[Sınavlar Almadı]=@sınavlaralmadı,[Sertifikalar Aldı]=@srtaldı,[Sertifikalar Almadı]=@srtalmadı,[Yetenek Hedefi 1]=@y1," +
                "[Yetenek Hedefi 2]=@y2,[Yetenek Hedefi 3]=@y3,[Yetenek 1 Açıklama]=@y1açıklama,[Yetenek 2 Açıklama]=@y2açıklama," +
                "[Yetenek 3 Açıklama]=@y3açıklama,[Seviye 1]=@seviye1,[Seviye 2]=@seviye2,[Seviye 3]=@seviye3," +
                "[Seviye 1 Açıklama]=@seviye1açıklama,[Seviye 2 Açıklama]=@seviye2açıklama,[Seviye 3 Açıklama]=@seviye3açıklama," +
                "[Yabancı Dil]=@ydil,[Ödüller]=@ödül,[Yetenek 1 Yetersiz]=@y1yetersiz,[Yetenek 1 Yeterli]=@y1yeterli, " +
                "[Yetenek 1 Üstün Yeterli]=@y1üstün,[Yetenek 2 Yetersiz]=@y2yetersiz,[Yetenek 2 Yeterli]=@y2yeterli, " +
                "[Yetenek 2 Üstün Yeterli]=@y2üstün,[Yetenek 3 Yetersiz]=@y3yetersiz,[Yetenek 3 Yeterli]=@y3yeterli, " +
                "[Yetenek 3 Üstün Yeterli]=@y3üstün,[Yabancı Dil Yetersiz]=@ydilyetersiz,[Yabancı Dil Yeterli]=@ydilyeterli, " +
                "[Yabancı Dil Üstün Yeterli]=@ydilüstün,[Ödüller Yok]=@ödülyok,[Ödül 1 Tane]=@ödül1tane," +
                "[Ödül 2 ve Fazla]=@ödül2vefazla,[Y1 Ağırlık]=@y1ağırlık,[Y2 Ağırlık]=@y2ağırlık,[Y3 Ağırlık]=@y3ağırlık," +
                "[Kıdem Ağırlık]=@kıdemağırlık,[Eğitim Ağırlık]=@eğitimağırlık,[YDil Ağırlık]=@ydilağırlık," +
                "[Sınavlar Ağırlık]=@sınavlarağırlık,[Sertifikalar Ağırlık]=@sertifikalarağırlık,[Ödüller Ağırlık]=" +
                "@ödüllerağırlık where [Kimlik No]=@kimlikno";
            OleDbCommand komut = new OleDbCommand(sql, con);
            if (textBox12.Text != "")
            {
                komut.Parameters.AddWithValue("@no", textBox12.Text);
            }
            else if (textBox12.Text == "")
            {
                komut.Parameters.AddWithValue("@no", " ");
            }

            komut.Parameters.AddWithValue("@kimlikno", personelID);

            if (textBox16.Text != "")
            {
                komut.Parameters.AddWithValue("@kıdem", textBox16.Text);
            }
            else if (textBox16.Text == "")
            {
                komut.Parameters.AddWithValue("@kıdem", " ");
            }
            if (checkBox22.Checked == true)
            {
                komut.Parameters.AddWithValue("@kıdemiyeterli", "-1");
            }
            else if (checkBox22.Checked == false)
            {
                komut.Parameters.AddWithValue("@kıdemiyeterli", "0");
            }
            if (checkBox25.Checked == true)
            {
                komut.Parameters.AddWithValue("@kıdemiyetersiz", "-1");
            }
            else if (checkBox25.Checked == false)
            {
                komut.Parameters.AddWithValue("@kıdemiyetersiz", "0");
            }
            if (textBox3.Text != "")
            {
                komut.Parameters.AddWithValue("@eğitim", textBox3.Text);
            }
            else if (textBox3.Text == "")
            {
                komut.Parameters.AddWithValue("@eğitim", " ");
            }
            if (textBox5.Text != "")
            {
                komut.Parameters.AddWithValue("@sınav", textBox5.Text);
            }
            else if (textBox5.Text == "")
            {
                komut.Parameters.AddWithValue("@sınav", " ");
            }
            if (textBox6.Text != "")
            {
                komut.Parameters.AddWithValue("@sertifika", textBox6.Text);
            }
            else if (textBox6.Text == "")
            {
                komut.Parameters.AddWithValue("@sertifika", " ");
            }
            if (checkBox1.Checked == true)
            {
                komut.Parameters.AddWithValue("@ealdı", "-1");
            }
            else if (checkBox1.Checked == false)
            {
                komut.Parameters.AddWithValue("@ealdı", "0");
            }

            if (checkBox2.Checked == true)
            {
                komut.Parameters.AddWithValue("@ealmadı", "-1");
            }
            else if (checkBox2.Checked == false)
            {
                komut.Parameters.AddWithValue("@ealmadı", "0");
            }
            //////////////////////////////////
            if (checkBox15.Checked == true)
            {
                komut.Parameters.AddWithValue("@sınavlaraldı", "-1");
            }
            else if (checkBox15.Checked == false)
            {
                komut.Parameters.AddWithValue("@sınavlaraldı", "0");
            }

            if (checkBox16.Checked == true)
            {
                komut.Parameters.AddWithValue("@sınavlaralmadı", "-1");
            }
            else if (checkBox16.Checked == false)
            {
                komut.Parameters.AddWithValue("@sınavlaralmadı", "0");
            }
            ///////////////////////////////////
            if (checkBox17.Checked == true)
            {
                komut.Parameters.AddWithValue("@srtaldı", "-1");
            }
            else if (checkBox17.Checked == false)
            {
                komut.Parameters.AddWithValue("@srtaldı", "0");
            }

            if (checkBox18.Checked == true)
            {
                komut.Parameters.AddWithValue("@srtalmadı", "-1");
            }
            else if (checkBox18.Checked == false)
            {
                komut.Parameters.AddWithValue("@srtalmadı", "0");
            }
            if (textBox7.Text != "")
            {
                komut.Parameters.AddWithValue("@y1", textBox7.Text);
            }
            else if (textBox7.Text == "")
            {
                komut.Parameters.AddWithValue("@y1", " ");
            }
            if (textBox8.Text != "")
            {
                komut.Parameters.AddWithValue("@y2", textBox8.Text);
            }
            else if (textBox8.Text == "")
            {
                komut.Parameters.AddWithValue("@y2", " ");
            }
            if (textBox9.Text != "")
            {
                komut.Parameters.AddWithValue("@y3", textBox9.Text);
            }
            else if (textBox9.Text == "")
            {
                komut.Parameters.AddWithValue("@y3", " ");
            }
            if (comboBox1.Text != "")
            {
                komut.Parameters.AddWithValue("@y1açıklama", comboBox1.Text);
            }
            else if (comboBox1.Text == "")
            {
                komut.Parameters.AddWithValue("@y1açıklama", " ");
            }

            if (comboBox2.Text != "")
            {
                komut.Parameters.AddWithValue("@y2açıklama", comboBox2.Text);
            }
            else if (comboBox2.Text == "")
            {
                komut.Parameters.AddWithValue("@y2açıklama", " ");
            }
            if (comboBox3.Text != "")
            {
                komut.Parameters.AddWithValue("@y3açıklama", comboBox3.Text);

            }
            else if (comboBox3.Text == "")
            {
                komut.Parameters.AddWithValue("@y3açıklama", " ");

            }
            if (comboBox4.Text != "")
            {
                komut.Parameters.AddWithValue("@seviye1", comboBox4.Text);
            }
            else if (comboBox4.Text == "")
            {
                komut.Parameters.AddWithValue("@seviye1", " ");
            }

            if (comboBox5.Text != "")
            {
                komut.Parameters.AddWithValue("@seviye2", comboBox5.Text);
            }
            else if (comboBox5.Text == "")
            {
                komut.Parameters.AddWithValue("@seviye2", " ");
            }
            if (comboBox6.Text != "")
            {
                komut.Parameters.AddWithValue("@seviye3", comboBox6.Text);
            }
            else if (comboBox6.Text == "")
            {
                komut.Parameters.AddWithValue("@seviye3", " ");
            }
            if (textBox13.Text != "")
            {
                komut.Parameters.AddWithValue("@seviye1açıklama", textBox13.Text);
            }
            else if (textBox13.Text == "")
            {
                komut.Parameters.AddWithValue("@seviye1açıklama", " ");
            }
            if (textBox14.Text != "")
            {
                komut.Parameters.AddWithValue("@seviye2açıklama", textBox14.Text);
            }
            else if (textBox14.Text == "")
            {
                komut.Parameters.AddWithValue("@seviye2açıklama", " ");
            }
            if (textBox15.Text != "")
            {
                komut.Parameters.AddWithValue("@seviye3açıklama", textBox15.Text);
            }
            else if (textBox15.Text == "")
            {
                komut.Parameters.AddWithValue("@seviye3açıklama", " ");
            }
            if (textBox4.Text != "")
            {
                komut.Parameters.AddWithValue("@ydil", textBox4.Text);
            }
            else if (textBox4.Text == "")
            {
                komut.Parameters.AddWithValue("@ydil", " ");
            }

            if (textBox10.Text != "")
            {
                komut.Parameters.AddWithValue("@ödül", textBox10.Text);
            }
            else if (textBox10.Text == "")
            {
                komut.Parameters.AddWithValue("@ödül", " ");
            }
            if (checkBox5.Checked == true)
            {
                komut.Parameters.AddWithValue("@y1yetersiz", "-1");
            }
            else if (checkBox5.Checked == false)
            {
                komut.Parameters.AddWithValue("@y1yetersiz", "0");
            }

            if (checkBox6.Checked == true)
            {
                komut.Parameters.AddWithValue("@y1yeterli", "-1");
            }
            else if (checkBox6.Checked == false)
            {
                komut.Parameters.AddWithValue("@y1yeterli", "0");
            }

            if (checkBox7.Checked == true)
            {
                komut.Parameters.AddWithValue("@y1üstün", "-1");
            }
            else if (checkBox7.Checked == false)
            {
                komut.Parameters.AddWithValue("@y1üstün", "0");
            }
            //////////////////////
            if (checkBox8.Checked == true)
            {
                komut.Parameters.AddWithValue("@y2yetersiz", "-1");
            }
            else if (checkBox8.Checked == false)
            {
                komut.Parameters.AddWithValue("@y2yetersiz", "0");
            }

            if (checkBox9.Checked == true)
            {
                komut.Parameters.AddWithValue("@y2yeterli", "-1");
            }
            else if (checkBox9.Checked == false)
            {
                komut.Parameters.AddWithValue("@y2yeterli", "0");
            }

            if (checkBox10.Checked == true)
            {
                komut.Parameters.AddWithValue("@y2üstün", "-1");
            }
            else if (checkBox10.Checked == false)
            {
                komut.Parameters.AddWithValue("@y2üstün", "0");
            }
            ////////////////////////
            if (checkBox11.Checked == true)
            {
                komut.Parameters.AddWithValue("@y3yetersiz", "-1");
            }
            else if (checkBox11.Checked == false)
            {
                komut.Parameters.AddWithValue("@y3yetersiz", "0");
            }

            if (checkBox12.Checked == true)
            {
                komut.Parameters.AddWithValue("@y3yeterli", "-1");
            }
            else if (checkBox12.Checked == false)
            {
                komut.Parameters.AddWithValue("@y3yeterli", "0");
            }

            if (checkBox13.Checked == true)
            {
                komut.Parameters.AddWithValue("@y3üstün", "-1");
            }
            else if (checkBox13.Checked == false)
            {
                komut.Parameters.AddWithValue("@y3üstün", "0");
            }
            //////////////////////////////
            if (checkBox3.Checked == true)
            {
                komut.Parameters.AddWithValue("@ydilyetersiz", "-1");
            }
            else if (checkBox3.Checked == false)
            {
                komut.Parameters.AddWithValue("@ydilyetersiz", "0");
            }

            if (checkBox4.Checked == true)
            {
                komut.Parameters.AddWithValue("@ydilyeterli", "-1");
            }
            else if (checkBox4.Checked == false)
            {
                komut.Parameters.AddWithValue("@ydilyeterli", "0");
            }

            if (checkBox14.Checked == true)
            {
                komut.Parameters.AddWithValue("@ydilüstün", "-1");
            }
            else if (checkBox14.Checked == false)
            {
                komut.Parameters.AddWithValue("@ydilüstün", "0");
            }
            /////////////////////////////////////////////

            if (checkBox19.Checked == true)
            {
                komut.Parameters.AddWithValue("@ödülyok", "-1");
            }
            else if (checkBox19.Checked == false)
            {
                komut.Parameters.AddWithValue("@ödülyok", " 0");
            }

            if (checkBox20.Checked == true)
            {
                komut.Parameters.AddWithValue("@ödül1tane", "-1");
            }
            else if (checkBox20.Checked == false)
            {
                komut.Parameters.AddWithValue("@ödül1tane", "0");
            }

            if (checkBox21.Checked == true)
            {
                komut.Parameters.AddWithValue("@ödül2vefazla", "-1");
            }
            else if (checkBox21.Checked == false)
            {
                komut.Parameters.AddWithValue("@ödül2vefazla", "0");
            }
            if (textBox23.Text != "")
            {
                komut.Parameters.AddWithValue("@y1ağırlık", textBox23.Text);
            }
            else if (textBox23.Text == "")
            {
                komut.Parameters.AddWithValue("@y1ağırlık", "");
            }
            if (textBox24.Text != "")
            {
                komut.Parameters.AddWithValue("@y2ağırlık", textBox24.Text);
            }
            else if (textBox24.Text == "")
            {
                komut.Parameters.AddWithValue("@y2ağırlık", "");
            }
            if (textBox25.Text != "")
            {
                komut.Parameters.AddWithValue("@y3ağırlık", textBox25.Text);
            }
            else if (textBox25.Text == "")
            {
                komut.Parameters.AddWithValue("@y3ağırlık", "");
            }
            if (textBox29.Text != "")
            {
                komut.Parameters.AddWithValue("@kıdemağırlık", textBox29.Text);
            }
            else if (textBox29.Text == "")
            {
                komut.Parameters.AddWithValue("@kıdemağırlık", "");
            }
            if (textBox30.Text != "")
            {
                komut.Parameters.AddWithValue("@eğitimağırlık", textBox30.Text);
            }
            else if (textBox30.Text == "")
            {
                komut.Parameters.AddWithValue("@eğitimağırlık", "");
            }
            if (textBox31.Text != "")
            {
                komut.Parameters.AddWithValue("@ydilağırlık", textBox31.Text);
            }
            else if (textBox31.Text == "")
            {
                komut.Parameters.AddWithValue("@ydilağırlık", "");
            }
            if (textBox32.Text != "")
            {
                komut.Parameters.AddWithValue("@sınavlarağırlık", textBox32.Text);
            }
            else if (textBox32.Text == "")
            {
                komut.Parameters.AddWithValue("@sınavlarağırlık", "");
            }
            if (textBox33.Text != "")
            {
                komut.Parameters.AddWithValue("@sertifikalarağırlık", textBox33.Text);
            }
            else if (textBox33.Text == "")
            {
                komut.Parameters.AddWithValue("@sertifikalarağırlık", "");
            }
            if (textBox34.Text != "")
            {
                komut.Parameters.AddWithValue("@ödüllerağırlık", textBox34.Text);
            }
            else if (textBox34.Text == "")
            {
                komut.Parameters.AddWithValue("@ödüllerağırlık", "");
            }
            komut.ExecuteNonQuery();
            con.Close();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            kararAnalizi();
            agırlıklardogrumu = true;
            if ((textBox23.Text != "") && (textBox24.Text == "") && (textBox25.Text == "") && (textBox29.Text == "") && (textBox30.Text == "") && (textBox31.Text == "") && (textBox32.Text == "") && (textBox33.Text == "") && (textBox34.Text == ""))
            {
                if (yetkinlik1ağırlık != 100)
                {
                    MessageBox.Show("Girdiğiniz ağırlıkların toplamı 100 olmalıdır. Lütfen 1 daha kontrol ediniz.");
                    agırlıklardogrumu = false;
                }
            }
            else if ((textBox23.Text != "") && (textBox24.Text != "") && (textBox25.Text == "") && (textBox29.Text == "") && (textBox30.Text == "") && (textBox31.Text == "") && (textBox32.Text == "") && (textBox33.Text == "") && (textBox34.Text == ""))
            {
                if (yetkinlik1ağırlık + yetkinlik2ağırlık != 100)
                {
                    MessageBox.Show("Girdiğiniz ağırlıkların toplamı 100 olmalıdır. Lütfen 1 daha kontrol ediniz.");
                    agırlıklardogrumu = false;
                }
            }
            else if ((textBox23.Text != "") && (textBox24.Text != "") && (textBox25.Text != "") && (textBox29.Text == "") && (textBox30.Text == "") && (textBox31.Text == "") && (textBox32.Text == "") && (textBox33.Text == "") && (textBox34.Text == ""))
            {
                if (yetkinlik1ağırlık + yetkinlik2ağırlık + yetkinlik3ağırlık != 100)
                {
                    MessageBox.Show("Girdiğiniz ağırlıkların toplamı 100 olmalıdır. Lütfen 1 daha kontrol ediniz.");
                    agırlıklardogrumu = false;
                }
            }
            else if ((textBox23.Text != "") && (textBox24.Text != "") && (textBox25.Text != "") && (textBox29.Text != "") && (textBox30.Text == "") && (textBox31.Text == "") && (textBox32.Text == "") && (textBox33.Text == "") && (textBox34.Text == ""))
            {
                if (yetkinlik1ağırlık + yetkinlik2ağırlık + yetkinlik3ağırlık + kıdemağırlık != 100)
                {
                    MessageBox.Show("Girdiğiniz ağırlıkların toplamı 100 olmalıdır. Lütfen 1 daha kontrol ediniz.");
                    agırlıklardogrumu = false;
                }
            }
            else if ((textBox23.Text != "") && (textBox24.Text != "") && (textBox25.Text != "") && (textBox29.Text != "") && (textBox30.Text != "") && (textBox31.Text == "") && (textBox32.Text == "") && (textBox33.Text == "") && (textBox34.Text == ""))
            {
                if (yetkinlik1ağırlık + yetkinlik2ağırlık + yetkinlik3ağırlık + kıdemağırlık + eğitimdurumuağırlık != 100)
                {
                    MessageBox.Show("Girdiğiniz ağırlıkların toplamı 100 olmalıdır. Lütfen 1 daha kontrol ediniz.");
                    agırlıklardogrumu = false;
                }
            }
            else if ((textBox23.Text != "") && (textBox24.Text != "") && (textBox25.Text != "") && (textBox29.Text != "") && (textBox30.Text != "") && (textBox31.Text != "") && (textBox32.Text == "") && (textBox33.Text == "") && (textBox34.Text == ""))
            {
                if (yetkinlik1ağırlık + yetkinlik2ağırlık + yetkinlik3ağırlık + kıdemağırlık + eğitimdurumuağırlık + yabancıdilağırlık != 100)
                {
                    MessageBox.Show("Girdiğiniz ağırlıkların toplamı 100 olmalıdır. Lütfen 1 daha kontrol ediniz.");
                    agırlıklardogrumu = false;
                }
            }
            else if ((textBox23.Text != "") && (textBox24.Text != "") && (textBox25.Text != "") && (textBox29.Text != "") && (textBox30.Text != "") && (textBox31.Text != "") && (textBox32.Text != "") && (textBox33.Text == "") && (textBox34.Text == ""))
            {
                if (yetkinlik1ağırlık + yetkinlik2ağırlık + yetkinlik3ağırlık + kıdemağırlık + eğitimdurumuağırlık + yabancıdilağırlık + sınavlarağırlık != 100)
                {
                    MessageBox.Show("Girdiğiniz ağırlıkların toplamı 100 olmalıdır. Lütfen 1 daha kontrol ediniz.");
                    agırlıklardogrumu = false;
                }
            }
            else if ((textBox23.Text != "") && (textBox24.Text != "") && (textBox25.Text != "") && (textBox29.Text != "") && (textBox30.Text != "") && (textBox31.Text != "") && (textBox32.Text != "") && (textBox33.Text != "") && (textBox34.Text == ""))
            {
                if (yetkinlik1ağırlık + yetkinlik2ağırlık + yetkinlik3ağırlık + kıdemağırlık + eğitimdurumuağırlık + yabancıdilağırlık + sınavlarağırlık + sertifikalarağırlık != 100)
                {
                    MessageBox.Show("Girdiğiniz ağırlıkların toplamı 100 olmalıdır. Lütfen 1 daha kontrol ediniz.");
                    agırlıklardogrumu = false;
                }
            }
            else if ((textBox23.Text != "") && (textBox24.Text != "") && (textBox25.Text != "") && (textBox29.Text != "") && (textBox30.Text != "") && (textBox31.Text != "") && (textBox32.Text != "") && (textBox33.Text != "") && (textBox34.Text != ""))
            {
                if (yetkinlik1ağırlık + yetkinlik2ağırlık + yetkinlik3ağırlık + kıdemağırlık + eğitimdurumuağırlık + yabancıdilağırlık + sınavlarağırlık + sertifikalarağırlık + ödüllerağırlık != 100)
                {
                    MessageBox.Show("Girdiğiniz ağırlıkların toplamı 100 olmalıdır. Lütfen 1 daha kontrol ediniz.");
                    agırlıklardogrumu = false;
                }
            }
            else if ((textBox23.Text != "") && (textBox24.Text == "") && (textBox25.Text == "") && (textBox29.Text != "") && (textBox30.Text != "") && (textBox31.Text != "") && (textBox32.Text != "") && (textBox33.Text != "") && (textBox34.Text != ""))
            {
                if (yetkinlik1ağırlık + kıdemağırlık + eğitimdurumuağırlık + yabancıdilağırlık + sınavlarağırlık + sertifikalarağırlık + ödüllerağırlık != 100)
                {
                    MessageBox.Show("Girdiğiniz ağırlıkların toplamı 100 olmalıdır. Lütfen 1 daha kontrol ediniz.");
                    agırlıklardogrumu = false;
                }
            }
            else if ((textBox23.Text != "") && (textBox24.Text != "") && (textBox25.Text == "") && (textBox29.Text != "") && (textBox30.Text != "") && (textBox31.Text != "") && (textBox32.Text != "") && (textBox33.Text != "") && (textBox34.Text != ""))
            {
                if (yetkinlik1ağırlık + yetkinlik2ağırlık + kıdemağırlık + eğitimdurumuağırlık + yabancıdilağırlık + sınavlarağırlık + sertifikalarağırlık + ödüllerağırlık != 100)
                {
                    MessageBox.Show("Girdiğiniz ağırlıkların toplamı 100 olmalıdır. Lütfen 1 daha kontrol ediniz.");
                    agırlıklardogrumu = false;
                }
            }

            if (agırlıklardogrumu == true)
            {
                Thread.Sleep(100);
                GenelBilgilerUpdate();
                performansSonuçlarıDeğiştir();
                MessageBox.Show("Değişiklikler kaydedildi.");
            }
        }
        private void performansSonuçlarıDeğiştir()
        {
            con.Open();
            string sql = "update PerformansSonuçları set [Personel No]=@personelno, [Kimlik No]=@kimlikno,[TOPSIS Sonucu]=@topsissonucu,[Analiz Sonucu]=@analizsonucu where [Kimlik No]=@kimlikno";

            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.Parameters.AddWithValue("@personelno", textBox12.Text);
            komut.Parameters.AddWithValue("@kimlikno", personelID);
            komut.Parameters.AddWithValue("@topsissonucu", textBox1.Text.ToString());
            komut.Parameters.AddWithValue("@analizsonucu", textBox2.Text.ToString());
            komut.ExecuteNonQuery();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            agırlıklardogrumu = true;
            if ((textBox23.Text != "") && (textBox24.Text == "") && (textBox25.Text == "") && (textBox29.Text == "") && (textBox30.Text == "") && (textBox31.Text == "") && (textBox32.Text == "") && (textBox33.Text == "") && (textBox34.Text == ""))
            {
                if (yetkinlik1ağırlık != 100)
                {
                    MessageBox.Show("A");
                    MessageBox.Show("Girdiğiniz ağırlıkların toplamı 100 olmalıdır. Lütfen 1 daha kontrol ediniz.");
                    agırlıklardogrumu = false;
                }
            }
            else if ((textBox23.Text != "") && (textBox24.Text != "") && (textBox25.Text == "") && (textBox29.Text == "") && (textBox30.Text == "") && (textBox31.Text == "") && (textBox32.Text == "") && (textBox33.Text == "") && (textBox34.Text == ""))
            {
                if (yetkinlik1ağırlık + yetkinlik2ağırlık != 100)
                {
                    MessageBox.Show("B");
                    MessageBox.Show("Girdiğiniz ağırlıkların toplamı 100 olmalıdır. Lütfen 1 daha kontrol ediniz.");
                    agırlıklardogrumu = false;
                }
            }
            else if ((textBox23.Text != "") && (textBox24.Text != "") && (textBox25.Text != "") && (textBox29.Text == "") && (textBox30.Text == "") && (textBox31.Text == "") && (textBox32.Text == "") && (textBox33.Text == "") && (textBox34.Text == ""))
            {
                if (yetkinlik1ağırlık + yetkinlik2ağırlık + yetkinlik3ağırlık != 100)
                {
                    MessageBox.Show("C");
                    MessageBox.Show("Girdiğiniz ağırlıkların toplamı 100 olmalıdır. Lütfen 1 daha kontrol ediniz.");
                    agırlıklardogrumu = false;
                }
            }
            else if ((textBox23.Text != "") && (textBox24.Text != "") && (textBox25.Text != "") && (textBox29.Text != "") && (textBox30.Text == "") && (textBox31.Text == "") && (textBox32.Text == "") && (textBox33.Text == "") && (textBox34.Text == ""))
            {
                if (yetkinlik1ağırlık + yetkinlik2ağırlık + yetkinlik3ağırlık + kıdemağırlık != 100)
                {
                    MessageBox.Show("D");
                    MessageBox.Show("Girdiğiniz ağırlıkların toplamı 100 olmalıdır. Lütfen 1 daha kontrol ediniz.");
                    agırlıklardogrumu = false;
                }
            }
            else if ((textBox23.Text != "") && (textBox24.Text != "") && (textBox25.Text != "") && (textBox29.Text != "") && (textBox30.Text != "") && (textBox31.Text == "") && (textBox32.Text == "") && (textBox33.Text == "") && (textBox34.Text == ""))
            {
                if (yetkinlik1ağırlık + yetkinlik2ağırlık + yetkinlik3ağırlık + kıdemağırlık + eğitimdurumuağırlık != 100)
                {
                    MessageBox.Show("E");
                    MessageBox.Show("Girdiğiniz ağırlıkların toplamı 100 olmalıdır. Lütfen 1 daha kontrol ediniz.");
                    agırlıklardogrumu = false;
                }
            }
            else if ((textBox23.Text != "") && (textBox24.Text != "") && (textBox25.Text != "") && (textBox29.Text != "") && (textBox30.Text != "") && (textBox31.Text != "") && (textBox32.Text == "") && (textBox33.Text == "") && (textBox34.Text == ""))
            {
                if (yetkinlik1ağırlık + yetkinlik2ağırlık + yetkinlik3ağırlık + kıdemağırlık + eğitimdurumuağırlık + yabancıdilağırlık != 100)
                {
                    MessageBox.Show("F");
                    MessageBox.Show("Girdiğiniz ağırlıkların toplamı 100 olmalıdır. Lütfen 1 daha kontrol ediniz.");
                    agırlıklardogrumu = false;
                }
            }
            else if ((textBox23.Text != "") && (textBox24.Text != "") && (textBox25.Text != "") && (textBox29.Text != "") && (textBox30.Text != "") && (textBox31.Text != "") && (textBox32.Text != "") && (textBox33.Text == "") && (textBox34.Text == ""))
            {
                if (yetkinlik1ağırlık + yetkinlik2ağırlık + yetkinlik3ağırlık + kıdemağırlık + eğitimdurumuağırlık + yabancıdilağırlık + sınavlarağırlık != 100)
                {
                    MessageBox.Show("G");
                    MessageBox.Show("Girdiğiniz ağırlıkların toplamı 100 olmalıdır. Lütfen 1 daha kontrol ediniz.");
                    agırlıklardogrumu = false;
                }
            }
            else if ((textBox23.Text != "") && (textBox24.Text != "") && (textBox25.Text != "") && (textBox29.Text != "") && (textBox30.Text != "") && (textBox31.Text != "") && (textBox32.Text != "") && (textBox33.Text != "") && (textBox34.Text == ""))
            {
                if (yetkinlik1ağırlık + yetkinlik2ağırlık + yetkinlik3ağırlık + kıdemağırlık + eğitimdurumuağırlık + yabancıdilağırlık + sınavlarağırlık + sertifikalarağırlık != 100)
                {
                    MessageBox.Show("H");
                    MessageBox.Show("Girdiğiniz ağırlıkların toplamı 100 olmalıdır. Lütfen 1 daha kontrol ediniz.");
                    agırlıklardogrumu = false;
                }
            }
            else if ((textBox23.Text != "") && (textBox24.Text != "") && (textBox25.Text != "") && (textBox29.Text != "") && (textBox30.Text != "") && (textBox31.Text != "") && (textBox32.Text != "") && (textBox33.Text != "") && (textBox34.Text != ""))
            {
                if (yetkinlik1ağırlık + yetkinlik2ağırlık + yetkinlik3ağırlık + kıdemağırlık + eğitimdurumuağırlık + yabancıdilağırlık + sınavlarağırlık + sertifikalarağırlık + ödüllerağırlık != 100)
                {
                    MessageBox.Show("I");
                    MessageBox.Show("Girdiğiniz ağırlıkların toplamı 100 olmalıdır. Lütfen 1 daha kontrol ediniz.");
                    agırlıklardogrumu = false;
                }
            }
            /*else if ((textBox23.Text != "") && (textBox24.Text == "") && (textBox25.Text == "") && (textBox29.Text != "") && (textBox30.Text != "") && (textBox31.Text != "") && (textBox32.Text != "") && (textBox33.Text != "") && (textBox34.Text != ""))
            {
                if (yetkinlik1ağırlık + kıdemağırlık + eğitimdurumuağırlık + yabancıdilağırlık + sınavlarağırlık + sertifikalarağırlık + ödüllerağırlık != 100)
                {
                    MessageBox.Show("J");
                    MessageBox.Show("Girdiğiniz ağırlıkların toplamı 100 olmalıdır. Lütfen 1 daha kontrol ediniz.");
                    agırlıklardogrumu = false;
                }
            }*/
            else if ((textBox23.Text != "") && (textBox24.Text != "") && (textBox25.Text == "") && (textBox29.Text != "") && (textBox30.Text != "") && (textBox31.Text != "") && (textBox32.Text != "") && (textBox33.Text != "") && (textBox34.Text != ""))
            {
                if (yetkinlik1ağırlık + yetkinlik2ağırlık + kıdemağırlık + eğitimdurumuağırlık + yabancıdilağırlık + sınavlarağırlık + sertifikalarağırlık + ödüllerağırlık != 100)
                {
                    MessageBox.Show("K");
                    MessageBox.Show("Girdiğiniz ağırlıkların toplamı 100 olmalıdır. Lütfen 1 daha kontrol ediniz.");
                    agırlıklardogrumu = false;
                }
            }

            if (agırlıklardogrumu == true)
            {
                if ((textBox7.Text == "") || (comboBox1.Text == "") || (comboBox4.Text == "") || (textBox13.Text == ""))
                {
                    MessageBox.Show("Lütfen en az 1 tane Yetenek Hedefi ve ona karşılık gelen 'Açıklama' ve 'Seviye' kısımlarını giriniz.");
                }
                else
                {
                    Thread.Sleep(100);
                    GenelBilgilerUpdate();
                    performansSonuçlarıDeğiştir();
                    MessageBox.Show("Yeni bilgiler kaydedildi.");
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (count1 == 1)
            {
                panel1.Visible = false;
                panel3.Visible = false;
                button4.Visible = false;
                count1--;
            }
            else
            {
                panel1.Visible = true;
                panel3.Visible = true;
                button4.Visible = true;
                count1++;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (count2 == 1)
            {
                panel2.Visible = false;
                panel4.Visible = false;
                count2--;
            }
            else
            {
                panel2.Visible = true;
                panel4.Visible = true;
                count2++;
            }
        }

        private void kararAnalizi()
        {
            if (checkBox5.Checked == true && checkBox6.Checked == false && checkBox7.Checked == false)
            {
                yetkinlik1 = 0;
            }
            else if (checkBox5.Checked == false && checkBox6.Checked == true && checkBox7.Checked == false)
            {
                yetkinlik1 = 0.9;
            }
            else if (checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == true)
            {
                yetkinlik1 = 1;
            }
            else if (checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false)
            {
                MessageBox.Show("En az 1 tane yetkinlik hedefi girmek zorunludur. Lütfen 'Yetkinlik 1' kısmını doldurunuz.");
            }
            ////////////////////////////////////////////////////
            if (checkBox8.Checked == true && checkBox9.Checked == false && checkBox10.Checked == false)
            {
                yetkinlik2 = 0;
            }
            else if (checkBox8.Checked == false && checkBox9.Checked == true && checkBox10.Checked == false)
            {
                yetkinlik2 = 0.9;
            }
            else if (checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == true)
            {
                yetkinlik2 = 1;
            }
            else if (checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false)
            {
                yetkinlik2 = 0;
            }
            ////////////////////////////////////////////////////
            if (checkBox11.Checked == true && checkBox12.Checked == false && checkBox13.Checked == false)
            {
                yetkinlik3 = 0;
            }
            else if (checkBox11.Checked == false && checkBox12.Checked == true && checkBox13.Checked == false)
            {
                yetkinlik3 = 0.9;
            }
            else if (checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == true)
            {
                yetkinlik3 = 1;
            }
            else if (checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false)
            {
                yetkinlik3 = 0;
            }
            ////////////////////////////////////////////////////
            if (checkBox3.Checked == true && checkBox4.Checked == false && checkBox14.Checked == false)
            {
                yabancıdil = 0;
            }
            else if (checkBox3.Checked == false && checkBox4.Checked == true && checkBox14.Checked == false)
            {
                yabancıdil = 0.9;
            }
            else if (checkBox3.Checked == false && checkBox4.Checked == false && checkBox14.Checked == true)
            {
                yabancıdil = 1;
            }
            ////////////////////////////
            if (checkBox22.Checked == true && checkBox25.Checked == false)
            {
                kıdem = 1;
            }
            else if (checkBox22.Checked == false && checkBox25.Checked == true)
            {
                kıdem = 0;
            }
            ///////////////////////////
            if (checkBox1.Checked == true && checkBox2.Checked == false)
            {
                eğitimdüzeyi = 1;
            }
            else if (checkBox1.Checked == false && checkBox2.Checked == true)
            {
                eğitimdüzeyi = 0;
            }
            ///////////////////////////
            if (checkBox15.Checked == true && checkBox16.Checked == false)
            {
                sınavlar = 1;
            }
            else if (checkBox15.Checked == false && checkBox16.Checked == true)
            {
                sınavlar = 0;
            }
            ///////////////////////////
            if (checkBox17.Checked == true && checkBox18.Checked == false)
            {
                sertifikalar = 1;
            }
            else if (checkBox17.Checked == false && checkBox18.Checked == true)
            {
                sertifikalar = 0;
            }
            ///////////////////////////
            if (checkBox19.Checked == true && checkBox20.Checked == false && checkBox21.Checked == false)
            {
                ödüller = 0;
            }
            else if (checkBox19.Checked == false && checkBox20.Checked == true && checkBox21.Checked == false)
            {
                ödüller = 0.8;
            }
            else if (checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == true)
            {
                ödüller = 1;
            }
            ///////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////
            if (textBox29.Text != "")
            {
                kıdemağırlık = Convert.ToDouble(textBox29.Text);
            }
            else if (textBox29.Text == "")
            {
                kıdemağırlık = 0;
            }
            if (textBox30.Text != "")
            {
                eğitimdurumuağırlık = Convert.ToDouble(textBox30.Text);
            }
            else if (textBox30.Text == "")
            {
                eğitimdurumuağırlık = 0;
            }
            if (textBox32.Text != "")
            {
                sınavlarağırlık = Convert.ToDouble(textBox32.Text);
            }
            else if (textBox32.Text == "")
            {
                sınavlarağırlık = 0;
            }
            if (textBox33.Text != "")
            {
                sertifikalarağırlık = Convert.ToDouble(textBox33.Text);
            }
            else if (textBox33.Text == "")
            {
                sertifikalarağırlık = 0;
            }
            if (textBox31.Text != "")
            {
                yabancıdilağırlık = Convert.ToDouble(textBox31.Text);
            }
            else if (textBox31.Text == "")
            {
                yabancıdilağırlık = 0;
            }
            if (textBox34.Text != "")
            {
                ödüllerağırlık = Convert.ToDouble(textBox34.Text);
            }
            else if (textBox34.Text == "")
            {
                ödüllerağırlık = 0;
            }

            if ((textBox7.Text != "") && (textBox8.Text == "") && (textBox9.Text == ""))
            {
                yetkinlik1ağırlık = Convert.ToDouble(textBox23.Text);
                yetkinlik1değer = yetkinlik1ağırlık * yetkinlik1;
                kıdemdeğer = kıdemağırlık * kıdem;
                eğitimdurumudeğer = eğitimdurumuağırlık * eğitimdüzeyi;
                sınavlardeğer = sınavlarağırlık * sınavlar;
                sertifikalardeğer = sertifikalarağırlık * sertifikalar;
                yabancıdildeğer = yabancıdilağırlık * yabancıdil;
                ödüllerdeğer = ödüllerağırlık * ödüller;


                kararanalizisonucu = yetkinlik1değer + kıdemdeğer + eğitimdurumudeğer + sınavlardeğer + sertifikalardeğer + yabancıdildeğer + ödüllerdeğer;
                textBox2.Text = kararanalizisonucu.ToString();
            }
            else if ((textBox7.Text != "") && (textBox8.Text != "") && (textBox9.Text == ""))
            {
                yetkinlik1ağırlık = Convert.ToDouble(textBox23.Text);
                if (textBox24.Text != "")
                {
                    yetkinlik2ağırlık = Convert.ToDouble(textBox24.Text);
                }
                else if (textBox24.Text == "")
                {
                    yetkinlik2ağırlık = 0;
                }
                yetkinlik1değer = yetkinlik1ağırlık * yetkinlik1;
                yetkinlik2değer = yetkinlik2ağırlık * yetkinlik2;
                kıdemdeğer = kıdemağırlık * kıdem;
                eğitimdurumudeğer = eğitimdurumuağırlık * eğitimdüzeyi;
                sınavlardeğer = sınavlarağırlık * sınavlar;
                sertifikalardeğer = sertifikalarağırlık * sertifikalar;
                yabancıdildeğer = yabancıdilağırlık * yabancıdil;
                ödüllerdeğer = ödüllerağırlık * ödüller;

                kararanalizisonucu = yetkinlik1değer + yetkinlik2değer + kıdemdeğer + eğitimdurumudeğer + sınavlardeğer + sertifikalardeğer + yabancıdildeğer + ödüllerdeğer;
                textBox2.Text = kararanalizisonucu.ToString();
            }
            else if ((textBox7.Text != "") && (textBox8.Text != "") && (textBox9.Text != ""))
            {
                yetkinlik1ağırlık = Convert.ToDouble(textBox23.Text);
                if (textBox24.Text != "")
                {
                    yetkinlik2ağırlık = Convert.ToDouble(textBox24.Text);
                }
                else if (textBox24.Text == "")
                {
                    yetkinlik2ağırlık = 0;
                }
                if (textBox25.Text != "")
                {
                    yetkinlik3ağırlık = Convert.ToDouble(textBox25.Text);
                }
                else if (textBox25.Text == "")
                {
                    yetkinlik3ağırlık = 0;
                }
                yetkinlik1değer = yetkinlik1ağırlık * yetkinlik1;
                yetkinlik2değer = yetkinlik2ağırlık * yetkinlik2;
                yetkinlik3değer = yetkinlik3ağırlık * yetkinlik3;
                kıdemdeğer = kıdemağırlık * kıdem;
                eğitimdurumudeğer = eğitimdurumuağırlık * eğitimdüzeyi;
                sınavlardeğer = sınavlarağırlık * sınavlar;
                sertifikalardeğer = sertifikalarağırlık * sertifikalar;
                yabancıdildeğer = yabancıdilağırlık * yabancıdil;
                ödüllerdeğer = ödüllerağırlık * ödüller;

                kararanalizisonucu = yetkinlik1değer + yetkinlik2değer + yetkinlik3değer + kıdemdeğer + eğitimdurumudeğer + sınavlardeğer + sertifikalardeğer + yabancıdildeğer + ödüllerdeğer;
                textBox2.Text = kararanalizisonucu.ToString(); ;
            }
        }

        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                checkBox6.Checked = false;
                checkBox7.Checked = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                checkBox5.Checked = false;
                checkBox7.Checked = false;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                checkBox5.Checked = false;
                checkBox6.Checked = false;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                checkBox9.Checked = false;
                checkBox10.Checked = false;
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                checkBox8.Checked = false;
                checkBox10.Checked = false;
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == true)
            {
                checkBox8.Checked = false;
                checkBox9.Checked = false;
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
            {
                checkBox12.Checked = false;
                checkBox13.Checked = false;
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked == true)
            {
                checkBox11.Checked = false;
                checkBox13.Checked = false;
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked == true)
            {
                checkBox12.Checked = false;
                checkBox11.Checked = false;
            }
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox22.Checked == true)
            {
                checkBox25.Checked = false;
            }
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox25.Checked == true)
            {
                checkBox22.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox4.Checked = false;
                checkBox14.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox3.Checked = false;
                checkBox14.Checked = false;
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked == true)
            {
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked == true)
            {
                checkBox16.Checked = false;
            }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox16.Checked == true)
            {
                checkBox15.Checked = false;
            }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked == true)
            {
                checkBox18.Checked = false;
            }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked == true)
            {
                checkBox17.Checked = false;
            }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked == true)
            {
                checkBox20.Checked = false;
                checkBox21.Checked = false;
            }
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox20.Checked == true)
            {
                checkBox19.Checked = false;
                checkBox21.Checked = false;
            }
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox21.Checked == true)
            {
                checkBox19.Checked = false;
                checkBox20.Checked = false;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelANALİZ_Click(object sender, EventArgs e)
        {

        }

        private void kullanımKılavuzuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("'Yetkinlik Hedefleri' kısmına önceden belirlenenen kişiye göre yetkinlik verilerini giriniz. Eğer 1'den çok " +
                "yetkinlik girmek istiyorsanız + butonuna basıp giriniz. Yetkinlikleri değerlendirmek için yanlarındaki 'Yeterli Değil', 'Yeterli" +
                " veya 'Üstün Yeterlilik kutucuklarından birini işaretleyiniz. Her yetkinlik için o yetkinliğin genel açıklamasını, " +
                "seviyesini ve seviyesinin açıklamasını giriniz. Ayrıca her yetkinliğin yanında, o yetkinliğe ait olduğu," +
                " kararlaştırılan ağırlığı giriniz.\n\n Güven Kıdemi, Eğitim Düzeyi ve diğer bilgiler otomatik " +
                "olarak gelecektir. Eğer değerlendirme yapacaksanız, bu seçeneklere de yanlarındaki uygun gördüğünüz butonları " +
                "işaretleyiniz. Girdiğiniz verileri sisteme kaydetmek için 'Kaydet' butonuna basınız.\n\n\n TOPSIS sonucu, personeller arası " +
                "karşılaştırma yapmak için kullanılan bir performans değerlendirmesidir. TOPSIS sonucu büyük olan personel, " +
                "diğer personellere göre daha İYİ bir performans sergilemiş demektir. TOPSIS sonucu İŞ HEDEFLERİ ile " +
                "alakalıdır. \n\n Eğer YETKİNLİK hedefleriyle alakalı bir kıyas yapmak istiyorsanız KARAR ANALİZİ kısmına " +
                "bakınız. Karar Analizi değeri yüksek olan personel diğer personellerden daha İYİ bir performans sergilemiş " +
                "demektir.\n\n");
        }
        private void boşata()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            checkBox12.Checked = false;
            checkBox13.Checked = false;
            checkBox14.Checked = false;
            checkBox15.Checked = false;
            checkBox16.Checked = false;
            checkBox17.Checked = false;
            checkBox18.Checked = false;
            checkBox19.Checked = false;
            checkBox20.Checked = false;
            checkBox21.Checked = false;
            checkBox22.Checked = false;
            checkBox25.Checked = false;
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            //kararAnalizi();
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            //kararAnalizi();
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            //kararAnalizi();
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            // kararAnalizi();
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            //kararAnalizi();
        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            // kararAnalizi();
        }

        private void textBox32_TextChanged(object sender, EventArgs e)
        {
            //kararAnalizi();
        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {
            //kararAnalizi();
        }

        private void textBox34_TextChanged(object sender, EventArgs e)
        {
            //kararAnalizi();
        }

        private void textBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (e.KeyChar == '.'))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (e.KeyChar == '.'))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox25_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (e.KeyChar == '.'))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox29_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (e.KeyChar == '.'))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox30_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (e.KeyChar == '.'))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox31_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (e.KeyChar == '.'))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox32_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (e.KeyChar == '.'))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox33_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (e.KeyChar == '.'))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox34_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (e.KeyChar == '.'))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "BAŞARI ODAKLILIK")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Beklentileri en iyi şekilde yerine getirir";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Zorlayıcı Hedefler Belirler";
                }
                if (comboBox4.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "EKİP ÇALIŞMASI")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Ekip Üyesidir.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Ekibe Yön Verir.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Ekibin Sürekliliğini Sağlar.";
                }
                if (comboBox4.Text == "S-4")
                {
                    textBox13.Text = "Ekip Çalışmasını Yaygınlaştırır.";
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "HASTA, HASTA YAKINI VE ÇALIŞAN ODAKLILIK")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Hasta, Hasta Yakını ve Çalışanların Beklentilerini Yerine Getirir.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Hasta, Hasta Yakını ve Çalışanların Taleplerini Yönlendirir.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Hasta, Hasta Yakını ve Çalışanların İş ve Hizmet Ortağıdır.";
                }
                if (comboBox4.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "PROBLEM ÇÖZME VE KARAR ALMA")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Harekete Geçer.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Problemin Kaynağını Araştırır/ Analiz Eder.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Proaktiftir.";
                }
                if (comboBox4.Text == "S-4")
                {
                    textBox13.Text = "Maliyet- Getiri Analizi Yapar.";
                }
                if (comboBox4.Text == "S-5")
                {
                    textBox13.Text = "Risk Alır.";
                }
            }

            if (comboBox1.Text == "KALİTE ODAKLILIK")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Kalite Standartlarına Uyar.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Kalite Sürecine Katkıda Bulunur.";
                }
                if (comboBox4.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "ETKİLEME VE İKNA")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Karşısındakinin Güvenini Kazanır.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Karşısındakini Anlar, Verilerie İkna Eder.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Karşısındakini Etkiler, Alternatifler Sunar.";
                }
                if (comboBox4.Text == "S-4")
                {
                    textBox13.Text = "Karşısındakini Yönlendirir.";
                }
                if (comboBox4.Text == "S-5")
                {
                    textBox13.Text = "İlişkileri Uzun Vade / Geniş Çerçevede Yönetir.";
                }
            }

            if (comboBox1.Text == "ÖNERİ GELİŞTİRME/ YENİLİKÇİLİK")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "İşiyle İlgili İyileştirmeler Önerir.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Sürekli İyilieştirme Fırsatları Arayışındadır.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Geniş Kapsamlı Farklı / Yenilikçi Öneriler Geliştirir.";
                }
                if (comboBox4.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "DEĞİŞİM YÖNTEMİ")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Değişimi Destekler.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Değişimi Gerçekleştirir / Sonuçlandırır.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Değişimi Başlatır.";
                }
                if (comboBox4.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "PLANLAMA VE ORGANİZE ETME")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Kendi İşleri İçin Öncelik Analizi Yapar.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Başkalarını Koordine Eder.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Kaynakları Planlar.";
                }
                if (comboBox4.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "STRATEJİ OLUŞTURMA VE YAYGINLAŞTIRMA")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Stratejileri Yaygınlaştırır.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Fonksiyonel Stratejiler Hazırlar; Organizasyonel Stratejilerin Oluşumuna Katkıda Bulunur.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Organizasyonel Strateji Oluşturur.";
                }
                if (comboBox4.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "BAŞKALARINI GELİŞTİRME")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Performansları Takip Eder.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Gelişim Önerileri Geliştirir.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Gelişim Fırsatları Yaratır.";
                }
                if (comboBox4.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "YETKİ DEVRİ VE DELEGASYON")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Çalışanların etkinliğini ve bağlılığını artırmak ve gelişimi sağlamak amacıyla, karar verme yetki ve sorumluluğunu planlı bir şekilde delege eder.";
                }
                if (comboBox4.Text == "S-2")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "ROL MODEL OLUŞTURMA")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Davranışları ve yaptıkları ile ekibi için bir rol model oluşturur ve diğerlerini bu yönde motive eder";
                }
                if (comboBox4.Text == "S-2")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }
            if (comboBox1.Text == "YÖNETİMSEL OLGUNLUK")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Yönetimsel ve görev gereği alınan tüm kararlara uyar ve/veya uygular. Bu kararlara muhalefet olsa bile ortak karar ve ortak hedef boyutunda uygulama sürecinde sahiplenir.";
                }
                if (comboBox4.Text == "S-2")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "KAR ODAKLILIK")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Pozisyonuyla ilgili gelir / gider ilişkilerini anlar ve hedeflere göre hareket eder.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Finansal hedeflere ulaşmada pozisyonunun etkisini bilir ve girişilen faaliyetler arasındaki ilişkileri anlar.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "İş planının finansal tarafını uygular, kendi sorumluluğundaki alanları hedefleri gerçekleştirmek için disiplinli bir şekilde izler ve gerektiğinde düzeltici faaliyetlerde bulunur.";
                }
                if (comboBox4.Text == "S-4")
                {
                    textBox13.Text = "Karı arttıracak yollar ve hissedarlara değer katacak yeni fırsatlar arar.";
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "FARKLILIKLARI YÖNETME")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Farklı çevre ve   koşullarda çalışmaya kolaylıkla uyum sağlar.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Farklı çevre ve koşulların üstesinden gelmek için en etkin yaklaşımları belirler ve bunları sonuca ulaşmada kullanır.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Farklılıkları analiz eder, bunlardan yararlanır, farklı koşullarda ve çevrelerde uygulanabilecek   stratejiler üretir.";
                }
                if (comboBox4.Text == "S-4")
                {
                    textBox13.Text = "Sağlık Sektöründeki ve organizasyondaki  farklılıkları anlar, en üst seviyede sinerji yaratabilmek için her ikisinin de gücünü kullanır.";
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "KENDİNE HAKİM OLMA")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Stres altında sağlıklı düşünebilir.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Baskı altında hemen yargıya varmak yerine sukunetini korur.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Başkalarının duygusal tepkileriyle ya da dışa vurumlarıyla karşılaştığında sakin davranır, duygularını kontrol altında tutar ve tahriklere kapılmaz. Sonuçları iyileştirmek için duygularını uygun bir şekilde gösterir.";
                }
                if (comboBox4.Text == "S-4")
                {
                    textBox13.Text = "Çeşitli nedenlerden kaynaklanan baskılar altında, başkalarını da yatıştırır ve yapıcı bir biçimde gerilimi azaltır.";
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "KURUMDAŞLIK")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Hastanenin tüm dinamiklerinin ve bölüm/birimlerin temel işlevlerini ve özelliklerini bilir.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Hastanenin Sağlık Sektörü içindeki gücünü bilir ve bunu hasta/hasta yakını ve çalışanların davranışlarını olumlu yönde etkilemek için  kullanır. Bu davranışı istikrarlı bir şekilde gerçekleştirir.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Hastanenin  sağlık sektörü içindeki gücünü oluşturan niteliklerin korunması, geliştirilmesi ve dış çevreye benimsetilmesini sağlar. Hastanedeki işleri ve süreçleri bir bütün olarak görür ve bu bakış açısının, başta kendisi olmak üzere, iş arkadaşlarına, işine, dış çevreye ve hasta/hasta yakınına yansımasını sağlar.";
                }
                if (comboBox4.Text == "S-4")
                {
                    textBox13.Text = "Hastanedeki kurumdaşlık sürecinin korunmasına ve geliştirilmesine katkı sağlar ve kalite standartlarına uyulmasında öncülük eder. Kurum içindeki kültürel çeşitliliği yönetir ve aralarında sinerji yaratır. Bu özellik aynı zamanda temel stratejik ve yönetsel değişiklikleri gerçekleştirmek için de son derece gereklidir. Kurum kültürünün etkinliğini, ne zaman ve nasıl değiştirilmesi gerektiğini değerlendirir. (Kısacası kurum kültürünün yönetimi temel bir liderlik ve yönetim yetkinliğidir.";
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "İŞ DİNAMİKLERİNİ ANLAMA")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Kendi sorumluluk alanı çerçevesinde işi etkileyen pek çok faktörü anlar";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Birbirleri ile ilişkili alanlarda alınmış kararların ardındaki mantığı anlar sonucu nasıl etkileyeceğini bilir ve ona göre hareket eder. ";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "İş ortamındaki yeni bilgileri elde eder ve değişiklikleri uygulamaya geçirir. Diğer iş süreçlerini de uygulamalara dahil eder.  ";
                }
                if (comboBox4.Text == "S-4")
                {
                    textBox13.Text = "Yeni eğilimlerin bilincindedir, darboğazları önceden görebilir. İş performansını arttırarak  ve sağlıklı süreç akışını sağlayarak  darboğazları ortadan kaldırır. ";
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "ANALİTİK DÜŞÜNME")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Konuları daha küçük parçalara ayırarak anlamaya çalışır.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Aralarındaki ilişkiyi anlamak için karmaşık bir görevi sistematik bir biçimde yönetilebilir parçalarına ayırır.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Alternatif çözümlere ulaşmak için karmaşık bir sorun veya süreci bileşenlerine ayırmada pek çok sistem ve teknik kullanır.";
                }
                if (comboBox4.Text == "S-4")
                {
                    textBox13.Text = "Birbirine bağlı olan karmaşık sistemleri, süreçleri ve fonksiyonları analiz ve organize eder, alternatif çözümler üretip, her birinin etkinliğini ayrı ayrı ölçer.";
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "SÜREÇLERLE YÖNETİM")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Süreçleri tanımlar ve süreçlerin akış şemasını çizer. ";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Aralarındaki ilişkiyi anlamak için karmaşık bir görevi sistematik bir biçimde yönetilebilir parçalarına ayırır.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Alternatif çözümlere ulaşmak için karmaşık bir sorun veya süreci bileşenlerine ayırmada pek çok sistem ve teknik kullanır.";
                }
                if (comboBox4.Text == "S-4")
                {
                    textBox13.Text = "Birbirine bağlı olan karmaşık sistemleri, süreçleri ve fonksiyonları analiz ve organize eder, alternatif çözümler üretip, her birinin etkinliğini ayrı ayrı ölçer.";
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "BAŞARI ODAKLILIK")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Beklentileri en iyi şekilde yerine getirir";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Zorlayıcı Hedefler Belirler";
                }
                if (comboBox5.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "EKİP ÇALIŞMASI")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Ekip Üyesidir.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Ekibe Yön Verir.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Ekibin Sürekliliğini Sağlar.";
                }
                if (comboBox5.Text == "S-4")
                {
                    textBox14.Text = "Ekip Çalışmasını Yaygınlaştırır.";
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "HASTA, HASTA YAKINI VE ÇALIŞAN ODAKLILIK")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Hasta, Hasta Yakını ve Çalışanların Beklentilerini Yerine Getirir.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Hasta, Hasta Yakını ve Çalışanların Taleplerini Yönlendirir.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Hasta, Hasta Yakını ve Çalışanların İş ve Hizmet Ortağıdır.";
                }
                if (comboBox5.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "PROBLEM ÇÖZME VE KARAR ALMA")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Harekete Geçer.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Problemin Kaynağını Araştırır/ Analiz Eder.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Proaktiftir.";
                }
                if (comboBox5.Text == "S-4")
                {
                    textBox14.Text = "Maliyet- Getiri Analizi Yapar.";
                }
                if (comboBox5.Text == "S-5")
                {
                    textBox14.Text = "Risk Alır.";
                }
            }

            if (comboBox2.Text == "KALİTE ODAKLILIK")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Kalite Standartlarına Uyar.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Kalite Sürecine Katkıda Bulunur.";
                }
                if (comboBox5.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "ETKİLEME VE İKNA")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Karşısındakinin Güvenini Kazanır.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Karşısındakini Anlar, Verilerie İkna Eder.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Karşısındakini Etkiler, Alternatifler Sunar.";
                }
                if (comboBox5.Text == "S-4")
                {
                    textBox14.Text = "Karşısındakini Yönlendirir.";
                }
                if (comboBox5.Text == "S-5")
                {
                    textBox14.Text = "İlişkileri Uzun Vade / Geniş Çerçevede Yönetir.";
                }
            }

            if (comboBox2.Text == "ÖNERİ GELİŞTİRME/ YENİLİKÇİLİK")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "İşiyle İlgili İyileştirmeler Önerir.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Sürekli İyilieştirme Fırsatları Arayışındadır.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Geniş Kapsamlı Farklı / Yenilikçi Öneriler Geliştirir.";
                }
                if (comboBox5.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "DEĞİŞİM YÖNTEMİ")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Değişimi Destekler.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Değişimi Gerçekleştirir / Sonuçlandırır.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Değişimi Başlatır.";
                }
                if (comboBox5.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "PLANLAMA VE ORGANİZE ETME")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Kendi İşleri İçin Öncelik Analizi Yapar.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Başkalarını Koordine Eder.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Kaynakları Planlar.";
                }
                if (comboBox5.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "STRATEJİ OLUŞTURMA VE YAYGINLAŞTIRMA")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Stratejileri Yaygınlaştırır.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Fonksiyonel Stratejiler Hazırlar; Organizasyonel Stratejilerin Oluşumuna Katkıda Bulunur.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Organizasyonel Strateji Oluşturur.";
                }
                if (comboBox5.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "BAŞKALARINI GELİŞTİRME")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Performansları Takip Eder.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Gelişim Önerileri Geliştirir.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Gelişim Fırsatları Yaratır.";
                }
                if (comboBox5.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "YETKİ DEVRİ VE DELEGASYON")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Çalışanların etkinliğini ve bağlılığını artırmak ve gelişimi sağlamak amacıyla, karar verme yetki ve sorumluluğunu planlı bir şekilde delege eder.";
                }
                if (comboBox5.Text == "S-2")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "ROL MODEL OLUŞTURMA")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Davranışları ve yaptıkları ile ekibi için bir rol model oluşturur ve diğerlerini bu yönde motive eder";
                }
                if (comboBox5.Text == "S-2")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }
            if (comboBox2.Text == "YÖNETİMSEL OLGUNLUK")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Yönetimsel ve görev gereği alınan tüm kararlara uyar ve/veya uygular. Bu kararlara muhalefet olsa bile ortak karar ve ortak hedef boyutunda uygulama sürecinde sahiplenir.";
                }
                if (comboBox5.Text == "S-2")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "KAR ODAKLILIK")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Pozisyonuyla ilgili gelir / gider ilişkilerini anlar ve hedeflere göre hareket eder.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Finansal hedeflere ulaşmada pozisyonunun etkisini bilir ve girişilen faaliyetler arasındaki ilişkileri anlar.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "İş planının finansal tarafını uygular, kendi sorumluluğundaki alanları hedefleri gerçekleştirmek için disiplinli bir şekilde izler ve gerektiğinde düzeltici faaliyetlerde bulunur.";
                }
                if (comboBox5.Text == "S-4")
                {
                    textBox14.Text = "Karı arttıracak yollar ve hissedarlara değer katacak yeni fırsatlar arar.";
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "FARKLILIKLARI YÖNETME")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Farklı çevre ve   koşullarda çalışmaya kolaylıkla uyum sağlar.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Farklı çevre ve koşulların üstesinden gelmek için en etkin yaklaşımları belirler ve bunları sonuca ulaşmada kullanır.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Farklılıkları analiz eder, bunlardan yararlanır, farklı koşullarda ve çevrelerde uygulanabilecek   stratejiler üretir.";
                }
                if (comboBox5.Text == "S-4")
                {
                    textBox14.Text = "Sağlık Sektöründeki ve organizasyondaki  farklılıkları anlar, en üst seviyede sinerji yaratabilmek için her ikisinin de gücünü kullanır.";
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "KENDİNE HAKİM OLMA")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Stres altında sağlıklı düşünebilir.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Baskı altında hemen yargıya varmak yerine sukunetini korur.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Başkalarının duygusal tepkileriyle ya da dışa vurumlarıyla karşılaştığında sakin davranır, duygularını kontrol altında tutar ve tahriklere kapılmaz. Sonuçları iyileştirmek için duygularını uygun bir şekilde gösterir.";
                }
                if (comboBox5.Text == "S-4")
                {
                    textBox14.Text = "Çeşitli nedenlerden kaynaklanan baskılar altında, başkalarını da yatıştırır ve yapıcı bir biçimde gerilimi azaltır.";
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "KURUMDAŞLIK")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Hastanenin tüm dinamiklerinin ve bölüm/birimlerin temel işlevlerini ve özelliklerini bilir.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Hastanenin Sağlık Sektörü içindeki gücünü bilir ve bunu hasta/hasta yakını ve çalışanların davranışlarını olumlu yönde etkilemek için  kullanır. Bu davranışı istikrarlı bir şekilde gerçekleştirir.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Hastanenin  sağlık sektörü içindeki gücünü oluşturan niteliklerin korunması, geliştirilmesi ve dış çevreye benimsetilmesini sağlar. Hastanedeki işleri ve süreçleri bir bütün olarak görür ve bu bakış açısının, başta kendisi olmak üzere, iş arkadaşlarına, işine, dış çevreye ve hasta/hasta yakınına yansımasını sağlar.";
                }
                if (comboBox5.Text == "S-4")
                {
                    textBox14.Text = "Hastanedeki kurumdaşlık sürecinin korunmasına ve geliştirilmesine katkı sağlar ve kalite standartlarına uyulmasında öncülük eder. Kurum içindeki kültürel çeşitliliği yönetir ve aralarında sinerji yaratır. Bu özellik aynı zamanda temel stratejik ve yönetsel değişiklikleri gerçekleştirmek için de son derece gereklidir. Kurum kültürünün etkinliğini, ne zaman ve nasıl değiştirilmesi gerektiğini değerlendirir. (Kısacası kurum kültürünün yönetimi temel bir liderlik ve yönetim yetkinliğidir.";
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "İŞ DİNAMİKLERİNİ ANLAMA")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Kendi sorumluluk alanı çerçevesinde işi etkileyen pek çok faktörü anlar";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Birbirleri ile ilişkili alanlarda alınmış kararların ardındaki mantığı anlar sonucu nasıl etkileyeceğini bilir ve ona göre hareket eder. ";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "İş ortamındaki yeni bilgileri elde eder ve değişiklikleri uygulamaya geçirir. Diğer iş süreçlerini de uygulamalara dahil eder.  ";
                }
                if (comboBox5.Text == "S-4")
                {
                    textBox14.Text = "Yeni eğilimlerin bilincindedir, darboğazları önceden görebilir. İş performansını arttırarak  ve sağlıklı süreç akışını sağlayarak  darboğazları ortadan kaldırır. ";
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "ANALİTİK DÜŞÜNME")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Konuları daha küçük parçalara ayırarak anlamaya çalışır.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Aralarındaki ilişkiyi anlamak için karmaşık bir görevi sistematik bir biçimde yönetilebilir parçalarına ayırır.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Alternatif çözümlere ulaşmak için karmaşık bir sorun veya süreci bileşenlerine ayırmada pek çok sistem ve teknik kullanır.";
                }
                if (comboBox5.Text == "S-4")
                {
                    textBox14.Text = "Birbirine bağlı olan karmaşık sistemleri, süreçleri ve fonksiyonları analiz ve organize eder, alternatif çözümler üretip, her birinin etkinliğini ayrı ayrı ölçer.";
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "SÜREÇLERLE YÖNETİM")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Süreçleri tanımlar ve süreçlerin akış şemasını çizer. ";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Aralarındaki ilişkiyi anlamak için karmaşık bir görevi sistematik bir biçimde yönetilebilir parçalarına ayırır.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Alternatif çözümlere ulaşmak için karmaşık bir sorun veya süreci bileşenlerine ayırmada pek çok sistem ve teknik kullanır.";
                }
                if (comboBox5.Text == "S-4")
                {
                    textBox14.Text = "Birbirine bağlı olan karmaşık sistemleri, süreçleri ve fonksiyonları analiz ve organize eder, alternatif çözümler üretip, her birinin etkinliğini ayrı ayrı ölçer.";
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "BAŞARI ODAKLILIK")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Beklentileri en iyi şekilde yerine getirir";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Zorlayıcı Hedefler Belirler";
                }
                if (comboBox4.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "EKİP ÇALIŞMASI")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Ekip Üyesidir.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Ekibe Yön Verir.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Ekibin Sürekliliğini Sağlar.";
                }
                if (comboBox4.Text == "S-4")
                {
                    textBox13.Text = "Ekip Çalışmasını Yaygınlaştırır.";
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "HASTA, HASTA YAKINI VE ÇALIŞAN ODAKLILIK")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Hasta, Hasta Yakını ve Çalışanların Beklentilerini Yerine Getirir.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Hasta, Hasta Yakını ve Çalışanların Taleplerini Yönlendirir.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Hasta, Hasta Yakını ve Çalışanların İş ve Hizmet Ortağıdır.";
                }
                if (comboBox4.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "PROBLEM ÇÖZME VE KARAR ALMA")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Harekete Geçer.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Problemin Kaynağını Araştırır/ Analiz Eder.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Proaktiftir.";
                }
                if (comboBox4.Text == "S-4")
                {
                    textBox13.Text = "Maliyet- Getiri Analizi Yapar.";
                }
                if (comboBox4.Text == "S-5")
                {
                    textBox13.Text = "Risk Alır.";
                }
            }

            if (comboBox1.Text == "KALİTE ODAKLILIK")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Kalite Standartlarına Uyar.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Kalite Sürecine Katkıda Bulunur.";
                }
                if (comboBox4.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "ETKİLEME VE İKNA")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Karşısındakinin Güvenini Kazanır.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Karşısındakini Anlar, Verilerie İkna Eder.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Karşısındakini Etkiler, Alternatifler Sunar.";
                }
                if (comboBox4.Text == "S-4")
                {
                    textBox13.Text = "Karşısındakini Yönlendirir.";
                }
                if (comboBox4.Text == "S-5")
                {
                    textBox13.Text = "İlişkileri Uzun Vade / Geniş Çerçevede Yönetir.";
                }
            }

            if (comboBox1.Text == "ÖNERİ GELİŞTİRME/ YENİLİKÇİLİK")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "İşiyle İlgili İyileştirmeler Önerir.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Sürekli İyilieştirme Fırsatları Arayışındadır.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Geniş Kapsamlı Farklı / Yenilikçi Öneriler Geliştirir.";
                }
                if (comboBox4.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "DEĞİŞİM YÖNTEMİ")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Değişimi Destekler.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Değişimi Gerçekleştirir / Sonuçlandırır.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Değişimi Başlatır.";
                }
                if (comboBox4.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "PLANLAMA VE ORGANİZE ETME")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Kendi İşleri İçin Öncelik Analizi Yapar.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Başkalarını Koordine Eder.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Kaynakları Planlar.";
                }
                if (comboBox4.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "STRATEJİ OLUŞTURMA VE YAYGINLAŞTIRMA")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Stratejileri Yaygınlaştırır.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Fonksiyonel Stratejiler Hazırlar; Organizasyonel Stratejilerin Oluşumuna Katkıda Bulunur.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Organizasyonel Strateji Oluşturur.";
                }
                if (comboBox4.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "BAŞKALARINI GELİŞTİRME")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Performansları Takip Eder.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Gelişim Önerileri Geliştirir.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Gelişim Fırsatları Yaratır.";
                }
                if (comboBox4.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "YETKİ DEVRİ VE DELEGASYON")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Çalışanların etkinliğini ve bağlılığını artırmak ve gelişimi sağlamak amacıyla, karar verme yetki ve sorumluluğunu planlı bir şekilde delege eder.";
                }
                if (comboBox4.Text == "S-2")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "ROL MODEL OLUŞTURMA")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Davranışları ve yaptıkları ile ekibi için bir rol model oluşturur ve diğerlerini bu yönde motive eder";
                }
                if (comboBox4.Text == "S-2")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }
            if (comboBox1.Text == "YÖNETİMSEL OLGUNLUK")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Yönetimsel ve görev gereği alınan tüm kararlara uyar ve/veya uygular. Bu kararlara muhalefet olsa bile ortak karar ve ortak hedef boyutunda uygulama sürecinde sahiplenir.";
                }
                if (comboBox4.Text == "S-2")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "KAR ODAKLILIK")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Pozisyonuyla ilgili gelir / gider ilişkilerini anlar ve hedeflere göre hareket eder.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Finansal hedeflere ulaşmada pozisyonunun etkisini bilir ve girişilen faaliyetler arasındaki ilişkileri anlar.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "İş planının finansal tarafını uygular, kendi sorumluluğundaki alanları hedefleri gerçekleştirmek için disiplinli bir şekilde izler ve gerektiğinde düzeltici faaliyetlerde bulunur.";
                }
                if (comboBox4.Text == "S-4")
                {
                    textBox13.Text = "Karı arttıracak yollar ve hissedarlara değer katacak yeni fırsatlar arar.";
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "FARKLILIKLARI YÖNETME")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Farklı çevre ve   koşullarda çalışmaya kolaylıkla uyum sağlar.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Farklı çevre ve koşulların üstesinden gelmek için en etkin yaklaşımları belirler ve bunları sonuca ulaşmada kullanır.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Farklılıkları analiz eder, bunlardan yararlanır, farklı koşullarda ve çevrelerde uygulanabilecek   stratejiler üretir.";
                }
                if (comboBox4.Text == "S-4")
                {
                    textBox13.Text = "Sağlık Sektöründeki ve organizasyondaki  farklılıkları anlar, en üst seviyede sinerji yaratabilmek için her ikisinin de gücünü kullanır.";
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "KENDİNE HAKİM OLMA")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Stres altında sağlıklı düşünebilir.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Baskı altında hemen yargıya varmak yerine sukunetini korur.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Başkalarının duygusal tepkileriyle ya da dışa vurumlarıyla karşılaştığında sakin davranır, duygularını kontrol altında tutar ve tahriklere kapılmaz. Sonuçları iyileştirmek için duygularını uygun bir şekilde gösterir.";
                }
                if (comboBox4.Text == "S-4")
                {
                    textBox13.Text = "Çeşitli nedenlerden kaynaklanan baskılar altında, başkalarını da yatıştırır ve yapıcı bir biçimde gerilimi azaltır.";
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "KURUMDAŞLIK")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Hastanenin tüm dinamiklerinin ve bölüm/birimlerin temel işlevlerini ve özelliklerini bilir.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Hastanenin Sağlık Sektörü içindeki gücünü bilir ve bunu hasta/hasta yakını ve çalışanların davranışlarını olumlu yönde etkilemek için  kullanır. Bu davranışı istikrarlı bir şekilde gerçekleştirir.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Hastanenin  sağlık sektörü içindeki gücünü oluşturan niteliklerin korunması, geliştirilmesi ve dış çevreye benimsetilmesini sağlar. Hastanedeki işleri ve süreçleri bir bütün olarak görür ve bu bakış açısının, başta kendisi olmak üzere, iş arkadaşlarına, işine, dış çevreye ve hasta/hasta yakınına yansımasını sağlar.";
                }
                if (comboBox4.Text == "S-4")
                {
                    textBox13.Text = "Hastanedeki kurumdaşlık sürecinin korunmasına ve geliştirilmesine katkı sağlar ve kalite standartlarına uyulmasında öncülük eder. Kurum içindeki kültürel çeşitliliği yönetir ve aralarında sinerji yaratır. Bu özellik aynı zamanda temel stratejik ve yönetsel değişiklikleri gerçekleştirmek için de son derece gereklidir. Kurum kültürünün etkinliğini, ne zaman ve nasıl değiştirilmesi gerektiğini değerlendirir. (Kısacası kurum kültürünün yönetimi temel bir liderlik ve yönetim yetkinliğidir.";
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "İŞ DİNAMİKLERİNİ ANLAMA")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Kendi sorumluluk alanı çerçevesinde işi etkileyen pek çok faktörü anlar";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Birbirleri ile ilişkili alanlarda alınmış kararların ardındaki mantığı anlar sonucu nasıl etkileyeceğini bilir ve ona göre hareket eder. ";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "İş ortamındaki yeni bilgileri elde eder ve değişiklikleri uygulamaya geçirir. Diğer iş süreçlerini de uygulamalara dahil eder.  ";
                }
                if (comboBox4.Text == "S-4")
                {
                    textBox13.Text = "Yeni eğilimlerin bilincindedir, darboğazları önceden görebilir. İş performansını arttırarak  ve sağlıklı süreç akışını sağlayarak  darboğazları ortadan kaldırır. ";
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "ANALİTİK DÜŞÜNME")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Konuları daha küçük parçalara ayırarak anlamaya çalışır.";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Aralarındaki ilişkiyi anlamak için karmaşık bir görevi sistematik bir biçimde yönetilebilir parçalarına ayırır.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Alternatif çözümlere ulaşmak için karmaşık bir sorun veya süreci bileşenlerine ayırmada pek çok sistem ve teknik kullanır.";
                }
                if (comboBox4.Text == "S-4")
                {
                    textBox13.Text = "Birbirine bağlı olan karmaşık sistemleri, süreçleri ve fonksiyonları analiz ve organize eder, alternatif çözümler üretip, her birinin etkinliğini ayrı ayrı ölçer.";
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox1.Text == "SÜREÇLERLE YÖNETİM")
            {
                if (comboBox4.Text == "S-1")
                {
                    textBox13.Text = "Süreçleri tanımlar ve süreçlerin akış şemasını çizer. ";
                }
                if (comboBox4.Text == "S-2")
                {
                    textBox13.Text = "Aralarındaki ilişkiyi anlamak için karmaşık bir görevi sistematik bir biçimde yönetilebilir parçalarına ayırır.";
                }
                if (comboBox4.Text == "S-3")
                {
                    textBox13.Text = "Alternatif çözümlere ulaşmak için karmaşık bir sorun veya süreci bileşenlerine ayırmada pek çok sistem ve teknik kullanır.";
                }
                if (comboBox4.Text == "S-4")
                {
                    textBox13.Text = "Birbirine bağlı olan karmaşık sistemleri, süreçleri ve fonksiyonları analiz ve organize eder, alternatif çözümler üretip, her birinin etkinliğini ayrı ayrı ölçer.";
                }
                if (comboBox4.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "BAŞARI ODAKLILIK")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Beklentileri en iyi şekilde yerine getirir";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Zorlayıcı Hedefler Belirler";
                }
                if (comboBox5.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "EKİP ÇALIŞMASI")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Ekip Üyesidir.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Ekibe Yön Verir.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Ekibin Sürekliliğini Sağlar.";
                }
                if (comboBox5.Text == "S-4")
                {
                    textBox14.Text = "Ekip Çalışmasını Yaygınlaştırır.";
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "HASTA, HASTA YAKINI VE ÇALIŞAN ODAKLILIK")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Hasta, Hasta Yakını ve Çalışanların Beklentilerini Yerine Getirir.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Hasta, Hasta Yakını ve Çalışanların Taleplerini Yönlendirir.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Hasta, Hasta Yakını ve Çalışanların İş ve Hizmet Ortağıdır.";
                }
                if (comboBox5.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "PROBLEM ÇÖZME VE KARAR ALMA")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Harekete Geçer.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Problemin Kaynağını Araştırır/ Analiz Eder.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Proaktiftir.";
                }
                if (comboBox5.Text == "S-4")
                {
                    textBox14.Text = "Maliyet- Getiri Analizi Yapar.";
                }
                if (comboBox5.Text == "S-5")
                {
                    textBox14.Text = "Risk Alır.";
                }
            }

            if (comboBox2.Text == "KALİTE ODAKLILIK")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Kalite Standartlarına Uyar.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Kalite Sürecine Katkıda Bulunur.";
                }
                if (comboBox5.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "ETKİLEME VE İKNA")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Karşısındakinin Güvenini Kazanır.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Karşısındakini Anlar, Verilerie İkna Eder.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Karşısındakini Etkiler, Alternatifler Sunar.";
                }
                if (comboBox5.Text == "S-4")
                {
                    textBox14.Text = "Karşısındakini Yönlendirir.";
                }
                if (comboBox5.Text == "S-5")
                {
                    textBox14.Text = "İlişkileri Uzun Vade / Geniş Çerçevede Yönetir.";
                }
            }

            if (comboBox2.Text == "ÖNERİ GELİŞTİRME/ YENİLİKÇİLİK")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "İşiyle İlgili İyileştirmeler Önerir.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Sürekli İyilieştirme Fırsatları Arayışındadır.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Geniş Kapsamlı Farklı / Yenilikçi Öneriler Geliştirir.";
                }
                if (comboBox5.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "DEĞİŞİM YÖNTEMİ")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Değişimi Destekler.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Değişimi Gerçekleştirir / Sonuçlandırır.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Değişimi Başlatır.";
                }
                if (comboBox5.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "PLANLAMA VE ORGANİZE ETME")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Kendi İşleri İçin Öncelik Analizi Yapar.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Başkalarını Koordine Eder.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Kaynakları Planlar.";
                }
                if (comboBox5.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "STRATEJİ OLUŞTURMA VE YAYGINLAŞTIRMA")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Stratejileri Yaygınlaştırır.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Fonksiyonel Stratejiler Hazırlar; Organizasyonel Stratejilerin Oluşumuna Katkıda Bulunur.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Organizasyonel Strateji Oluşturur.";
                }
                if (comboBox5.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "BAŞKALARINI GELİŞTİRME")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Performansları Takip Eder.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Gelişim Önerileri Geliştirir.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Gelişim Fırsatları Yaratır.";
                }
                if (comboBox5.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "YETKİ DEVRİ VE DELEGASYON")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Çalışanların etkinliğini ve bağlılığını artırmak ve gelişimi sağlamak amacıyla, karar verme yetki ve sorumluluğunu planlı bir şekilde delege eder.";
                }
                if (comboBox5.Text == "S-2")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "ROL MODEL OLUŞTURMA")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Davranışları ve yaptıkları ile ekibi için bir rol model oluşturur ve diğerlerini bu yönde motive eder";
                }
                if (comboBox5.Text == "S-2")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }
            if (comboBox2.Text == "YÖNETİMSEL OLGUNLUK")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Yönetimsel ve görev gereği alınan tüm kararlara uyar ve/veya uygular. Bu kararlara muhalefet olsa bile ortak karar ve ortak hedef boyutunda uygulama sürecinde sahiplenir.";
                }
                if (comboBox5.Text == "S-2")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "KAR ODAKLILIK")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Pozisyonuyla ilgili gelir / gider ilişkilerini anlar ve hedeflere göre hareket eder.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Finansal hedeflere ulaşmada pozisyonunun etkisini bilir ve girişilen faaliyetler arasındaki ilişkileri anlar.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "İş planının finansal tarafını uygular, kendi sorumluluğundaki alanları hedefleri gerçekleştirmek için disiplinli bir şekilde izler ve gerektiğinde düzeltici faaliyetlerde bulunur.";
                }
                if (comboBox5.Text == "S-4")
                {
                    textBox14.Text = "Karı arttıracak yollar ve hissedarlara değer katacak yeni fırsatlar arar.";
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "FARKLILIKLARI YÖNETME")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Farklı çevre ve   koşullarda çalışmaya kolaylıkla uyum sağlar.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Farklı çevre ve koşulların üstesinden gelmek için en etkin yaklaşımları belirler ve bunları sonuca ulaşmada kullanır.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Farklılıkları analiz eder, bunlardan yararlanır, farklı koşullarda ve çevrelerde uygulanabilecek   stratejiler üretir.";
                }
                if (comboBox5.Text == "S-4")
                {
                    textBox14.Text = "Sağlık Sektöründeki ve organizasyondaki  farklılıkları anlar, en üst seviyede sinerji yaratabilmek için her ikisinin de gücünü kullanır.";
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "KENDİNE HAKİM OLMA")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Stres altında sağlıklı düşünebilir.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Baskı altında hemen yargıya varmak yerine sukunetini korur.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Başkalarının duygusal tepkileriyle ya da dışa vurumlarıyla karşılaştığında sakin davranır, duygularını kontrol altında tutar ve tahriklere kapılmaz. Sonuçları iyileştirmek için duygularını uygun bir şekilde gösterir.";
                }
                if (comboBox5.Text == "S-4")
                {
                    textBox14.Text = "Çeşitli nedenlerden kaynaklanan baskılar altında, başkalarını da yatıştırır ve yapıcı bir biçimde gerilimi azaltır.";
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "KURUMDAŞLIK")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Hastanenin tüm dinamiklerinin ve bölüm/birimlerin temel işlevlerini ve özelliklerini bilir.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Hastanenin Sağlık Sektörü içindeki gücünü bilir ve bunu hasta/hasta yakını ve çalışanların davranışlarını olumlu yönde etkilemek için  kullanır. Bu davranışı istikrarlı bir şekilde gerçekleştirir.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Hastanenin  sağlık sektörü içindeki gücünü oluşturan niteliklerin korunması, geliştirilmesi ve dış çevreye benimsetilmesini sağlar. Hastanedeki işleri ve süreçleri bir bütün olarak görür ve bu bakış açısının, başta kendisi olmak üzere, iş arkadaşlarına, işine, dış çevreye ve hasta/hasta yakınına yansımasını sağlar.";
                }
                if (comboBox5.Text == "S-4")
                {
                    textBox14.Text = "Hastanedeki kurumdaşlık sürecinin korunmasına ve geliştirilmesine katkı sağlar ve kalite standartlarına uyulmasında öncülük eder. Kurum içindeki kültürel çeşitliliği yönetir ve aralarında sinerji yaratır. Bu özellik aynı zamanda temel stratejik ve yönetsel değişiklikleri gerçekleştirmek için de son derece gereklidir. Kurum kültürünün etkinliğini, ne zaman ve nasıl değiştirilmesi gerektiğini değerlendirir. (Kısacası kurum kültürünün yönetimi temel bir liderlik ve yönetim yetkinliğidir.";
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "İŞ DİNAMİKLERİNİ ANLAMA")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Kendi sorumluluk alanı çerçevesinde işi etkileyen pek çok faktörü anlar";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Birbirleri ile ilişkili alanlarda alınmış kararların ardındaki mantığı anlar sonucu nasıl etkileyeceğini bilir ve ona göre hareket eder. ";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "İş ortamındaki yeni bilgileri elde eder ve değişiklikleri uygulamaya geçirir. Diğer iş süreçlerini de uygulamalara dahil eder.  ";
                }
                if (comboBox5.Text == "S-4")
                {
                    textBox14.Text = "Yeni eğilimlerin bilincindedir, darboğazları önceden görebilir. İş performansını arttırarak  ve sağlıklı süreç akışını sağlayarak  darboğazları ortadan kaldırır. ";
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "ANALİTİK DÜŞÜNME")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Konuları daha küçük parçalara ayırarak anlamaya çalışır.";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Aralarındaki ilişkiyi anlamak için karmaşık bir görevi sistematik bir biçimde yönetilebilir parçalarına ayırır.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Alternatif çözümlere ulaşmak için karmaşık bir sorun veya süreci bileşenlerine ayırmada pek çok sistem ve teknik kullanır.";
                }
                if (comboBox5.Text == "S-4")
                {
                    textBox14.Text = "Birbirine bağlı olan karmaşık sistemleri, süreçleri ve fonksiyonları analiz ve organize eder, alternatif çözümler üretip, her birinin etkinliğini ayrı ayrı ölçer.";
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox2.Text == "SÜREÇLERLE YÖNETİM")
            {
                if (comboBox5.Text == "S-1")
                {
                    textBox14.Text = "Süreçleri tanımlar ve süreçlerin akış şemasını çizer. ";
                }
                if (comboBox5.Text == "S-2")
                {
                    textBox14.Text = "Aralarındaki ilişkiyi anlamak için karmaşık bir görevi sistematik bir biçimde yönetilebilir parçalarına ayırır.";
                }
                if (comboBox5.Text == "S-3")
                {
                    textBox14.Text = "Alternatif çözümlere ulaşmak için karmaşık bir sorun veya süreci bileşenlerine ayırmada pek çok sistem ve teknik kullanır.";
                }
                if (comboBox5.Text == "S-4")
                {
                    textBox14.Text = "Birbirine bağlı olan karmaşık sistemleri, süreçleri ve fonksiyonları analiz ve organize eder, alternatif çözümler üretip, her birinin etkinliğini ayrı ayrı ölçer.";
                }
                if (comboBox5.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "BAŞARI ODAKLILIK")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Beklentileri en iyi şekilde yerine getirir";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Zorlayıcı Hedefler Belirler";
                }
                if (comboBox6.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "EKİP ÇALIŞMASI")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Ekip Üyesidir.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Ekibe Yön Verir.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Ekibin Sürekliliğini Sağlar.";
                }
                if (comboBox6.Text == "S-4")
                {
                    textBox15.Text = "Ekip Çalışmasını Yaygınlaştırır.";
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "HASTA, HASTA YAKINI VE ÇALIŞAN ODAKLILIK")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Hasta, Hasta Yakını ve Çalışanların Beklentilerini Yerine Getirir.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Hasta, Hasta Yakını ve Çalışanların Taleplerini Yönlendirir.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Hasta, Hasta Yakını ve Çalışanların İş ve Hizmet Ortağıdır.";
                }
                if (comboBox6.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "PROBLEM ÇÖZME VE KARAR ALMA")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Harekete Geçer.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Problemin Kaynağını Araştırır/ Analiz Eder.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Proaktiftir.";
                }
                if (comboBox6.Text == "S-4")
                {
                    textBox15.Text = "Maliyet- Getiri Analizi Yapar.";
                }
                if (comboBox6.Text == "S-5")
                {
                    textBox15.Text = "Risk Alır.";
                }
            }

            if (comboBox3.Text == "KALİTE ODAKLILIK")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Kalite Standartlarına Uyar.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Kalite Sürecine Katkıda Bulunur.";
                }
                if (comboBox6.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "ETKİLEME VE İKNA")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Karşısındakinin Güvenini Kazanır.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Karşısındakini Anlar, Verilerie İkna Eder.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Karşısındakini Etkiler, Alternatifler Sunar.";
                }
                if (comboBox6.Text == "S-4")
                {
                    textBox15.Text = "Karşısındakini Yönlendirir.";
                }
                if (comboBox6.Text == "S-5")
                {
                    textBox15.Text = "İlişkileri Uzun Vade / Geniş Çerçevede Yönetir.";
                }
            }

            if (comboBox3.Text == "ÖNERİ GELİŞTİRME/ YENİLİKÇİLİK")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "İşiyle İlgili İyileştirmeler Önerir.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Sürekli İyilieştirme Fırsatları Arayışındadır.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Geniş Kapsamlı Farklı / Yenilikçi Öneriler Geliştirir.";
                }
                if (comboBox6.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "DEĞİŞİM YÖNTEMİ")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Değişimi Destekler.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Değişimi Gerçekleştirir / Sonuçlandırır.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Değişimi Başlatır.";
                }
                if (comboBox6.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "PLANLAMA VE ORGANİZE ETME")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Kendi İşleri İçin Öncelik Analizi Yapar.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Başkalarını Koordine Eder.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Kaynakları Planlar.";
                }
                if (comboBox6.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "STRATEJİ OLUŞTURMA VE YAYGINLAŞTIRMA")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Stratejileri Yaygınlaştırır.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Fonksiyonel Stratejiler Hazırlar; Organizasyonel Stratejilerin Oluşumuna Katkıda Bulunur.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Organizasyonel Strateji Oluşturur.";
                }
                if (comboBox6.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "BAŞKALARINI GELİŞTİRME")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Performansları Takip Eder.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Gelişim Önerileri Geliştirir.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Gelişim Fırsatları Yaratır.";
                }
                if (comboBox6.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "YETKİ DEVRİ VE DELEGASYON")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Çalışanların etkinliğini ve bağlılığını artırmak ve gelişimi sağlamak amacıyla, karar verme yetki ve sorumluluğunu planlı bir şekilde delege eder.";
                }
                if (comboBox6.Text == "S-2")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "ROL MODEL OLUŞTURMA")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Davranışları ve yaptıkları ile ekibi için bir rol model oluşturur ve diğerlerini bu yönde motive eder";
                }
                if (comboBox6.Text == "S-2")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }
            if (comboBox3.Text == "YÖNETİMSEL OLGUNLUK")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Yönetimsel ve görev gereği alınan tüm kararlara uyar ve/veya uygular. Bu kararlara muhalefet olsa bile ortak karar ve ortak hedef boyutunda uygulama sürecinde sahiplenir.";
                }
                if (comboBox6.Text == "S-2")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "KAR ODAKLILIK")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Pozisyonuyla ilgili gelir / gider ilişkilerini anlar ve hedeflere göre hareket eder.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Finansal hedeflere ulaşmada pozisyonunun etkisini bilir ve girişilen faaliyetler arasındaki ilişkileri anlar.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "İş planının finansal tarafını uygular, kendi sorumluluğundaki alanları hedefleri gerçekleştirmek için disiplinli bir şekilde izler ve gerektiğinde düzeltici faaliyetlerde bulunur.";
                }
                if (comboBox6.Text == "S-4")
                {
                    textBox15.Text = "Karı arttıracak yollar ve hissedarlara değer katacak yeni fırsatlar arar.";
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "FARKLILIKLARI YÖNETME")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Farklı çevre ve   koşullarda çalışmaya kolaylıkla uyum sağlar.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Farklı çevre ve koşulların üstesinden gelmek için en etkin yaklaşımları belirler ve bunları sonuca ulaşmada kullanır.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Farklılıkları analiz eder, bunlardan yararlanır, farklı koşullarda ve çevrelerde uygulanabilecek   stratejiler üretir.";
                }
                if (comboBox6.Text == "S-4")
                {
                    textBox15.Text = "Sağlık Sektöründeki ve organizasyondaki  farklılıkları anlar, en üst seviyede sinerji yaratabilmek için her ikisinin de gücünü kullanır.";
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "KENDİNE HAKİM OLMA")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Stres altında sağlıklı düşünebilir.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Baskı altında hemen yargıya varmak yerine sukunetini korur.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Başkalarının duygusal tepkileriyle ya da dışa vurumlarıyla karşılaştığında sakin davranır, duygularını kontrol altında tutar ve tahriklere kapılmaz. Sonuçları iyileştirmek için duygularını uygun bir şekilde gösterir.";
                }
                if (comboBox6.Text == "S-4")
                {
                    textBox15.Text = "Çeşitli nedenlerden kaynaklanan baskılar altında, başkalarını da yatıştırır ve yapıcı bir biçimde gerilimi azaltır.";
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "KURUMDAŞLIK")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Hastanenin tüm dinamiklerinin ve bölüm/birimlerin temel işlevlerini ve özelliklerini bilir.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Hastanenin Sağlık Sektörü içindeki gücünü bilir ve bunu hasta/hasta yakını ve çalışanların davranışlarını olumlu yönde etkilemek için  kullanır. Bu davranışı istikrarlı bir şekilde gerçekleştirir.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Hastanenin  sağlık sektörü içindeki gücünü oluşturan niteliklerin korunması, geliştirilmesi ve dış çevreye benimsetilmesini sağlar. Hastanedeki işleri ve süreçleri bir bütün olarak görür ve bu bakış açısının, başta kendisi olmak üzere, iş arkadaşlarına, işine, dış çevreye ve hasta/hasta yakınına yansımasını sağlar.";
                }
                if (comboBox6.Text == "S-4")
                {
                    textBox15.Text = "Hastanedeki kurumdaşlık sürecinin korunmasına ve geliştirilmesine katkı sağlar ve kalite standartlarına uyulmasında öncülük eder. Kurum içindeki kültürel çeşitliliği yönetir ve aralarında sinerji yaratır. Bu özellik aynı zamanda temel stratejik ve yönetsel değişiklikleri gerçekleştirmek için de son derece gereklidir. Kurum kültürünün etkinliğini, ne zaman ve nasıl değiştirilmesi gerektiğini değerlendirir. (Kısacası kurum kültürünün yönetimi temel bir liderlik ve yönetim yetkinliğidir.";
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "İŞ DİNAMİKLERİNİ ANLAMA")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Kendi sorumluluk alanı çerçevesinde işi etkileyen pek çok faktörü anlar";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Birbirleri ile ilişkili alanlarda alınmış kararların ardındaki mantığı anlar sonucu nasıl etkileyeceğini bilir ve ona göre hareket eder. ";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "İş ortamındaki yeni bilgileri elde eder ve değişiklikleri uygulamaya geçirir. Diğer iş süreçlerini de uygulamalara dahil eder.  ";
                }
                if (comboBox6.Text == "S-4")
                {
                    textBox15.Text = "Yeni eğilimlerin bilincindedir, darboğazları önceden görebilir. İş performansını arttırarak  ve sağlıklı süreç akışını sağlayarak  darboğazları ortadan kaldırır. ";
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "ANALİTİK DÜŞÜNME")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Konuları daha küçük parçalara ayırarak anlamaya çalışır.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Aralarındaki ilişkiyi anlamak için karmaşık bir görevi sistematik bir biçimde yönetilebilir parçalarına ayırır.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Alternatif çözümlere ulaşmak için karmaşık bir sorun veya süreci bileşenlerine ayırmada pek çok sistem ve teknik kullanır.";
                }
                if (comboBox6.Text == "S-4")
                {
                    textBox15.Text = "Birbirine bağlı olan karmaşık sistemleri, süreçleri ve fonksiyonları analiz ve organize eder, alternatif çözümler üretip, her birinin etkinliğini ayrı ayrı ölçer.";
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "SÜREÇLERLE YÖNETİM")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Süreçleri tanımlar ve süreçlerin akış şemasını çizer. ";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Aralarındaki ilişkiyi anlamak için karmaşık bir görevi sistematik bir biçimde yönetilebilir parçalarına ayırır.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Alternatif çözümlere ulaşmak için karmaşık bir sorun veya süreci bileşenlerine ayırmada pek çok sistem ve teknik kullanır.";
                }
                if (comboBox6.Text == "S-4")
                {
                    textBox15.Text = "Birbirine bağlı olan karmaşık sistemleri, süreçleri ve fonksiyonları analiz ve organize eder, alternatif çözümler üretip, her birinin etkinliğini ayrı ayrı ölçer.";
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "BAŞARI ODAKLILIK")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Beklentileri en iyi şekilde yerine getirir";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Zorlayıcı Hedefler Belirler";
                }
                if (comboBox6.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "EKİP ÇALIŞMASI")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Ekip Üyesidir.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Ekibe Yön Verir.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Ekibin Sürekliliğini Sağlar.";
                }
                if (comboBox6.Text == "S-4")
                {
                    textBox15.Text = "Ekip Çalışmasını Yaygınlaştırır.";
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "HASTA, HASTA YAKINI VE ÇALIŞAN ODAKLILIK")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Hasta, Hasta Yakını ve Çalışanların Beklentilerini Yerine Getirir.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Hasta, Hasta Yakını ve Çalışanların Taleplerini Yönlendirir.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Hasta, Hasta Yakını ve Çalışanların İş ve Hizmet Ortağıdır.";
                }
                if (comboBox6.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "PROBLEM ÇÖZME VE KARAR ALMA")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Harekete Geçer.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Problemin Kaynağını Araştırır/ Analiz Eder.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Proaktiftir.";
                }
                if (comboBox6.Text == "S-4")
                {
                    textBox15.Text = "Maliyet- Getiri Analizi Yapar.";
                }
                if (comboBox6.Text == "S-5")
                {
                    textBox15.Text = "Risk Alır.";
                }
            }

            if (comboBox3.Text == "KALİTE ODAKLILIK")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Kalite Standartlarına Uyar.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Kalite Sürecine Katkıda Bulunur.";
                }
                if (comboBox6.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "ETKİLEME VE İKNA")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Karşısındakinin Güvenini Kazanır.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Karşısındakini Anlar, Verilerie İkna Eder.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Karşısındakini Etkiler, Alternatifler Sunar.";
                }
                if (comboBox6.Text == "S-4")
                {
                    textBox15.Text = "Karşısındakini Yönlendirir.";
                }
                if (comboBox6.Text == "S-5")
                {
                    textBox15.Text = "İlişkileri Uzun Vade / Geniş Çerçevede Yönetir.";
                }
            }

            if (comboBox3.Text == "ÖNERİ GELİŞTİRME/ YENİLİKÇİLİK")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "İşiyle İlgili İyileştirmeler Önerir.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Sürekli İyilieştirme Fırsatları Arayışındadır.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Geniş Kapsamlı Farklı / Yenilikçi Öneriler Geliştirir.";
                }
                if (comboBox6.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "DEĞİŞİM YÖNTEMİ")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Değişimi Destekler.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Değişimi Gerçekleştirir / Sonuçlandırır.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Değişimi Başlatır.";
                }
                if (comboBox6.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "PLANLAMA VE ORGANİZE ETME")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Kendi İşleri İçin Öncelik Analizi Yapar.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Başkalarını Koordine Eder.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Kaynakları Planlar.";
                }
                if (comboBox6.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "STRATEJİ OLUŞTURMA VE YAYGINLAŞTIRMA")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Stratejileri Yaygınlaştırır.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Fonksiyonel Stratejiler Hazırlar; Organizasyonel Stratejilerin Oluşumuna Katkıda Bulunur.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Organizasyonel Strateji Oluşturur.";
                }
                if (comboBox6.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "BAŞKALARINI GELİŞTİRME")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Performansları Takip Eder.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Gelişim Önerileri Geliştirir.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Gelişim Fırsatları Yaratır.";
                }
                if (comboBox6.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "YETKİ DEVRİ VE DELEGASYON")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Çalışanların etkinliğini ve bağlılığını artırmak ve gelişimi sağlamak amacıyla, karar verme yetki ve sorumluluğunu planlı bir şekilde delege eder.";
                }
                if (comboBox6.Text == "S-2")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "ROL MODEL OLUŞTURMA")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Davranışları ve yaptıkları ile ekibi için bir rol model oluşturur ve diğerlerini bu yönde motive eder";
                }
                if (comboBox6.Text == "S-2")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }
            if (comboBox3.Text == "YÖNETİMSEL OLGUNLUK")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Yönetimsel ve görev gereği alınan tüm kararlara uyar ve/veya uygular. Bu kararlara muhalefet olsa bile ortak karar ve ortak hedef boyutunda uygulama sürecinde sahiplenir.";
                }
                if (comboBox6.Text == "S-2")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-3")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-4")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "KAR ODAKLILIK")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Pozisyonuyla ilgili gelir / gider ilişkilerini anlar ve hedeflere göre hareket eder.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Finansal hedeflere ulaşmada pozisyonunun etkisini bilir ve girişilen faaliyetler arasındaki ilişkileri anlar.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "İş planının finansal tarafını uygular, kendi sorumluluğundaki alanları hedefleri gerçekleştirmek için disiplinli bir şekilde izler ve gerektiğinde düzeltici faaliyetlerde bulunur.";
                }
                if (comboBox6.Text == "S-4")
                {
                    textBox15.Text = "Karı arttıracak yollar ve hissedarlara değer katacak yeni fırsatlar arar.";
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "FARKLILIKLARI YÖNETME")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Farklı çevre ve   koşullarda çalışmaya kolaylıkla uyum sağlar.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Farklı çevre ve koşulların üstesinden gelmek için en etkin yaklaşımları belirler ve bunları sonuca ulaşmada kullanır.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Farklılıkları analiz eder, bunlardan yararlanır, farklı koşullarda ve çevrelerde uygulanabilecek   stratejiler üretir.";
                }
                if (comboBox6.Text == "S-4")
                {
                    textBox15.Text = "Sağlık Sektöründeki ve organizasyondaki  farklılıkları anlar, en üst seviyede sinerji yaratabilmek için her ikisinin de gücünü kullanır.";
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "KENDİNE HAKİM OLMA")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Stres altında sağlıklı düşünebilir.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Baskı altında hemen yargıya varmak yerine sukunetini korur.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Başkalarının duygusal tepkileriyle ya da dışa vurumlarıyla karşılaştığında sakin davranır, duygularını kontrol altında tutar ve tahriklere kapılmaz. Sonuçları iyileştirmek için duygularını uygun bir şekilde gösterir.";
                }
                if (comboBox6.Text == "S-4")
                {
                    textBox15.Text = "Çeşitli nedenlerden kaynaklanan baskılar altında, başkalarını da yatıştırır ve yapıcı bir biçimde gerilimi azaltır.";
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "KURUMDAŞLIK")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Hastanenin tüm dinamiklerinin ve bölüm/birimlerin temel işlevlerini ve özelliklerini bilir.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Hastanenin Sağlık Sektörü içindeki gücünü bilir ve bunu hasta/hasta yakını ve çalışanların davranışlarını olumlu yönde etkilemek için  kullanır. Bu davranışı istikrarlı bir şekilde gerçekleştirir.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Hastanenin  sağlık sektörü içindeki gücünü oluşturan niteliklerin korunması, geliştirilmesi ve dış çevreye benimsetilmesini sağlar. Hastanedeki işleri ve süreçleri bir bütün olarak görür ve bu bakış açısının, başta kendisi olmak üzere, iş arkadaşlarına, işine, dış çevreye ve hasta/hasta yakınına yansımasını sağlar.";
                }
                if (comboBox6.Text == "S-4")
                {
                    textBox15.Text = "Hastanedeki kurumdaşlık sürecinin korunmasına ve geliştirilmesine katkı sağlar ve kalite standartlarına uyulmasında öncülük eder. Kurum içindeki kültürel çeşitliliği yönetir ve aralarında sinerji yaratır. Bu özellik aynı zamanda temel stratejik ve yönetsel değişiklikleri gerçekleştirmek için de son derece gereklidir. Kurum kültürünün etkinliğini, ne zaman ve nasıl değiştirilmesi gerektiğini değerlendirir. (Kısacası kurum kültürünün yönetimi temel bir liderlik ve yönetim yetkinliğidir.";
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "İŞ DİNAMİKLERİNİ ANLAMA")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Kendi sorumluluk alanı çerçevesinde işi etkileyen pek çok faktörü anlar";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Birbirleri ile ilişkili alanlarda alınmış kararların ardındaki mantığı anlar sonucu nasıl etkileyeceğini bilir ve ona göre hareket eder. ";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "İş ortamındaki yeni bilgileri elde eder ve değişiklikleri uygulamaya geçirir. Diğer iş süreçlerini de uygulamalara dahil eder.  ";
                }
                if (comboBox6.Text == "S-4")
                {
                    textBox15.Text = "Yeni eğilimlerin bilincindedir, darboğazları önceden görebilir. İş performansını arttırarak  ve sağlıklı süreç akışını sağlayarak  darboğazları ortadan kaldırır. ";
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "ANALİTİK DÜŞÜNME")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Konuları daha küçük parçalara ayırarak anlamaya çalışır.";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Aralarındaki ilişkiyi anlamak için karmaşık bir görevi sistematik bir biçimde yönetilebilir parçalarına ayırır.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Alternatif çözümlere ulaşmak için karmaşık bir sorun veya süreci bileşenlerine ayırmada pek çok sistem ve teknik kullanır.";
                }
                if (comboBox6.Text == "S-4")
                {
                    textBox15.Text = "Birbirine bağlı olan karmaşık sistemleri, süreçleri ve fonksiyonları analiz ve organize eder, alternatif çözümler üretip, her birinin etkinliğini ayrı ayrı ölçer.";
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }

            if (comboBox3.Text == "SÜREÇLERLE YÖNETİM")
            {
                if (comboBox6.Text == "S-1")
                {
                    textBox15.Text = "Süreçleri tanımlar ve süreçlerin akış şemasını çizer. ";
                }
                if (comboBox6.Text == "S-2")
                {
                    textBox15.Text = "Aralarındaki ilişkiyi anlamak için karmaşık bir görevi sistematik bir biçimde yönetilebilir parçalarına ayırır.";
                }
                if (comboBox6.Text == "S-3")
                {
                    textBox15.Text = "Alternatif çözümlere ulaşmak için karmaşık bir sorun veya süreci bileşenlerine ayırmada pek çok sistem ve teknik kullanır.";
                }
                if (comboBox6.Text == "S-4")
                {
                    textBox15.Text = "Birbirine bağlı olan karmaşık sistemleri, süreçleri ve fonksiyonları analiz ve organize eder, alternatif çözümler üretip, her birinin etkinliğini ayrı ayrı ölçer.";
                }
                if (comboBox6.Text == "S-5")
                {
                    MessageBox.Show("Seçili hedef için böyle bir seviye bulunmamaktadır.");
                }
            }
        }
    }
}
   
    

