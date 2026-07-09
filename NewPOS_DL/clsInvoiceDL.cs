using NewPOS_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPOS_DL
{
    public class clsInvoiceDL
    {
       

        public bool AddInvoice(clsInvoice Invoice)
        {
            if (Invoice == null)
            {
                return false;
            }

            int InvoiceID = 0;

            using (SqlConnection connection = new SqlConnection
                (ConfigurationManager.ConnectionStrings["MydbConnection"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_AddInvoice", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TotalPrice", Invoice.TotalPrice);

                    SqlParameter outInvoiceID = new SqlParameter("@InvoiceID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };


                    SqlParameter outCreatedDateTime = new SqlParameter("@CreatedDateTime", SqlDbType.DateTime)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(outInvoiceID);
                    command.Parameters.Add(outCreatedDateTime);

                    connection.Open();

                    command.ExecuteNonQuery();

                    InvoiceID = Convert.ToInt32(command.Parameters["@InvoiceID"].Value);
                    

                    Invoice.InvoiceID = InvoiceID;
                    Invoice.CreatedDateTime = Convert.ToDateTime
                        (command.Parameters["@CreatedDateTime"].Value);
                }
            }

            return InvoiceID > 0;
        }

        public bool UpdateInvoiceTotalPrice(int InvoicID,decimal TotalPrice)
        {
            if (TotalPrice < 0) return false;

            int rowAffected = 0;

            using (SqlConnection connection = new SqlConnection
                (ConfigurationManager.ConnectionStrings["MydbConnection"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateInvoiceTotalPrice", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@TotalPrice",TotalPrice);
                    command.Parameters.AddWithValue("@InvoiceID", InvoicID);

                    connection.Open();  

                    rowAffected = command.ExecuteNonQuery();

                }
            }

            return rowAffected > 0;    
        }

        public bool CheckInvoiceExists(int InvoiceID)
        {
            bool isExists = false;

            // نص الاستعلام الخاص باستدعاء الدالة (يجب كتابة dbo. قبل اسم الدالة دائماً)
            string query = "select dbo.FN_CheckInvoiceExists(@InvoiceID)";

            using (SqlConnection conn = 
                new SqlConnection(ConfigurationManager.ConnectionStrings["MydbConnection"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@InvoiceID", InvoiceID);

                    conn.Open();

                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        isExists = (bool)result;
                    }
                }
            }

            return isExists;
        }

        public bool SaveInvoice(DataTable Basket, ref clsInvoice Invoice)
        {
            Invoice = new clsInvoice();


            using (SqlConnection connection = new SqlConnection
                (ConfigurationManager.ConnectionStrings["MydbConnection"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_SaveInvoice", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;


                    SqlParameter outInvoiceID = new SqlParameter("@InvoiceID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };


                    SqlParameter outInvoiceTotalPrice = new SqlParameter("@InvoicePrice", SqlDbType.Decimal)
                    {
                        Direction = ParameterDirection.Output
                    };

                    SqlParameter itemsParameter =
                        command.Parameters.AddWithValue("@Items", Basket);

                    itemsParameter.SqlDbType = SqlDbType.Structured;

                    itemsParameter.TypeName = "InvoiceItemsType";


                    command.Parameters.Add(outInvoiceID);
                    command.Parameters.Add(outInvoiceTotalPrice);

                    connection.Open();

                  
                    command.ExecuteNonQuery();

                    Invoice.InvoiceID = Convert.ToInt32(command.Parameters["@InvoiceID"].Value);
                    Invoice.TotalPrice = Convert.ToDecimal(command.Parameters["@InvoicePrice"].Value);


                }
            }

            return Invoice.InvoiceID > 0;
        }

        public DataTable GetAllInvoices()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.
                ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllInvoices", connection))
                {


                    connection.Open();

                    dt.Load(command.ExecuteReader());
                }
            }

            return dt;
        }

        public DataTable GetInvoiceitemsByInvoiceID(int InvoiceID)
        {
            DataTable dt = new DataTable(); 

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.
                ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetInvoiceitemsByInvoiceID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@InvoiceID" , InvoiceID);

                    connection.Open();

                    dt.Load(command.ExecuteReader());
                }
            }

            return dt;
        }
    }
}
