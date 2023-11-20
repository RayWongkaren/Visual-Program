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
    public partial class Masuk : Form
    {
        public Masuk()
        {
            InitializeComponent();
        }

        private void Masuk_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaru utama = new DataBaru();
            utama.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            riwayatpenyakit utama = new riwayatpenyakit();
            utama.Show();
            this.Hide();
        }
    }
}
