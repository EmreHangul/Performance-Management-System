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
    public partial class FormEgitimİhtiyacı : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\Access Databases\\Proje.mdb");
        public string isim = "";

        public FormEgitimİhtiyacı()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormPerformansNot form = new FormPerformansNot();
            form.personelIsim = isim;
            form.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            updateİhtiyaç();
        }

        private void FormEgitimİhtiyacı_Load(object sender, EventArgs e)
        {
            con.Open();

            string sql = "select * from ProjeDatası where [Personel No]= '"+isim+"'";
            OleDbCommand komut = new OleDbCommand(sql, con);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                richTextBox1.Text = oku["Eğitim İhtiyacı"].ToString();
            }
            con.Close();
        }

        private void updateİhtiyaç()
        {
            DialogResult result = MessageBox.Show("Kaydetmek İstediğinize Emin Misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                con.Open();

                string sql = "update ProjeDatası set [Personel No]=@no,[Eğitim İhtiyacı]=@ihtiyac where [Personel No]=@no";
                OleDbCommand komut = new OleDbCommand(sql, con);
                komut.Parameters.AddWithValue("@no", isim);
                komut.Parameters.AddWithValue("@ihtiyac", richTextBox1.Text);
                komut.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Kaydedildi.");
            }
        }
    }
}

