namespace NewPOS.Invoices
{
    partial class frmInvoices
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
            this.dgvInvoicesList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsinvoice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSell = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tsmShowItems = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoicesList)).BeginInit();
            this.cmsinvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInvoicesList
            // 
            this.dgvInvoicesList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInvoicesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoicesList.ContextMenuStrip = this.cmsinvoice;
            this.dgvInvoicesList.EnableHeadersVisualStyles = false;
            this.dgvInvoicesList.Location = new System.Drawing.Point(9, 207);
            this.dgvInvoicesList.Name = "dgvInvoicesList";
            this.dgvInvoicesList.ReadOnly = true;
            this.dgvInvoicesList.Size = new System.Drawing.Size(506, 220);
            this.dgvInvoicesList.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(174, 123);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(181, 32);
            this.label1.TabIndex = 13;
            this.label1.Text = "Invoices List";
            // 
            // cmsinvoice
            // 
            this.cmsinvoice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowItems});
            this.cmsinvoice.Name = "cmsBasket";
            this.cmsinvoice.Size = new System.Drawing.Size(158, 34);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Lime;
            this.btnClose.Image = global::NewPOS.Properties.Resources.delete;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(433, 433);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 32);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSell
            // 
            this.btnSell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSell.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSell.ForeColor = System.Drawing.Color.Black;
            this.btnSell.Image = global::NewPOS.Properties.Resources.add_button_8371340;
            this.btnSell.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSell.Location = new System.Drawing.Point(440, 172);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(75, 29);
            this.btnSell.TabIndex = 15;
            this.btnSell.Text = "Sell";
            this.btnSell.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NewPOS.Properties.Resources.invoice_3366266;
            this.pictureBox1.Location = new System.Drawing.Point(202, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // tsmShowItems
            // 
            this.tsmShowItems.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmShowItems.Image = global::NewPOS.Properties.Resources.invoice_3366266__2_;
            this.tsmShowItems.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmShowItems.Name = "tsmShowItems";
            this.tsmShowItems.Size = new System.Drawing.Size(157, 30);
            this.tsmShowItems.Text = "Show Items";
            this.tsmShowItems.Click += new System.EventHandler(this.tsmShowItems_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Lime;
            this.btnPrint.Image = global::NewPOS.Properties.Resources.printer_684906;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.Location = new System.Drawing.Point(345, 433);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(82, 32);
            this.btnPrint.TabIndex = 19;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 472);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.dgvInvoicesList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmInvoices";
            this.Text = "frmInvoices";
            this.Load += new System.EventHandler(this.frmInvoices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoicesList)).EndInit();
            this.cmsinvoice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvInvoicesList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.ContextMenuStrip cmsinvoice;
        private System.Windows.Forms.ToolStripMenuItem tsmShowItems;
        private System.Windows.Forms.Button btnPrint;
    }
}