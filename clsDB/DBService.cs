using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using clswinApi;

namespace clsDB
{
    public class DBService
    {
        private DbContext context = new DbContext(StaticWinApi.connStr);
        private DbConnection conn;


        private TransactionScope tran;
        public DBService()
        {
            context = new Model1();
            conn = context.Database.Connection;
            tran = null;
        }


        public DataTable GetDatafromDB(string qrystring)
        {
            //initiate  if was  not initiated
            if (context == null )
            {
                context = new Model1();
                conn = context.Database.Connection;
                tran = null;
            }
                
                

            var dt = new DataTable();
            var connectionState = conn.State;
            try
            {
                if (connectionState != ConnectionState.Open) conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = qrystring;
                    cmd.CommandType = CommandType.Text;
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                // error handling
                throw;
            }
            finally
            {
                if (connectionState != ConnectionState.Closed) conn.Close();
            }
            return dt;

        }

        public Boolean ExecuteSql(string qrystring,out string errormsg)
        {

            {
                var dt = new DataTable();
                var connectionState = conn.State;
                try
                {
                    if (connectionState != ConnectionState.Open) conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = qrystring;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        errormsg = "";
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    // error handling
                    errormsg = ex.Message;
                    return false;

                }
                finally
                {
                    if (connectionState != ConnectionState.Closed) conn.Close();
                }
            }


        }

        public Boolean BeginTrans()
        {
            try
            {
                if (tran==null)
                tran = new TransactionScope();
                return true;
            }

            catch (Exception)
            {

                throw;
            }
        }


        public Boolean CommitTrans()
        {
            try
            {
                tran.Complete();
                tran.Dispose();
                return true;
            }

            catch (Exception)
            {

                throw;
            }
        }

        public Boolean RollbackTran()
        {
            try
            {
                tran.Dispose();
                return true;
            }

            catch (Exception)
            {

                throw;
            }
        }


    } 
}
