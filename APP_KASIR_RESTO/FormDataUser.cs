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
    public partial class FormDataUser : Form
    {
        public FormDataUser()
        {
            InitializeComponent();
            LoadDataUser();
        }

        public void LoadDataUser() {
            try
            {
                Koneksi.buka();
                dataGridViewUser.Rows.Clear();
                SqlCommand cmd = new SqlCommand();
                SqlDataReader rd;
                cmd.CommandText = $"SELECT * FROM users WHERE nama LIKE '%{txtSearchUser.Text}%' ORDER BY id";
                cmd.Connection = Koneksi.sqlConn;
                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    int newIndex = dataGridViewUser.Rows.Add();
                    dataGridViewUser.Rows[newIndex].Cells[0].Value = rd["id"].ToString();
                    dataGridViewUser.Rows[newIndex].Cells[1].Value = rd["nama"].ToString();
                    dataGridViewUser.Rows[newIndex].Cells[2].Value = rd["role"].ToString();
                    dataGridViewUser.Rows[newIndex].Cells[3].Value = rd["username"].ToString();
                    dataGridViewUser.Rows[newIndex].Cells[4].Value = rd["password"].ToString();
                    dataGridViewUser.Rows[newIndex].Cells[5].Value = "Edit";
                    dataGridViewUser.Rows[newIndex].Cells[6].Value = "Delete";
                }
                cmd.Dispose();
                rd.Close();
                Koneksi.tutup();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat menampilkan data" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadDataUser();
            }
        }

        private void buttonTambahUser_Click(object sender, EventArgs e)
        {
            FormDataUserCreate frm = new FormDataUserCreate();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Text = "Tambah Data User Baru";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadDataUser();  //reload data didalam gridView
            }
        }

        private void dataGridViewUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)  //jika klik EDIT
            {
                FormDataUserCreate frm = new FormDataUserCreate();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.Text = "Edit Data User";
                frm.id_user_edit = int.Parse(dataGridViewUser.Rows[e.RowIndex].Cells[0].Value.ToString());
                frm.txtNamaUser.Text = dataGridViewUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                frm.comboBoxRole.Text = dataGridViewUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                frm.txtUsername.Text = dataGridViewUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                frm.txtPassword.Text = dataGridViewUser.Rows[e.RowIndex].Cells[4].Value.ToString();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadDataUser();  //reload data didalam gridView
                }
            }

            if (e.ColumnIndex == 6)  //jika klik DELETE
            {
                if (MessageBox.Show("Apakah yakin menghapus data ini?", "Konfirmasi",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    return;
                }

                try
                {
                    string id_user_dihapus = dataGridViewUser.Rows[e.RowIndex].Cells[0].Value.ToString();
                    //buat koneksi ke database
                    Koneksi.buka();

                    //buat command DELETE
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Koneksi.sqlConn;
                    cmd.CommandText = " DELETE FROM users WHERE id = @pID ";
                    cmd.Parameters.AddWithValue("pID", id_user_dihapus);
                    cmd.ExecuteNonQuery(); //eksekusi command  
                    Koneksi.tutup();
                    cmd.Dispose();
                    LoadDataUser();  //reload/refresh data di gridView
                }
                catch
                {
                    MessageBox.Show("Terjadi kesalahan saat menghapus data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
