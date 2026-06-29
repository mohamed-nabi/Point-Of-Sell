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
    public partial class ucShowProductInfo : UserControl
    {
        public ucShowProductInfo()
        {
            InitializeComponent();
        }

        public void Find(int ProuctID)
        {
            _ProductID = ProuctID;

            if (_ProductID < 0)
                return;

            if (!_ProductBL.CheckProductExists(_ProductID))
            {
                MessageBox.Show("Product ID not exists",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Product = _ProductBL.GetPeroductByProductID(_ProductID);

            if (Product == null)
            {
                MessageBox.Show("Product Dose not exisits");
                return;
            }

            lblProductID.Text = Product.ProductID.ToString();
            lblProductName.Text = Product.ProductName.ToString();

        }



        public clsProduct Product = new clsProduct();
        private int _ProductID = -1; 
        private clsProductBL _ProductBL = new clsProductBL();

        
        private void ucFindProduct_Load(object sender, EventArgs e)
        {
           
        }

        private void lblProductName_Click(object sender, EventArgs e)
        {

        }
    }
}
