namespace NewPOS.Sell
{
    partial class frmSell
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
            this.spMian = new System.Windows.Forms.SplitContainer();
            this.gbInvoice = new System.Windows.Forms.GroupBox();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvBasket = new System.Windows.Forms.DataGridView();
            this.cmsBasket = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ucListFindProduct1 = new NewPOS.User_Controlls.ucListFindProduct();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tsmEditQty = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spMian)).BeginInit();
            this.spMian.Panel1.SuspendLayout();
            this.spMian.Panel2.SuspendLayout();
            this.spMian.SuspendLayout();
            this.gbInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).BeginInit();
            this.cmsBasket.SuspendLayout();
            this.SuspendLayout();
            // 
            // spMian
            // 
            this.spMian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spMian.Location = new System.Drawing.Point(0, 0);
            this.spMian.Name = "spMian";
            // 
            // spMian.Panel1
            // 
            this.spMian.Panel1.Controls.Add(this.btnPrint);
            this.spMian.Panel1.Controls.Add(this.gbInvoice);
            this.spMian.Panel1.Controls.Add(this.btnSave);
            this.spMian.Panel1.Controls.Add(this.label1);
            this.spMian.Panel1.Controls.Add(this.btnDeleteRow);
            this.spMian.Panel1.Controls.Add(this.btnClear);
            this.spMian.Panel1.Controls.Add(this.dgvBasket);
            // 
            // spMian.Panel2
            // 
            this.spMian.Panel2.Controls.Add(this.btnUpdateProduct);
            this.spMian.Panel2.Controls.Add(this.btnAddProduct);
            this.spMian.Panel2.Controls.Add(this.ucListFindProduct1);
            this.spMian.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.spMian.Size = new System.Drawing.Size(800, 450);
            this.spMian.SplitterDistance = 401;
            this.spMian.TabIndex = 0;
            // 
            // gbInvoice
            // 
            this.gbInvoice.Controls.Add(this.lblTotalPrice);
            this.gbInvoice.Controls.Add(this.label2);
            this.gbInvoice.Location = new System.Drawing.Point(10, 312);
            this.gbInvoice.Name = "gbInvoice";
            this.gbInvoice.Size = new System.Drawing.Size(373, 76);
            this.gbInvoice.TabIndex = 12;
            this.gbInvoice.TabStop = false;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.ForeColor = System.Drawing.Color.Black;
            this.lblTotalPrice.Location = new System.Drawing.Point(162, 26);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(97, 32);
            this.lblTotalPrice.TabIndex = 14;
            this.lblTotalPrice.Text = "????$";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(28, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Total Price :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(158, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 29);
            this.label1.TabIndex = 11;
            this.label1.Text = "Basket";
            // 
            // dgvBasket
            // 
            this.dgvBasket.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBasket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBasket.ContextMenuStrip = this.cmsBasket;
            this.dgvBasket.EnableHeadersVisualStyles = false;
            this.dgvBasket.Location = new System.Drawing.Point(3, 50);
            this.dgvBasket.Name = "dgvBasket";
            this.dgvBasket.ReadOnly = true;
            this.dgvBasket.Size = new System.Drawing.Size(395, 232);
            this.dgvBasket.TabIndex = 5;
            this.dgvBasket.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvBasket_RowsAdded);
            // 
            // cmsBasket
            // 
            this.cmsBasket.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmEditQty});
            this.cmsBasket.Name = "cmsBasket";
            this.cmsBasket.Size = new System.Drawing.Size(168, 34);
            // 
            // ucListFindProduct1
            // 
            this.ucListFindProduct1.Location = new System.Drawing.Point(6, 209);
            this.ucListFindProduct1.Name = "ucListFindProduct1";
            this.ucListFindProduct1.Size = new System.Drawing.Size(378, 229);
            this.ucListFindProduct1.TabIndex = 16;
            this.ucListFindProduct1.ProductSelected += new System.EventHandler<NewPOS.User_Controlls.ucListFindProduct.ProductSelectedEventArgs>(this.ucListFindProduct1_ProductSelected);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.White;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Image = global::NewPOS.Properties.Resources.printer_684906;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.Location = new System.Drawing.Point(294, 409);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(89, 29);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = global::NewPOS.Properties.Resources.Save_24;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(202, 409);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 29);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.BackColor = System.Drawing.Color.White;
            this.btnDeleteRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteRow.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteRow.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteRow.Image = global::NewPOS.Properties.Resources.Delete_Row;
            this.btnDeleteRow.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteRow.Location = new System.Drawing.Point(107, 409);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(89, 29);
            this.btnDeleteRow.TabIndex = 9;
            this.btnDeleteRow.Text = "Del Row";
            this.btnDeleteRow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteRow.UseVisualStyleBackColor = false;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Image = global::NewPOS.Properties.Resources.clear_24;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.Location = new System.Drawing.Point(12, 409);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(89, 29);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tsmEditQty
            // 
            this.tsmEditQty.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmEditQty.Image = global::NewPOS.Properties.Resources.Edit_Qty_24;
            this.tsmEditQty.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmEditQty.Name = "tsmEditQty";
            this.tsmEditQty.Size = new System.Drawing.Size(167, 30);
            this.tsmEditQty.Text = "Edit Quantity";
            this.tsmEditQty.Click += new System.EventHandler(this.tsmEditQty_Click);
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateProduct.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateProduct.ForeColor = System.Drawing.Color.Black;
            this.btnUpdateProduct.Image = global::NewPOS.Properties.Resources.pen_16474192;
            this.btnUpdateProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateProduct.Location = new System.Drawing.Point(82, 199);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(82, 25);
            this.btnUpdateProduct.TabIndex = 13;
            this.btnUpdateProduct.Text = "Update";
            this.btnUpdateProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProduct.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProduct.ForeColor = System.Drawing.Color.Black;
            this.btnAddProduct.Image = global::NewPOS.Properties.Resources.add_button_8371340;
            this.btnAddProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddProduct.Location = new System.Drawing.Point(6, 199);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(71, 25);
            this.btnAddProduct.TabIndex = 12;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // frmSell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.spMian);
            this.Name = "frmSell";
            this.Text = "Sell";
            this.Load += new System.EventHandler(this.frmSell_Load);
            this.spMian.Panel1.ResumeLayout(false);
            this.spMian.Panel1.PerformLayout();
            this.spMian.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spMian)).EndInit();
            this.spMian.ResumeLayout(false);
            this.gbInvoice.ResumeLayout(false);
            this.gbInvoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).EndInit();
            this.cmsBasket.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spMian;
        private System.Windows.Forms.DataGridView dgvBasket;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdateProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private User_Controlls.ucListFindProduct ucListFindProduct1;
        private System.Windows.Forms.ContextMenuStrip cmsBasket;
        private System.Windows.Forms.ToolStripMenuItem tsmEditQty;
        private System.Windows.Forms.GroupBox gbInvoice;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrint;
    }
}