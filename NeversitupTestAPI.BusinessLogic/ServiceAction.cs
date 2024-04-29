using NeversitupTestAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeversitupTestAPI.BusinessLogic
{
    public class ServiceAction
    {
        #region " STATIC "
        private readonly string _connectionstring = string.Empty;
        private readonly CultureInfo culture = new CultureInfo("th-TH");
        private readonly string DBENV = string.Empty;
        public ServiceAction(string connectionstring, string DBENV)
        {
            this._connectionstring = connectionstring;
            this.DBENV = DBENV;
        }
        #endregion " STATIC "

        public void GET_STATUS(string status_type)
        => GET_STATUS(status_type, (Repository)null);

        private void GET_STATUS(string status_type, Repository? repository)
        {
            bool internalConnection = false;
            if(repository is null)
            {
                repository = new Repository(_connectionstring,DBENV);
                repository.OpenConnection();
               // repository.beginTransection(); //กรณีผม update insert  delete
            }
            try
            {
                // if (internalConnection)
                 // repository.CommitTransection();//กรณีผม update insert  delete
            }
            catch (Exception ex)
            {
                // if (internalConnection)
                //  repository.RollbackTransection();//กรณีผม update insert  delete
                throw ex;
            }
            finally
            {
                if(internalConnection)
                    repository.CloseConnection();
            }
        }
    }
}
