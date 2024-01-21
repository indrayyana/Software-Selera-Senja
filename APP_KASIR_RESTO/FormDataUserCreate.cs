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
    public partial class FormDataUserCreate : Form
    {
        public int id_user_edit = 0;

        public FormDataUserCreate()
        {
            InitializeComponent();
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            // Validasi input
            if (string.IsNullOrWhiteSpace(txtNamaUser.Text) ||
                string.IsNullOrWhiteSpace(comboBoxRole.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
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

                if (id_user_edit == 0) //user melakukan insert
                {
                    cmd.CommandText = " INSERT INTO users (nama, role, username, password) "
                                    + " VALUES (@pNama, @pRole, @pUsername, @pPassword) ";
                }
                else if (id_user_edit > 0) //user melakukan update
                {
                    cmd.CommandText = " UPDATE users SET "
                                    + " nama = @pNama, role = @pRole, username = @pUsername, "
                                    + " password = @pPassword WHERE id = @pID ";
                    cmd.Parameters.AddWithValue("pID", id_user_edit);
                }

                cmd.Parameters.AddWithValue("pNama", txtNamaUser.Text);
                cmd.Parameters.AddWithValue("pRole", comboBoxRole.Text);
                cmd.Parameters.AddWithValue("pUsername", txtUsername.Text);
                cmd.Parameters.AddWithValue("pPassword", txtPassword.Text);

                //eksekusi command tersebut
                cmd.ExecuteNonQuery();
                Koneksi.tutup();
                cmd.Dispose();
            }
            catch
            {
                MessageBox.Show("Terjadi kesalahan saat menyimpan data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
