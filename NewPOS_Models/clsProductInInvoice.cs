using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPOS_Models
{
    public class clsProductInInvoice
    {

        public int ProductInInvoiceID { get; set; }
        public int InvoiceID { get; set; }
        public int UnitID { get; set; }

        public clsProductInInvoice()
        {
            ProductInInvoiceID = -1;
            InvoiceID = -1; 
            UnitID = -1;    
        }

        public clsProductInInvoice(int productInInvoiceID, int invoiceID, int unitID)
        {
            ProductInInvoiceID = productInInvoiceID;
            InvoiceID = invoiceID;
            UnitID = unitID;
        }
    }
}
