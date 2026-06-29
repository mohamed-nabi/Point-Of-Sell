using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPOS_DL
{
    internal class clsDBHelper
    {
        private static string dbConnectionString = "Server=.;Database=POS_DB;User ID=sa;Password=123456;";

        public DataTable ExecuteTable(string spName, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(dbConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null) cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // دالة لتنفيذ الأوامر التي تعيد قيمة Output أو تعيد القيمة المنطقية (مثل التحقق، الحفظ، الحذف)
        public SqlCommand ExecuteCommand(string spName, SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (parameters != null) cmd.Parameters.AddRange(parameters);

            conn.Open();
            cmd.ExecuteNonQuery();
            // نترك الاتصال مفتوحاً ليقوم الـ DAL بقراءة قيم الـ Output ثم يغلقه
            return cmd;
        }
    }
}
