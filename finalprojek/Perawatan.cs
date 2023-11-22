using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace finalprojek
{
    public partial class Perawatan : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;

        private DataSet ds = new DataSet();
        private string alamat, query;
        public Perawatan()
        {
            alamat = "server=localhost; database=db_rekammedis; username=root; password=;";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();
        }

        private void TxtTanggal_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtKeluhan_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtPerawatan_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtKeterangan_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtParaf_TextChanged(object sender, EventArgs e)
        {

        }

        private void Perawatan_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Odontogram utama = new Odontogram();
            utama.Show();
            this.Hide();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            ReportPerawatan utama = new ReportPerawatan();
            utama.Show();
            this.Hide();
        }

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                query = string.Format("INSERT INTO `perawatan`(`tanggal`, `nama`, `gigi`, `keluhan`, `perawatan`, `keterangan`, `paraf`) VALUES ('{0}','{1}', '{2}','{3}','{4}','{5}','{6}')", TxtTanggal.Text, TxtNama.Text, TxtGigi.Text, TxtKeluhan.Text, TxtPerawatan.Text, TxtKeterangan.Text, TxtParaf.Text);

                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                int res = perintah.ExecuteNonQuery();

                koneksi.Close();
                if (res == 1)
                {
                    MessageBox.Show("Sukses memasukkan data");
                    Perawatan_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Gagal memasukkan data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
