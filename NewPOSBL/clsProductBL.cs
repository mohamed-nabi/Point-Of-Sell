using NewPOS_DL;
using NewPOS_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPOSBL
{
    public class clsProductBL
    {
        clsProductDL _ProductDL = new clsProductDL();

        private bool _AddProduct(clsProduct Product)
        {
            bool IsComplete = false;

            if( _ProductDL.AddProduct(Product))
            {
                IsComplete = true;
                Product.Mode = clsProduct.enMode.Edit;
            }

            return IsComplete;  
                
        }

        private bool _UpdateProduct(clsProduct Product)
        {
            bool IsComplete = false;


            try
            {
                IsComplete = _ProductDL.UpdateProduct(Product);
                Product.Mode = clsProduct.enMode.Edit;
                return IsComplete;
            }    
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }

           
        }

        public DataTable GetAllProucts()
        {
            return _ProductDL.GetAllProucts();
        }

        public bool AddUpdateProduct(clsProduct product)
        {
            bool IsComplete = false;

            if (product.Mode == clsProduct.enMode.Add)
            {
                IsComplete = _AddProduct(product);
            }

            else if(product.Mode == clsProduct.enMode.Edit)
            {
                try
                {
                    IsComplete = _UpdateProduct(product);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }


            return IsComplete;
        }

        public bool CheckProductExists(int productId)
        {
            try
            {
                return _ProductDL.CheckIfProductExistsUsingFn(productId);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public clsProduct GetPeroductByProductID(int ProductID)
        {
            clsProduct product = new clsProduct();
            string ProductName = "" , Barcode = "";

            if(_ProductDL.GetPeroductByProductID(ProductID ,ref ProductName 
                ,ref Barcode))
            {
                product.ProductID = ProductID;
                product.ProductName = ProductName;
                product.Barcode = Barcode;
                product.Mode = clsProduct.enMode.Edit;

                return product;
            }

            throw (new Exception("Product Not Found"));
        }

    }
}
