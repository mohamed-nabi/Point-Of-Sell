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

namespace NewPOS.User_Controlls
{
    public partial class ucListFindProduct : UserControl
    {
        public ucListFindProduct()
        {
            InitializeComponent();
        }

        DataTable _dt = new DataTable();

        clsUnitInventoryBL _InvUnitBL = new clsUnitInventoryBL();

        int _InvUnitID = -1;

        public int InvUnitID { get { return _InvUnitID; } }

        public class ProductSelectedEventArgs : EventArgs
        {
            public int ProductID { get; }
            public int InvUnitID { get; }
            public string ProductName { get;}
            public decimal UnitPrice { get; }
            public short Quantity { get; }

           public ProductSelectedEventArgs(int productID ,int invUnitID ,
               string productName ,decimal unitPrice ,short Qty)
            {
                ProductID = productID;
                InvUnitID = invUnitID;
                ProductName = productName;
                UnitPrice = unitPrice;
                Quantity = Qty;
            } 
        }

        public event EventHandler<ProductSelectedEventArgs> ProductSelected;

        private void OnProductSelected(ProductSelectedEventArgs SelectedProduct)
        {
            ProductSelected?.Invoke(this ,SelectedProduct);    
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void Reload()
        {
            _dt = _InvUnitBL.GetInventoryList();
            dgvListProducts.DataSource = _dt;
            _FormatdgvProductList();
        }

        private void _FormatdgvProductList()
        {
            if(dgvListProducts.DataSource != null)
            {
                dgvListProducts.Columns["Product Name"].Width = 85;
                dgvListProducts.Columns["UnitID"].Width = 50;
                dgvListProducts.Columns["ProductID"].Width = 50;
                dgvListProducts.Columns["Quantity"].Width = 50;
                dgvListProducts.Columns["Unit Price"].Width = 50;
            }
        }

        private void ucListFindProduct_Load(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                _dt.DefaultView.RowFilter = "";
                return;
            }

            if (rbID.Checked)
            {
                if (int.TryParse(txtSearch.Text, out int id))
                {
                    _dt.DefaultView.RowFilter = $"ProductID = {id}";
                }
                else
                {
                    _dt.DefaultView.RowFilter = "1 = 0";
                }
            }
           


            else if (rbName.Checked)
            {
                _dt.DefaultView.RowFilter = $"[Product Name] LIKE '%{txtSearch.Text}%'";
            }

            
        }

        private void dgvListProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListProducts.CurrentRow == null)
                return;

            DataGridViewRow row = dgvListProducts.CurrentRow;




            OnProductSelected(GetSelectedProduct());

        }

        private ProductSelectedEventArgs GetSelectedProduct()
        {
            int productID = Convert.ToInt32(
                dgvListProducts.CurrentRow.Cells["ProductID"].Value);

            short Qty = Convert.ToInt16(
    dgvListProducts.CurrentRow.Cells["Quantity"].Value);

            decimal UnitPrice = Convert.ToDecimal(
    dgvListProducts.CurrentRow.Cells["Unit Price"].Value);

            string productName =
                dgvListProducts.CurrentRow.Cells["Product Name"].Value.ToString();

            return new ProductSelectedEventArgs(productID, _InvUnitID, productName,
                UnitPrice ,Qty);
        }

        private void dgvListProducts_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvListProducts.CurrentRow == null)
            {
                _InvUnitID = -1;
                return;
            }
               
            object value = dgvListProducts.CurrentRow.Cells["UnitID"].Value;

            if (value == null || value == DBNull.Value)
            {
                _InvUnitID = -1;    
                return; 
            }
                

            _InvUnitID = Convert.ToInt32(value);
        }
    }
}
