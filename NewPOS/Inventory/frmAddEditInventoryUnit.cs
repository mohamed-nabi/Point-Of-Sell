using NewPOS.Products;
using NewPOS.Properties;
using NewPOS.User_Controlls;
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
using System.Xml.Linq;

namespace NewPOS.Inventory
{
    public partial class frmAddEditInventoryUnit : Form
    {
        public frmAddEditInventoryUnit()
        {
            InitializeComponent();
        }

        public frmAddEditInventoryUnit(int InventoryUnitID)
        {
            InitializeComponent();
            _InventoryUnitID = InventoryUnitID;
        }

        private clsUnitInventoryBL _inventoryUnitBL = new clsUnitInventoryBL();
        private int _InventoryUnitID = -1;
        private clsInventoryUnit _InventoryUnit = new clsInventoryUnit();



        private void frmAddEditInventoryUnit_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnSearch, "Search for a product");

            //after check the given InventoryUnitID
            //we retrive UnitInventory it and put it in '_InventoryUnit'
            if (_InventoryUnitID > 0)
            {
                _InventoryUnit = 
                    _inventoryUnitBL.GetUnitInventoryByUnitInventoryID(_InventoryUnitID);

                _FillFieldsByInvUnitInfo();
            }

            _UpdateFormAppearance();

        }

        private void _FillFieldsByInvUnitInfo()
        {
            txtQuantity.Text = _InventoryUnit.Quantity.ToString();
            txtUnitPrice.Text = _InventoryUnit.UnitPrice.ToString();
            lblUnitInventoryID.Text = _InventoryUnit.UnitID.ToString();
            lblProductID.Text = _InventoryUnit.ProductID.ToString();
            lblProductName.Text = _InventoryUnit.Product.ProductName;
        }

        

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
                   e.KeyChar != '.' &&
                   !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' &&txtUnitPrice.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void _Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                errorProvider1.SetError(txt, "You should fill this field" +
                    " with positif");

                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txt, "");
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            if(_InventoryUnit.Mode == clsInventoryUnit.enMode.Add)
            {
                if (lblProductID.Text != "????" &&
               lblProductName.Text != "????")
                {

                    if(_inventoryUnitBL.
                        CheckInvUnitExistsByProductID(Convert.ToInt32(lblProductID.Text)))
                    {
                        MessageBox.Show("You can only have on " +
                            "Inv Unit for each product." ,
                            "Error" ,MessageBoxButtons.OK , MessageBoxIcon.Error);

                        return;
                    }


                    _FillInvUnitClass(_InventoryUnit);
                    if (_inventoryUnitBL.AddUpdateUnitInventory(_InventoryUnit))
                    {
                        lblUnitInventoryID.Text = _InventoryUnit.UnitID.ToString();

                        MessageBox.Show("Inv.Unit Add Succssfuly with ID : " +
                            _InventoryUnit.UnitID,
                            "saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                
            }

            else if(_InventoryUnit.Mode == clsInventoryUnit.enMode.Edit)
            {
                _FillInvUnitClass(_InventoryUnit);


                if (_InventoryUnit.UnitPrice > 0 && _InventoryUnit.Quantity > 0)
                {
                    if(_inventoryUnitBL.AddUpdateUnitInventory( _InventoryUnit))
                    {
                        MessageBox.Show("Inv.Unit Updated Succssfuly",
                           "saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            _UpdateFormAppearance();

        }

        private void _FillInvUnitClass(clsInventoryUnit InvUnit)
        {
            if(!string.IsNullOrWhiteSpace(lblUnitInventoryID.Text))
                _InventoryUnit.UnitID = Convert.ToInt32(lblUnitInventoryID.Text);


            _InventoryUnit.ProductID = Convert.ToInt32(lblProductID.Text);
            _InventoryUnit.Quantity = Convert.ToInt16(txtQuantity.Text); 
            _InventoryUnit.UnitPrice = Convert.ToDouble(txtUnitPrice.Text);  
        }
        

        private void btnSearch_Click(object sender, EventArgs e)
        {
        
            frmFindProduct frm = new frmFindProduct();
            

            if(frm.ShowDialog() == DialogResult.OK)
            {
                _ExtractProductInfo(frm);
            }
        
        }

        private void _ExtractProductInfo(frmFindProduct frm)
        {
            if(frm.DialogResult == DialogResult.OK)
            {
                lblProductID.Text =
                    frm.GetucFindProduct.GetucShowProductInfo.
                    Product.ProductID.ToString();

                lblProductName.Text =
                    frm.GetucFindProduct.GetucShowProductInfo.
                    Product.ProductName.ToString();
            }

            else
            {
                MessageBox.Show("Can't upload product info" ,
                    "Error" ,MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }

        }

        private void _UpdateFormAppearance()
        {

            if (_InventoryUnit.Mode == clsInventoryUnit.enMode.Add)
            {
                lblTitle.Text = "Add Inventory Unit";
                btnAdd.Text = "Add";
                btnAdd.Image = Resources.add_button_8371340;
            }

            else if(_InventoryUnit.Mode == clsInventoryUnit.enMode.Edit)
            {
                lblTitle.Text = "Update Inventory Unit";
                btnAdd.Text = "Edit";
                btnAdd.Image = Resources.pen_16474192;
            }
        }
    }
}
