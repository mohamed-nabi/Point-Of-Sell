using NewPOS_DL;
using NewPOS_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NewPOS_DL.clsInvoiceDL;

namespace NewPOSBL
{
    public class clsInvoiceBL
    {
        public clsInvoiceDL _InvoiceDL = new clsInvoiceDL();
        public clsUnitInventoryDL _InvUnitDL = new clsUnitInventoryDL();    

      

        public bool AddInvoice(clsInvoice Invoice)
        {
            return _InvoiceDL.AddInvoice(Invoice);
        }

        public bool UpdateInvoiceTotalPrice(int InvoicID, decimal TotalPrice)
        {
            return _InvoiceDL.UpdateInvoiceTotalPrice(InvoicID, TotalPrice);
        }

        public bool CheckInvoiceExists(int InvoiceID)
        {
            return _InvoiceDL.CheckInvoiceExists(InvoiceID);    
        }

        public List<string> GetInsufficientStockProducts(BindingList<clsBasketItem> Basket)
        {
            List<clsInventoryUnit> list = _InvUnitDL.GetInvUnitsList();
                
            BindingList<clsInventoryUnit> ListInv = new BindingList<clsInventoryUnit>(list);

            List<string> lessQtyProducts = new List<string>();

            lessQtyProducts =
               Basket.Where(bItem =>
               { 
                   var invItem = ListInv.FirstOrDefault(i => i.UnitID == bItem.InvUnitID);

                   return invItem == null || invItem.Quantity < bItem.Quantity;

               }).Select(bItem => bItem.ProductName)
               .ToList();

            return lessQtyProducts;
        }

        private DataTable _ConvertToDataTable(BindingList<clsBasketItem> basket)
        {
            DataTable table = new DataTable();

           
            table.Columns.Add("UnitID", typeof(int));
            table.Columns.Add("InvoiceID", typeof(int));
            table.Columns.Add("Quantity", typeof(short));
            table.Columns.Add("SellUnitPrice", typeof(decimal));

            foreach (var item in basket)
            {
                table.Rows.Add(
                    item.InvUnitID,
                    0,
                    item.Quantity,
                    item.UnitPrice);
            }

            return table;
        }

        public bool SaveInvoice(BindingList<clsBasketItem> BasketList,ref clsInvoice Invoice)
        {
            DataTable dtBasket = _ConvertToDataTable(BasketList);

            if(dtBasket != null)
            {
                if (_InvoiceDL.SaveInvoice(dtBasket, ref Invoice))
                {
                    Invoice.Mode = clsInvoice.enMode.Edit;
                    return true;
                }
            }

            return false;
        }
    }
}
