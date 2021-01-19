using System;
using System.Data.SQLite;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace DAL
{
    public class SQLiteHelper
    {
        private string _conn = ConfigurationManager.ConnectionStrings["connString"].ToString();
        //private readonly string _conn = "Data Source=Weather.sqlite;Version=3;";
        
        #region ExecuteNonQuery
        /// <summary>
        /// Perform database operations (add, update, or delete)
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        /// <param name="cmd">SqlCommand Object</param>
        /// <returns>The number of rows affected</returns>
        public int ExecuteNonQuery(SQLiteCommand cmd)
        {
            int result = 0;
            if (string.IsNullOrEmpty(_conn))
                throw new ArgumentNullException("Connection string is missing.");
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                SQLiteTransaction trans = null;
                PrepareCommand(cmd, con, ref trans, true, cmd.CommandType, cmd.CommandText);
                try
                {
                    result = cmd.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }

        /// <summary>
        /// Perform database operations (add, update, or delete)
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        /// <param name="commandText">Execute statement or stored procedure name</param>
        /// <param name="commandType">Execution type</param>
        /// <returns>The number of rows affected</returns>
        public int ExecuteNonQuery(string commandText, CommandType commandType)
        {
            int result = 0;
            if (string.IsNullOrEmpty(_conn))
                throw new ArgumentNullException("Connection string is missing.");
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException("commandText");
            SQLiteCommand cmd = new SQLiteCommand();
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                SQLiteTransaction trans = null;
                PrepareCommand(cmd, con, ref trans, true, commandType, commandText);
                try
                {
                    result = cmd.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }

        /// <summary>
        /// Perform database operations (add, update, or delete)
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        /// <param name="commandText">Execute statement or stored procedure name</param>
        /// <param name="commandType">Execution type</param>
        /// <param name="cmdParms">SQL parameter object</param>
        /// <returns>The number of rows affected</returns>
        public int ExecuteNonQuery(string commandText, CommandType commandType, params SQLiteParameter[] cmdParms)
        {
            int result = 0;
            if (string.IsNullOrEmpty(_conn))
                throw new ArgumentNullException("Connection string is missing.");
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException("commandText");

            SQLiteCommand cmd = new SQLiteCommand();
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                SQLiteTransaction trans = null;
                PrepareCommand(cmd, con, ref trans, true, commandType, commandText, cmdParms);
                try
                {
                    result = cmd.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }
        #endregion

        #region ExecuteScalar
        /// <summary>
        /// Perform database operations (add, update, or delete) and return the first row and first column data from the post-execution query.
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        /// <param name="cmd">SqlCommand Object</param>
        /// <returns>Query the first row and first column data</returns>
        public object ExecuteScalar(SQLiteCommand cmd)
        {
            object result = 0;
            if (string.IsNullOrEmpty(_conn))
                throw new ArgumentNullException("Connection string is missing.");
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                SQLiteTransaction trans = null;
                PrepareCommand(cmd, con, ref trans, true, cmd.CommandType, cmd.CommandText);
                try
                {
                    result = cmd.ExecuteScalar();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }

        /// <summary>
        /// Perform database operations (add, update, or delete) and return the first row and first column data from the post-execution query.
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        /// <param name="commandText">Execute statement or stored procedure name</param>
        /// <param name="commandType">Execution type</param>
        /// <returns>Query the first row and first column data</returns>
        public object ExecuteScalar(string commandText, CommandType commandType)
        {
            object result = 0;
            if (string.IsNullOrEmpty(_conn))
                throw new ArgumentNullException("Connection string is missing.");
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException("commandText");
            SQLiteCommand cmd = new SQLiteCommand();
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                SQLiteTransaction trans = null;
                PrepareCommand(cmd, con, ref trans, true, commandType, commandText);
                try
                {
                    result = cmd.ExecuteScalar();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }

        /// <summary>
        /// Perform database operations (add, update, or delete) and return the first row and first column data from the post-execution query.
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        /// <param name="commandText">Execute statement or stored procedure name</param>
        /// <param name="commandType">Execution type</param>
        /// <param name="cmdParms">SQL parameter object</param>
        /// <returns>Query the first row and first column data</returns>
        public object ExecuteScalar(string commandText, CommandType commandType, params SQLiteParameter[] cmdParms)
        {
            object result = 0;
            if (string.IsNullOrEmpty(_conn))
                throw new ArgumentNullException("Connection string is missing.");
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException("commandText");

            SQLiteCommand cmd = new SQLiteCommand();
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                SQLiteTransaction trans = null;
                PrepareCommand(cmd, con, ref trans, true, commandType, commandText);
                try
                {
                    result = cmd.ExecuteScalar();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }
        #endregion


        #region ExecuteReader
        /// <summary>
        /// Execute a database query, return a SqlDataReader object
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        /// <param name="cmd">SqlCommand Object</param>
        /// <returns>SqlDataReader Object</returns>
        public DbDataReader ExecuteReader(SQLiteCommand cmd)
        {
            DbDataReader reader = null;
            if (string.IsNullOrEmpty(_conn))
                throw new ArgumentNullException("Connection string is missing.");

            SQLiteConnection con = new SQLiteConnection(_conn);
            SQLiteTransaction trans = null;
            PrepareCommand(cmd, con, ref trans, false, cmd.CommandType, cmd.CommandText);
            try
            {
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reader;
        }

        /// <summary>
        /// Execute a database query, return a SqlDataReader object
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        /// <param name="commandText">Execute statement or stored procedure name</param>
        /// <param name="commandType">Execution type</param>
        /// <returns>SqlDataReader Object</returns>
        public DbDataReader ExecuteReader(string commandText, CommandType commandType)
        {
            DbDataReader reader = null;
            if (string.IsNullOrEmpty(_conn))
                throw new ArgumentNullException("Connection string is missing.");
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException("commandText");

            SQLiteConnection con = new SQLiteConnection(_conn);
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteTransaction trans = null;
            PrepareCommand(cmd, con, ref trans, false, commandType, commandText);
            try
            {
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reader;
        }

        /// <summary>
        /// Execute a database query, return a SqlDataReader object
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        /// <param name="commandText">Execute statement or stored procedure name</param>
        /// <param name="commandType">Execution type</param>
        /// <param name="cmdParms">SQL parameter object</param>
        /// <returns>SqlDataReader Object</returns>
        public DbDataReader ExecuteReader(string commandText, CommandType commandType, params SQLiteParameter[] cmdParms)
        {
            DbDataReader reader = null;
            if (string.IsNullOrEmpty(_conn))
                throw new ArgumentNullException("Connection string is missing.");
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException("commandText");

            SQLiteConnection con = new SQLiteConnection(_conn);
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteTransaction trans = null;
            PrepareCommand(cmd, con, ref trans, false, commandType, commandText, cmdParms);
            try
            {
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reader;
        }
        #endregion

        #region ExecuteDataSet
        /// <summary>
        /// Execute a database query, return a DataSet object
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        /// <param name="cmd">SqlCommand Object</param>
        /// <returns>DataSet Object</returns>
        public DataSet ExecuteDataSet(SQLiteCommand cmd)
        {
            DataSet ds = new DataSet();
            SQLiteConnection con = new SQLiteConnection(_conn);
            SQLiteTransaction trans = null;
            PrepareCommand(cmd, con, ref trans, false, cmd.CommandType, cmd.CommandText);
            try
            {
                SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd.Connection != null)
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                }
            }
            return ds;
        }

        /// <summary>
        /// Execute a database query, return a DataSet object
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        /// <param name="commandText">Execute statement or stored procedure name</param>
        /// <param name="commandType">Execution type</param>
        /// <returns>DataSet Object</returns>
        public DataSet ExecuteDataSet(string commandText, CommandType commandType)
        {
            if (string.IsNullOrEmpty(_conn))
                throw new ArgumentNullException("Connection string is missing.");
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException("commandText");
            DataSet ds = new DataSet();
            SQLiteConnection con = new SQLiteConnection(_conn);
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteTransaction trans = null;
            PrepareCommand(cmd, con, ref trans, false, commandType, commandText);
            try
            {
                SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            return ds;
        }

        /// <summary>
        /// Execute a database query, return a DataSet object
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        /// <param name="commandText">Execute statement or stored procedure name</param>
        /// <param name="commandType">Execution type</param>
        /// <param name="cmdParms">SQL parameter object</param>
        /// <returns>DataSet Object</returns>
        public DataSet ExecuteDataSet(string commandText, CommandType commandType, params SQLiteParameter[] cmdParms)
        {
            if (string.IsNullOrEmpty(_conn))
                throw new ArgumentNullException("Connection string is missing.");
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException("commandText");
            DataSet ds = new DataSet();
            SQLiteConnection con = null;
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteTransaction trans = null;
            try
            {
                con = new SQLiteConnection(_conn);
                PrepareCommand(cmd, con, ref trans, false, commandType, commandText, cmdParms);
                SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            return ds;
        }
        #endregion

        /// <summary>
        /// General paged query method
        /// </summary>
        /// <param name="connString">Connection string</param>
        /// <param name="tableName">Table Name</param>
        /// <param name="strColumns">Query field name</param>
        /// <param name="strWhere">Where condition</param>
        /// <param name="strOrder">Sorting condition</param>
        /// <param name="pageSize">Number of data per page</param>
        /// <param name="currentIndex">current page number</param>
        /// <param name="recordOut">Total data</param>
        /// <returns>DataTable data table</returns>
        public DataTable SelectPaging(string tableName, string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordOut)
        {
            DataTable dt = new DataTable();
            //Total number of queries
            string countSql = "select count(*) from " + tableName + " where {0}";
            countSql = String.Format(countSql, strWhere);

            recordOut = Convert.ToInt32(ExecuteScalar(countSql, CommandType.Text));
            //Pagination
            string pagingTemplate = "select {0} from {1} where {2} order by {3} limit {4} offset {5} ";
            int offsetCount = (currentIndex - 1) * pageSize;
            string commandText = String.Format(pagingTemplate, strColumns, tableName, strWhere, strOrder, pageSize.ToString(), offsetCount.ToString());
            using (DbDataReader reader = ExecuteReader(commandText, CommandType.Text))
            {
                if (reader != null)
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }

        /// <summary>
        /// Pre-processing the Command object, database link, transaction, object to be executed, parameters, etc.
        /// </summary>
        /// <param name="cmd">Command object</param>
        /// <param name="conn">Connection object</param>
        /// <param name="trans">Transcationobject</param>
        /// <param name="useTrans">Whether to use a transaction</param>
        /// <param name="cmdType">SQL string execution type</param>
        /// <param name="cmdText">SQL Text</param>
        /// <param name="cmdParms">SQLiteParameters to use in the command</param>
        private void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, ref SQLiteTransaction trans, bool useTrans, CommandType cmdType, string cmdText, params SQLiteParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (useTrans)
            {
                trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = trans;
            }


            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SQLiteParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
    }
}
