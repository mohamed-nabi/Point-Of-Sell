using NewPOS_DL;
using NewPOS_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPOSBL
{
    public class clsProductInInvoiceBL
    {
        clsProductInInvoiceDL _ProductInInvoiceDL = new clsProductInInvoiceDL();

        public bool AddProductInInvoice(clsProductInInvoice ProductInInvoice)
        {
            return _ProductInInvoiceDL.AddProductInInvoice(ProductInInvoice);   
        }

    }
}
