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
    public partial class FormReportTransaksi : Form
    {
        public FormReportTransaksi()
        {
            InitializeComponent();
        }

        private void FormReportTransaksi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.DataTableTransaksiDetail' table. You can move, or remove it, as needed.
            this.dataTableTransaksiDetailTableAdapter.Fill(this.dataSet1.DataTableTransaksiDetail);

            this.reportViewer1.RefreshReport();
        }
    }
}
