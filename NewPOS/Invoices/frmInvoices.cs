using NewPOS.Sell;
using NewPOSBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPOS.Invoices
{
    public partial class frmInvoices : Form
    {
        public frmInvoices()
        {
            InitializeComponent();
        }

        DataTable _dtInvoices = new DataTable();
        clsInvoiceBL _InvoicesBL = new clsInvoiceBL();

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
            _dtInvoices = _InvoicesBL.GetAllInvoices();
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
    }
}
