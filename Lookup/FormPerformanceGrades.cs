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
using System.IO;
namespace Lookup
{
    public partial class FormPerformanceGrades : Form
    {
        public FormPerformanceGrades()
        {
            InitializeComponent();
        }
        public double w1 = 0; public double n1 = 0;
        public double w2 = 0; public double n2 = 0;
        public double w3 = 0; public double n3 = 0;
        public double w4 = 0; public double n4 = 0;
        public double w5 = 0; public double n5 = 0;
        public double w6 = 0; public double n6 = 0;

        public double w1personel=0; public double n1personel=0;
        public double w2personel=0; public double n2personel=0;
        public double w3personel=0; public double n3personel=0;
        public double w4personel=0; public double n4personel=0;
        public double w5personel=0; public double n5personel=0;
        public double w6personel=0; public double n6personel=0;

        public int count1 = 0;
        public int count2 = 0;
        public int count3 = 0;
        public int count4 = 0;
        public bool veri2boş=false;
        public bool veri3boş=false;
        public bool veri4boş=false;
        public bool veri5boş=false;
        public bool veri6boş=false;
        public string personelIsim;
        public string personelId;
        public string personelDepartment;
        public string personelGorev;
        public bool degistir;
        public bool kaydet;
        public bool xc = true;
        public string nereden;
        public string çalışanID;
        public string personelEkledenGelen1;
        public bool buttonkaydetebasıldı = false;
        public int personelnumarası;
        public bool resimkaydetmeekle=false;

