namespace APP_KASIR_RESTO
{
    partial class FormReportTransaksi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportTransaksi));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataTableTransaksiDetailBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new APP_KASIR_RESTO.DataSet1();
            this.dataTableTransaksiDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataTableTransaksiDetailTableAdapter = new APP_KASIR_RESTO.DataSet1TableAdapters.DataTableTransaksiDetailTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableTransaksiDetailBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableTransaksiDetailBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dataTableTransaksiDetailBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "APP_KASIR_RESTO.ReportTransaksi.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataTableTransaksiDetailBindingSource1
            // 
            this.dataTableTransaksiDetailBindingSource1.DataMember = "DataTableTransaksiDetail";
            this.dataTableTransaksiDetailBindingSource1.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataTableTransaksiDetailBindingSource
            // 
            this.dataTableTransaksiDetailBindingSource.DataMember = "DataTableTransaksiDetail";
            this.dataTableTransaksiDetailBindingSource.DataSource = this.dataSet1;
            // 
            // dataTableTransaksiDetailTableAdapter
            // 
            this.dataTableTransaksiDetailTableAdapter.ClearBeforeFill = true;
            // 
            // FormReportTransaksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormReportTransaksi";
            this.Text = "FormReportTransaksi";
            this.Load += new System.EventHandler(this.FormReportTransaksi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTableTransaksiDetailBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableTransaksiDetailBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource dataTableTransaksiDetailBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dataTableTransaksiDetailBindingSource1;
        private DataSet1TableAdapters.DataTableTransaksiDetailTableAdapter dataTableTransaksiDetailTableAdapter;
    }
}