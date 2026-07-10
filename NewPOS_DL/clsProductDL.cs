using NewPOS_Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace NewPOS_DL
{
    public class clsProductDL
    {

        private readonly  string dbConnectionString = "Server=.;Database=POS_DB;User ID=sa;Password=123456;";
        public bool AddProduct(clsProduct Product)
        {
            if(Product == null)
            {
                return false;
            }

            int ProductID = 0;

            using (SqlConnection connection = new SqlConnection(dbConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_AddProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductName", Product.ProductName);
                    command.Parameters.AddWithValue("@Barcode", Product.Barcode);


                    SqlParameter outputIdParam = new SqlParameter("@ProductID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(outputIdParam);

                    connection.Open();  

                    command.ExecuteNonQuery();

                    ProductID = Convert.ToInt32(command.Parameters["@ProductID"].Value);

                    Product.ProductID = ProductID;
                }
            }

            return ProductID > 0;
        }

        public bool UpdateProduct(clsProduct Product)
        {
            if (Product == null)
            {
                return false;
            }

            bool IsSuccess = false;

            using (SqlConnection connection = new SqlConnection(dbConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ProductName", Product.ProductName);
                    command.Parameters.AddWithValue("@ProductID", Product.ProductID);
                    command.Parameters.AddWithValue("@Barcode", Product.Barcode);


                    SqlParameter outputIdParam = new SqlParameter("@IsSuccess", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(outputIdParam);

                    try
                    {
                        connection.Open();

                        command.ExecuteNonQuery();

                        IsSuccess = Convert.ToBoolean(command.Parameters["@IsSuccess"].Value);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }

            return IsSuccess;
        }

        public DataTable GetAllProucts()
        {
            DataTable dt = new DataTable(); 

            using (SqlConnection connection = new SqlConnection(dbConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllProducts", connection))
                {
                   

                    connection.Open();

                    dt.Load(command.ExecuteReader());
                }
            }

            return dt;
        }

        public bool CheckIfProductExistsUsingFn(int productId)
        {
            bool isExists = false;

            // نص الاستعلام الخاص باستدعاء الدالة (يجب كتابة dbo. قبل اسم الدالة دائماً)
            string query = "select dbo.FN_CheckProductExists(@ProductID)";

            using (SqlConnection conn = new SqlConnection(dbConnectionString))
            {
                // نستخدم CommandType.Text العادي هنا لأننا نستدعي الدالة عبر جملة SELECT
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    // تمرير المعامل للدالة
                    cmd.Parameters.AddWithValue("@ProductID", productId);

                    try
                    {
                        conn.Open();

                        // ExecuteScalar تقوم بجلب أول عميل وأول صف (وهي القيمة التي ترجعها الدالة)
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            isExists = (bool)result;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }

            return isExists;
        }

        public bool GetPeroductByProductID(int ProductID ,
            ref string ProductName ,ref string Barcode)
        {
            if (ProductID < 0)
            {
                return false;
            }

            if (!CheckIfProductExistsUsingFn(ProductID))
                return false;

            using (SqlConnection connection = new SqlConnection(dbConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetProductByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", ProductID);

                    SqlParameter outputIdParam = new SqlParameter("@ProductName", SqlDbType.NVarChar ,200)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(outputIdParam);

                    SqlParameter outBarcodepram = new SqlParameter("@Barcode", SqlDbType.VarChar, 20)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(outBarcodepram);

                    connection.Open();

                    command.ExecuteNonQuery();

                    ProductName = command.Parameters["@ProductName"].Value.ToString();
                    Barcode = command.Parameters["@Barcode"].Value.ToString();

                }
            }

            return true;
        }

    }
}