        OleDbDataAdapter da;
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\user\\Desktop\\Lookup\\bin\\Debug\\Database\\Proje.mdb");
        private void FormPerformansNot_Load(object sender, EventArgs e)
        {
            if (nereden == "Çalışan")
            {
                personelId = çalışanID;
                button4.Visible = false;
                button5.Visible = false;
                button7.Visible = true;
                checkBox1.AutoCheck = false;
                checkBox2.AutoCheck = false;
                checkBox3.AutoCheck = false;
                checkBox4.AutoCheck = false;
                checkBox5.AutoCheck = false;
                checkBox6.AutoCheck = false;
                checkBox7.AutoCheck = false;
                checkBox8.AutoCheck = false;
                checkBox9.AutoCheck = false;
                checkBox10.AutoCheck = false;
                checkBox11.AutoCheck = false;
                checkBox12.AutoCheck = false;
                checkBox13.AutoCheck = false;
                checkBox14.AutoCheck = false;
                checkBox15.AutoCheck = false;
                checkBox16.AutoCheck = false;
                checkBox17.AutoCheck = false;
                checkBox18.AutoCheck = false;
                textBox7.Enabled = false;               
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox4.Enabled = false;
                textBox6.Enabled = false;
                textBox13.Enabled = false;
                textBox17.Enabled = false;
                textBox3.Enabled = false;
                textBox11.Enabled = false;
                textBox14.Enabled = false;
                textBox15.Enabled = false;
                textBox18.Enabled = false;
                textBox19.Enabled = false;
                textBox20.Enabled = false;
                textBox21.Enabled = false;
                textBox22.Enabled = false;
                textBox23.Enabled = false;
                textBox24.Enabled = false;
                textBox25.Enabled = false;
                textBoxYorum1.Enabled = false;
                textBoxYorum2.Enabled = false;
                textBoxYorum3.Enabled = false;
                textBoxYorum4.Enabled = false;
                textBoxYorum5.Enabled = false;
                textBoxYorum6.Enabled = false;
                label24.Visible = true;
                label25.Visible = true;                                          
                personelağırlık1();
                personelağırlık2();
                personelağırlık3();
                personelağırlık4();
                personelağırlık5();
                personelağırlık6();
                islemlerpersonel();
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                textBox5.Enabled = false;
                textBox16.Enabled = false;
                textBox12.Enabled = false;
                if (w2personel == 0)
                {
                    textBox27.Enabled = false;
                }
                if (w3personel == 0)
                {
                    textBox28.Enabled = false;
                }
                if (w4personel == 0)
                {
                    textBox29.Enabled = false;
                }
                if (w5personel == 0)
                {
                    textBox30.Enabled = false;
                }
                if (w6personel == 0)
                {
                    textBox31.Enabled = false;
                }
            }
            if (nereden != "Çalışan")
            {
                button2.Visible = true;
                personelağırlık1();
                personelağırlık2();
                personelağırlık3();
                personelağırlık4();
                personelağırlık5();
                personelağırlık6();
                islemlerpersonel();
                textBox26.Enabled = false;
                textBox27.Enabled = false;
                textBox28.Enabled = false;
                textBox29.Enabled = false;
                textBox30.Enabled = false;
                textBox31.Enabled = false;
                textBox32.Enabled = false;               
            }
            con.Open();
            string sql1 = "Select * from ProjeDatası where [Kimlik No]='" + çalışanID + "'";
            OleDbCommand komut = new OleDbCommand(sql1, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                personelIsim = oku["Personel No"].ToString();
                personelDepartment = oku["Departman"].ToString();
                personelGorev = oku["Görev"].ToString();
            }
            con.Close();

            if (personelIsim != "label15")
            {
                textBoxIsim.Text = personelIsim;
            }
            if (personelId != "label16")
            {
                textBoxID.Text = personelId;
            }
            if (personelDepartment != "label17")
            {
                textBoxDepartman.Text = personelDepartment;
            }
            if (personelGorev != "label18")
            {
                textBoxGorev.Text = personelGorev;
            }

            if (degistir)
            {
                buttonDegistir.Visible = true;
            }
            if (kaydet)
            {
                buttonKaydet.Visible = true;
            }
            agırlık_goster_W1();
            agırlık_goster_W2();
            agırlık_goster_W3();
            agırlık_goster_W4();
            agırlık_goster_W5();
            agırlık_goster_W6();
            if (textBox2.Text == "")
            {
                veri2boş = true;
            }
            if (textBox4.Text == "")
            {
                veri3boş = true;
            }
            if (textBox6.Text == "")
            {
                veri4boş = true;
            }
            if (textBox13.Text == "")
            {
                veri5boş = true;
            }
            if (textBox17.Text == "")
            {
                veri6boş = true;
            }
            Thread.Sleep(50);
            resimgöster();
            labelPersonelAd.Text = textBoxIsim.Text;
            islemler();
            FormTOPSIS form1 = new FormTOPSIS();
            form1.performansSonucuTOPSISSayfası = textBox7.Text.ToString();
        }
        private void islemler()
        {
            ///////////////////////////////Weights
            if (textBox8.Text != "")
            {
                w1 = Convert.ToDouble(textBox8.Text);
            }
            if (textBox9.Text != "")
            {
                w2 = Convert.ToDouble(textBox9.Text);
            }
            if (textBox10.Text != "")
            {
                w3 = Convert.ToDouble(textBox10.Text);
            }
            if (textBox5.Text != "")
            {
                w4 = Convert.ToDouble(textBox5.Text);
            }
            if (textBox12.Text != "")
            {
                w5 = Convert.ToDouble(textBox12.Text);
            }
            if (textBox16.Text != "")
            {
                w6 = Convert.ToDouble(textBox16.Text);
            }
            ///////////////100 e eşit olcak.
            //////////////////////Grades
            if (textBox3.Text != "")
            {
                n1 = Convert.ToDouble(textBox3.Text);
            }

            if (textBox11.Text != "")
            {
                n2 = Convert.ToDouble(textBox11.Text);

            }

            if (textBox14.Text != "")
            {
                n3 = Convert.ToDouble(textBox14.Text);
            }

            if (textBox15.Text != "")
            {
                n4 = Convert.ToDouble(textBox15.Text);
            }

            if (textBox18.Text != "")
            {
                n5 = Convert.ToDouble(textBox18.Text);
            }

            if (textBox19.Text != "")
            {
                n6 = Convert.ToDouble(textBox19.Text);
            }

            //textBox3.Text = (int.Parse(text) * 2).ToString();
            //Not
            double toplam = ((w1 / 100) * n1) + ((w2 / 100) * n2) + ((w3 / 100) * n3) + ((w4 / 100) * n4) + ((w5 / 100) * n5) + ((w6 / 100) * n6);
            textBox7.Text = toplam.ToString();
            labelPerformansSonucu.Text = textBox7.Text;


            FormKarşılaştırma form = new FormKarşılaştırma();
            form.performanssonucu = labelPerformansSonucu.Text;
            //TOPSIS
            double squarerootsA = Math.Sqrt((n1 * n1) + (n2 * n2) + (n3 * n3) + (n4 * n4) + (n5 * n5) + (n6 * n6));
            double[] vMatrix = new double[6];
            vMatrix[0] = ((n1 / squarerootsA) * w1);
            vMatrix[1] = ((n2 / squarerootsA) * w2);
            vMatrix[2] = ((n3 / squarerootsA) * w3);
            vMatrix[3] = ((n4 / squarerootsA) * w4);
            vMatrix[4] = ((n5 / squarerootsA) * w5);
            vMatrix[5] = ((n6 / squarerootsA) * w6);

            double[] aPlusMatrix = new double[1];
            aPlusMatrix[0] = vMatrix.Max();

            double[] aMinusMatrix = new double[1];
            aMinusMatrix[0] = vMatrix.Min();

            double[] sPlusMatrix = new double[1];
            sPlusMatrix[0] = Math.Sqrt(Math.Pow(aPlusMatrix[0] - vMatrix[0], 2) + Math.Pow(aPlusMatrix[0] - vMatrix[1], 2) + Math.Pow(aPlusMatrix[0] - vMatrix[2], 2) + Math.Pow(aPlusMatrix[0] - vMatrix[3], 2) + Math.Pow(aPlusMatrix[0] - vMatrix[4], 2) + Math.Pow(aPlusMatrix[0] - vMatrix[5], 2));

            double[] sMinusMatrix = new double[1];
            sMinusMatrix[0] = Math.Sqrt(Math.Pow(vMatrix[0] - aMinusMatrix[0], 2) + Math.Pow(vMatrix[1] - aMinusMatrix[0], 2) + Math.Pow(vMatrix[2] - aMinusMatrix[0], 2) + Math.Pow(vMatrix[3] - aMinusMatrix[0], 2) + Math.Pow(vMatrix[4] - aMinusMatrix[0], 2) + Math.Pow(vMatrix[5] - aMinusMatrix[0], 2));

            double[] TOPSIS = new double[1];
            TOPSIS[0] = (sMinusMatrix[0]) / (sMinusMatrix[0] + sPlusMatrix[0]);
            TOPSIS[0] = Math.Ceiling(TOPSIS[0] * 100);
            labelTOPSIS.Text = TOPSIS[0].ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (nereden != "Çalışan")
            {
                FormPersonnel form = new FormPersonnel();
                form.Show();
                this.Hide();
            }
            else if (nereden == "Çalışan")
            {
                FormMain form = new FormMain();
                form.Show();
                this.Hide();
            }
        }
        private void labelIsim_Click(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            if (checkBox3.Checked)
            {
                labelYorum1.Visible = true;
                textBoxYorum1.Visible = true;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
            else
            {
                labelYorum1.Visible = false;
                textBoxYorum1.Visible = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            if (checkBox6.Checked)
            {
                labelYorum2.Visible = true;
                textBoxYorum2.Visible = true;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
            }
            else
            {
                labelYorum2.Visible = false;
                textBoxYorum2.Visible = false;
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            if (checkBox9.Checked)
            {
                labelYorum3.Visible = true;
                textBoxYorum3.Visible = true;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
            }
            else
            {
                labelYorum3.Visible = false;
                textBoxYorum3.Visible = false;
            }
        }
        private void label9_Click(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (buttonkaydetebasıldı == false)
            {
                MessageBox.Show("Please click 'save changes' first.");
            }
            else if (buttonkaydetebasıldı == true)
            {
                if ((textBox8.Text == "") || (textBox1.Text == "") || (textBox3.Text == ""))
                {
                    if ((checkBox1.Checked == false) && (checkBox2.Checked == false) && (checkBox3.Checked == false))
                    {
                        MessageBox.Show("Lütfen en az 1 tane iş hedefi tanımlayınız. Ayrıca iş hedefine karşılık gelen ağırlığı da tanımlayınız.");
                    }
                }
                else if ((textBox8.Text != "") && (textBox1.Text != "") && (textBox3.Text != ""))
                {
                    FormTOPSIS form = new FormTOPSIS();
                    if (personelEkledenGelen1 == "Doğru")
                    {
                        form.personelEkledenGelen2 = "Doğru";
                    }
                    form.personelID = textBoxID.Text;
                    form.personelNo = textBoxIsim.Text;
                    form.TOPSISsonuc = labelTOPSIS.Text;
                    form.Performanssonuc = labelPerformansSonucu.Text;
                    form.Show();
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
        }
        private void checkBox12_CheckedChanged_1(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            if (checkBox12.Checked)
            {
                labelYorum4.Visible = true;
                textBoxYorum4.Visible = true;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
            }
            else
            {
                labelYorum4.Visible = false;
                textBoxYorum4.Visible = false;
            }
        }

        private void checkBox15_CheckedChanged_1(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            if (checkBox15.Checked)
            {
                labelYorum5.Visible = true;
                textBoxYorum5.Visible = true;
                checkBox13.Checked = false;
                checkBox14.Checked = false;
            }
            else
            {
                labelYorum5.Visible = false;
                textBoxYorum5.Visible = false;
            }
        }

        private void checkBox18_CheckedChanged_1(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            if (checkBox18.Checked)
            {
                labelYorum6.Visible = true;
                textBoxYorum6.Visible = true;
                checkBox16.Checked = false;
                checkBox17.Checked = false;
            }
            else
            {
                labelYorum6.Visible = false;
                textBoxYorum6.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            if (count1 == 1)
            {
                panel1.Visible = false;
                buttonArtı2.Visible = false;
                count1--;
            }
            else
            {
                panel1.Visible = true;
                buttonArtı2.Visible = true;
                count1++;
            }
        }
        private void buttonArtı2_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            if (count2 == 1)
            {
                panel2.Visible = false;
                buttonArtı3.Visible = false;
                count2--;
            }
            else
            {
                panel2.Visible = true;
                buttonArtı3.Visible = true;
                count2++;
            }
        }
        private void buttonArtı3_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            if (count3 == 1)
            {
                panel3.Visible = false;
                buttonArtı4.Visible = false;
                count3--;
            }
            else
            {
                panel3.Visible = true;
                buttonArtı4.Visible = true;
                count3++;
            }
        }
        private void buttonArtı4_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            if (count4 == 1)
            {
                panel4.Visible = false;
                count4--;
            }
            else
            {
                panel4.Visible = true;
                count4++;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            int result;
            if (int.TryParse(textBox8.Text, out result))
            {
                w1 = Convert.ToDouble(textBox8.Text);
                if (w1 > 100 || w1 <= 0)
                {
                    MessageBox.Show(" Lütfen bir sayı giriniz. Ağırlıklar '0' ile '100' arasında olmalıdır.");
                }
            }
            else
            {
                MessageBox.Show(" 1. İş Hedefi Ağırlığına yanlış sayı girdiniz. Ağırlıklar '0' ile '100' arasında olmalıdır.");
            }
        }
        private void agırlık_goster_W1()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Kimlik No]='" + personelId + "'and [İş No]='" + "1" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                textBox8.Text = oku["Weight of the Goals"].ToString();
                string text = oku["Grades"].ToString();
                textBox3.Text = text;
                textBox1.Text = oku["Goals"].ToString();
                if (oku["Underperformed"].ToString() == "-1")
                {
                    checkBox1.Checked = true;
                    textBox20.Text = oku["Kötü Comment"].ToString();
                }
                if (oku["Performed"].ToString() == "-1")
                {
                    checkBox2.Checked = true;
                }
                if (oku["Overperformed"].ToString() == "-1")
                {
                    checkBox3.Checked = true;
                    textBoxYorum1.Text = oku["Comment"].ToString();
                }
            }
            con.Close();
        }
        private void agırlık_goster_W2()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Kimlik No]='" + personelId + "'and [İş No]='" + "2" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                textBox9.Text = oku["Weight of the Goals"].ToString();
                string text = oku["Grades"].ToString();
                textBox11.Text = text;
                textBox2.Text = oku["Goals"].ToString();
                if (oku["Underperformed"].ToString() == "-1")
                {
                    checkBox4.Checked = true;
                    textBox21.Text = oku["Kötü Comment"].ToString();
                }
                if (oku["Performed"].ToString() == "-1")
                {
                    checkBox5.Checked = true;
                }
                if (oku["Overperformed"].ToString() == "-1")
                {
                    checkBox6.Checked = true;
                    textBoxYorum2.Text = oku["Comment"].ToString();
                }
            }
            con.Close();
        }
        private void agırlık_goster_W3()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Kimlik No]='" + personelId + "'and [İş No]='" + "3" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                textBox10.Text = oku["Weight of the Goals"].ToString();
                string text = oku["Grades"].ToString();
                textBox14.Text = text;
                textBox4.Text = oku["Goals"].ToString();

                if (oku["Underperformed"].ToString() == "-1")
                {
                    checkBox7.Checked = true;
                    textBox22.Text = oku["Kötü Comment"].ToString();
                }
                if (oku["Performed"].ToString() == "-1")
                {
                    checkBox8.Checked = true;
                }
                if (oku["Overperformed"].ToString() == "-1")
                {
                    checkBox9.Checked = true;
                    textBoxYorum3.Text = oku["Comment"].ToString();
                }
            }
            con.Close();
        }
        private void agırlık_goster_W4()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Kimlik No]='" + personelId + "'and [İş No]='" + "4" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                textBox5.Text = oku["Weight of the Goals"].ToString();
                string text = oku["Grades"].ToString();
                textBox15.Text = text;
                textBox6.Text = oku["Goals"].ToString();

                if (oku["Underperformed"].ToString() == "-1")
                {
                    checkBox10.Checked = true;
                    textBox23.Text = oku["Kötü Comment"].ToString();
                }
                if (oku["Performed"].ToString() == "-1")
                {
                    checkBox11.Checked = true;
                }
                if (oku["Overperformed"].ToString() == "-1")
                {
                    checkBox12.Checked = true;
                    textBoxYorum4.Text = oku["Comment"].ToString();
                }
            }
            con.Close();
        }
        private void agırlık_goster_W5()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Kimlik No]='" + personelId + "'and [İş No]='" + "5" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                textBox12.Text = oku["Weight of the Goals"].ToString();
                string text = oku["Grades"].ToString();
                textBox18.Text = text;
                textBox13.Text = oku["Goals"].ToString();
                if (oku["Underperformed"].ToString() == "-1")
                {
                    checkBox13.Checked = true;
                    textBox24.Text = oku["Kötü Comment"].ToString();
                }
                if (oku["Performed"].ToString() == "-1")
                {
                    checkBox14.Checked = true;
                }
                if (oku["Overperformed"].ToString() == "-1")
                {
                    checkBox15.Checked = true;
                    textBoxYorum5.Text = oku["Comment"].ToString();
                }
            }
            con.Close();
        }
        private void agırlık_goster_W6()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Kimlik No]='" + personelId + "'and [İş No]='" + "6" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                textBox16.Text = oku["Weight of the Goals"].ToString();
                string text = oku["Grades"].ToString();
                textBox19.Text = text;
                textBox17.Text = oku["Goals"].ToString();

                if (oku["Underperformed"].ToString() == "-1")
                {
                    checkBox16.Checked = true;
                    textBox25.Text = oku["Kötü Comment"].ToString();
                }
                if (oku["Performed"].ToString() == "-1")
                {
                    checkBox17.Checked = true;
                }
                if (oku["Overperformed"].ToString() == "-1")
                {
                    checkBox18.Checked = true;
                    textBoxYorum6.Text = oku["Comment"].ToString();
                }
            }
            con.Close();
        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            int result;
            if (int.TryParse(textBox9.Text, out result))
            {
                w2 = Convert.ToDouble(textBox9.Text);
                if (w2 > 100 || w2 <= 0)
                {
                    MessageBox.Show(" Lütfen bir sayı giriniz. Ağırlıklar '0' ile '100' arasında olmalıdır.");
                }
            }
            else
            {
                MessageBox.Show(" 2. İş Hedefi Ağırlığına yanlış sayı girdiniz. Ağırlıklar '0' ile '100' arasında olmalıdır.");
            }
        }
        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            buttonkaydetebasıldı = true;
            bool dogrumuKaydet = true;

            double txt3değer = Convert.ToDouble(textBox3.Text);
            if (txt3değer > 10)
            {
                MessageBox.Show("Notlar 10'dan büyük olamaz. Lütfen kontrol ediniz.");
            }

            if (textBox11.Text != "")
            {
                double txt11değer = Convert.ToDouble(textBox11.Text);
                if (txt11değer > 10)
                {
                    MessageBox.Show("Notlar 10'dan büyük olamaz. Lütfen kontrol ediniz.");
                    dogrumuKaydet = false;
                }
            }
            if (textBox11.Text == "")
            {
            }
            if (textBox14.Text != "")
            {
                double txt14değer = Convert.ToDouble(textBox14.Text);
                if (txt14değer > 10)
                {
                    MessageBox.Show("Notlar 10'dan büyük olamaz. Lütfen kontrol ediniz.");
                    dogrumuKaydet = false;
                }
            }
            if (textBox14.Text == "")
            {
            }
            if (textBox15.Text != "")
            {
                double txt15değer = Convert.ToDouble(textBox15.Text);
                if (txt15değer > 10)
                {
                    MessageBox.Show("Notlar 10'dan büyük olamaz. Lütfen kontrol ediniz.");
                    dogrumuKaydet = false;
                }
            }
            if (textBox15.Text == "")
            {
            }
            if (textBox18.Text != "")
            {
                double txt18değer = Convert.ToDouble(textBox18.Text);
                if (txt18değer > 10)
                {
                    MessageBox.Show("Notlar 10'dan büyük olamaz. Lütfen kontrol ediniz.");
                    dogrumuKaydet = false;
                }
            }
            if (textBox18.Text == "")
            {
            }
            if (textBox19.Text != "")
            {
                double txt19değer = Convert.ToDouble(textBox19.Text);
                if (txt19değer > 10)
                {
                    MessageBox.Show("Notlar 10'dan büyük olamaz. Lütfen kontrol ediniz.");
                    dogrumuKaydet = false;
                }
            }
            if (textBox19.Text == "")
            {
            }
            if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox5.Text == "") && (textBox12.Text == "") && (textBox16.Text == ""))
            {
                MessageBox.Show("Lütfen en az 1 tane iş hedefi tanımlayınız.");
            }
                if ((textBox8.Text != "") & (textBox9.Text == "") & (textBox10.Text == "") & (textBox5.Text == "") & (textBox12.Text == "") & (textBox16.Text == ""))
            {
                if (w1 != 100)
                {
                    MessageBox.Show("Sadece 1 iş hedefi tanımladınız. Ağırlık kesinlikle 100 olmalıdır.");
                    dogrumuKaydet = false;
                }
            }
            else if ((textBox8.Text != "") & (textBox9.Text != "") & (textBox10.Text == "") & (textBox5.Text == "") & (textBox12.Text == "") & (textBox16.Text == ""))
            {
                if (w1 + w2 != 100)
                {
                    MessageBox.Show("2 iş hedefi tanımladınız. Toplam ağırlık 100 olmalıdır. Lütfen ağırlıkları buna uygun olarak giriniz.");
                    dogrumuKaydet = false;
                }
            }
            else if ((textBox8.Text != "") & (textBox9.Text != "") & (textBox10.Text != "") & (textBox5.Text == "") & (textBox12.Text == "") & (textBox16.Text == ""))
            {
                if (w1 + w2 + w3 != 100)
                {
                    MessageBox.Show("3 iş hedefi tanımladınız. Toplam ağırlık 100 olmalıdır. Lütfen ağırlıkları buna uygun olarak giriniz.");
                    dogrumuKaydet = false;
                }
            }
            else if ((textBox8.Text != "") & (textBox9.Text != "") & (textBox10.Text != "") & (textBox5.Text != "") & (textBox12.Text == "") & (textBox16.Text == ""))
            {
                if (w1 + w2 + w3 + w4 != 100)
                {
                    MessageBox.Show("4 iş hedefi tanımladınız. Toplam ağırlık 100 olmalıdır. Lütfen ağırlıkları buna uygun olarak giriniz.");
                    dogrumuKaydet = false;
                }
            }
            else if ((textBox8.Text != "") & (textBox9.Text != "") & (textBox10.Text != "") & (textBox5.Text != "") & (textBox12.Text != "") & (textBox16.Text == ""))
            {
                if (w1 + w2 + w3 + w4 + w5 != 100)
                {
                    MessageBox.Show("5 iş hedefi tanımladınız. Toplam ağırlık 100 olmalıdır. Lütfen ağırlıkları buna uygun olarak giriniz.");
                    dogrumuKaydet = false;
                }
            }
            else if ((textBox8.Text != "") & (textBox9.Text != "") & (textBox10.Text != "") & (textBox5.Text != "") & (textBox12.Text != "") & (textBox16.Text != ""))
            {
                if (w1 + w2 + w3 + w4 + w5 + w6 != 100)
                {
                    MessageBox.Show("6 iş hedefi tanımladınız. Toplam ağırlık 100 olmalıdır. Lütfen ağırlıkları buna uygun olarak giriniz.");
                    dogrumuKaydet = false;
                }
            }
            if (dogrumuKaydet)
            {
                DialogResult result = MessageBox.Show("Kaydetmek İstediğinize Emin Misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    insert1();
                    insert2();
                    insert3();
                    insert4();
                    insert5();
                    insert6();
                    performanssonucuKaydet();
                    resimInsert();
                }
                MessageBox.Show("Kaydedildi");
            }
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void performanssonucuKaydet()
        {
            con.Open();
            string sql = "Insert into PerformansSonuçları([Personel No],[Kimlik No],[Performans Sonucu]) values (@personelno,@kimlikno,@performanssonucu)";

            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.Parameters.AddWithValue("@personelno", textBoxIsim.Text);
            komut.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
            komut.Parameters.AddWithValue("@performanssonucu", textBox7.Text.ToString());
            komut.ExecuteNonQuery();
            con.Close();
        }
        private void performanssonucuDeğiştir()
        {
            con.Open();
            string sql = "update PerformansSonuçları set [Personel No]=@personelno, [Kimlik No]=@kimlikno," +
                "[Performans Sonucu]=@performanssonucu where [Kimlik No]=@kimlikno";

            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.Parameters.AddWithValue("@personelno", textBoxIsim.Text);
            komut.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
            komut.Parameters.AddWithValue("@performanssonucu", textBox7.Text.ToString());
            komut.ExecuteNonQuery();
            con.Close();
        }
        private void kullanmaKılavuzuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Önce İş Hedeflerini Giriniz. Sonra ağırlıkları belirleyiniz.\n\nEğer bir performans değerlendirmesi yapılacaksa, " +
                " kişinin performansına göre 'Hedefini Gerçekleştirmedi', 'Hedefini Gerçekleştirdi' ve 'Hedefinin Üstüne Çıktı' " +
                "seçeneklerinden birini işaretleyiniz. \n\nEğer 'Hedefini Gerçekleştirmedi' kısmını işaretlerseniz, 'Not' kısmının altına" +
                " performans notu olarak:" + "\n\b0,1,2 veya 3 veriniz.\n\nEğer 'Hedefini Gerçekleştirdi' kısmını işaretlerseniz, 'Not' kısmının altına " +
                "performans notu olarak:" + "\n\b4,5,6,7 veya 8 veriniz.\n\nEğer 'Hedefinin Üstüne Çıktı' kısmını işaratlerseniz, 'Not' kısmının altına " +
                "performans notu olarak:" + "\n\b9 veya 10 veriniz.\n\nSon olarak, eğer 'Hedefinin Üstüne Çıktı' veya'Hedefini Gerçekleştirmedi' kısmını işaretlerseniz yorum kısmına " +
                "kişinin performansı hakkında kendi yorumunu yazınız.\n\nTerfi işlemleri için gereken performans sonucunu görmek için 'Personel Performansı Karşılaştırma '" +
                "butonuna tıklayınız.", "Kullanım");
        }
        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //////////////////////////// Veri Güncelle 1

        private void veriGuncelle1()
        {
                con.Open();
                string sql = "update PerformansVerileri set [Personel No]=@no, [Kimlik No]=@kimlikno, [Goals]=@goals,[Weight of the Goals]=@weight,[Grades]=@grades,[Underperformed]=@under,[Performed]=@right,[Overperformed]=@over,[Comment]=@comment,[Kötü Comment]=@kötücomment, [İş No]=@iş where [Kimlik No]=@kimlikno and [İş No]=@iş";
                OleDbCommand komut = new OleDbCommand(sql, con);
                komut.Parameters.AddWithValue("@no", textBoxIsim.Text);
                komut.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
                komut.Parameters.AddWithValue("@goals", textBox1.Text);
                komut.Parameters.AddWithValue("@weight", textBox8.Text);
                komut.Parameters.AddWithValue("@grades", textBox3.Text);
                if (checkBox1.Checked == true)
                {
                    komut.Parameters.AddWithValue("@under", -1);
                }
                else if (checkBox1.Checked == false)
                {
                    komut.Parameters.AddWithValue("@under", 0);
                }

                if (checkBox2.Checked == true)
                {
                    komut.Parameters.AddWithValue("@right", -1);
                }
                else if (checkBox2.Checked == false)
                {
                    komut.Parameters.AddWithValue("@right", 0);
                }

                if (checkBox3.Checked == true)
                {
                    komut.Parameters.AddWithValue("@over", -1);
                }
                else if (checkBox3.Checked == false)
                {
                    komut.Parameters.AddWithValue("@over", 0);
                }
                komut.Parameters.AddWithValue("@comment", textBoxYorum1.Text);
                if (checkBox1.Checked == true)
                {
                    komut.Parameters.AddWithValue("@kötücomment", textBox20.Text);
                }
                else if (checkBox1.Checked == false)
                {
                    komut.Parameters.AddWithValue("@kötücomment", "");
                }
                komut.Parameters.AddWithValue("@iş", "1");
                komut.ExecuteNonQuery();
                con.Close();
                con.Open();
                string sql1 = "update PersonelPerformansVerileri set [Kimlik No]=@kimlikno,[Weights]=@weights,[İş No]=@işno where [Kimlik No]=@kimlikno and [İş No]=@işno";
                OleDbCommand komut1 = new OleDbCommand(sql1, con);
                komut1.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
                komut1.Parameters.AddWithValue("@weights", textBox8.Text);
                komut1.Parameters.AddWithValue("@işno", "1");
                komut1.ExecuteNonQuery();
                con.Close();
        }
        ///////////////////////////////////////Veri Güncelle 2
        private void veriGuncelle2()
        {
                con.Open();
                string sql = "update PerformansVerileri set [Personel No]=@no, [Kimlik No]=@kimlikno, [Goals]=@goals,[Weight of the Goals]=@weight,[Grades]=@grades,[Underperformed]=@under,[Performed]=@right,[Overperformed]=@over,[Comment]=@comment,[Kötü Comment]=@kötücomment, [İş No]=@iş where [Kimlik No]=@kimlikno and [İş No]=@iş";
                OleDbCommand komut = new OleDbCommand(sql, con);
                komut.Parameters.AddWithValue("@no", textBoxIsim.Text);
                komut.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
                komut.Parameters.AddWithValue("@goals", textBox2.Text);
                komut.Parameters.AddWithValue("@weight", textBox9.Text);
                komut.Parameters.AddWithValue("@grades", textBox11.Text);
                if (checkBox4.Checked == true)
                {
                    komut.Parameters.AddWithValue("@under", -1);
                }
                else if (checkBox4.Checked == false)
                {
                    komut.Parameters.AddWithValue("@under", 0);
                }

                if (checkBox5.Checked == true)
                {
                    komut.Parameters.AddWithValue("@right", -1);
                }
                else if (checkBox5.Checked == false)
                {
                    komut.Parameters.AddWithValue("@right", 0);
                }

                if (checkBox6.Checked == true)
                {
                    komut.Parameters.AddWithValue("@over", -1);
                }
                else if (checkBox6.Checked == false)
                {
                    komut.Parameters.AddWithValue("@over", 0);
                }
                komut.Parameters.AddWithValue("@comment", textBoxYorum2.Text);
                if (checkBox4.Checked == true)
                {
                    komut.Parameters.AddWithValue("@kötücomment", textBox21.Text);
                }
                else if (checkBox4.Checked == false)
                {
                    komut.Parameters.AddWithValue("@kötücomment", "");
                }
                komut.Parameters.AddWithValue("@iş", "2");
                komut.ExecuteNonQuery();
                con.Close();           
                con.Open();
                string sql1 = "update PersonelPerformansVerileri set [Kimlik No]=@kimlikno,[Weights]=@weights,[İş No]=@işno where [Kimlik No]=@kimlikno and [İş No]=@işno";
                OleDbCommand komut1 = new OleDbCommand(sql1, con);
                komut1.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
                komut1.Parameters.AddWithValue("@weights", textBox9.Text);
                komut1.Parameters.AddWithValue("@işno", "2");
                komut1.ExecuteNonQuery();
                con.Close();
        }
        ///////////////////////////////Veri GÜncelle 3
        private void veriGuncelle3()
        {
                con.Open();
                string sql = "update PerformansVerileri set [Personel No]=@no, [Kimlik No]=@kimlikno,[Goals]=@goals,[Weight of the Goals]=@weight,[Grades]=@grades,[Underperformed]=@under,[Performed]=@right,[Overperformed]=@over,[Comment]=@comment,[Kötü Comment]=@kötücomment,[İş No]=@iş where [Kimlik No]=@kimlikno and [İş No]=@iş";
                OleDbCommand komut = new OleDbCommand(sql, con);
                komut.Parameters.AddWithValue("@no", textBoxIsim.Text);
                komut.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
                komut.Parameters.AddWithValue("@goals", textBox4.Text);
                komut.Parameters.AddWithValue("@weight", textBox10.Text);
                komut.Parameters.AddWithValue("@grades", textBox14.Text);
                if (checkBox7.Checked == true)
                {
                    komut.Parameters.AddWithValue("@under", -1);
                }
                else if (checkBox7.Checked == false)
                {
                    komut.Parameters.AddWithValue("@under", 0);
                }

                if (checkBox8.Checked == true)
                {
                    komut.Parameters.AddWithValue("@right", -1);
                }
                else if (checkBox8.Checked == false)
                {
                    komut.Parameters.AddWithValue("@right", 0);
                }

                if (checkBox9.Checked == true)
                {
                    komut.Parameters.AddWithValue("@over", -1);
                }
                else if (checkBox9.Checked == false)
                {
                    komut.Parameters.AddWithValue("@over", 0);
                }
                komut.Parameters.AddWithValue("@comment", textBoxYorum3.Text);
                if (checkBox7.Checked == true)
                {
                    komut.Parameters.AddWithValue("@kötücomment", textBox22.Text);
                }
                else if (checkBox7.Checked == false)
                {
                    komut.Parameters.AddWithValue("@kötücomment", "");
                }
                komut.Parameters.AddWithValue("@iş", "3");
                komut.ExecuteNonQuery();
                con.Close();
                con.Open();
                string sql1 = "update PersonelPerformansVerileri set [Kimlik No]=@kimlikno,[Weights]=@weights,[İş No]=@işno where [Kimlik No]=@kimlikno and [İş No]=@işno";
                OleDbCommand komut1 = new OleDbCommand(sql1, con);
                komut1.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
                komut1.Parameters.AddWithValue("@weights", textBox10.Text);
                komut1.Parameters.AddWithValue("@işno", "3");
                komut1.ExecuteNonQuery();
                con.Close();
        }
        //////////////////////////////////////////////Veri Güncelle 4
        private void veriGuncelle4()
        {
                con.Open();
                string sql = "update PerformansVerileri set [Personel No]=@no, [Kimlik No]=@kimlikno,[Goals]=@goals,[Weight of the Goals]=@weight,[Grades]=@grades,[Underperformed]=@under,[Performed]=@right,[Overperformed]=@over,[Comment]=@comment,[Kötü Comment]=@kötücomment,[İş No]=@iş where [Kimlik No]=@kimlikno and [İş No]=@iş";
                OleDbCommand komut = new OleDbCommand(sql, con);
                komut.Parameters.AddWithValue("@no", textBoxIsim.Text);
                komut.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
                komut.Parameters.AddWithValue("@goals", textBox6.Text);
                komut.Parameters.AddWithValue("@weight", textBox5.Text);
                komut.Parameters.AddWithValue("@grades", textBox15.Text);
                if (checkBox10.Checked == true)
                {
                    komut.Parameters.AddWithValue("@under", -1);
                }
                else if (checkBox10.Checked == false)
                {
                    komut.Parameters.AddWithValue("@under", 0);
                }

                if (checkBox11.Checked == true)
                {
                    komut.Parameters.AddWithValue("@right", -1);
                }
                else if (checkBox11.Checked == false)
                {
                    komut.Parameters.AddWithValue("@right", 0);
                }

                if (checkBox12.Checked == true)
                {
                    komut.Parameters.AddWithValue("@over", -1);
                }
                else if (checkBox12.Checked == false)
                {
                    komut.Parameters.AddWithValue("@over", 0);
                }
                komut.Parameters.AddWithValue("@comment", textBoxYorum4.Text);
                if (checkBox10.Checked == true)
                {
                    komut.Parameters.AddWithValue("@kötücomment", textBox23.Text);
                }
                else if (checkBox10.Checked == false)
                {
                    komut.Parameters.AddWithValue("@kötücomment", "");
                }
                komut.Parameters.AddWithValue("@iş", "4");
                komut.ExecuteNonQuery();
                con.Close();
                con.Open();
                string sql1 = "update PersonelPerformansVerileri set [Kimlik No]=@kimlikno,[Weights]=@weights,[İş No]=@işno where [Kimlik No]=@kimlikno and [İş No]=@işno";
                OleDbCommand komut1 = new OleDbCommand(sql1, con);
                komut1.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
                komut1.Parameters.AddWithValue("@weights", textBox5.Text);
                komut1.Parameters.AddWithValue("@işno", "4");
                komut1.ExecuteNonQuery();
                con.Close();
        }
        //////////////////////////////Veri GÜncelle 5
        private void veriGuncelle5()
        {
                con.Open();
                string sql = "update PerformansVerileri set [Personel No]=@no,[Kimlik No]=@kimlikno, [Goals]=@goals,[Weight of the Goals]=@weight,[Grades]=@grades,[Underperformed]=@under,[Performed]=@right,[Overperformed]=@over,[Comment]=@comment,[Kötü Comment]=@kötücomment,[İş No]=@iş where [Kimlik No]=@kimlikno and [İş No]=@iş";
                OleDbCommand komut = new OleDbCommand(sql, con);
                komut.Parameters.AddWithValue("@no", textBoxIsim.Text);
                komut.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
                komut.Parameters.AddWithValue("@goals", textBox13.Text);
                komut.Parameters.AddWithValue("@weight", textBox12.Text);
                komut.Parameters.AddWithValue("@grades", textBox18.Text);

                if (checkBox13.Checked == true)
                {
                    komut.Parameters.AddWithValue("@under", -1);
                }
                else if (checkBox13.Checked == false)
                {
                    komut.Parameters.AddWithValue("@under", 0);
                }

                if (checkBox14.Checked == true)
                {
                    komut.Parameters.AddWithValue("@right", -1);
                }
                else if (checkBox14.Checked == false)
                {
                    komut.Parameters.AddWithValue("@right", 0);
                }

                if (checkBox15.Checked == true)
                {
                    komut.Parameters.AddWithValue("@over", -1);
                }
                else if (checkBox15.Checked == false)
                {
                    komut.Parameters.AddWithValue("@over", 0);
                }
                komut.Parameters.AddWithValue("@comment", textBoxYorum5.Text);
                if (checkBox13.Checked == true)
                {
                    komut.Parameters.AddWithValue("@kötücomment", textBox24.Text);
                }
                else if (checkBox13.Checked == false)
                {
                    komut.Parameters.AddWithValue("@kötücomment", "");
                }
                komut.Parameters.AddWithValue("@iş", "5");
                komut.ExecuteNonQuery();
                con.Close();
                con.Open();
                string sql1 = "update PersonelPerformansVerileri set [Kimlik No]=@kimlikno,[Weights]=@weights,[İş No]=@işno where [Kimlik No]=@kimlikno and [İş No]=@işno";
                OleDbCommand komut1 = new OleDbCommand(sql1, con);
                komut1.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
                komut1.Parameters.AddWithValue("@weights", textBox12.Text);
                komut1.Parameters.AddWithValue("@işno", "5");
                komut1.ExecuteNonQuery();
                con.Close();
        }
        /////////////////////////////Veri GÜncelle 6
        private void veriGuncelle6()
        {
                con.Open();

                string sql = "update PerformansVerileri set [Personel No]=@no, [Kimlik No]=@kimlikno,[Goals]=@goals,[Weight of the Goals]=@weight,[Grades]=@grades,[Underperformed]=@under,[Performed]=@right,[Overperformed]=@over,[Comment]=@comment,[Kötü Comment]=@kötücomment,[İş No]=@iş where [Kimlik No]=@kimlikno and [İş No]=@iş";
                OleDbCommand komut = new OleDbCommand(sql, con);
                komut.Parameters.AddWithValue("@no", textBoxIsim.Text);
                komut.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
                komut.Parameters.AddWithValue("@goals", textBox17.Text);
                komut.Parameters.AddWithValue("@weight", textBox16.Text);
                komut.Parameters.AddWithValue("@grades", textBox19.Text);
                if (checkBox16.Checked == true)
                {
                    komut.Parameters.AddWithValue("@under", -1);
                }
                else if (checkBox16.Checked == false)
                {
                    komut.Parameters.AddWithValue("@under", 0);
                }

                if (checkBox17.Checked == true)
                {
                    komut.Parameters.AddWithValue("@right", -1);
                }
                else if (checkBox17.Checked == false)
                {
                    komut.Parameters.AddWithValue("@right", 0);
                }

                if (checkBox18.Checked == true)
                {
                    komut.Parameters.AddWithValue("@over", -1);
                }
                else if (checkBox18.Checked == false)
                {
                    komut.Parameters.AddWithValue("@over", 0);
                }
                komut.Parameters.AddWithValue("@comment", textBoxYorum6.Text);
                if (checkBox16.Checked == true)
                {
                    komut.Parameters.AddWithValue("@kötücomment", textBox25.Text);
                }
                else if (checkBox16.Checked == false)
                {
                    komut.Parameters.AddWithValue("@kötücomment", "");
                }
                komut.Parameters.AddWithValue("@iş", "6");
                komut.ExecuteNonQuery();
                con.Close();
                con.Open();
                string sql1 = "update PersonelPerformansVerileri set [Kimlik No]=@kimlikno,[Weights]=@weights,[İş No]=@işno where [Kimlik No]=@kimlikno and [İş No]=@işno";
                OleDbCommand komut1 = new OleDbCommand(sql1, con);
                komut1.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
                komut1.Parameters.AddWithValue("@weights", textBox16.Text);
                komut1.Parameters.AddWithValue("@işno", "6");
                komut1.ExecuteNonQuery();
                con.Close();
        }
        private void buttonDegistir_Click(object sender, EventArgs e)
        {
            bool dogruMu = true;
            buttonkaydetebasıldı = true;
            double txt3değer = Convert.ToDouble(textBox3.Text);
            if (txt3değer > 10)
            {
                MessageBox.Show("Notlar 10'dan büyük olamaz. Lütfen kontrol ediniz.");
                dogruMu = false;
            }
            if (textBox11.Text != "")
            {
                double txt11değer = Convert.ToDouble(textBox11.Text);
                if (txt11değer > 10)
                {
                    MessageBox.Show("Notlar 10'dan büyük olamaz. Lütfen kontrol ediniz.");
                    dogruMu = false;
                }
            }
            if (textBox11.Text == "")
            {
            }
            if (textBox14.Text != "")
            {
                double txt14değer = Convert.ToDouble(textBox14.Text);
                if (txt14değer > 10)
                {
                    MessageBox.Show("Notlar 10'dan büyük olamaz. Lütfen kontrol ediniz.");
                    dogruMu = false;
                }
            }
            if (textBox14.Text == "")
            {
            }
            if (textBox15.Text != "")
            {
                double txt15değer = Convert.ToDouble(textBox15.Text);
                if (txt15değer > 10)
                {
                    MessageBox.Show("Notlar 10'dan büyük olamaz. Lütfen kontrol ediniz.");
                    dogruMu = false;
                }
            }
            if (textBox15.Text == "")
            {
            }
            if (textBox18.Text != "")
            {
                double txt18değer = Convert.ToDouble(textBox18.Text);
                if (txt18değer > 10)
                {
                    MessageBox.Show("Notlar 10'dan büyük olamaz. Lütfen kontrol ediniz.");
                    dogruMu = false;
                }
            }
            if (textBox18.Text == "")
            {
            }
            if (textBox19.Text != "")
            {
                double txt19değer = Convert.ToDouble(textBox19.Text);
                if (txt19değer > 10)
                {
                    MessageBox.Show("Notlar 10'dan büyük olamaz. Lütfen kontrol ediniz.");
                    dogruMu = false;
                }
            }
            if (textBox19.Text == "")
            {
            }
            if ((textBox8.Text != "") & (textBox9.Text == "") & (textBox10.Text == "") & (textBox5.Text == "") & (textBox12.Text == "") & (textBox16.Text == ""))
            {
                if (w1 != 100)
                {
                    MessageBox.Show("Sadece 1 iş hedefi tanımladınız. Ağırlık kesinlikle 100 olmalıdır.");
                    dogruMu = false;
                }
            }
            else if ((textBox8.Text != "") & (textBox9.Text != "") & (textBox10.Text == "") & (textBox5.Text == "") & (textBox12.Text == "") & (textBox16.Text == ""))
            {
                if (w1 + w2 != 100)
                {
                    MessageBox.Show("2 iş hedefi tanımladınız. Toplam ağırlık 100 olmalıdır. Lütfen ağırlıkları buna uygun olarak giriniz.");
                    dogruMu = false;
                }
            }
            else if ((textBox8.Text != "") & (textBox9.Text != "") & (textBox10.Text != "") & (textBox5.Text == "") & (textBox12.Text == "") & (textBox16.Text == ""))
            {
                if (w1 + w2 + w3 != 100)
                {
                    MessageBox.Show("3 iş hedefi tanımladınız. Toplam ağırlık 100 olmalıdır. Lütfen ağırlıkları buna uygun olarak giriniz.");
                    dogruMu = false;
                }
            }
            else if ((textBox8.Text != "") & (textBox9.Text != "") & (textBox10.Text != "") & (textBox5.Text != "") & (textBox12.Text == "") & (textBox16.Text == ""))
            {
                if (w1 + w2 + w3 + w4 != 100)
                {
                    MessageBox.Show("4 iş hedefi tanımladınız. Toplam ağırlık 100 olmalıdır. Lütfen ağırlıkları buna uygun olarak giriniz.");
                    dogruMu = false;
                }
            }
            else if ((textBox8.Text != "") & (textBox9.Text != "") & (textBox10.Text != "") & (textBox5.Text != "") & (textBox12.Text != "") & (textBox16.Text == ""))
            {
                if (w1 + w2 + w3 + w4 + w5 != 100)
                {
                    MessageBox.Show("5 iş hedefi tanımladınız. Toplam ağırlık 100 olmalıdır. Lütfen ağırlıkları buna uygun olarak giriniz.");
                    dogruMu = false;
                }
            }
            else if ((textBox8.Text != "") & (textBox9.Text != "") & (textBox10.Text != "") & (textBox5.Text != "") & (textBox12.Text != "") & (textBox16.Text != ""))
            {
                if (w1 + w2 + w3 + w4 + w5 + w6 != 100)
                {
                    MessageBox.Show("6 iş hedefi tanımladınız. Toplam ağırlık 100 olmalıdır. Lütfen ağırlıkları buna uygun olarak giriniz.");
                    dogruMu = false;
                }
            }
            if (dogruMu)
            {
                DialogResult result = MessageBox.Show("Değiştirmek İstediğinize Emin Misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if ((veri2boş == true) && (textBox2.Text != ""))
                    {
                        insert2();
                    }
                    if ((veri3boş == true) && (textBox4.Text != ""))
                    {
                        insert3();
                    }
                    if ((veri4boş == true) && (textBox6.Text != ""))
                    {
                        insert4();
                    }
                    if ((veri5boş == true) && (textBox13.Text != ""))
                    {
                        insert5();
                    }
                    if ((veri6boş == true) && (textBox16.Text != ""))
                    {
                        insert6();
                    }
                    if ((textBox1.Text == "") && (textBox2.Text == "") && (textBox4.Text == "") && (textBox6.Text == "") && (textBox13.Text == "") && (textBox17.Text == ""))
                    {
                        MessageBox.Show("Lütfen en az 1 tane iş hedefi tanımlayınız.");
                    }
                        if ((textBox1.Text != "") && (textBox2.Text =="") && (textBox4.Text == "") && (textBox6.Text == "") && (textBox13.Text == "") && (textBox17.Text == ""))
                    {
                        veriGuncelle1();
                    }
                    if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox4.Text == "") && (textBox6.Text == "") && (textBox13.Text == "") && (textBox17.Text == ""))
                    {
                        veriGuncelle1();
                        veriGuncelle2();
                    }
                    if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox4.Text != "") && (textBox6.Text == "") && (textBox13.Text == "") && (textBox17.Text == ""))
                    {
                        veriGuncelle1();
                        veriGuncelle2();
                        veriGuncelle3();
                    }
                    if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox4.Text != "") && (textBox6.Text != "") && (textBox13.Text == "") && (textBox17.Text == ""))
                    {
                        veriGuncelle1();
                        veriGuncelle2();
                        veriGuncelle3();
                        veriGuncelle4();
                    }
                    if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox4.Text != "") && (textBox6.Text != "") && (textBox13.Text != "") && (textBox17.Text == ""))
                    {
                        veriGuncelle1();
                        veriGuncelle2();
                        veriGuncelle3();
                        veriGuncelle4();
                        veriGuncelle5();
                    }
                    if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox4.Text != "") && (textBox6.Text != "") && (textBox13.Text != "") && (textBox17.Text != ""))
                    {
                        veriGuncelle1();
                        veriGuncelle2();
                        veriGuncelle3();
                        veriGuncelle4();
                        veriGuncelle5();
                        veriGuncelle6();
                    }
                    performanssonucuDeğiştir();
                    MessageBox.Show("Kaydedildi");
                }
                else if (result == DialogResult.No)
                {
                    MessageBox.Show("Değişiklikler başarısız oldu.");
                }
            }
        }
        ////////////////////////İnsert kodları

        private void insert1()
        {
            con.Open();

            string sql = "Insert into PerformansVerileri([Personel No],[Kimlik No],[Goals],[Weight of the Goals],[Grades],[Underperformed],[Performed],[Overperformed],[Comment],[Kötü Comment],[İş No]) values(@no,@kimlikno,@goals,@weight,@grades,@under,@right,@over,@comment,@kötücomment,@işno)";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.Parameters.AddWithValue("@no", textBoxIsim.Text);
            komut.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
            komut.Parameters.AddWithValue("@goals", textBox1.Text);
            komut.Parameters.AddWithValue("@weight", textBox8.Text);
            komut.Parameters.AddWithValue("@grades", textBox3.Text);
            if (checkBox1.Checked == true)
            {
                komut.Parameters.AddWithValue("@under", -1);
            }
            else if (checkBox1.Checked == false)
            {
                komut.Parameters.AddWithValue("@under", 0);
            }

            if (checkBox2.Checked == true)
            {
                komut.Parameters.AddWithValue("@right", -1);
            }
            else if (checkBox2.Checked == false)
            {
                komut.Parameters.AddWithValue("@right", 0);
            }

            if (checkBox3.Checked == true)
            {
                komut.Parameters.AddWithValue("@over", -1);
            }
            else if (checkBox3.Checked == false)
            {
                komut.Parameters.AddWithValue("@over", 0);
            }
            komut.Parameters.AddWithValue("@comment", textBoxYorum1.Text);
            if (checkBox1.Checked == true)
            {
                komut.Parameters.AddWithValue("@kötücomment", textBox20.Text);
            }
            else if (checkBox1.Checked == false)
            {
                komut.Parameters.AddWithValue("@kötücomment", "");
            }
            komut.Parameters.AddWithValue("@iş", "1");
            komut.ExecuteNonQuery();
            string sql1 = "Insert into PersonelPerformansVerileri([Kimlik No],[Weights],[İş No]) values(@kimlikno,@weights,@işno)";
            OleDbCommand komut1 = new OleDbCommand(sql1, con);
            komut1.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
            komut1.Parameters.AddWithValue("@weights", textBox8.Text);
            komut1.Parameters.AddWithValue("@işno", "1");
            komut1.ExecuteNonQuery();
            con.Close();
        }
        private void insert2()
        {
            if (textBox2.Text != "")
            {
                con.Open();

                string sql = "Insert into PerformansVerileri([Personel No],[Kimlik No],[Goals],[Weight of the Goals],[Grades],[Underperformed],[Performed],[Overperformed],[Comment],[Kötü Comment],[İş No]) values(@no,@kimlikno,@goals,@weight,@grades,@under,@right,@over,@comment,@kötücomment,@işno)";
                OleDbCommand komut = new OleDbCommand(sql, con);
                komut.Parameters.AddWithValue("@no", textBoxIsim.Text);
                komut.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
                komut.Parameters.AddWithValue("@goals", textBox2.Text);
                komut.Parameters.AddWithValue("@weight", textBox9.Text);
                komut.Parameters.AddWithValue("@grades", textBox11.Text);
                if (checkBox4.Checked == true)
                {
                    komut.Parameters.AddWithValue("@under", -1);
                }
                else if (checkBox4.Checked == false)
                {
                    komut.Parameters.AddWithValue("@under", 0);
                }

                if (checkBox5.Checked == true)
                {
                    komut.Parameters.AddWithValue("@right", -1);
                }
                else if (checkBox5.Checked == false)
                {
                    komut.Parameters.AddWithValue("@right", 0);
                }

                if (checkBox6.Checked == true)
                {
                    komut.Parameters.AddWithValue("@over", -1);
                }
                else if (checkBox6.Checked == false)
                {
                    komut.Parameters.AddWithValue("@over", 0);
                }
                komut.Parameters.AddWithValue("@comment", textBoxYorum2.Text);
                if (checkBox4.Checked == true)
                {
                    komut.Parameters.AddWithValue("@kötücomment", textBox21.Text);
                }
                else if (checkBox4.Checked == false)
                {
                    komut.Parameters.AddWithValue("@kötücomment", "");
                }
                komut.Parameters.AddWithValue("@iş", "2");
                komut.ExecuteNonQuery();
                string sql1 = "Insert into PersonelPerformansVerileri([Kimlik No],[Weights],[İş No]) values(@kimlikno,@weights,@işno)";
                OleDbCommand komut1 = new OleDbCommand(sql1, con);
                komut1.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
                komut1.Parameters.AddWithValue("@weights", textBox9.Text);
                komut1.Parameters.AddWithValue("@işno", "2");
                komut1.ExecuteNonQuery();
                con.Close();
            }
        }
        private void insert3()
        {
            if (textBox4.Text != "")
            {
                con.Open();
                string sql = "Insert into PerformansVerileri([Personel No],[Kimlik No],[Goals],[Weight of the Goals],[Grades],[Underperformed],[Performed],[Overperformed],[Comment],[Kötü Comment],[İş No]) values(@no,@kimlikno,@goals,@weight,@grades,@under,@right,@over,@comment,@kötücomment,@işno)";
                OleDbCommand komut = new OleDbCommand(sql, con);
                komut.Parameters.AddWithValue("@no", textBoxIsim.Text);
                komut.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
                komut.Parameters.AddWithValue("@goals", textBox4.Text);
                komut.Parameters.AddWithValue("@weight", textBox10.Text);
                komut.Parameters.AddWithValue("@grades", textBox14.Text);
                if (checkBox7.Checked == true)
                {
                    komut.Parameters.AddWithValue("@under", -1);
                }
                else if (checkBox7.Checked == false)
                {
                    komut.Parameters.AddWithValue("@under", 0);
                }

                if (checkBox8.Checked == true)
                {
                    komut.Parameters.AddWithValue("@right", -1);
                }
                else if (checkBox8.Checked == false)
                {
                    komut.Parameters.AddWithValue("@right", 0);
                }

                if (checkBox9.Checked == true)
                {
                    komut.Parameters.AddWithValue("@over", -1);
                }
                else if (checkBox9.Checked == false)
                {
                    komut.Parameters.AddWithValue("@over", 0);
                }
                komut.Parameters.AddWithValue("@comment", textBoxYorum3.Text);
                if (checkBox7.Checked == true)
                {
                    komut.Parameters.AddWithValue("@kötücomment", textBox22.Text);
                }
                else if (checkBox7.Checked == false)
                {
                    komut.Parameters.AddWithValue("@kötücomment", "");
                }
                komut.Parameters.AddWithValue("@iş", "3");
                komut.ExecuteNonQuery();
                string sql1 = "Insert into PersonelPerformansVerileri([Kimlik No],[Weights],[İş No]) values(@kimlikno,@weights,@işno)";
                OleDbCommand komut1 = new OleDbCommand(sql1, con);
                komut1.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
                komut1.Parameters.AddWithValue("@weights", textBox10.Text);
                komut1.Parameters.AddWithValue("@işno", "3");
                komut1.ExecuteNonQuery();
                con.Close();
            }
        }
        private void insert4()
        {
            if (textBox6.Text != "")
            {
                con.Open();

                string sql = "Insert into PerformansVerileri([Personel No],[Kimlik No],[Goals],[Weight of the Goals],[Grades],[Underperformed],[Performed],[Overperformed],[Comment],[Kötü Comment],[İş No]) values(@no,@kimlikno,@goals,@weight,@grades,@under,@right,@over,@comment,@kötücomment,@işno)";
                OleDbCommand komut = new OleDbCommand(sql, con);
                komut.Parameters.AddWithValue("@no", textBoxIsim.Text);
                komut.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
                komut.Parameters.AddWithValue("@goals", textBox6.Text);
                komut.Parameters.AddWithValue("@weight", textBox5.Text);
                komut.Parameters.AddWithValue("@grades", textBox15.Text);
                if (checkBox10.Checked == true)
                {
                    komut.Parameters.AddWithValue("@under", -1);
                }
                else if (checkBox10.Checked == false)
                {
                    komut.Parameters.AddWithValue("@under", 0);
                }

                if (checkBox11.Checked == true)
                {
                    komut.Parameters.AddWithValue("@right", -1);
                }
                else if (checkBox11.Checked == false)
                {
                    komut.Parameters.AddWithValue("@right", 0);
                }

                if (checkBox12.Checked == true)
                {
                    komut.Parameters.AddWithValue("@over", -1);
                }
                else if (checkBox12.Checked == false)
                {
                    komut.Parameters.AddWithValue("@over", 0);
                }
                komut.Parameters.AddWithValue("@comment", textBoxYorum4.Text);
                if (checkBox10.Checked == true)
                {
                    komut.Parameters.AddWithValue("@kötücomment", textBox23.Text);
                }
                else if (checkBox10.Checked == false)
                {
                    komut.Parameters.AddWithValue("@kötücomment", "");
                }
                komut.Parameters.AddWithValue("@iş", "4");
                komut.ExecuteNonQuery();
                string sql1 = "Insert into PersonelPerformansVerileri([Kimlik No],[Weights],[İş No]) values(@kimlikno,@weights,@işno)";
                OleDbCommand komut1 = new OleDbCommand(sql1, con);
                komut1.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
                komut1.Parameters.AddWithValue("@weights", textBox5.Text);
                komut1.Parameters.AddWithValue("@işno", "4");
                komut1.ExecuteNonQuery();
                con.Close();
            }
        }
        private void insert5()
        {
            if (textBox13.Text != "")
            {
                con.Open();

                string sql = "Insert into PerformansVerileri([Personel No],[Kimlik No],[Goals],[Weight of the Goals],[Grades],[Underperformed],[Performed],[Overperformed],[Comment],[Kötü Comment],[İş No]) values(@no,@kimlikno,@goals,@weight,@grades,@under,@right,@over,@comment,@kötücomment,@işno)";
                OleDbCommand komut = new OleDbCommand(sql, con);
                komut.Parameters.AddWithValue("@no", textBoxIsim.Text);
                komut.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
                komut.Parameters.AddWithValue("@goals", textBox13.Text);
                komut.Parameters.AddWithValue("@weight", textBox12.Text);
                komut.Parameters.AddWithValue("@grades", textBox18.Text);

                if (checkBox13.Checked == true)
                {
                    komut.Parameters.AddWithValue("@under", -1);
                }
                else if (checkBox13.Checked == false)
                {
                    komut.Parameters.AddWithValue("@under", 0);
                }

                if (checkBox14.Checked == true)
                {
                    komut.Parameters.AddWithValue("@right", -1);
                }
                else if (checkBox14.Checked == false)
                {
                    komut.Parameters.AddWithValue("@right", 0);
                }

                if (checkBox15.Checked == true)
                {
                    komut.Parameters.AddWithValue("@over", -1);
                }
                else if (checkBox15.Checked == false)
                {
                    komut.Parameters.AddWithValue("@over", 0);
                }
                komut.Parameters.AddWithValue("@comment", textBoxYorum5.Text);
                if (checkBox13.Checked == true)
                {
                    komut.Parameters.AddWithValue("@kötücomment", textBox24.Text);
                }
                else if (checkBox13.Checked == false)
                {
                    komut.Parameters.AddWithValue("@kötücomment", "");
                }
                komut.Parameters.AddWithValue("@iş", "5");
                komut.ExecuteNonQuery();
                string sql1 = "Insert into PersonelPerformansVerileri([Kimlik No],[Weights],[İş No]) values(@kimlikno,@weights,@işno)";
                OleDbCommand komut1 = new OleDbCommand(sql1, con);
                komut1.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
                komut1.Parameters.AddWithValue("@weights", textBox12.Text);
                komut1.Parameters.AddWithValue("@işno", "5");
                komut1.ExecuteNonQuery();
                con.Close();
            }
        }
        private void insert6()
        {
            if (textBox17.Text != "")
            {
                con.Open();
                string sql = "Insert into PerformansVerileri([Personel No],[Kimlik No],[Goals],[Weight of the Goals],[Grades],[Underperformed],[Performed],[Overperformed],[Comment],[Kötü Comment],[İş No]) values(@no,@kimlikno,@goals,@weight,@grades,@under,@right,@over,@comment,@kötücomment,@işno)";
                OleDbCommand komut = new OleDbCommand(sql, con);
                komut.Parameters.AddWithValue("@no", textBoxIsim.Text);
                komut.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
                komut.Parameters.AddWithValue("@goals", textBox17.Text);
                komut.Parameters.AddWithValue("@weight", textBox16.Text);
                komut.Parameters.AddWithValue("@grades", textBox19.Text);
                if (checkBox16.Checked == true)
                {
                    komut.Parameters.AddWithValue("@under", -1);
                }
                else if (checkBox16.Checked == false)
                {
                    komut.Parameters.AddWithValue("@under", 0);
                }

                if (checkBox17.Checked == true)
                {
                    komut.Parameters.AddWithValue("@right", -1);
                }
                else if (checkBox17.Checked == false)
                {
                    komut.Parameters.AddWithValue("@right", 0);
                }

                if (checkBox18.Checked == true)
                {
                    komut.Parameters.AddWithValue("@over", -1);
                }
                else if (checkBox18.Checked == false)
                {
                    komut.Parameters.AddWithValue("@over", 0);
                }
                komut.Parameters.AddWithValue("@comment", textBoxYorum6.Text);
                if (checkBox16.Checked == true)
                {
                    komut.Parameters.AddWithValue("@kötücomment", textBox25.Text);
                }
                else if (checkBox16.Checked == false)
                {
                    komut.Parameters.AddWithValue("@kötücomment", "");
                }
                komut.Parameters.AddWithValue("@iş", "6");
                komut.ExecuteNonQuery();
                string sql1 = "Insert into PersonelPerformansVerileri([Kimlik No],[Weights],[İş No]) values(@kimlikno,@weights,@işno)";
                OleDbCommand komut1 = new OleDbCommand(sql1, con);
                komut1.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
                komut1.Parameters.AddWithValue("@weights", textBox16.Text);
                komut1.Parameters.AddWithValue("@işno", "6");
                komut1.ExecuteNonQuery();
                con.Close();
            }
        }
        private void textBoxYorum3_TextChanged(object sender, EventArgs e)
        {
        }
        ////////////////////////////// 3.4.5.6 ağırlıklar sayı doğrulaması
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            int result;
            if (int.TryParse(textBox10.Text, out result))
            {
                w3 = Convert.ToDouble(textBox10.Text);
                if (w3 > 100 || w3 <= 0)
                {
                    MessageBox.Show(" Lütfen bir sayı giriniz. Ağırlıklar '0' ile '100' arasında olmalıdır.");
                }
            }
            else
            {
                MessageBox.Show(" 3. İş Hedefi Ağırlığına yanlış sayı girdiniz. Ağırlıklar '0' ile '100' arasında olmalıdır.");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int result;
            if (int.TryParse(textBox5.Text, out result))
            {
                w4 = Convert.ToDouble(textBox5.Text);
                if (w4 > 100 || w4 <= 0)
                {
                    MessageBox.Show(" Lütfen bir sayı giriniz. Ağırlıklar '0' ile '100' arasında olmalıdır.");
                }
            }
            else
            {
                MessageBox.Show(" 4. İş Hedefi Ağırlığına yanlış sayı girdiniz. Ağırlıklar '0' ile '100' arasında olmalıdır.");
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            int result;
            if (int.TryParse(textBox12.Text, out result))
            {
                w5 = Convert.ToDouble(textBox12.Text);
                if (w5 > 100 || w5 <= 0)
                {
                    MessageBox.Show(" Lütfen bir sayı giriniz. Ağırlıklar '0' ile '100' arasında olmalıdır.");
                }
            }
            else
            {
                MessageBox.Show(" 5. İş Hedefi Ağırlığına yanlış sayı girdiniz. Ağırlıklar '0' ile '100' arasında olmalıdır.");
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            int result;
            if (int.TryParse(textBox16.Text, out result))
            {
                w6 = Convert.ToDouble(textBox16.Text);
                if (w6 > 100 || w6 <= 0)
                {
                    MessageBox.Show(" Lütfen bir sayı giriniz. Ağırlıklar '0' ile '100' arasında olmalıdır.");
                }
            }
            else
            {
                MessageBox.Show(" 6. İş Hedefi Ağırlığına yanlış sayı girdiniz. Ağırlıklar '0' ile '100' arasında olmalıdır.");
            }
        }
        /////////////////////////////Hedefini gerçekleştiremedi checkboxları
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            if (checkBox1.Checked)
            {
                label14.Visible = true;
                textBox20.Visible = true;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
            else
            {
                label14.Visible = false;
                textBox20.Visible = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            if (checkBox4.Checked)
            {
                label15.Visible = true;
                textBox21.Visible = true;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
            }
            else
            {
                label15.Visible = false;
                textBox21.Visible = false;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            if (checkBox7.Checked)
            {
                label16.Visible = true;
                textBox22.Visible = true;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
            }
            else
            {
                label16.Visible = false;
                textBox22.Visible = false;
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            if (checkBox10.Checked)
            {
                label17.Visible = true;
                textBox23.Visible = true;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
            }
            else
            {
                label17.Visible = false;
                textBox23.Visible = false;
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            if (checkBox13.Checked)
            {
                label18.Visible = true;
                textBox24.Visible = true;
                checkBox14.Checked = false;
                checkBox15.Checked = false;
            }
            else
            {
                label18.Visible = false;
                textBox24.Visible = false;
            }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            if (checkBox16.Checked)
            {
                label19.Visible = true;
                textBox25.Visible = true;
                checkBox17.Checked = false;
                checkBox18.Checked = false;
            }
            else
            {
                label19.Visible = false;
                textBox25.Visible = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                checkBox4.Checked = false;
                checkBox6.Checked = false;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                checkBox7.Checked = false;
                checkBox9.Checked = false;
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
            {
                checkBox10.Checked = false;
                checkBox12.Checked = false;
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked)
            {
                checkBox13.Checked = false;
                checkBox15.Checked = false;
            }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked)
            {
                checkBox16.Checked = false;
                checkBox18.Checked = false;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox18_TextChanged_1(object sender, EventArgs e)
        {
            islemler();
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            islemler();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            islemler();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            islemler();
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            islemler();
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            islemler();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Resim Seç(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox1.Image = new Bitmap(open.FileName);
                // image file path  
                label21.Text = open.FileName;
            }
        }
        private void resimInsert()
        {
            con.Open();
            string sql = "Insert into ResimlerTablosu([Kimlik No]) values (@kimlikno)";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
            komut.ExecuteNonQuery();
            con.Close();
        }
        private void resimupdate()
        {
            con.Open();
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] photo_aray = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(photo_aray, 0, photo_aray.Length);

            string sql = "update ResimlerTablosu set [Kimlik No]=@kimlikno,[Resimler]=@resimler,[Resim Yolu]=@resimyolu where [Kimlik No]=@kimlikno";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
            komut.Parameters.AddWithValue("@resimler", photo_aray);
            komut.Parameters.AddWithValue("@resimyolu", label21.Text);
            komut.ExecuteNonQuery();
            con.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (resimkaydetmeekle == true)
            {
                DialogResult result = MessageBox.Show("Resmi eklemeden önce lütfen ekranın altındaki ''Kaydet'' butonuna bastığınıza " +
                    "emin olunuz. Basmadıysanız lütfen bu iletişim kutusunu kapatıp önce ''Kaydet'' butonuna basınız.\n\n''Kaydet'' butonuna " +
                    "basıldığına emin misiniz? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    resimupdate();
                    MessageBox.Show("Resim Kaydedildi.");
                }
            }
            if (resimkaydetmeekle == false)
            {
                DialogResult result = MessageBox.Show("Resmi eklemeden önce lütfen ekranın altındaki ''Değişiklikleri Kaydet'' butonuna bastığınıza " +
                    "emin olunuz. Basmadıysanız lütfen bu iletişim kutusunu kapatıp önce ''Değişiklikleri Kaydet'' butonuna basınız.\n\n''Değişiklikleri Kaydet'' butonuna " +
                    "basıldığına emin misiniz? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    resimupdate();
                    MessageBox.Show("Resim Kaydedildi.");
                }
            }
        }
        private void resimgöster()
        {
            con.Open();
            string sql = "Select * from ResimlerTablosu where [Kimlik No]='" + textBoxID.Text + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                pictureBox1.Image = Image.FromFile(@oku["Resim Yolu"].ToString());
            }
            con.Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (e.KeyChar == '.'))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (e.KeyChar == '.'))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (e.KeyChar == '.'))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (e.KeyChar == '.'))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (e.KeyChar == '.'))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (e.KeyChar == '.'))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (e.KeyChar == '.'))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
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
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (e.KeyChar == '.'))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (e.KeyChar == '.'))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
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
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (e.KeyChar == '.'))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
        private void resimKaydetmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bir resmi o personele ait olarak belirlemek için:\n\n 1) Eğer yeni bir personele resim" +
                " ekliyorsanız, öncelikle 'Resim Seç' butonundan bir resim seçiniz. Resim 'JPEG' türünden olmalıdır. " +
                "Sonra iş hedeflierini ve diğer yerleri doldurunuz. Sonra 'Kaydet' butonuna basınız ve kaydediniz. En SON " +
                "olarak da 'Resim Kaydet' butonuna basınız. Gerekli bilgileri doldurup'Kaydet' butonuna basmadan önce 'Resmi Kaydet' butonuna basmayınız." +
                "\n\n 2) Eğer halihazırdaki bir personele ait olan bir resmi değiştirecekseniz, yine önce bir resim seçip ardından " +
                " istediğiniz değişiklikleri yapıp" +
                " 'Değişiklikleri Kaydet' butonuna basınız. En SON olarak da 'Resmi Kaydet' butonuna basınız. Eğer personeli sadece" +
                " resmini değiştirmek istiyorsanız (kişinin hedeflerinde bir değişiklik yapmayacaksanız), yine de önce 'Değişiklikleri Kaydet' butonuna, sonra da " +
                "'Resmi Kaydet' butonuna basınız.");
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }
        private void personelağırlık1()
        {
            con.Open();
            string sql = "Select * from PersonelPerformansVerileri where [Kimlik No]='" + personelId + "'and [İş No]='" + "1" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                string text = oku["Grades"].ToString();
                label28.Text = oku["Weights"].ToString();
                textBox26.Text = text;
            }
            con.Close();
        }
        private void personelağırlık2()
        {
            con.Open();
            string sql = "Select * from PersonelPerformansVerileri where [Kimlik No]='" + personelId + "'and [İş No]='" + "2" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                string text = oku["Grades"].ToString();
                label29.Text = oku["Weights"].ToString();
                textBox27.Text = text;
            }
            con.Close();
        }
        private void personelağırlık3()
        {
            con.Open();
            string sql = "Select * from PersonelPerformansVerileri where [Kimlik No]='" + personelId + "'and [İş No]='" + "3" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                string text = oku["Grades"].ToString();
                label30.Text = oku["Weights"].ToString();
                textBox28.Text = text;
            }
            con.Close();
        }
        private void personelağırlık4()
        {
            con.Open();
            string sql = "Select * from PersonelPerformansVerileri where [Kimlik No]='" + personelId + "'and [İş No]='" + "4" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                string text = oku["Grades"].ToString();
                label31.Text = oku["Weights"].ToString();
                textBox29.Text = text;
            }
            con.Close();
        }
        private void personelağırlık5()
        {
            con.Open();
            string sql = "Select * from PersonelPerformansVerileri where [Kimlik No]='" + personelId + "'and [İş No]='" + "5" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                string text = oku["Grades"].ToString();
                label32.Text = oku["Weights"].ToString();
                textBox30.Text = text;
            }
            con.Close();
        }
        private void personelağırlık6()
        {
            con.Open();
            string sql = "Select * from PersonelPerformansVerileri where [Kimlik No]='" + personelId + "'and [İş No]='" + "6" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                string text = oku["Grades"].ToString();
                label33.Text = oku["Weights"].ToString();
                textBox31.Text = text;
            }
            con.Close();
        }
        private void islemlerpersonel()
        {
            ///////////////////////////////Weights
            if (label28.Text != "")
            {
                w1personel = Convert.ToDouble(label28.Text);
            }
            if (label28.Text == "")
            {
                w1personel = 0;
            }               
            if (label29.Text != "")
            {
                w2personel = Convert.ToDouble(label29.Text);
            }
            if (label29.Text == "")
            {
                w2personel = 0;
            }
            if (label30.Text != "")
            {
                w3personel = Convert.ToDouble(label30.Text);
            }
            if (label30.Text == "")
            {
                w3personel = 0;
            }
            if (label31.Text != "")
            {
                w4personel = Convert.ToDouble(label31.Text);
            }
            if (label31.Text == "")
            {
                w4personel = 0;
            }
            if (label32.Text != "")
            {
                w5personel = Convert.ToDouble(label32.Text);
            }
            if (label32.Text == "")
            {
                w5personel = 0;
            }
            if (label33.Text != "")
            {
                w6personel = Convert.ToDouble(label33.Text);
            }
            if (label33.Text == "")
            {
                w6personel = 0;
            }
            ///////////////100 e eşit olcak.
            //////////////////////Grades
            if (textBox26.Text != "")
            {
                n1personel = Convert.ToDouble(textBox26.Text);
            }
            if (textBox27.Text != "")
            {
                n2personel = Convert.ToDouble(textBox27.Text);
            }
            if (textBox28.Text != "")
            {
                n3personel = Convert.ToDouble(textBox28.Text);
            }
            if (textBox29.Text != "")
            {
                n4personel = Convert.ToDouble(textBox29.Text);
            }
            if (textBox30.Text != "")
            {
                n5personel = Convert.ToDouble(textBox30.Text);
            }
            if (textBox31.Text != "")
            {
                n6personel = Convert.ToDouble(textBox31.Text);
            }
            //Not
            double toplampersonel = ((w1personel / 100) * n1personel) + ((w2personel / 100) * n2personel) + ((w3personel / 100) * n3personel) + ((w4personel / 100) * n4personel) + ((w5personel / 100) * n5personel) + ((w6personel / 100) * n6personel);
            textBox32.Text = toplampersonel.ToString();
        }
        private void updatePerformansPersonel1()
        {
            con.Open();

            string sql = "update PersonelPerformansVerileri set [Personel No]=@no,[Kimlik No]=@kimlikno,[Grades]=@grades,[İş No]=@işno where [Kimlik No]=@kimlikno and [İş No]=@işno";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.Parameters.AddWithValue("@no", textBoxIsim.Text);
            komut.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
            if (textBox26.Text != "")
            {
                komut.Parameters.AddWithValue("@grades", textBox26.Text);
            }
            komut.Parameters.AddWithValue("@işno", "1");
            komut.ExecuteNonQuery();
            con.Close();
        }
        private void updatePerformansPersonel2()
        {
            con.Open();

            string sql = "update PersonelPerformansVerileri set [Personel No]=@no,[Kimlik No]=@kimlikno,[Grades]=@grades,[İş No]=@işno where [Kimlik No]=@kimlikno and [İş No]=@işno";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.Parameters.AddWithValue("@no", textBoxIsim.Text);
            komut.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
            if (textBox27.Text != "")
            {
                komut.Parameters.AddWithValue("@grades", textBox27.Text);
            }               
            komut.Parameters.AddWithValue("@işno", "2");
            komut.ExecuteNonQuery();
            con.Close();
        }
        private void updatePerformansPersonel3()
        {
            con.Open();

            string sql = "update PersonelPerformansVerileri set [Personel No]=@no,[Kimlik No]=@kimlikno,[Grades]=@grades,[İş No]=@işno where [Kimlik No]=@kimlikno and [İş No]=@işno";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.Parameters.AddWithValue("@no", textBoxIsim.Text);
            komut.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
            if (textBox28.Text != "")
            {
                komut.Parameters.AddWithValue("@grades", textBox28.Text);
            }           
            komut.Parameters.AddWithValue("@işno", "3");
            komut.ExecuteNonQuery();
            con.Close();
        }
        private void updatePerformansPersonel4()
        {
            con.Open();

            string sql = "update PersonelPerformansVerileri set [Personel No]=@no,[Kimlik No]=@kimlikno,[Grades]=@grades,[İş No]=@işno where [Kimlik No]=@kimlikno and [İş No]=@işno";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.Parameters.AddWithValue("@no", textBoxIsim.Text);
            komut.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
            if (textBox29.Text != "")
            {
                komut.Parameters.AddWithValue("@grades", textBox29.Text);
            }            
            komut.Parameters.AddWithValue("@işno", "4");
            komut.ExecuteNonQuery();
            con.Close();
        }
        private void updatePerformansPersonel5()
        {
            con.Open();

            string sql = "update PersonelPerformansVerileri set [Personel No]=@no,[Kimlik No]=@kimlikno,[Grades]=@grades,[İş No]=@işno where [Kimlik No]=@kimlikno and [İş No]=@işno";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.Parameters.AddWithValue("@no", textBoxIsim.Text);
            komut.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
            if(textBox30.Text!="")
            {
                komut.Parameters.AddWithValue("@grades", textBox30.Text);
            }
            komut.Parameters.AddWithValue("@işno", "5");
            komut.ExecuteNonQuery();
            con.Close();
        }
        private void updatePerformansPersonel6()
        {
            con.Open();
            string sql = "update PersonelPerformansVerileri set [Personel No]=@no,[Kimlik No]=@kimlikno,[Grades]=@grades,[İş No]=@işno where [Kimlik No]=@kimlikno and [İş No]=@işno";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.Parameters.AddWithValue("@no", textBoxIsim.Text);
            komut.Parameters.AddWithValue("@kimlikno", textBoxID.Text);
            if (textBox31.Text != "")
            {
                komut.Parameters.AddWithValue("@grades", textBox31.Text);
            }
            komut.Parameters.AddWithValue("@işno", "6");
            komut.ExecuteNonQuery();
            con.Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox26.Text != "")
            {
                double txt26değer = Convert.ToDouble(textBox26.Text);
                if (txt26değer > 10)
                {
                    MessageBox.Show("Notlar 10'dan büyük olamaz. Lütfen kontrol ediniz.");
                    xc = false;
                }
            }
            if (textBox26.Text == "")
            {
            }
            if (textBox27.Text != "")
            {
                double txt27değer = Convert.ToDouble(textBox27.Text);
                if (txt27değer > 10)
                {
                    MessageBox.Show("Notlar 10'dan büyük olamaz. Lütfen kontrol ediniz.");
                    xc = false;
                }
            }
            if (textBox27.Text == "")
            {
            }
            if (textBox28.Text != "")
            {
                double txt28değer = Convert.ToDouble(textBox28.Text);
                if (txt28değer > 10)
                {
                    MessageBox.Show("Notlar 10'dan büyük olamaz. Lütfen kontrol ediniz.");
                    xc = false;
                }
            }
            if (textBox28.Text == "")
            {
            }
            if (textBox29.Text != "")
            {
                double txt29değer = Convert.ToDouble(textBox29.Text);
                if (txt29değer > 10)
                {
                    MessageBox.Show("Notlar 10'dan büyük olamaz. Lütfen kontrol ediniz.");
                    xc = false;
                }
            }
            if (textBox29.Text == "")
            { 
            }
            if (textBox30.Text != "")
            {
                double txt30değer = Convert.ToDouble(textBox30.Text);
                if (txt30değer > 10)
                {
                    MessageBox.Show("Notlar 10'dan büyük olamaz. Lütfen kontrol ediniz.");
                    xc = false;
                }
            }
            if (textBox30.Text == "")
            {
            }
            if (textBox31.Text != "")
            {
                double txt31değer = Convert.ToDouble(textBox31.Text);
                if (txt31değer > 10)
                {
                    MessageBox.Show("Notlar 10'dan büyük olamaz. Lütfen kontrol ediniz.");
                    xc = false;
                }
            }
            if (textBox31.Text == "")
            {
            }
            if (xc == true)
            {
                updatePerformansPersonel1();
                if (label29.Text != "")
                {
                    updatePerformansPersonel2();
                }
                if (label30.Text != "")
                {
                    updatePerformansPersonel3();
                }
                if (label31.Text != "")
                {
                    updatePerformansPersonel4();
                }
                if (label32.Text != "")
                {
                    updatePerformansPersonel5();
                }
                if (label33.Text != "")
                {
                    updatePerformansPersonel6();
                }
                MessageBox.Show("Değişiklikler kaydedildi.");
            }           
        }
        private void textBox32_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            islemlerpersonel();
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            islemlerpersonel();
        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            islemlerpersonel();
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            islemlerpersonel();
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            islemlerpersonel();
        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            islemlerpersonel();
        }

        private void textBox26_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (e.KeyChar == '.'))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox27_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (e.KeyChar == '.'))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox28_KeyPress(object sender, KeyPressEventArgs e)
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
    }       
}
