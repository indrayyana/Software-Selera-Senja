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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace APP_KASIR_RESTO
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private bool isValid()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || 
                string.IsNullOrWhiteSpace(txtPassword.Text) || 
                string.IsNullOrWhiteSpace(comboBoxRole.Text))
            {
                MessageBox.Show("Semua input harus diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                try
                {
                    Koneksi.buka();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Koneksi.sqlConn;

                    cmd.CommandText = "SELECT * FROM users WHERE username = @pUsername AND password = @pPassword AND role = @pRole";
                    cmd.Parameters.AddWithValue("@pUsername", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@pPassword", txtPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@pRole", comboBoxRole.Text);

                    SqlDataReader rd;
                    rd = cmd.ExecuteReader();

                    if (rd.HasRows) // Periksa apakah ada baris yang dikembalikan (login valid)
                    {
                        rd.Close();
                        cmd.Dispose();
                        Koneksi.tutup();

                        // Buka FormHome
                        FormHome formHome = new FormHome(comboBoxRole.Text);
                        formHome.Show();

                        // Sembunyikan formulir login
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username atau password tidak valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Terjadi kesalahan saat login", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
