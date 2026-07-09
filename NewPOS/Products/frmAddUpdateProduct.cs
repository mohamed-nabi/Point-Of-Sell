using NewPOS.Properties;
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

namespace NewPOS.Products
{
    public partial class frmAddUpdateProduct : Form
    {
        public frmAddUpdateProduct()
        {
            InitializeComponent();
        }
        public frmAddUpdateProduct(int ProductID)
        {
            InitializeComponent();
            _ProductID = ProductID;
        }


        int _ProductID = -1;
        clsProduct _Product = new clsProduct();
        private clsProductBL _ProductBL = new clsProductBL();

        public clsProduct Product
        {
            get { return _Product; }    
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.ValidateChildren();

            _Product.ProductName = txtName.Text;
            _Product.Barcode = txtBarcode.Text; 

            if(_Product.Mode == clsProduct.enMode.Add)
            {
                if (_ProductBL.AddUpdateProduct(_Product))
                {
                    MessageBox.Show($"Product Add With Prouct Id : {_Product.ProductID}", "ss", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    _UpdateContantByFormStatus();

                    this.DialogResult = DialogResult.OK;
                }
            }



            else if(_Product.Mode == clsProduct.enMode.Edit)
            {
                if (_ProductBL.AddUpdateProduct(_Product))
                {
                    MessageBox.Show("Product Updated successfuly" ,"Info" , MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                // 1. إظهار أيقونة الخطأ بجانب الحقل ونص التنبيه
                errorProvider1.SetError(txtName, "You Should To Fill this field.");

                // 2. اختياري: منع المستخدم من الانتقال لحقل آخر حتى يصحح الخطأ
                e.Cancel = true;
            }
            else
            {
                // إلغاء الخطأ إذا كانت البيانات صحيحة
                errorProvider1.SetError(txtName, "");
            }
        }

        private void frmAddUpdateProduct_Load(object sender, EventArgs e)
        {
            if(_ProductID > 0)
            {
                if(!_ProductBL.CheckProductExists(_ProductID))
                {
                    MessageBox.Show("Product Not Found" ,"Error" ,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.Close();
                    return;

                }

                _Product = _ProductBL.GetPeroductByProductID(_ProductID);
                txtName.Text = _Product.ProductName;
                txtBarcode.Text = _Product.Barcode;
            }

            _UpdateContantByFormStatus();
        }
        
        private void _UpdateContantByFormStatus()
        {
            if (_Product.Mode == clsProduct.enMode.Edit)
            {
                btnAdd.Text = "Edit";
                btnAdd.Image = Resources.pen_16474192;
                btnAdd.Name = "btnEdit";

                lblTitle.Text = "Update Product";
                pbPictureForm.Image = Resources.EditProduct;

                this.Name = "Edit Product";
            }

            else
            {

                btnAdd.Text = "Add";
                btnAdd.Image = Resources.add_button_8371340;
                btnAdd.Name = "btnAdd";

                lblTitle.Text = "Add Product";
                pbPictureForm.Image = Resources.AddProduct;

                this.Name = "Add Product";
            }
        }

        private void txtBarcode_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsLetterOrDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
                
        }
    }
}
