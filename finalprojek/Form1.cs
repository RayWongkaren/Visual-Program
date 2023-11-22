using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalprojek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "12345")
            {
                Masuk utama = new Masuk();
                utama.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Salah masukan password");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                textBox1.UseSystemPasswordChar = false;
            }
            else
            {
                textBox1.UseSystemPasswordChar = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.UseSystemPasswordChar = true;
        }

        private void BtnMasuk_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "12345")
            {
                Masuk utama = new Masuk();
                utama.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Salah input password");
            }
        }
    }
}
