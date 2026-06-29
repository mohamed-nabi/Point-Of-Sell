using NewPOSBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPOS.Products
{
    public partial class frmProduct : Form
    {


        public frmProduct()
        {
            InitializeComponent();
        }

        clsProductBL _ProductBL = new clsProductBL();
        DataTable _dt = new DataTable();

        private void _Editdgv(DataGridView dgv)
        {
            dgv.Columns["ProductID"].HeaderText = "Product ID";
            dgv.Columns["ProductID"].Width = 150;

       //     dgv.Columns["ProductName"].HeaderText = "Product Name";
            dgv.Columns["Product Name"].Width = 300;

        }

        private async void frmProducrs_Load(object sender, EventArgs e)
        {
            DataTable _dt = _ProductBL.GetAllProucts();

            //Simulating the retrieval of large of data from a database

             await Task.Delay(4000);

            dgvListProducts.DataSource = _dt;
            _Editdgv(dgvListProducts);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _RefruseProductList()
        {
            _dt = _ProductBL.GetAllProucts();
            dgvListProducts.DataSource = _dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateProduct();
            frm.ShowDialog();
            _RefruseProductList();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (dgvListProducts.CurrentCell != null)
            {
                
                int currentColumn = dgvListProducts.CurrentCell.ColumnIndex;


                if (dgvListProducts.Columns[currentColumn].Name == "ProductID")
                {
                    int ProductID = Convert.ToInt32(dgvListProducts.CurrentCell.Value);

                    Form frm =
                        new frmAddUpdateProduct(ProductID);

                    frm.ShowDialog();
                }
            }

            _RefruseProductList();
        }
    }
}
