using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPOS_Models
{
    public class clsInventoryUnit
    {
        public enum enMode { Add ,Edit}
        public enMode Mode { get; set; }

        public int UnitID { get; set; }
        public short Quantity { get; set; }
        public double UnitPrice { get; set; }

        public int ProductID {  get; set; }
        public clsProduct Product { get; set; }





        public clsInventoryUnit()
        {
            UnitID = -1;
            ProductID = -1;
            Product = null;
            Quantity = -1;
            UnitPrice = -1;
            Mode = enMode.Add;
        }

        public clsInventoryUnit(int unitID, int productID, short quantity, double unitPrice)
        {
            UnitID = unitID;
            ProductID = productID;
            Product = new clsProduct();
            Quantity = quantity;
            UnitPrice = unitPrice;
            Mode = enMode.Edit;
        }
    }
}
