using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace APP_KASIR_RESTO
{
    public partial class FormDataMenuCreate : Form
    {
        public int id_menu_edit = 0;

        public FormDataMenuCreate()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validasi input
            if (string.IsNullOrWhiteSpace(txtNama.Text) ||
                string.IsNullOrWhiteSpace(txtKategori.Text) ||
                string.IsNullOrWhiteSpace(txtHarga.Text) ||
                string.IsNullOrWhiteSpace(comboBoxKetersediaan.Text))
            {
                MessageBox.Show("Semua input harus diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                //koneksi ke database
                Koneksi.buka();

                //buat command SQL
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Koneksi.sqlConn;

                if (id_menu_edit == 0) //user melakukan insert
                {
                    cmd.CommandText = " INSERT INTO menu (nama, kategori, harga, ketersediaan) "
                                    + " VALUES (@pNama, @pKategori, @pHarga, @pKetersediaan) ";
                }
                else if (id_menu_edit > 0) //user melakukan update
                {
                    cmd.CommandText = " UPDATE menu SET "
                                    + " nama = @pNama, kategori = @pKategori, harga = @pHarga, "
                                    + " ketersediaan = @pKetersediaan WHERE id = @pID ";
                    cmd.Parameters.AddWithValue("pID", id_menu_edit);
                }

                cmd.Parameters.AddWithValue("pNama", txtNama.Text);
                cmd.Parameters.AddWithValue("pKategori", txtKategori.Text);
                cmd.Parameters.AddWithValue("pHarga", txtHarga.Text);
                cmd.Parameters.AddWithValue("pKetersediaan", comboBoxKetersediaan.Text);

                //eksekusi command tersebut
                cmd.ExecuteNonQuery();
                Koneksi.tutup();
                cmd.Dispose();
            } catch 
            {
                MessageBox.Show("Terjadi kesalahan saat menyimpan data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
