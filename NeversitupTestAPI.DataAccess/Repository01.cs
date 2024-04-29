using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeversitupTestAPI.DataAccess
{
    public partial class Repository
    {
        public  void GET_STATUS(string status_type)
        {
            SqlCommand sql = new SqlCommand
            {
                CommandType = System.Data.CommandType.Text,
                Connection = this.sqlConnection,
                CommandText = $@"SELECT [id]
      ,[STATUS_CODE]
      ,[STATUS_DESCRIPTION]
      ,[STATUS_SEQ]
      ,[ACTIVE_FLG]
      ,[STATUS_TYPE]
  FROM [{DBENV}].dbo.[tbm_substatus]
  WHERE ACTIVE_FLG =1
  AND STATUS_TYPE = @STATUS_TYPE
  ORDER BY STATUS_SEQ ASC"
            };
            sql.Parameters.AddWithValue("@STATUS_TYPE", status_type);

            //using (DataTable dt =  ITUtility.Utility.FillDataTable(sql))
            //{
            //  ...
            //}

        }

    }
}
