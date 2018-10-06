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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\user\\Desktop\\Lookup\\bin\\Debug\\Database\\Proje.mdb");
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click (object sender, EventArgs e)
        {
           
        }
        private void button4_Click (object sender, EventArgs e)
        {
           
        }
        private void buttonPersonel_Click(object sender, EventArgs e)
        {
            FormLogin form = new FormLogin();
            form.yöneticiyadaçalışan = "Çalışan";
            form.Show();
        }
        private void buttonYönetici_Click(object sender, EventArgs e)
        {
            FormLogin form = new FormLogin();
            form.yöneticiyadaçalışan = "Yönetici";
            form.Show();

        }
       
    }
}
