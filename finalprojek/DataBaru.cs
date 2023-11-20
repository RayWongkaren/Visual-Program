using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;


namespace finalprojek
{
    public partial class DataBaru : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;

        private DataSet ds = new DataSet();
        private string alamat, query;

        public DataBaru()
        {
            alamat = "server=localhost; database=db_rekammedis; username=root; password=;";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();
        }

        private void DataBaru_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            try
            {
                koneksi.Open();
                query = string.Format("SELECT * FROM data_pasien ORDER BY nama_pasien ASC");
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
                dataGridView1.Columns[1].HeaderText = "Tempat Lahir";
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[2].HeaderText = "NIK";
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[3].HeaderText = "Tanggal Lahir";
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[4].HeaderText = "Jenis Kelamin";
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].HeaderText = "Suku/Ras";
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].HeaderText = "Alamat";
                dataGridView1.Columns[6].Width = 100;
                dataGridView1.Columns[7].HeaderText = "Nomor Hp";
                dataGridView1.Columns[7].Width = 100;
                dataGridView1.Columns[8].HeaderText = "Pekerjaan";
                dataGridView1.Columns[8].Width = 100;
                
                TxtNama.Clear();
                TxtTempatLahir.Clear();
                TxtNIK.Clear();
                TxtTanggalLahir.Clear();
                CbJenisKelamin.Text = "";
                TxtSukuRas.Clear();
                TxtAlamatRumah.Clear();
                TxtNomorHp.Clear();
                TxtPekerjaan.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                query = string.Format("UPDATE `data_pasien` SET `tempatlahir_pasien`='{0}',`nik_pasien`='{1}',`tanggallahir_pasien`='{2}',`jeniskelamin_pasien`='{3}',`sukuras_pasien`='{4}',`alamat_pasien`='{5}',`nomorhp_pasien`='{6}',`pekerjaan_pasien`='{7}' WHERE nama_pasien = '{8}'", TxtTempatLahir.Text, TxtNIK.Text, TxtTanggalLahir.Text, CbJenisKelamin.Text, TxtSukuRas.Text, TxtAlamatRumah.Text, TxtNomorHp.Text, TxtPekerjaan.Text, TxtNama.Text);
                ds.Clear();
                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                adapter.Fill(ds);
                koneksi.Close();

                DataBaru_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void TxtNIK_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtTanggalLahir_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            // Button delete
            try
            {
                koneksi.Open();
                query = string.Format("DELETE FROM data_pasien WHERE nama_pasien = '{0}'", TxtNama.Text);
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

        private void BtnCari_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi.Open();

                query = string.Format("SELECT * FROM data_pasien WHERE nama_pasien = '{0}'", TxtNama.Text);
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
                        TxtTempatLahir.Text = kolom["tempatlahir_pasien"].ToString();
                        TxtNIK.Text = kolom["nik_pasien"].ToString();
                        TxtTanggalLahir.Text = kolom["tanggallahir_pasien"].ToString();
                        CbJenisKelamin.Text = kolom["jeniskelamin_pasien"].ToString();
                        TxtSukuRas.Text = kolom["sukuras_pasien"].ToString();
                        TxtAlamatRumah.Text = kolom["alamat_pasien"].ToString();
                        TxtNomorHp.Text = kolom["nomorhp_pasien"].ToString();
                        TxtPekerjaan.Text = kolom["pekerjaan_pasien"].ToString();


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

        private void BtnClear_Click(object sender, EventArgs e)
        {
            // Button clear
            try
            {
                DataBaru_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                query = string.Format("INSERT INTO `data_pasien`(`nama_pasien`, `tempatlahir_pasien`, `nik_pasien`, `tanggallahir_pasien`, `jeniskelamin_pasien`, `sukuras_pasien`, `alamat_pasien`, `nomorhp_pasien`, `pekerjaan_pasien`) VALUES ('{0}','{1}', '{2}','{3}','{4}','{5}','{6}','{7}','{8}')", TxtNama.Text, TxtTempatLahir.Text, TxtNIK.Text, TxtTanggalLahir.Text, CbJenisKelamin.Text, TxtSukuRas.Text, TxtAlamatRumah.Text, TxtNomorHp.Text, TxtPekerjaan.Text);

                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                int res = perintah.ExecuteNonQuery();

                koneksi.Close();
                if (res == 1)
                {
                    MessageBox.Show("Sukses memasukkan data");
                    DataBaru_Load(null, null);
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

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Masuk utama = new Masuk();
            utama.Show();
            this.Hide();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            riwayatpenyakit utama = new riwayatpenyakit();
            utama.Show();
            this.Hide();
        }
    }
}
