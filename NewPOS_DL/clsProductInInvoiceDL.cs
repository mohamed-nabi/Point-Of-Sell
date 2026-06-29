using NewPOS_Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPOS_DL
{
    public class clsProductInInvoiceDL
    {
        public bool AddProductInInvoice(clsProductInInvoice ProductInInvoice)
        {
            if (ProductInInvoice == null)
            {
                return false;
            }

            int ProductInInvoiceID = 0;

            using (SqlConnection connection = new SqlConnection
                (ConfigurationManager.ConnectionStrings["MydbConnection"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[SP_AddProductInInvoice]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UnitID", ProductInInvoice.UnitID);
                    command.Parameters.AddWithValue("@InvoiceID", ProductInInvoice.InvoiceID);

                    SqlParameter outPIniID = new SqlParameter("@ProductInInvoiceID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(outPIniID);

                    connection.Open();

                    command.ExecuteNonQuery();

                    ProductInInvoiceID = Convert.ToInt32(command.Parameters["@ProductInInvoiceID"].Value);


                    ProductInInvoice.ProductInInvoiceID = ProductInInvoiceID;
                    

                }
            }

            return ProductInInvoiceID > 0;
        }

    }
}
