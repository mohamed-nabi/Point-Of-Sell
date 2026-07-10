using NewPOS.Invoices;
using NewPOS_Models;
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
using System.IO;
using QuestPDF.Fluent;


namespace NewPOS
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        } 

        clsInvoiceBL InvoiceBL = new clsInvoiceBL(); 

        private void frmTest_Load(object sender, EventArgs e)
        {

             QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;


            var model = InvoiceBL.GetInvoiceModel(46);
            var document = new clsInvoiceDocument(model);
            document.GeneratePdfAndShow();
        }
    }
}
