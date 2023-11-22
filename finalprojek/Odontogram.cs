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
    public partial class Odontogram : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;

        private DataSet ds = new DataSet();
        private string alamat, query;
        public Odontogram()
        {
            alamat = "server=localhost; database=db_rekammedis; username=root; password=;";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();
        }

        private void Odontogram_Load(object sender, EventArgs e)
        {

        }

        private void sombolOdontogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Simbol_odotogram utama = new Simbol_odotogram();
            utama.Show();
        }

        private void ketentuanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ketentuan_umum_khusus utama = new Ketentuan_umum_khusus();
            utama.Show();
        }

        private void keadaanGigiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            keadaan_gigi utama = new keadaan_gigi();
            utama.Show();
        }

        private void bahanRestorasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bahan_restorasi utama = new bahan_restorasi();
            utama.Show();
        }

        private void protesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            protesa utama = new protesa();
            utama.Show();
        }

        private void permukaanGigiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            permukaan_gigi utama = new permukaan_gigi();
            utama.Show();
        }

        private void restorasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restorasi utama = new restorasi();
            utama.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void TxtTempatTanggalLahir_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                query = string.Format("INSERT INTO `pemeriksaann_odontogram`(`nik`, `nama`, `jenis_kelamin`, `tempat_tanggal_lahir`, `occlusi`, `torus_palatinus`, `torus_mandibularis`, `platum`, `diastema`, `ada_diastema`, `gigi_anomali`, `ada_gigi_anomali`, `lain_lain`, `jumlah_foto`, `jumlah_foto_rontgen`, `gigi_11`, `gigi_12`, `gigi_13`, `gigi_14`, `gigi_15`, `gigi_16`, `gigi_17`, `gigi_18`, `gigi_21`, `gigi_22`, `gigi_23`, `gigi_24`, `gigi_25`, `gigi_26`, `gigi_27`, `gigi_28`, `gigi_31`, `gigi_32`, `gigi_33`, `gigi_34`, `gigi_35`, `gigi_36`, `gigi_37`, `gigi_38`, `gigi_41`, `gigi_42`, `gigi_43`, `gigi_44`, `gigi_45`, `gigi_46`, `gigi_47`, `gigi_48`, `gigi_51`, `gigi_52`, `gigi_53`, `gigi_54`, `gigi_55`, `gigi_61`, `gigi_62`, `gigi_63`, `gigi_64`, `gigi_65`, `gigi_71`, `gigi_72`, `gigi_73`, `gigi_74`, `gigi_75`, `gigi_81`, `gigi_82`, `gigi_83`, `gigi_84`, `gigi_85`) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', '{28}', '{29}', '{30}', '{31}', '{32}', '{33}', '{34}', '{35}', '{36}', '{37}', '{38}', '{39}', '{40}', '{41}', '{42}', '{43}', '{44}', '{45}', '{46}', '{47}', '{48}', '{49}', '{50}', '{51}', '{52}', '{53}', '{54}', '{55}', '{56}', '{57}', '{58}', '{59}', '{60}', '{61}', '{62}', '{63}', '{64}', '{65}', '{66}')", TxtNIK.Text, TxtNama.Text, CbJenisKelamin.Text, TxtTempatTanggalLahir.Text, CBboxOcclusi.Text, CBboxTorusPalatinus.Text, CBboxTorusMandibularis.Text, CBboxPlatum.Text, CBboxDiastema.Text, TxtAdaDiastema.Text, CBboxGigiAnomali.Text, TxtAdaGigiAnomali.Text, TxtLainLain.Text, TxtJumlahFoto.Text, TxtJumlahFotoRontgen.Text, TxtGigi11.Text, TxtGigi12.Text, TxtGigi13.Text, TxtGigi14.Text, TxtGigi15.Text, TxtGigi16.Text, TxtGigi17.Text, TxtGigi18.Text, TxtGigi21.Text, TxtGigi22.Text, TxtGigi23.Text, TxtGigi24.Text, TxtGigi25.Text, TxtGigi26.Text, TxtGigi27.Text, TxtGigi28.Text, TxtGigi31.Text, TxtGigi32.Text, TxtGigi33.Text, TxtGigi34.Text, TxtGigi35.Text, TxtGigi36.Text, TxtGigi37.Text, TxtGigi38.Text, TxtGigi41.Text, TxtGigi42.Text, TxtGigi43.Text, TxtGigi44.Text, TxtGigi45.Text, TxtGigi46.Text, TxtGigi47.Text, TxtGigi48.Text, TxtGigi51.Text, TxtGigi52.Text, TxtGigi53.Text, TxtGigi54.Text, TxtGigi55.Text, TxtGigi61.Text, TxtGigi62.Text, TxtGigi63.Text, TxtGigi64.Text, TxtGigi65.Text, TxtGigi71.Text, TxtGigi72.Text, TxtGigi73.Text, TxtGigi74.Text, TxtGigi75.Text, TxtGigi81.Text, TxtGigi82.Text, TxtGigi83.Text, TxtGigi84.Text, TxtGigi85.Text);

                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                int res = perintah.ExecuteNonQuery();

                koneksi.Close();
                if (res == 1)
                {
                    MessageBox.Show("Sukses memasukkan data");
                    Odontogram_Load(null, null);
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

        private void TxtNIK_TextChanged(object sender, EventArgs e)
        {

        }

        private void CbJenisKelamin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi11_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi12_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi13_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi14_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi15_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi16_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi17_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi18_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi21_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi22_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi23_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi24_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi25_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi26_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi27_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi28_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi31_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi32_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi33_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi34_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi35_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi36_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi37_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi38_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi41_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi42_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi43_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi44_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi45_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi46_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi47_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi48_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi51_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi52_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi53_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi54_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi55_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi61_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi62_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi63_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi64_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi65_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi71_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi72_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi73_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi74_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi75_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi81_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi82_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi83_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi84_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGigi85_TextChanged(object sender, EventArgs e)
        {

        }

        private void CBboxOcclusi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CBboxTorusPalatinus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CBboxTorusMandibularis_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CBboxPlatum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CBboxDiastema_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtAdaDiastema_TextChanged(object sender, EventArgs e)
        {

        }

        private void CBboxGigiAnomali_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtAdaGigiAnomali_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtLainLain_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtJumlahFoto_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            riwayatpenyakit utama = new riwayatpenyakit();
            utama.Show();
            this.Hide();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            Perawatan utama = new Perawatan();
            utama.Show();
            this.Hide();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void daftarSingkatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TxtJumlahFotoRontgen_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
