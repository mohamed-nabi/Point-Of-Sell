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
    public class clsUnitInventoryBL
    {
        clsUnitInventoryDL _UnitInventoryDL = new clsUnitInventoryDL();
        clsProductBL _ProductBL = new clsProductBL();

        private bool _AddUnitInventory(clsInventoryUnit UnitInventory)
        {
            bool IsComplete = false;

            if (_UnitInventoryDL.AddUnitInventory(UnitInventory))
            {
                IsComplete = true;
                UnitInventory.Mode = clsInventoryUnit.enMode.Edit;
            }

            UnitInventory.Product = 
                _ProductBL.GetPeroductByProductID(UnitInventory.ProductID);

            return IsComplete;
        }

        private bool _UpdateUnitInventory(clsInventoryUnit UnitInventory)
        {
            bool IsComplete = false;


            try
            {
                IsComplete = _UnitInventoryDL.UpdateUnitInventory(UnitInventory);   
                UnitInventory.Mode= clsInventoryUnit.enMode.Edit;
                UnitInventory.Product =
                _ProductBL.GetPeroductByProductID(UnitInventory.ProductID);
                return IsComplete;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public bool AddUpdateUnitInventory(clsInventoryUnit UnitInventory)
        {
            bool IsComplete = false;

            if (UnitInventory.Mode == clsInventoryUnit.enMode.Add)
            {
                IsComplete = _AddUnitInventory(UnitInventory);
            }

            else if (UnitInventory.Mode == clsInventoryUnit.enMode.Edit)
            {
                try
                {
                    IsComplete = _UpdateUnitInventory(UnitInventory);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }


            return IsComplete;
        }

        public DataTable GetInventoryList()
        {
            return _UnitInventoryDL.GetAllInventoryUnits();
        }

        public bool CheckIfUnitInventoryExistsUsingFn(int InventoryUnitId)
        {
            try
            {
                return _UnitInventoryDL.CheckIfUnitInventoryExistsUsingFn(InventoryUnitId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool CheckInvUnitExistsByProductID(int ProductID)
        {
            return _UnitInventoryDL.CheckInvUnitExistsByProductID
                (ProductID);    
        }
        public clsInventoryUnit GetUnitInventoryByUnitInventoryID(int InventoryUnitID)
        {
            clsInventoryUnit UnitInventory = new clsInventoryUnit();
            int ProductID = 0;
            short Quantity = 0;
            double UnitPrice = 0;

            if (_UnitInventoryDL.GetUnitInventoryByUnitInventoryID(InventoryUnitID ,
                ref ProductID ,ref Quantity ,ref UnitPrice))
            {
                UnitInventory.UnitID = InventoryUnitID;
                UnitInventory.UnitPrice = UnitPrice;
                UnitInventory.ProductID = ProductID;
                UnitInventory.Quantity = Quantity;

                UnitInventory.Product =
                _ProductBL.GetPeroductByProductID(UnitInventory.ProductID);

                UnitInventory.Mode = clsInventoryUnit.enMode.Edit;

                return UnitInventory;

            }

            throw (new Exception("Unit Inventory Not Found"));
        }

        public List<clsInventoryUnit> GetInvUnitsList()
        {
            return _UnitInventoryDL.GetInvUnitsList();  
        }

    }
}
