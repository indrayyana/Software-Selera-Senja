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
    public partial class FormTransaksiCreate : Form
    {
        public int id_menu_edit = 0;

        public FormTransaksiCreate()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Mengambil data dari FormTransaksiCreate
                string nama = txtNama.Text;
                string harga = txtHarga.Text;
                string jumlah = numJumlah.Text;

                // Membuat objek FormTransaksi
                FormTransaksi frm = Application.OpenForms["FormTransaksi"] as FormTransaksi;

                if (frm != null)
                {
                    // Memanggil metode LoadKalkulator di FormTransaksi
                    frm.LoadKalkulator(id_menu_edit, nama, harga, jumlah);
                }
            }
            catch
            {
                MessageBox.Show("Terjadi kesalahan saat menambahkan data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
