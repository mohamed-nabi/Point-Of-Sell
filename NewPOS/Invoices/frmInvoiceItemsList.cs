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
    public partial class frmInvoiceItemsList : Form
    {
        public frmInvoiceItemsList(int InvoiceID)
        {
            InitializeComponent();
            _InvoiceID = InvoiceID;
        }


        clsInvoiceBL _InvoiceBL = new clsInvoiceBL();

        int _InvoiceID = -1;
        DataTable _dt = new DataTable();

        public int InvoiceID {  get { return _InvoiceID; } }    

        private void frmInvoiceItemsList_Load(object sender, EventArgs e)
        {
            if (!(_InvoiceID > 0))
                return;

            _dt = _InvoiceBL.GetInvoiceitemsByInvoiceID(_InvoiceID);
            dgvInvoiceItemsList.DataSource = _dt;


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
