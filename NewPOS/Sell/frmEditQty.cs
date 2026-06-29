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
    public partial class frmEditQty : Form
    {
        public frmEditQty(int Qty)
        {
            InitializeComponent();
            this.Qty = Qty;
        }

        public int Qty {  get; set; }   

        private void frmEditQty_Load(object sender, EventArgs e)
        {
            txtQuantity.Text = this.Qty.ToString(); 
        }

        private void _close()
        {
            Qty = Convert.ToInt32(txtQuantity.Text);
            this.DialogResult = DialogResult.OK;
        }

        private void frmEditQty_FormClosed(object sender, FormClosedEventArgs e)
        {
            _close();   
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtQuantity_Validated(object sender, EventArgs e)
        {
            int qty = Convert.ToInt32(txtQuantity.Text);

            if(qty <=0)
            {
                errorProvider1.SetError(txtQuantity, "Enter number grater then 0");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                _close();
            }
        }

        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
