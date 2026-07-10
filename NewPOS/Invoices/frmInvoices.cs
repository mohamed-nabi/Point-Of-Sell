using NewPOS.Sell;
using NewPOSBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace NewPOS.Invoices
{
    public partial class frmInvoices : Form
    {
        public frmInvoices()
        {
            InitializeComponent();
        }

        DataTable _dtInvoices = new DataTable();
        clsInvoiceBL InvoiceBL = new clsInvoiceBL();

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            frmSell frm = new frmSell();
            frm.ShowDialog();   
        }

        private void frmInvoices_Load(object sender, EventArgs e)
        {
            _dtInvoices = InvoiceBL.GetAllInvoices();
            dgvInvoicesList.DataSource = _dtInvoices;
        }

        private void tsmShowItems_Click(object sender, EventArgs e)
        {
            if (dgvInvoicesList.CurrentRow == null)
                return;

            DataGridViewRow row = dgvInvoicesList.CurrentRow;

            int InvoiceID = Convert.ToInt32(row.Cells["InvoiceID"].Value);


            frmInvoiceItemsList frm = new frmInvoiceItemsList(InvoiceID);
            frm.ShowDialog();   
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvInvoicesList.CurrentRow == null)
                return;

            DataGridViewRow row = dgvInvoicesList.CurrentRow;

            int InvoiceID = Convert.ToInt32(row.Cells["InvoiceID"].Value);

            clsUtil Util = new clsUtil();


            Util.PrintPdfFile(Util.GeneratePDFInvoice(InvoiceID));


        }
    }
}
 