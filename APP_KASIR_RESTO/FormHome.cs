using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_KASIR_RESTO
{
    public partial class FormHome : Form
    {
        private Form activeChildForm = null;
        private string roleUser;

        public FormHome(string roleUser)
        {
            InitializeComponent();
            this.roleUser = roleUser;

            // Jika bukan Admin
            if (!roleUser.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                // maka hapus/jangan tampilkan node "Pengelolaan Data"
                treeView1.Nodes.RemoveByKey("Node0");
            }
        }

        private void OpenChildForm(Form childForm)
        {
            // Untuk menutup form yg sudah tidak aktif (sehingga hanya ada 1 form aktif)
            if (activeChildForm != null)
                activeChildForm.Close();

            activeChildForm = childForm;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text.Equals("Data Menu"))
            {
                OpenChildForm(new FormDataMenu());
            }

            if (e.Node.Text.Equals("Data User"))
            {
                OpenChildForm(new FormDataUser());
            }

            if (e.Node.Text.Equals("Kalkulator Kasir"))
            {
                OpenChildForm(new FormTransaksi());
            }

            if (e.Node.Text.Equals("Laporan Bulanan"))
            {
                OpenChildForm(new FormReportTransaksi());
            }
        }
    }
}
