using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace finalprojek
{
    public partial class riwayatpenyakit : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;

        private DataSet ds = new DataSet();
        private string alamat, query;
        public riwayatpenyakit()
        {
            alamat = "server=localhost; database=db_rekammedis; username=root; password=;";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();
        }

        private void riwayatpenyakit_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            try
            {
                koneksi.Open();
                query = string.Format("SELECT * FROM riwayatt_penyakit ORDER BY nama_pasien ASC");
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[0].HeaderText = "Nama";
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[1].HeaderText = "Golongan Darah";
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[2].HeaderText = "Tekanan Darah";
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[3].HeaderText = "Penyakit Jantung";
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[4].HeaderText = "Diabetes";
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].HeaderText = "Haemopilia";
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].HeaderText = "Hepatitis";
                dataGridView1.Columns[6].Width = 100;
                dataGridView1.Columns[7].HeaderText = "Gastring";
                dataGridView1.Columns[7].Width = 100;
                dataGridView1.Columns[8].HeaderText = "Penyakit lainnya";
                dataGridView1.Columns[8].Width = 100;
                dataGridView1.Columns[9].HeaderText = "Alergi terhadap obat-obatan";
                dataGridView1.Columns[9].Width = 100;
                dataGridView1.Columns[10].HeaderText = "Ada alergi obat";
                dataGridView1.Columns[10].Width = 100;
                dataGridView1.Columns[11].HeaderText = "Alergi terhadap makanan";
                dataGridView1.Columns[11].Width = 100;
                dataGridView1.Columns[12].HeaderText = "Ada alergi makanan";
                dataGridView1.Columns[12].Width = 100;

                TxtNama.Clear();
                CBboxGolDarah.Text = "";
                TxtTekananDarah.Clear();
                CBboxPenyakitJantung.Text = "";
                CBboxDiabetes.Text = "";
                CBboxHaemopilia.Text = "";
                CBboxHepatitis.Text = "";
                CBboxGastring.Text = "";
                TxtPenyakitLain.Clear();
                CBboxAlergiObat.Text = "";
                TxtAdaAlergiObat.Clear();
                CBboxAlergiMakanan.Text = "";
                TxtAdaAlergiMakanan.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void TxtNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void CBboxGolDarah_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtTekananDarah_TextChanged(object sender, EventArgs e)
        {

        }

        private void CBboxPenyakitJantung_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CBboxDiabetes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CBboxHepatitis_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtPenyakitLain_TextChanged(object sender, EventArgs e)
        {

        }

        private void CBboxAlergiObat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtAdaAlergiObat_TextChanged(object sender, EventArgs e)
        {

        }

        private void CBboxAlergiMakanan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtAdaAlergiMakanan_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                query = string.Format("INSERT INTO `riwayatt_penyakit`(`nama_pasien`, `gol_darah`, `tekanan_darah`, `penyakit_jantung`, `diabetes`, `haemopilia`, `hepatitis`, `gastring`, `penyakit_lainnya`, `alergi_obat`, `ada_alergi_obat`, `alergi_makanan`, `ada_alergi_makanan`) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')", TxtNama.Text, CBboxGolDarah.Text, TxtTekananDarah.Text, CBboxPenyakitJantung.Text, CBboxDiabetes.Text, CBboxHaemopilia.Text, CBboxHepatitis.Text, CBboxGastring.Text, TxtPenyakitLain.Text, CBboxAlergiObat.Text, TxtAdaAlergiObat.Text, CBboxAlergiMakanan.Text, TxtAdaAlergiMakanan.Text);

                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                int res = perintah.ExecuteNonQuery();

                koneksi.Close();
                if (res == 1)
                {
                    MessageBox.Show("Sukses memasukkan data");
                    riwayatpenyakit_Load(null, null);
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

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi.Open();
                query = string.Format("DELETE FROM riwayatt_penyakit WHERE nama_pasien = '{0}'", TxtNama.Text);
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
             
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                riwayatpenyakit_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnCari_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi.Open();
                query = string.Format("SELECT * FROM riwayatt_penyakit WHERE nama_pasien = '{0}'", TxtNama.Text);
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow kolom in ds.Tables[0].Rows)
                    {
                        TxtNama.Text = kolom["nama_pasien"].ToString();
                        CBboxGolDarah.Text = kolom["gol_darah"].ToString();
                        TxtTekananDarah.Text = kolom["tekanan_darah"].ToString();
                        CBboxPenyakitJantung.Text = kolom["penyakit_jantung"].ToString();
                        CBboxDiabetes.Text = kolom["diabetes"].ToString();
                        CBboxHaemopilia.Text = kolom["haemopilia"].ToString();
                        CBboxHepatitis.Text = kolom["hepatitis"].ToString();
                        CBboxGastring.Text = kolom["gastring"].ToString();
                        TxtPenyakitLain.Text = kolom["penyakit_lainnya"].ToString();
                        CBboxAlergiObat.Text = kolom["alergi_obat"].ToString();
                        TxtAdaAlergiObat.Text = kolom["ada_alergi_obat"].ToString();
                        CBboxAlergiMakanan.Text = kolom["alergi_makanan"].ToString();
                        TxtAdaAlergiMakanan.Text = kolom["ada_alergi_makanan"].ToString();


                        BtnUpdate.Enabled = true;
                        BtnDelete.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                query = string.Format("UPDATE `riwayatt_penyakit` SET `gol_darah`='{0}',`tekanan_darah`='{1}',`penyakit_jantung`='{2}',`diabetes`='{3}',`haemopilia`='{4}',`hepatitis`='{5}',`gastring`='{6}',`penyakit_lainnya`='{7}',`alergi_obat`='{8}',`ada_alergi_obat`='{9}',`alergi_makanan`='{10}',`ada_alergi_makanan`='{11}' WHERE nama_pasien = '{12}'", CBboxGolDarah.Text, TxtTekananDarah.Text, CBboxPenyakitJantung.Text, CBboxDiabetes.Text, CBboxHaemopilia.Text, CBboxHepatitis.Text, CBboxGastring.Text, TxtPenyakitLain.Text, CBboxAlergiObat.Text, TxtAdaAlergiObat.Text, CBboxAlergiMakanan.Text, TxtAdaAlergiMakanan.Text, TxtNama.Text);

                ds.Clear();
                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                adapter.Fill(ds);
                koneksi.Close();

                riwayatpenyakit_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CBboxHaemopilia_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            DataBaru utama = new DataBaru();
            utama.Show();
            this.Hide();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            Odontogram utama = new Odontogram();
            utama.Show();
            this.Hide();
        }
    }
}
