using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPOS_Models
{
    public class clsInvoice
    {

        public enum enMode { Add ,Edit};

        public enMode Mode { get; set; }

        public int InvoiceID { get;set; }
        
        public DateTime CreatedDateTime { get;set; }    

        public decimal TotalPrice { get;set; }

        public clsInvoice()
        {
            InvoiceID = -1;
            CreatedDateTime = DateTime.Now;
            TotalPrice = -1;
            Mode = enMode.Add;
        }

        public clsInvoice(int invoiceID, DateTime createdDateTime, decimal totalPrice)
        {
            InvoiceID = invoiceID;
            CreatedDateTime = createdDateTime;
            TotalPrice = totalPrice;
            Mode = enMode.Edit;
        }
    }
}
