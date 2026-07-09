using System;
using System.Collections.Generic;
using System.Linq;


namespace NewPOS_Models
{
    public class clsProduct
    {

        public enum enMode { Add ,Edit};

        public enMode Mode = enMode.Add;

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public  string Barcode { get; set; }    

        public clsProduct()
        {
            ProductID = -1;
            ProductName = "";
            Barcode = "";
        }

        public clsProduct(int productID ,string productName ,string barcode)
        {
            ProductName = productName;
            ProductID = productID;      
            Barcode = barcode;
        }
    }
}
