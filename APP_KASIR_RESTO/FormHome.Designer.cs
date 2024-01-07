namespace APP_KASIR_RESTO
{
    partial class FormHome
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
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("Data Menu");
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("Data User");
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("Pengelolaan Data", new System.Windows.Forms.TreeNode[] {
            treeNode43,
            treeNode44});
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("Kalkulator Kasir");
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("Transaksi", new System.Windows.Forms.TreeNode[] {
            treeNode46});
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("Laporan Bulanan");
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("Reporting", new System.Windows.Forms.TreeNode[] {
            treeNode48});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ItemHeight = 20;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode43.Name = "Node1";
            treeNode43.Text = "Data Menu";
            treeNode44.Name = "Node3";
            treeNode44.Text = "Data User";
            treeNode45.Name = "Node0";
            treeNode45.Text = "Pengelolaan Data";
            treeNode46.Name = "Node5";
            treeNode46.Text = "Kalkulator Kasir";
            treeNode47.Name = "Node4";
            treeNode47.Text = "Transaksi";
            treeNode48.Name = "Node7";
            treeNode48.Text = "Laporan Bulanan";
            treeNode49.Name = "Node6";
            treeNode49.Text = "Reporting";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode45,
            treeNode47,
            treeNode49});
            this.treeView1.Size = new System.Drawing.Size(176, 450);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 450);
            this.Controls.Add(this.treeView1);
            this.IsMdiContainer = true;
            this.Name = "FormHome";
            this.Text = "FormHome";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
    }
}