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
    public partial class FormKarşılaştırma : Form
    {
        public FormKarşılaştırma()
        {
            InitializeComponent();
        }
        public string performanssonucu;
        public string topsissonucu;
        public string analizsonucu;

        public double n1 = 0; public double n7 = 0; public double n13 = 0; public double n19 = 0; public double n25 = 0;
        public double n2 = 0; public double n8 = 0; public double n14 = 0; public double n20 = 0; public double n26 = 0;
        public double n3 = 0; public double n9 = 0; public double n15 = 0; public double n21 = 0; public double n27 = 0;
        public double n4 = 0; public double n10 = 0; public double n16 = 0; public double n22 = 0; public double n28 = 0;
        public double n5 = 0; public double n11 = 0; public double n17 = 0; public double n23 = 0; public double n29 = 0;
        public double n6 = 0; public double n12 = 0; public double n18 = 0; public double n24 = 0; public double n30 = 0;

        public double n31 = 0;
        public double n32 = 0;
        public double n33 = 0;
        public double n34 = 0;
        public double n35 = 0;
        public double n36 = 0;

        public double w1 = 0; public double w7 = 0; public double w13 = 0; public double w19 = 0; public double w25 = 0;
        public double w2 = 0; public double w8 = 0; public double w14 = 0; public double w20 = 0; public double w26 = 0;
        public double w3 = 0; public double w9 = 0; public double w15 = 0; public double w21 = 0; public double w27 = 0;
        public double w4 = 0; public double w10 = 0; public double w16 = 0; public double w22 = 0; public double w28 = 0;
        public double w5 = 0; public double w11 = 0; public double w17 = 0; public double w23 = 0; public double w29 = 0;
        public double w6 = 0; public double w12 = 0; public double w18 = 0; public double w24 = 0; public double w30 = 0;

        public double w31 = 0;
        public double w32 = 0;
        public double w33 = 0;
        public double w34 = 0;
        public double w35 = 0;
        public double w36 = 0;

        public double c;
        public double d;
        public double g;
        public double topsis1 = 0;
        public double topsis2 = 0;
        public double topsis3 = 0;
        public double topsis4 = 0;
        public double topsis5 = 0;
        public double topsis6 = 0;

        public double performanssonucu1 = 0;
        public double performanssonucu2 = 0;
        public double performanssonucu3 = 0;
        public double performanssonucu4 = 0;
        public double performanssonucu5 = 0;
        public double performanssonucu6 = 0;

        public double analizsonucu1 = 0;
        public double analizsonucu2 = 0;
        public double analizsonucu3 = 0;
        public double analizsonucu4 = 0;
        public double analizsonucu5 = 0;
        public double analizsonucu6 = 0;

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\user\\Desktop\\Lookup\\bin\\Debug\\Database\\Proje.mdb");
        private void FormKarşılaştırma_Load(object sender, EventArgs e)
        {
            veriGösterListView();
        }
        private void veriGösterListView()
        {
            listView1.Items.Clear();
            con.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = con;
            komut.CommandText = "Select * from PerformansSonuçları";

            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem list = new ListViewItem();
                list.Text = oku["Personel No"].ToString();
                list.SubItems.Add(oku["Kimlik No"].ToString());
                list.SubItems.Add(oku["Performans Sonucu"].ToString());
                list.SubItems.Add(oku["TOPSIS Sonucu"].ToString());
                list.SubItems.Add(oku["Analiz Sonucu"].ToString());
                listView1.Items.Add(list);
            }
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string sql = "Select * from PerformansSonuçları where [Personel No] like '%" + textBox1.Text + "%'";
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
                list.SubItems.Add(oku["Performans Sonucu"].ToString());
                list.SubItems.Add(oku["TOPSIS Sonucu"].ToString());
                list.SubItems.Add(oku["Analiz Sonucu"].ToString());
                listView1.Items.Add(list);
            }
            con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string sql = "Select * from PerformansSonuçları where [Personel No] like '%" + textBox2.Text + "%'";
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
                list.SubItems.Add(oku["Performans Sonucu"].ToString());
                list.SubItems.Add(oku["TOPSIS Sonucu"].ToString());
                list.SubItems.Add(oku["Analiz Sonucu"].ToString());
                listView1.Items.Add(list);
            }
            con.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string sql = "Select * from PerformansSonuçları where [Personel No] like '%" + textBox3.Text + "%'";
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
                list.SubItems.Add(oku["Performans Sonucu"].ToString());
                list.SubItems.Add(oku["TOPSIS Sonucu"].ToString());
                list.SubItems.Add(oku["Analiz Sonucu"].ToString());
                listView1.Items.Add(list);
            }
            con.Close();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string sql = "Select * from PerformansSonuçları where [Personel No] like '%" + textBox7.Text + "%'";
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
                list.SubItems.Add(oku["Performans Sonucu"].ToString());
                list.SubItems.Add(oku["TOPSIS Sonucu"].ToString());
                list.SubItems.Add(oku["Analiz Sonucu"].ToString());
                listView1.Items.Add(list);
            }
            con.Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string sql = "Select * from PerformansSonuçları where [Personel No] like '%" + textBox8.Text + "%'";
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
                list.SubItems.Add(oku["Performans Sonucu"].ToString());
                list.SubItems.Add(oku["TOPSIS Sonucu"].ToString());
                list.SubItems.Add(oku["Analiz Sonucu"].ToString());
                listView1.Items.Add(list);
            }
            con.Close();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string sql = "Select * from PerformansSonuçları where [Personel No] like '%" + textBox9.Text + "%'";
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
                list.SubItems.Add(oku["Performans Sonucu"].ToString());
                list.SubItems.Add(oku["TOPSIS Sonucu"].ToString());
                list.SubItems.Add(oku["Analiz Sonucu"].ToString());
                listView1.Items.Add(list);
            }
            con.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string sql = "Select * from PerformansSonuçları where [Kimlik No] like '%" + textBox4.Text + "%'";
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
                list.SubItems.Add(oku["Performans Sonucu"].ToString());
                list.SubItems.Add(oku["TOPSIS Sonucu"].ToString());
                list.SubItems.Add(oku["Analiz Sonucu"].ToString());
                listView1.Items.Add(list);
            }
            con.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string sql = "Select * from PerformansSonuçları where [Kimlik No] like '%" + textBox5.Text + "%'";
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
                list.SubItems.Add(oku["Performans Sonucu"].ToString());
                list.SubItems.Add(oku["TOPSIS Sonucu"].ToString());
                list.SubItems.Add(oku["Analiz Sonucu"].ToString());
                listView1.Items.Add(list);
            }
            con.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string sql = "Select * from PerformansSonuçları where [Kimlik No] like '%" + textBox6.Text + "%'";
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
                list.SubItems.Add(oku["Performans Sonucu"].ToString());
                list.SubItems.Add(oku["TOPSIS Sonucu"].ToString());
                list.SubItems.Add(oku["Analiz Sonucu"].ToString());
                listView1.Items.Add(list);
            }
            con.Close();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string sql = "Select * from PerformansSonuçları where [Kimlik No] like '%" + textBox10.Text + "%'";
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
                list.SubItems.Add(oku["Performans Sonucu"].ToString());
                list.SubItems.Add(oku["TOPSIS Sonucu"].ToString());
                list.SubItems.Add(oku["Analiz Sonucu"].ToString());
                listView1.Items.Add(list);
            }
            con.Close();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string sql = "Select * from PerformansSonuçları where [Kimlik No] like '%" + textBox11.Text + "%'";
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
                list.SubItems.Add(oku["Performans Sonucu"].ToString());
                list.SubItems.Add(oku["TOPSIS Sonucu"].ToString());
                list.SubItems.Add(oku["Analiz Sonucu"].ToString());
                listView1.Items.Add(list);
            }
            con.Close();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string sql = "Select * from PerformansSonuçları where [Kimlik No] like '%" + textBox12.Text + "%'";
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
                list.SubItems.Add(oku["Performans Sonucu"].ToString());
                list.SubItems.Add(oku["TOPSIS Sonucu"].ToString());
                list.SubItems.Add(oku["Analiz Sonucu"].ToString());
                listView1.Items.Add(list);
            }
            con.Close();
        }
        public void topsisBul()
        {
            listView1.Items.Clear();
            string sql = "";
            if (con != null && con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (textBox1.Text != "")
            {
                sql = "Select * from PerformansSonuçları where [Personel No]='" + textBox1.Text + "'";
            }
            else if (textBox4.Text != "")
            {
                sql = "Select * from PerformansSonuçları where [Kimlik No]='" + textBox4.Text + "'";
            }

            if (sql != "")
            {
                OleDbCommand komut = new OleDbCommand(sql, con);
                komut.ExecuteNonQuery();
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem list = new ListViewItem();
                    list.Text = oku["Personel No"].ToString();
                    list.SubItems.Add(oku["Kimlik No"].ToString());
                    list.SubItems.Add(oku["Performans Sonucu"].ToString());
                    list.SubItems.Add(oku["TOPSIS Sonucu"].ToString());
                    list.SubItems.Add(oku["Analiz Sonucu"].ToString());
                    listView1.Items.Add(list);
                    topsis1 = Convert.ToDouble(oku["TOPSIS Sonucu"].ToString());
                    performanssonucu1 = Convert.ToDouble(oku["Performans Sonucu"].ToString());
                    analizsonucu1 = Convert.ToDouble(oku["Analiz Sonucu"].ToString());
                }
            }
            con.Close();
            sql = "";

            con.Open();
            if (textBox2.Text != "")
            {
                sql = "Select * from PerformansSonuçları where [Personel No]='" + textBox2.Text + "'";
            }
            else if (textBox5.Text != "")
            {
                sql = "Select * from PerformansSonuçları where [Kimlik No]='" + textBox5.Text + "'";
            }

            if (sql != "")
            {
                OleDbCommand komut = new OleDbCommand(sql, con);
                komut.ExecuteNonQuery();
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem list = new ListViewItem();
                    list.Text = oku["Personel No"].ToString();
                    list.SubItems.Add(oku["Kimlik No"].ToString());
                    list.SubItems.Add(oku["Performans Sonucu"].ToString());
                    list.SubItems.Add(oku["TOPSIS Sonucu"].ToString());
                    list.SubItems.Add(oku["Analiz Sonucu"].ToString());
                    listView1.Items.Add(list);
                    topsis2 = Convert.ToDouble(oku["TOPSIS Sonucu"].ToString());
                    performanssonucu2 = Convert.ToDouble(oku["Performans Sonucu"].ToString());
                    analizsonucu2 = Convert.ToDouble(oku["Analiz Sonucu"].ToString());
                }
            }
            con.Close();
            sql = "";

            con.Open();
            if (textBox3.Text != "")
            {
                sql = "Select * from PerformansSonuçları where [Personel No]='" + textBox3.Text + "'";
            }
            else if (textBox6.Text != "")
            {
                sql = "Select * from PerformansSonuçları where [Kimlik No]='" + textBox6.Text + "'";
            }

            if (sql != "")
            {
                OleDbCommand komut = new OleDbCommand(sql, con);
                komut.ExecuteNonQuery();
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem list = new ListViewItem();
                    list.Text = oku["Personel No"].ToString();
                    list.SubItems.Add(oku["Kimlik No"].ToString());
                    list.SubItems.Add(oku["Performans Sonucu"].ToString());
                    list.SubItems.Add(oku["TOPSIS Sonucu"].ToString());
                    list.SubItems.Add(oku["Analiz Sonucu"].ToString());
                    listView1.Items.Add(list);
                    topsis3 = Convert.ToDouble(oku["TOPSIS Sonucu"].ToString());
                    performanssonucu3 = Convert.ToDouble(oku["Performans Sonucu"].ToString());
                    analizsonucu3 = Convert.ToDouble(oku["Analiz Sonucu"].ToString());
                }
            }
            con.Close();
            sql = "";

            con.Open();
            if (textBox7.Text != "")
            {
                sql = "Select * from PerformansSonuçları where [Personel No]='" + textBox7.Text + "'";
            }
            else if (textBox10.Text != "")
            {
                sql = "Select * from PerformansSonuçları where [Kimlik No]='" + textBox10.Text + "'";
            }

            if (sql != "")
            {
                OleDbCommand komut = new OleDbCommand(sql, con);
                komut.ExecuteNonQuery();
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem list = new ListViewItem();
                    list.Text = oku["Personel No"].ToString();
                    list.SubItems.Add(oku["Kimlik No"].ToString());
                    list.SubItems.Add(oku["Performans Sonucu"].ToString());
                    list.SubItems.Add(oku["TOPSIS Sonucu"].ToString());
                    list.SubItems.Add(oku["Analiz Sonucu"].ToString());
                    listView1.Items.Add(list);
                    topsis4 = Convert.ToDouble(oku["TOPSIS Sonucu"].ToString());
                    performanssonucu4 = Convert.ToDouble(oku["Performans Sonucu"].ToString());
                    analizsonucu4 = Convert.ToDouble(oku["Analiz Sonucu"].ToString());
                }
            }
            con.Close();
            sql = "";

            con.Open();
            if (textBox8.Text != "")
            {
                sql = "Select * from PerformansSonuçları where [Personel No]='" + textBox8.Text + "'";
            }
            else if (textBox11.Text != "")
            {
                sql = "Select * from PerformansSonuçları where [Kimlik No]='" + textBox11.Text + "'";
            }

            if (sql != "")
            {
                OleDbCommand komut = new OleDbCommand(sql, con);
                komut.ExecuteNonQuery();
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem list = new ListViewItem();
                    list.Text = oku["Personel No"].ToString();
                    list.SubItems.Add(oku["Kimlik No"].ToString());
                    list.SubItems.Add(oku["Performans Sonucu"].ToString());
                    list.SubItems.Add(oku["TOPSIS Sonucu"].ToString());
                    list.SubItems.Add(oku["Analiz Sonucu"].ToString());
                    listView1.Items.Add(list);
                    topsis5 = Convert.ToDouble(oku["TOPSIS Sonucu"].ToString());
                    performanssonucu5 = Convert.ToDouble(oku["Performans Sonucu"].ToString());
                    analizsonucu5 = Convert.ToDouble(oku["Analiz Sonucu"].ToString());
                }
            }
            con.Close();
            sql = "";

            con.Open();
            if (textBox9.Text != "")
            {
                sql = "Select * from PerformansSonuçları where [Personel No]='" + textBox9.Text + "'";
            }
            else if (textBox12.Text != "")
            {
                sql = "Select * from PerformansSonuçları where [Kimlik No]= '" + textBox12.Text + "'";
            }

            if (sql != "")
            {
                OleDbCommand komut = new OleDbCommand(sql, con);
                komut.ExecuteNonQuery();
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem list = new ListViewItem();
                    list.Text = oku["Personel No"].ToString();
                    list.SubItems.Add(oku["Kimlik No"].ToString());
                    list.SubItems.Add(oku["Performans Sonucu"].ToString());
                    list.SubItems.Add(oku["TOPSIS Sonucu"].ToString());
                    list.SubItems.Add(oku["Analiz Sonucu"].ToString());
                    listView1.Items.Add(list);
                    topsis6 = Convert.ToDouble(oku["TOPSIS Sonucu"].ToString());
                    performanssonucu6 = Convert.ToDouble(oku["Performans Sonucu"].ToString());
                    analizsonucu6 = Convert.ToDouble(oku["Analiz Sonucu"].ToString());
                }
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            topsisBul();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((performanssonucu1 != 0) && (performanssonucu2 != 0) && (performanssonucu3 == 0) && (performanssonucu4 == 0) && (performanssonucu5 == 0) && (performanssonucu6 == 0))
            {
                c = Math.Max(performanssonucu1, performanssonucu2);
                if (c == performanssonucu1)
                {
                    MessageBox.Show("Performans Sonucuna Göre daha iyi olan personel " + textBox1.Text + " dir.");
                }
                if (c == performanssonucu2)
                {
                    MessageBox.Show("Performans Sonucuna Göre daha iyi olan personel " + textBox2.Text + " dir.");
                }
            }
            if ((performanssonucu1 != 0) && (performanssonucu2 != 0) && (performanssonucu3 != 0) && (performanssonucu4 == 0) && (performanssonucu5 == 0) && (performanssonucu6 == 0))
            {
                c = Math.Max(performanssonucu1, Math.Max(performanssonucu2, performanssonucu3));
                if (c == performanssonucu1)
                {
                    MessageBox.Show("Performans Sonucuna Göre daha iyi olan personel " + textBox1.Text + " dir.");
                }
                if (c == performanssonucu2)
                {
                    MessageBox.Show("Performans Sonucuna Göre daha iyi olan personel " + textBox2.Text + " dir.");
                }
                if (c == performanssonucu3)
                {
                    MessageBox.Show("Performans Sonucuna Göre daha iyi olan personel " + textBox3.Text + " dir.");
                }
            }
            if ((performanssonucu1 != 0) && (performanssonucu2 != 0) && (performanssonucu3 != 0) && (performanssonucu4 != 0) && (performanssonucu5 == 0) && (performanssonucu6 == 0))
            {
                c = Math.Max(performanssonucu1, Math.Max(performanssonucu2, Math.Max(performanssonucu3, performanssonucu4)));
                if (c == performanssonucu1)
                {
                    MessageBox.Show("Performans Sonucuna Göre daha iyi olan personel " + textBox1.Text + " dir.");
                }
                if (c == performanssonucu2)
                {
                    MessageBox.Show("Performans Sonucuna Göre daha iyi olan personel " + textBox2.Text + " dir.");
                }
                if (c == performanssonucu3)
                {
                    MessageBox.Show("Performans Sonucuna Göre daha iyi olan personel " + textBox3.Text + " dir.");
                }
                if (c == performanssonucu4)
                {
                    MessageBox.Show("Performans Sonucuna Göre daha iyi olan personel " + textBox7.Text + " dir.");
                }
            }
            if ((performanssonucu1 != 0) && (performanssonucu2 != 0) && (performanssonucu3 != 0) && (performanssonucu4 != 0) && (performanssonucu5 != 0) && (performanssonucu6 == 0))
            {
                c = Math.Max(performanssonucu1, Math.Max(performanssonucu2, Math.Max(performanssonucu3, Math.Max(performanssonucu4, performanssonucu5))));
                if (c == performanssonucu1)
                {
                    MessageBox.Show("Performans Sonucuna Göre daha iyi olan personel " + textBox1.Text + " dir.");
                }
                if (c == performanssonucu2)
                {
                    MessageBox.Show("Performans Sonucuna Göre daha iyi olan personel " + textBox2.Text + " dir.");
                }
                if (c == performanssonucu3)
                {
                    MessageBox.Show("Performans Sonucuna Göre daha iyi olan personel " + textBox3.Text + " dir.");
                }
                if (c == performanssonucu4)
                {
                    MessageBox.Show("Performans Sonucuna Göre daha iyi olan personel " + textBox7.Text + " dir.");
                }
                if (c == performanssonucu5)
                {
                    MessageBox.Show("Performans Sonucuna Göre daha iyi olan personel " + textBox8.Text + " dir.");
                }
            }
            if ((performanssonucu1 != 0) && (performanssonucu2 != 0) && (performanssonucu3 != 0) && (performanssonucu4 != 0) && (performanssonucu5 != 0) && (performanssonucu6 != 0))
            {
                c = Math.Max(performanssonucu1, Math.Max(performanssonucu2, Math.Max(performanssonucu3, Math.Max(performanssonucu4, Math.Max(performanssonucu5, performanssonucu6)))));
                if (c == performanssonucu1)
                {
                    MessageBox.Show("Performans Sonucuna Göre daha iyi olan personel " + textBox1.Text + " dir.");
                }
                if (c == performanssonucu2)
                {
                    MessageBox.Show("Performans Sonucuna Göre daha iyi olan personel " + textBox2.Text + " dir.");
                }
                if (c == performanssonucu3)
                {
                    MessageBox.Show("Performans Sonucuna Göre daha iyi olan personel " + textBox3.Text + " dir.");
                }
                if (c == performanssonucu4)
                {
                    MessageBox.Show("Performans Sonucuna Göre daha iyi olan personel " + textBox7.Text + " dir.");
                }
                if (c == performanssonucu5)
                {
                    MessageBox.Show("Performans Sonucuna Göre daha iyi olan personel " + textBox8.Text + " dir.");
                }
                if (c == performanssonucu6)
                {
                    MessageBox.Show("Performans Sonucuna Göre daha iyi olan personel " + textBox9.Text + " dir.");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((topsis1 != 0) && (topsis2 != 0) && (topsis3 == 0) && (topsis4 == 0) && (topsis5 == 0) && (topsis6 == 0))
            {
                d = Math.Max(topsis1, topsis2);
                if (d == topsis1)
                {
                    MessageBox.Show("TOPSIS Sonucuna Göre daha iyi olan personel " + textBox1.Text + " dir.");
                }
                if (d == topsis2)
                {
                    MessageBox.Show("TOPSIS Sonucuna Göre daha iyi olan personel " + textBox2.Text + " dir.");
                }
            }
            if ((topsis1 != 0) && (topsis2 != 0) && (topsis3 != 0) && (topsis4 == 0) && (topsis5 == 0) && (topsis6 == 0))
            {
                d = Math.Max(topsis1, Math.Max(topsis2, topsis3));
                if (d == topsis1)
                {
                    MessageBox.Show("TOPSIS Sonucuna Göre daha iyi olan personel " + textBox1.Text + " dir.");
                }
                if (d == topsis2)
                {
                    MessageBox.Show("TOPSIS Sonucuna Göre daha iyi olan personel " + textBox2.Text + " dir.");
                }
                if (d == topsis3)
                {
                    MessageBox.Show("TOPSIS Sonucuna Göre daha iyi olan personel " + textBox3.Text + " dir.");
                }
            }
            if ((topsis1 != 0) && (topsis2 != 0) && (topsis3 != 0) && (topsis4 != 0) && (topsis5 == 0) && (topsis6 == 0))
            {
                d = Math.Max(topsis1, Math.Max(topsis2, Math.Max(topsis3, topsis4)));
                if (d == topsis1)
                {
                    MessageBox.Show("TOPSIS Sonucuna Göre daha iyi olan personel " + textBox1.Text + " dir.");
                }
                if (d == topsis2)
                {
                    MessageBox.Show("TOPSIS Sonucuna Göre daha iyi olan personel " + textBox2.Text + " dir.");
                }
                if (d == topsis3)
                {
                    MessageBox.Show("TOPSIS Sonucuna Göre daha iyi olan personel " + textBox3.Text + " dir.");
                }
                if (d == topsis4)
                {
                    MessageBox.Show("TOPSIS Sonucuna Göre daha iyi olan personel " + textBox7.Text + " dir.");
                }
            }
            if ((topsis1 != 0) && (topsis2 != 0) && (topsis3 != 0) && (topsis4 != 0) && (topsis5 != 0) && (topsis6 == 0))
            {
                d = Math.Max(topsis1, Math.Max(topsis2, Math.Max(topsis3, Math.Max(topsis4, topsis5))));
                if (d == topsis1)
                {
                    MessageBox.Show("TOPSIS Sonucuna Göre daha iyi olan personel " + textBox1.Text + " dir.");
                }
                if (d == topsis2)
                {
                    MessageBox.Show("TOPSIS Sonucuna Göre daha iyi olan personel " + textBox2.Text + " dir.");
                }
                if (d == topsis3)
                {
                    MessageBox.Show("TOPSIS Sonucuna Göre daha iyi olan personel " + textBox3.Text + " dir.");
                }
                if (d == topsis4)
                {
                    MessageBox.Show("TOPSIS Sonucuna Göre daha iyi olan personel " + textBox7.Text + " dir.");
                }
                if (d == topsis5)
                {
                    MessageBox.Show("TOPSIS Sonucuna Göre daha iyi olan personel " + textBox8.Text + " dir.");
                }
            }
            if ((topsis1 != 0) && (topsis2 != 0) && (topsis3 != 0) && (topsis4 != 0) && (topsis5 != 0) && (topsis6 != 0))
            {
                d = Math.Max(topsis1, Math.Max(topsis2, Math.Max(topsis3, Math.Max(topsis4, Math.Max(topsis5, topsis6)))));
                if (d == topsis1)
                {
                    MessageBox.Show("TOPSIS Sonucuna Göre daha iyi olan personel " + textBox1.Text + " dir.");
                }
                if (d == topsis2)
                {
                    MessageBox.Show("TOPSIS Sonucuna Göre daha iyi olan personel " + textBox2.Text + " dir.");
                }
                if (d == topsis3)
                {
                    MessageBox.Show("TOPSIS Sonucuna Göre daha iyi olan personel " + textBox3.Text + " dir.");
                }
                if (d == topsis4)
                {
                    MessageBox.Show("TOPSIS Sonucuna Göre daha iyi olan personel " + textBox7.Text + " dir.");
                }
                if (d == topsis5)
                {
                    MessageBox.Show("TOPSIS Sonucuna Göre daha iyi olan personel " + textBox8.Text + " dir.");
                }
                if (d == topsis6)
                {
                    MessageBox.Show("TOPSIS Sonucuna Göre daha iyi olan personel " + textBox9.Text + " dir.");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((analizsonucu1 != 0) && (analizsonucu2 != 0) && (analizsonucu3 == 0) && (analizsonucu4 == 0) && (analizsonucu5 == 0) && (analizsonucu6 == 0))
            {
                g = Math.Max(analizsonucu1, analizsonucu2);
                if (g == analizsonucu1)
                {
                    MessageBox.Show("Analiz Sonucuna Göre daha iyi olan personel " + textBox1.Text + " dir.");
                }
                if (g == analizsonucu2)
                {
                    MessageBox.Show("Analiz Sonucuna Göre daha iyi olan personel " + textBox2.Text + " dir.");
                }
            }
            if ((analizsonucu1 != 0) && (analizsonucu2 != 0) && (analizsonucu3 != 0) && (analizsonucu4 == 0) && (analizsonucu5 == 0) && (analizsonucu6 == 0))
            {
                g = Math.Max(analizsonucu1, Math.Max(analizsonucu2, analizsonucu3));
                if (g == analizsonucu1)
                {
                    MessageBox.Show("Analiz Sonucuna Göre daha iyi olan personel " + textBox1.Text + " dir.");
                }
                if (g == analizsonucu2)
                {
                    MessageBox.Show("Analiz Sonucuna Göre daha iyi olan personel " + textBox2.Text + " dir.");
                }
                if (g == analizsonucu3)
                {
                    MessageBox.Show("Analiz Sonucuna Göre daha iyi olan personel " + textBox3.Text + " dir.");
                }
            }
            if ((analizsonucu1 != 0) && (analizsonucu2 != 0) && (analizsonucu3 != 0) && (analizsonucu4 != 0) && (analizsonucu5 == 0) && (analizsonucu6 == 0))
            {
                g = Math.Max(analizsonucu1, Math.Max(analizsonucu2, Math.Max(analizsonucu3, analizsonucu4)));
                if (g == analizsonucu1)
                {
                    MessageBox.Show("Analiz Sonucuna Göre daha iyi olan personel " + textBox1.Text + " dir.");
                }
                if (g == analizsonucu2)
                {
                    MessageBox.Show("Analiz Sonucuna Göre daha iyi olan personel " + textBox2.Text + " dir.");
                }
                if (g == analizsonucu3)
                {
                    MessageBox.Show("Analiz Sonucuna Göre daha iyi olan personel " + textBox3.Text + " dir.");
                }
                if (g == analizsonucu4)
                {
                    MessageBox.Show("Analiz Sonucuna Göre daha iyi olan personel " + textBox7.Text + " dir.");
                }
            }
            if ((analizsonucu1 != 0) && (analizsonucu2 != 0) && (analizsonucu3 != 0) && (analizsonucu4 != 0) && (analizsonucu5 != 0) && (analizsonucu6 == 0))
            {
                g = Math.Max(analizsonucu1, Math.Max(analizsonucu2, Math.Max(analizsonucu3, Math.Max(analizsonucu4, analizsonucu5))));
                if (g == analizsonucu1)
                {
                    MessageBox.Show("Analiz Sonucuna Göre daha iyi olan personel " + textBox1.Text + " dir.");
                }
                if (g == analizsonucu2)
                {
                    MessageBox.Show("Analiz Sonucuna Göre daha iyi olan personel " + textBox2.Text + " dir.");
                }
                if (g == analizsonucu3)
                {
                    MessageBox.Show("Analiz Sonucuna Göre daha iyi olan personel " + textBox3.Text + " dir.");
                }
                if (g == analizsonucu4)
                {
                    MessageBox.Show("Analiz Sonucuna Göre daha iyi olan personel " + textBox7.Text + " dir.");
                }
                if (g == analizsonucu5)
                {
                    MessageBox.Show("Analiz Sonucuna Göre daha iyi olan personel " + textBox8.Text + " dir.");
                }
            }
            if ((analizsonucu1 != 0) && (analizsonucu2 != 0) && (analizsonucu3 != 0) && (analizsonucu4 != 0) && (analizsonucu5 != 0) && (analizsonucu6 != 0))
            {
                g = Math.Max(analizsonucu1, Math.Max(analizsonucu2, Math.Max(analizsonucu3, Math.Max(analizsonucu4, Math.Max(analizsonucu5, analizsonucu6)))));
                if (g == analizsonucu1)
                {
                    MessageBox.Show("Analiz Sonucuna Göre daha iyi olan personel " + textBox1.Text + " dir.");
                }
                if (g == analizsonucu2)
                {
                    MessageBox.Show("Analiz Sonucuna Göre daha iyi olan personel " + textBox2.Text + " dir.");
                }
                if (g == analizsonucu3)
                {
                    MessageBox.Show("Analiz Sonucuna Göre daha iyi olan personel " + textBox3.Text + " dir.");
                }
                if (g == analizsonucu4)
                {
                    MessageBox.Show("Analiz Sonucuna Göre daha iyi olan personel " + textBox7.Text + " dir.");
                }
                if (g == analizsonucu5)
                {
                    MessageBox.Show("Analiz Sonucuna Göre daha iyi olan personel " + textBox8.Text + " dir.");
                }
                if (g == analizsonucu6)
                {
                    MessageBox.Show("Analiz Sonucuna Göre daha iyi olan personel " + textBox9.Text + " dir.");
                }
            }
        }
        private void kullanımKılavuzuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Personeller arası KIYAS yapmak için bu ekranı kullanınız.\n\n Karşılaştırma " +
                "yapmak istediğiniz personeli İsim/Soyisime göre veyahut Güven ID'sine göre aratınız. Eğer Güven ID sine göre aratıcaksanız, arattıktan" +
                "sonra karşınıza gelen personelin ismini lütfen yazınız. Karşılaştırma isimlere göre yapılacaktır.\n\n " +
                "6 personele kadar aratabilirsiniz. Aratmayı tamamladıktan sonra 'Personellerin Bilgilerini Al' " +
                "butonuna tıklayınız. Listede kıyas yapmak istediğiniz personellerin bilgileri gözükecektir. " +
                "\n\n Eğer klasik 1-10 arası performans verilerine göre bir kıyas yapmak isterseniz 'Performans Sonucuna Göre " +
                "Karşılaştır' butonuna tıklayınız.\n\n Eğer İŞ HEDEFLERİNE GÖRE kıyas yapmak isterseniz 'TOPSIS Son " +
                "ucuna Göre Karşılaştır' butonuna tıklayınız.\n\n Eğer YETKİNLİK hedeflerine göre kıyas yapmak " +
                "isterseniz 'Karar Analizi Sonucuna Göre Karşılaştır' butonuna tıklayınız. Karşınıza gelen mesaj " +
                "kutusunda belirlediğiniz performans kriterine göre EN İYİ performans gösteren personelin ismi " +
                "yer alacaktır.");
        }
        /*private void işlemler()
        {
            ağırlıkgöster1(); ağırlıkgöster7(); ağırlıkgöster13(); ağırlıkgöster19(); ağırlıkgöster25(); ağırlıkgöster31();
            ağırlıkgöster2(); ağırlıkgöster8(); ağırlıkgöster14(); ağırlıkgöster20(); ağırlıkgöster26(); ağırlıkgöster32();
            ağırlıkgöster3(); ağırlıkgöster9(); ağırlıkgöster15(); ağırlıkgöster21(); ağırlıkgöster27(); ağırlıkgöster33();
            ağırlıkgöster4(); ağırlıkgöster10(); ağırlıkgöster16(); ağırlıkgöster22(); ağırlıkgöster28(); ağırlıkgöster34();
            ağırlıkgöster5(); ağırlıkgöster11(); ağırlıkgöster17(); ağırlıkgöster23(); ağırlıkgöster29(); ağırlıkgöster35();
            ağırlıkgöster6(); ağırlıkgöster12(); ağırlıkgöster18(); ağırlıkgöster24(); ağırlıkgöster30(); ağırlıkgöster36();
            if ((textBox1.Text == "") && (textBox2.Text == "") && (textBox3.Text == "") && (textBox7.Text == "") && (textBox8.Text == "") && (textBox9.Text == ""))
            {
                MessageBox.Show("Lütfen en az 2 tane personelin bilgisini alınız.");
            }
            if ((textBox1.Text != "") && (textBox2.Text == "") && (textBox3.Text == "") && (textBox7.Text == "") && (textBox8.Text == "") && (textBox9.Text == ""))
            {
                MessageBox.Show("Lütfen en az 2 tane personelin bilgisini alınız.");
            }
            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text == "") && (textBox7.Text == "") && (textBox8.Text == "") && (textBox9.Text == ""))
            {
                if ((w7 != 0) && (w8 != 0) && (w13 == 0) && (w14 == 0) && (w19 == 0) && (w20 == 0) && (w25 == 0) && (w26 == 0) && (w31 == 0) && (w32 == 0))
                {
                    double squarerootswork1 = Math.Sqrt(n1 * n1 + n2 * n2);
                    double squarerootswork2 = Math.Sqrt(n7 * n7 + n8 * n8);

                    double[] vmatrixwork1 = new double[2];
                    double[] vmatrixwork2 = new double[2];
                    vmatrixwork1[0]= ((n1 / squarerootswork1) * w1);
                    vmatrixwork1[1] = ((n2 / squarerootswork1) * w2);
                    vmatrixwork2[0] = ((n7 / squarerootswork2) * w7);
                    vmatrixwork2[1] = ((n8 / squarerootswork2) * w8);

                    double[] apluswork1 = new double[1];
                    apluswork1[0] = vmatrixwork1.Max();
                    double[] apluswork2 = new double[1];
                    apluswork2[0] = vmatrixwork2.Max();

                    double[] aminuswork1 = new double[1];
                    aminuswork1[0] = vmatrixwork1.Min();
                    double[] aminuswork2 = new double[1];
                    aminuswork2[0] = vmatrixwork2.Min();

                }
            }
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
            //labelTOPSIS.Text = TOPSIS[0].ToString();
        }
        private void ağırlıkgöster1()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox1.Text + "'and [İş No]='" + "1" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n1 = Convert.ToDouble(oku["Grades"].ToString());
                w1 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster2()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox2.Text + "'and [İş No]='" + "1" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n2 = Convert.ToDouble(oku["Grades"].ToString());
                w2 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster3()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox3.Text + "'and [İş No]='" + "1" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n3 = Convert.ToDouble(oku["Grades"].ToString());
                w3 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster4()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox7.Text + "'and [İş No]='" + "1" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n4 = Convert.ToDouble(oku["Grades"].ToString());
                w4 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster5()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox8.Text + "'and [İş No]='" + "1" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n5 = Convert.ToDouble(oku["Grades"].ToString());
                w5 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster6()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox9.Text + "'and [İş No]='" + "1" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n6 = Convert.ToDouble(oku["Grades"].ToString());
                w6 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster7()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox1.Text + "'and [İş No]='" + "2" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n7 = Convert.ToDouble(oku["Grades"].ToString());
                w7 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster8()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox2.Text + "'and [İş No]='" + "2" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n8 = Convert.ToDouble(oku["Grades"].ToString());
                w8 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster9()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox3.Text + "'and [İş No]='" + "2" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n9 = Convert.ToDouble(oku["Grades"].ToString());
                w9 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster10()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox7.Text + "'and [İş No]='" + "2" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n10 = Convert.ToDouble(oku["Grades"].ToString());
                w10 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster11()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox8.Text + "'and [İş No]='" + "2" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n11 = Convert.ToDouble(oku["Grades"].ToString());
                w11 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster12()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox9.Text + "'and [İş No]='" + "2" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n12 = Convert.ToDouble(oku["Grades"].ToString());
                w12 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster13()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox1.Text + "'and [İş No]='" + "3" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n13 = Convert.ToDouble(oku["Grades"].ToString());
                w13 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster14()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox2.Text + "'and [İş No]='" + "3" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n14 = Convert.ToDouble(oku["Grades"].ToString());
                w14 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster15()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox3.Text + "'and [İş No]='" + "3" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n15 = Convert.ToDouble(oku["Grades"].ToString());
                w15 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster16()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox7.Text + "'and [İş No]='" + "3" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n16 = Convert.ToDouble(oku["Grades"].ToString());
                w16 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster17()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox8.Text + "'and [İş No]='" + "3" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n17 = Convert.ToDouble(oku["Grades"].ToString());
                w17 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster18()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox9.Text + "'and [İş No]='" + "3" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n18 = Convert.ToDouble(oku["Grades"].ToString());
                w18 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster19()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox1.Text + "'and [İş No]='" + "4" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n19 = Convert.ToDouble(oku["Grades"].ToString());
                w19 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster20()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox2.Text + "'and [İş No]='" + "4" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n20 = Convert.ToDouble(oku["Grades"].ToString());
                w20 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster21()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox3.Text + "'and [İş No]='" + "4" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n21 = Convert.ToDouble(oku["Grades"].ToString());
                w21 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster22()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox7.Text + "'and [İş No]='" + "4" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n22 = Convert.ToDouble(oku["Grades"].ToString());
                w22 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster23()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox8.Text + "'and [İş No]='" + "4" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n23 = Convert.ToDouble(oku["Grades"].ToString());
                w23 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster24()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox9.Text + "'and [İş No]='" + "4" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n24 = Convert.ToDouble(oku["Grades"].ToString());
                w24 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster25()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox1.Text + "'and [İş No]='" + "5" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n25 = Convert.ToDouble(oku["Grades"].ToString());
                w25 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster26()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox2.Text + "'and [İş No]='" + "5" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n26 = Convert.ToDouble(oku["Grades"].ToString());
                w26 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster27()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox3.Text + "'and [İş No]='" + "5" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n27 = Convert.ToDouble(oku["Grades"].ToString());
                w27 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster28()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox7.Text + "'and [İş No]='" + "5" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n28 = Convert.ToDouble(oku["Grades"].ToString());
                w28 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster29()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox8.Text + "'and [İş No]='" + "5" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n29 = Convert.ToDouble(oku["Grades"].ToString());
                w29 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster30()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox9.Text + "'and [İş No]='" + "5" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n30 = Convert.ToDouble(oku["Grades"].ToString());
                w30 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster31()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox1.Text + "'and [İş No]='" + "6" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n31 = Convert.ToDouble(oku["Grades"].ToString());
                w31 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster32()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox2.Text + "'and [İş No]='" + "6" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n32 = Convert.ToDouble(oku["Grades"].ToString());
                w32 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster33()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox3.Text + "'and [İş No]='" + "6" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n33 = Convert.ToDouble(oku["Grades"].ToString());
                w33 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster34()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox7.Text + "'and [İş No]='" + "6" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n34 = Convert.ToDouble(oku["Grades"].ToString());
                w34 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster35()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox8.Text + "'and [İş No]='" + "6" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n35 = Convert.ToDouble(oku["Grades"].ToString());
                w35 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }
        private void ağırlıkgöster36()
        {
            con.Open();
            string sql = "Select * from PerformansVerileri where [Personel No]='" + textBox9.Text + "'and [İş No]='" + "6" + "'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                n36 = Convert.ToDouble(oku["Grades"].ToString());
                w36 = Convert.ToDouble(oku["Weight of the Goals"].ToString());
                con.Close();
            }
        }*/
    }
}
