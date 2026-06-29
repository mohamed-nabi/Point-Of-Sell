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

namespace NewPOS.User_Controlls
{
    public partial class ucFindProduct : UserControl
    {


        public class ProductSelectedEventArgs : EventArgs
        {
           
            public clsProduct Product { get; set; } 

            public ProductSelectedEventArgs(clsProduct product)
            {
                Product = product;
            }
        }

        public ucShowProductInfo GetucShowProductInfo
        {
            get { return ucShowProductInfo1; }
        }

//        public event EventHandler<ProductSelectedEventArgs> ProductSelected;


        public ucFindProduct()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if(int.TryParse(txtSearch.Text ,out int ProductID))
            {
                ucShowProductInfo1.Find(ProductID);
            }
            


            //ProductSelected?.Invoke(sender ,
            //    new ProductSelectedEventArgs(Product));

        }

        private void txtSearch_Validating(object sender, CancelEventArgs e)
        {
            if(!int.TryParse(txtSearch.Text, out int productID))
            {
                errorProvider1.SetError(txtSearch, "You Should eter a number");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void ucShowProductInfo1_Load(object sender, EventArgs e)
        {
          
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ucFindProduct_Load(object sender, EventArgs e)
        {

        }
    }
}
