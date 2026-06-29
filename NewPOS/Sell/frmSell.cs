using NewPOS.Inventory;
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

namespace NewPOS.Sell
{
    public partial class frmSell : Form
    {
        public frmSell()
        {
            InitializeComponent();
        }

        clsInvoiceBL _InvoiceBL = new clsInvoiceBL();
        clsInvoice _Invoice = new clsInvoice();
    

        BindingList<clsBasketItem> _Basket = new BindingList<clsBasketItem>();

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmAddEditInventoryUnit frm = new frmAddEditInventoryUnit();
            frm.ShowDialog();
            ucListFindProduct1.Reload();
        }

       

        private void FormatDGVBasket()
        {
            dgvBasket.Columns["ProductName"].HeaderText = "Product";
            dgvBasket.Columns["UnitPrice"].HeaderText = "Price";
            dgvBasket.Columns["Quantity"].HeaderText = "Qty";
            dgvBasket.Columns["InvUnitID"].HeaderText = "InvID";


            dgvBasket.Columns["ProductName"].Width = 122;
            dgvBasket.Columns["Quantity"].Width = 70;
            dgvBasket.Columns["UnitPrice"].Width = 70;
            dgvBasket.Columns["Total"].Width = 90;
            dgvBasket.Columns["Total"].Width = 90;
            dgvBasket.Columns["InvUnitID"].Width = 50;

        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if(ucListFindProduct1.InvUnitID > 0)
            {
                frmAddEditInventoryUnit frm
                 = new frmAddEditInventoryUnit(ucListFindProduct1.InvUnitID);

                frm.ShowDialog();
                ucListFindProduct1.Reload();
            }
        }

        private void ucListFindProduct1_ProductSelected(object sender, User_Controlls.ucListFindProduct.ProductSelectedEventArgs e)
        {
            if(_Basket.Any(p => p.ProductID == e.ProductID))
            {
                var item = _Basket.FirstOrDefault(p=>p.ProductID == e.ProductID);

                if(item != null)
                {
                    item.Quantity++;

                    //item.Total = item.UnitPrice * item.Quantity;
                }

                return;
            }

            _Basket.Add(new clsBasketItem(e.ProductID ,e.InvUnitID ,
                e.ProductName ,e.UnitPrice ,1));

        }

        private void tsmEditQty_Click(object sender, EventArgs e)
        {
            if (dgvBasket.CurrentRow == null)
                return;

            DataGridViewRow row = dgvBasket.CurrentRow;

            int qty = Convert.ToInt32(row.Cells["Quantity"].Value);
            int UID = Convert.ToInt32(row.Cells["InvUnitID"].Value);


            using (frmEditQty frm = new frmEditQty(qty))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var item = _Basket.FirstOrDefault(p => p.InvUnitID == UID);
                    item.Quantity = frm.Qty;
                    _UpdateTotalPrice();
                }
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _Basket.Clear();
        }

        private void frmSell_Load(object sender, EventArgs e)
        {
            ucListFindProduct1.Reload();
            dgvBasket.DataSource = _Basket;
            FormatDGVBasket();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_Basket.Count == 0)
            {
                MessageBox.Show("There is now prouct in the basket",
                    "Empty basket", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }    

            List<string> lessQtyProduct = _InvoiceBL.GetInsufficientStockProducts(_Basket);

            if(lessQtyProduct.Any())
            {
                MessageBox.Show($"Stock has less Qty then " +
                    $"basket in the next product : {string.Join(" , ", lessQtyProduct)}.",
                    "Availability Issue", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            
            if(_InvoiceBL.SaveInvoice(_Basket ,ref _Invoice))
            {
                MessageBox.Show($"Invoice Save With ID: {_Invoice.InvoiceID}.", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ucListFindProduct1.Reload();

                _Basket.Clear();
            }

        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvBasket.CurrentRow;

            if (row == null)
                return;

            if(int.TryParse(row.Cells["InvUnitID"].Value.ToString() 
                ,out int UnitID))
            {
                var item = _Basket.FirstOrDefault(p => p.InvUnitID == UnitID);

                if(item != null)
                {
                    _Basket.Remove(item);
                    _UpdateTotalPrice();
                }
            }
        }

        private void _UpdateTotalPrice()
        {
            lblTotalPrice.Text = _Basket.Sum(p => p.Total).ToString() + "$";
        }

        private void dgvBasket_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            _UpdateTotalPrice();
        }
    }
}
