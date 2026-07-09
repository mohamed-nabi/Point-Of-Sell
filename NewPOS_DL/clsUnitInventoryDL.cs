using NewPOS_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NewPOS_DL
{
    public class clsUnitInventoryDL
    {
        public bool AddUnitInventory(clsInventoryUnit UnitInventory)
        {
            if (UnitInventory == null)
            {
                return false;
            }

            int UnitInventoryID = 0;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_AddInventoryUnit", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", UnitInventory.ProductID);
                    command.Parameters.AddWithValue("@Quantity", UnitInventory.Quantity);
                    command.Parameters.AddWithValue("@UnitPrice", UnitInventory.UnitPrice);

                    SqlParameter outputIdParam = new SqlParameter("@InventoryUnitID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(outputIdParam);

                    connection.Open();

                    command.ExecuteNonQuery();

                    UnitInventoryID = Convert.ToInt32(command.Parameters["@InventoryUnitID"].Value);

                    UnitInventory.UnitID = UnitInventoryID;
                }
            }

            return UnitInventoryID > 0;
        }

        public bool UpdateUnitInventory(clsInventoryUnit UnitInventory)
        {
            if (UnitInventory == null)
            {
                return false;
            }

            bool IsSuccess = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateInventory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Quantity", UnitInventory.Quantity);
                    command.Parameters.AddWithValue("@UnitPrice", UnitInventory.UnitPrice);
                    command.Parameters.AddWithValue("@InventoryUnitID", UnitInventory.UnitID);


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

        public DataTable GetAllInventoryUnits()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = 
                new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetInventoryList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    dt.Load(command.ExecuteReader());
                }
            }

            return dt;
        }


        public List<clsInventoryUnit> GetInvUnitsList()
        {
            List<clsInventoryUnit> list = new List<clsInventoryUnit> ();    

            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetInventoryList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                   using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new clsInventoryUnit
                            {
                                 UnitID = (int)reader["UnitID"],
                                 ProductID = (int)reader["ProductID"],

                                 // We Solve it later
                                 //Product = new clsProduct((int)reader["ProductID"], (string)reader["Product Name"]),
                                 UnitPrice = Convert.ToDouble( reader["Unit Price"]),
                                 Quantity = (short)reader["Quantity"]
                            });
                        }
                    }
                }
            }

            return list;
        }


        public bool CheckIfUnitInventoryExistsUsingFn(int UnitInventoryID)
        {
            bool isExists = false;

            // نص الاستعلام الخاص باستدعاء الدالة (يجب كتابة dbo. قبل اسم الدالة دائماً)
            string query = "select dbo.FN_CheckUnitInventroyExists(@InventoryUnitID)";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                // نستخدم CommandType.Text العادي هنا لأننا نستدعي الدالة عبر جملة SELECT
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.CommandType = CommandType.Text;

                    // تمرير المعامل للدالة
                    cmd.Parameters.AddWithValue("@InventoryUnitID", UnitInventoryID);

                    try
                    {
                        connection.Open();

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

        public bool CheckInvUnitExistsByProductID(int ProductID)
        {
            bool isExists = false;

            string query = "SELECT dbo.FN_CheckInvUnitExistsByProductID(@ProductID)";
                

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ProductID", ProductID);

                    try
                    {
                        connection.Open();

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

        public bool GetUnitInventoryByUnitInventoryID(int UnitInventoryID, ref int ProductID
            ,ref short Quantity ,ref double UnitPrice)
        {
            if (UnitInventoryID < 0)
            {
                return false;
            }

            

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetUnitInventoryByUnitInventoryID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UnitInventoryID", UnitInventoryID);

                    SqlParameter outProductID = new SqlParameter("@ProductID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };


                    SqlParameter outQuantity = new SqlParameter("@Quantity", SqlDbType.SmallInt)
                    {
                        Direction = ParameterDirection.Output
                    };


                    SqlParameter outUnitPrice = new SqlParameter("@UnitPrice", SqlDbType.Decimal)
                    {
                        Direction = ParameterDirection.Output ,
                        Precision = 7 ,
                        Scale = 2
                        
                    };


                    command.Parameters.Add(outProductID);
                    command.Parameters.Add(outQuantity);
                    command.Parameters.Add(outUnitPrice);


                    connection.Open();

                    command.ExecuteNonQuery();

                    ProductID = Convert.ToInt32(command.Parameters["@ProductID"].Value);
                    Quantity = Convert.ToInt16(command.Parameters["@Quantity"].Value);
                    UnitPrice = Convert.ToDouble(command.Parameters["@UnitPrice"].Value);
                }
            }

            return true;
        }

    }
}
