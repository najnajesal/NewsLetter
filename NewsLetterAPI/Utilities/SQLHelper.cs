using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NewsLetterAPI.Utilities
{
    [Serializable]
    public enum ConnectionStrings
    {
      NewsLetter
    }

    public class SQLHelper : IDisposable
    {
        public SQLHelper()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private SqlConnection connection;
        private SqlCommand command;

        public int ConnectionTimeout
        {
            get { return command.CommandTimeout; }
            set { command.CommandTimeout = value; }
        }

        public SqlParameterCollection Parameters
        {
            get { return command.Parameters; }
        }

        public static string ConnectionString(ConnectionStrings conn)
        {
            switch (conn)
            {
                case ConnectionStrings.NewsLetter:
                    return Utility.GetConnectionString(ConnectionStrings.NewsLetter).ConnectionString;

              
                default:
                    return "";
            }
        }

        public SQLHelper(ConnectionStrings conn, int connTimeout = 30)
        {
            Initialize(conn, connTimeout);
        }

        public void Initialize(ConnectionStrings conn, int connTimeout)
        {
            string connString = "";

            try
            {
                connString = SQLHelper.ConnectionString(conn);
            }
            catch
            {
            }

            connection = new SqlConnection(connString);
            command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = connTimeout;
        }

        public int ExecuteNonQuery(string commandText, CommandType commandType)
        {
            command.CommandText = commandText;
            command.CommandType = commandType;
            int recordsAffected = 0;
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                command.Connection = connection;
                recordsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Kill();
                throw ex;
            }

            return recordsAffected;
        }

        public object ExecuteScalar(string commandText, CommandType commandType)
        {
            command.CommandText = commandText;
            command.CommandType = commandType;
            object result;
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                command.Connection = connection;
                result = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Kill();
                throw ex;
            }

            return result;
        }

        public SqlDataReader ExecuteReader(string commandText, CommandType commandType)
        {
            command.CommandText = commandText;
            command.CommandType = commandType;
            SqlDataReader reader;
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                command.Connection = connection;
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                Kill();
                throw ex;
            }

            return reader;
        }

        public DataSet ReturnDataSet(string commandText, CommandType commandType)
        {
            command.CommandText = commandText;
            command.CommandType = commandType;
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                command.Connection = connection;
                da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                Kill();
                throw ex;
            }

            return ds;
        }

        public DataTable ReturnDataTable(string commandText, CommandType commandType)
        {
            command.CommandText = commandText;
            command.CommandType = commandType;
            SqlDataAdapter da;
            DataTable ds = new DataTable();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                command.Connection = connection;
                da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                Kill();
                throw ex;
            }

            return ds;
        }

        public void Kill()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
            command.Dispose();
        }

        public void Dispose()
        {
            if (connection.State != ConnectionState.Closed) connection.Close();
            connection.Dispose();
            command.Dispose();
        }
        //Check a column exist or not

    }

    public static class SqlHelperExtensions
    {
        private static StreamWriter logFile;

        public static bool IsColumnExists(this DataRow row, string column)
        {
            if (!row.Table.Columns.Contains(column))
            {
                //Create_Log(row.Table.Columns.Contains(column) ? "Yes-->" + column : "No-->" + column);
            }
            return row.Table.Columns.Contains(column) ? (row[column] != DBNull.Value ? true : false) : false;
        }
        public static void Create_Log(string Message, Exception ex = null)
        {
            string logFilePath = HttpContext.Current.Server.MapPath("~/Log/log.txt");
            try
            {
                logFile = new StreamWriter(logFilePath, true);
                logFile.WriteLine(DateTime.Now + "\t\t" + Message);
                // if (ex != null) Utility.SendErrorNotification("SqlHelperOnlineTest", "", HttpContext.Current.Request.Url.ToString(), ex, Message);
                logFile.Close();
            }

            catch (Exception exs)
            {
            }
            finally
            {
                if (logFile != null)
                    logFile.Dispose();
            }
        }
    }
}
