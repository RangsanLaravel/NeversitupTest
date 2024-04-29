using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeversitupTestAPI.DataAccess
{
    public partial class Repository 
    {
        #region " STATIC "

        private readonly SqlConnection sqlConnection = null;
        private SqlTransaction transaction;

        private readonly string DBENV = string.Empty;
        public Repository(string connectionstring, string DBENV) : this(new SqlConnection(connectionstring), DBENV)
        {

        }
        public Repository(SqlConnection ConnectionString, string DBENV)
        {
            this.sqlConnection = ConnectionString;
            this.DBENV = DBENV;
        }
        public void OpenConnection() =>
        this.sqlConnection.Open();
        public void CloseConnection() =>
        this.sqlConnection.Close();

        public void beginTransection() =>
            this.transaction = this.sqlConnection.BeginTransaction();

        public void CommitTransection() =>
            this.transaction.Commit();


        public void RollbackTransection() =>
            this.transaction.Rollback();
        #endregion " STATIC "


    }
}
