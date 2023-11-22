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
    public partial class ReportPerawatan : Form
    {
        public ReportPerawatan()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Perawatan utama = new Perawatan();
            utama.Show();
            this.Hide();
        }

        private void BtnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
