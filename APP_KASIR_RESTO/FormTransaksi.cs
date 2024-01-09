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

namespace APP_KASIR_RESTO
{
    public partial class FormTransaksi : Form
    {
        int subTotalHarga, pajak, totalHarga, kembali = 0;

        public FormTransaksi()
        {
            InitializeComponent();
            LoadDaftarMenu();
        }

        public void LoadDaftarMenu()
        {
            try
            {
                Koneksi.buka();
                dataGridView1.Rows.Clear();
                SqlCommand cmd = new SqlCommand();
                SqlDataReader rd;
                cmd.CommandText = $"SELECT * FROM menu WHERE nama LIKE '%{textBox1.Text}%' ORDER BY id";
                cmd.Connection = Koneksi.sqlConn;
                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    int newIndex = dataGridView1.Rows.Add();
                    dataGridView1.Rows[newIndex].Cells[0].Value = rd["id"].ToString();
                    dataGridView1.Rows[newIndex].Cells[1].Value = rd["nama"].ToString();
                    dataGridView1.Rows[newIndex].Cells[2].Value = rd["kategori"].ToString();
                    dataGridView1.Rows[newIndex].Cells[3].Value = rd["harga"].ToString();
                    dataGridView1.Rows[newIndex].Cells[4].Value = rd["ketersediaan"].ToString();
                    dataGridView1.Rows[newIndex].Cells[5].Value = "Add";
                }
                cmd.Dispose();
                rd.Close();
                Koneksi.tutup();
            }
            catch
            {
                MessageBox.Show("Terjadi kesalahan saat menampilkan data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadDaftarMenu();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)  //jika klik Add
            {
                string ketersediaan = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

                // Cek apakah menu tersedia atau tidak
                if (ketersediaan == "Tersedia")
                {
                    FormTransaksiCreate frm = new FormTransaksiCreate();
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.Text = "Tambah Pesanan";
                    frm.id_menu_edit = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    frm.txtNama.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    frm.numHarga.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadDaftarMenu();  //reload data didalam gridView
                    }
                }
                else
                {
                    MessageBox.Show("Menu tidak tersedia.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        
        public void LoadKalkulator(int id, string nama, string harga, string jumlah)
        {
            try
            {
                int newIndex = dataGridViewKalkulator.Rows.Add();
                dataGridViewKalkulator.Rows[newIndex].Cells[0].Value = id.ToString();
                dataGridViewKalkulator.Rows[newIndex].Cells[1].Value = nama.ToString();
                dataGridViewKalkulator.Rows[newIndex].Cells[2].Value = harga.ToString();
                dataGridViewKalkulator.Rows[newIndex].Cells[3].Value = jumlah.ToString();

                // Menghitung subTotal
                subTotalHarga += int.Parse(harga) * int.Parse(jumlah);
                labelSubTotal.Text = "Rp " + subTotalHarga.ToString("N0");
                
                // Menghitung pajak (10% dari subTotal)
                pajak = (subTotalHarga * 10) / 100 ;

                // Menghitung Total
                totalHarga = subTotalHarga + pajak;
                labelTotal.Text = "Rp " + totalHarga.ToString("N0");
            }
            catch
            {
                MessageBox.Show("Terjadi kesalahan saat menampilkan data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numTunai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Validasi input
                if (string.IsNullOrWhiteSpace(numTunai.Text))
                {
                    MessageBox.Show("Input harus diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Mengembalikan format ribu ke nilai asli saat proses perhitungan
                numTunai.ThousandsSeparator = false;

                kembali = int.Parse(numTunai.Text) - totalHarga;
                labelKembali.Text = "Rp " + kembali.ToString("N0");

                // Kembalikan ke format ribu setelah proses perhitungan
                numTunai.ThousandsSeparator = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            subTotalHarga = 0;
            dtpKalkulator.Value = DateTime.Now;
            dataGridViewKalkulator.Rows.Clear();
            labelSubTotal.Text = "-";
            labelTotal.Text = "-";
            numTunai.Value = 0;
            labelKembali.Text = "-";
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            Koneksi.buka();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Koneksi.sqlConn;

            cmd.CommandText = " INSERT INTO transaksi (tanggal_pembayaran, biaya_total) "
                                + " VALUES (@pTanggal, @pTotal) ";
            cmd.Parameters.AddWithValue("pTanggal", dtpKalkulator.Value);
            cmd.Parameters.AddWithValue("pTotal", totalHarga);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Transaksi Berhasil Disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Koneksi.tutup();
            cmd.Dispose();
        }
    }
}
