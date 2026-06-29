using NewPOS.User_Controlls;
using NewPOS_Models;
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
    public partial class frmFindProduct : Form
    {
        public frmFindProduct()
        {
            InitializeComponent();
        }

        //public clsProduct GetSelectedProduct
        //{
        //    get { return ucFindProduct1.Product; } 
        //}

        public ucFindProduct GetucFindProduct
        {
            get { return ucFindProduct1; }
        }

        private void frmFindProduct_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (GetucFindProduct.GetucShowProductInfo.Product.ProductID > 0
                && !string.IsNullOrWhiteSpace(
                    GetucFindProduct.GetucShowProductInfo.Product.ProductName))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void ucFindProduct1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
