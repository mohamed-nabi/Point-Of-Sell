using NewPOS.Products;
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

namespace NewPOS.Inventory
{
    public partial class frmInventory : Form
    {

        public frmInventory()
        {
            InitializeComponent();
        }

       

        private clsUnitInventoryBL _inventoryUnitBL = new clsUnitInventoryBL();  


        DataTable _dtInventoryList = new DataTable();

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            _dtInventoryList = _inventoryUnitBL.GetInventoryList();
            dgvInventoryUnitsList.DataSource = _dtInventoryList;    
        }


        private void _RefruseInvUnitList()
        {
            _dtInventoryList = _inventoryUnitBL.GetInventoryList();
            dgvInventoryUnitsList.DataSource = _dtInventoryList;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEditInventoryUnit frm = new frmAddEditInventoryUnit();
            frm.ShowDialog();

            _RefruseInvUnitList();
        }
                

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvInventoryUnitsList.CurrentRow != null)
            {

                int currentRow = dgvInventoryUnitsList.CurrentRow.Index;


                if (int.TryParse(dgvInventoryUnitsList.Rows[currentRow].Cells["UnitID"].Value.ToString() ,
                    out int InvUnitID))
                {

                    frmAddEditInventoryUnit frm =
                         new frmAddEditInventoryUnit(InvUnitID);
                        

                    frm.ShowDialog();

                   
                }
            }

            _RefruseInvUnitList();
        }
    }
}
