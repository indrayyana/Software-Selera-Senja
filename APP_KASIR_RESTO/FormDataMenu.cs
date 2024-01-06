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
    public partial class FormDataMenu : Form
    {
        public FormDataMenu()
        {
            InitializeComponent();
            LoadDataMenu();
        }

        public void LoadDataMenu()
        {
            string connString = @"data source=DESKTOP-1KQRPTA\SQLEXPRESS01; initial catalog=KASIR_RESTO; integrated security=true";
            SqlConnection sqlConn = new SqlConnection(connString);
            sqlConn.Open();

            dataGridView1.Rows.Clear();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rd;
            cmd.CommandText = $"SELECT * FROM menu WHERE nama LIKE '%{textBox1.Text}%' ORDER BY id";
            cmd.Connection = sqlConn;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                int newIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[newIndex].Cells[0].Value = rd["id"].ToString();
                dataGridView1.Rows[newIndex].Cells[1].Value = rd["nama"].ToString();
                dataGridView1.Rows[newIndex].Cells[2].Value = rd["kategori"].ToString();
                dataGridView1.Rows[newIndex].Cells[3].Value = rd["harga"].ToString();
                dataGridView1.Rows[newIndex].Cells[4].Value = rd["ketersediaan"].ToString();
                dataGridView1.Rows[newIndex].Cells[5].Value = "Edit";
                dataGridView1.Rows[newIndex].Cells[6].Value = "Delete";
            }
            cmd.Dispose();
            rd.Close();
            sqlConn.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadDataMenu();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDataMenuCreate frm = new FormDataMenuCreate();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Text = "Tambah Data Menu Baru";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadDataMenu();  //reload data didalam gridView
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)  //jika klik EDIT
            {
                FormDataMenuCreate frm = new FormDataMenuCreate();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.Text = "Edit Data Menu";
                frm.id_menu_edit = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                frm.txtNama.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                frm.txtKategori.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                frm.txtHarga.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                frm.comboBoxKetersediaan.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadDataMenu();  //reload data didalam gridView
                }
            }

            if (e.ColumnIndex == 6)  //jika klik DELETE
            {
                if (MessageBox.Show("Apakah yakin menghapus data ini?", "Konfirmasi",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    return;
                }

                string id_menu_dihapus = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                //buat koneksi ke database
                string connString = @"data source=DESKTOP-1KQRPTA\SQLEXPRESS01; initial catalog=KASIR_RESTO; integrated security=true";
                SqlConnection sqlConn = new SqlConnection(connString);
                sqlConn.Open();

                //buat command DELETE
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConn;
                cmd.CommandText = " DELETE FROM menu WHERE id = @pID ";
                cmd.Parameters.AddWithValue("pID", id_menu_dihapus);
                cmd.ExecuteNonQuery(); //eksekusi command  
                sqlConn.Close();
                cmd.Dispose();
                LoadDataMenu();  //reload/refresh data di gridView
            }
        }
    }
}
