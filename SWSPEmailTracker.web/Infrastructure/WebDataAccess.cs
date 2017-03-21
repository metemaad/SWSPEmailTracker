using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace SWSPEmailTracker.web.Infrastructure
{
    public static class DataTableExtensions
    {
        public static IList<T> ToList<T>(this DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            IList<T> result = new List<T>();

            foreach (var row in table.Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, properties);
                result.Add(item);
            }

            return result;
        }

        public static IList<T> ToList<T>(this DataTable table, Dictionary<string, string> mappings) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            IList<T> result = new List<T>();

            foreach (var row in table.Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, properties, mappings);
                result.Add(item);
            }

            return result;
        }

        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();
            foreach (var property in properties)
            {
                property.SetValue(item, row[property.Name], null);
            }
            return item;
        }

        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties, Dictionary<string, string> mappings) where T : new()
        {
            T item = new T();
            foreach (var property in properties)
            {
                if (mappings.ContainsKey(property.Name))
                    property.SetValue(item, row[mappings[property.Name]], null);
            }
            return item;
        }
    }
    public class WebDataAccess
    {
        private string _connectionString;
        private int connectiontimeout=int.MaxValue;
        public WebDataAccess()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["SWSPDBWeb"].ConnectionString;
            connection = new MySqlConnection(_connectionString);
           OpenConnection();
        }
        public DataTable GetTable(IDataReader _reader)
        {
            DataTable dataTable1 = _reader.GetSchemaTable();
            DataTable dataTable2 = new DataTable();
            string[] arrayList = new string[dataTable1.Rows.Count];
            for (int i = 0; i < dataTable1.Rows.Count; i++)
            {
                DataColumn dataColumn = new DataColumn();
                if (!dataTable2.Columns.Contains(dataTable1.Rows[i][0].ToString()))
                {
                    dataColumn.ColumnName = dataTable1.Rows[i][0].ToString();
                    //dataColumn.Unique = Convert.ToBoolean(dataTable1.Rows[i]["IsUnique "]);
                    //dataColumn.AllowDBNull = Convert.ToBoolean(dataTable1.Rows[i]["AllowDBNull "]);
                    //dataColumn.ReadOnly = Convert.ToBoolean(dataTable1.Rows[i]["IsReadOnly "]);
                    dataColumn.DataType = (Type)dataTable1.Rows[i][11];
                    arrayList[i] = dataColumn.ColumnName;
                    dataTable2.Columns.Add(dataColumn);
                }
            }
            dataTable2.BeginLoadData();
            while (_reader.Read())
            {
                DataRow dataRow = dataTable2.NewRow();
                for (int j = 0; j < arrayList.Length; j++)
                {
                    dataRow[arrayList[j]] = _reader[arrayList[j]];
                }
                dataTable2.Rows.Add(dataRow);
            }
            _reader.Close();
            dataTable2.EndLoadData();
            return dataTable2;
        }
        public DataTable Populate(string query)
        {

            DataTable ret;

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
              //  cmd.CommandTimeout = connectiontimeout;
                //Create a data reader and Execute the command
            //connection.Open();
                MySqlDataReader dataReader = cmd.ExecuteReader();
                ret = GetTable(dataReader);
                //Read the data and store them in the list




                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return ret;
            }
            else
            {
                return null;
            }


        }
        public bool Exec(string command)
        {
            bool res = false;
            if (this.OpenConnection() == true)
            {

                using (MySqlCommand cmd = connection.CreateCommand())
                using (MySqlTransaction xt = connection.BeginTransaction())
                {
                    cmd.CommandTimeout = connectiontimeout;
                    cmd.Connection = connection;
                    cmd.Transaction = xt;
                    try
                    {
                        cmd.CommandText = command;
                        cmd.ExecuteNonQuery();
                        xt.Commit();
                        this.CloseConnection();
                        res = true;
                    }
                    catch
                    {
                        xt.Rollback();
                        res = false;
                    }
                }
            }

            return res;
        }

        public DataTable ExecQ(string command)
        {
            DataTable res = null;
            if (this.OpenConnection() == true)
            {

                using (MySqlCommand cmd = connection.CreateCommand())
                using (MySqlTransaction xt = connection.BeginTransaction())
                {
                    cmd.CommandTimeout = connectiontimeout;       
                    cmd.Connection = connection;
                    cmd.Transaction = xt;
                    try
                    {
                        
                        cmd.CommandText = command;
                        var reader=cmd.ExecuteReader();

                        res = GetTable(reader);
                        reader.Close();
                        
                        xt.Commit();

                        this.CloseConnection();
                        
                    }
                    catch
                    {
                        xt.Rollback();
                        res = null;
                    }
                }
            }

            return res;
        }
        public DataTable ExecP(string command, MySqlParameter parameter)
        {
            DataTable res = null;
            if (this.OpenConnection() == true)
            {

                using (MySqlCommand cmd = connection.CreateCommand())
                using (MySqlTransaction xt = connection.BeginTransaction())
                {
                    //cmd.CommandTimeout = connectiontimeout;
                    cmd.Connection = connection;
                    cmd.Transaction = xt;
                    try
                    {
                        cmd.CommandTimeout = int.MinValue;

                        cmd.CommandText = command;
                        //cmd.Parameters.Add(new MySqlParameter("@a",MySqlDbType.Guid,));
                        cmd.Parameters.Add(parameter);
                        cmd.ExecuteNonQuery();

                        //res = GetTable(reader);
                        //reader.Close();

                        xt.Commit();

                        this.CloseConnection();

                    }
                    catch (Exception exception)
                    {
                        xt.Rollback();
                        res = null;
                    }
                }
            }

            return res;
        }
        public DataTable ExecQP(string command,MySqlParameter parameter)
        {
            DataTable res = null;
            if (this.OpenConnection() == true)
            {

                using (MySqlCommand cmd = connection.CreateCommand())
                using (MySqlTransaction xt = connection.BeginTransaction())
                {
                    //cmd.CommandTimeout = connectiontimeout;
                    cmd.Connection = connection;
                    cmd.Transaction = xt;
                    try
                    {
                        cmd.CommandTimeout = int.MinValue;

                        cmd.CommandText = command;
                        //cmd.Parameters.Add(new MySqlParameter("@a",MySqlDbType.Guid,));
                        cmd.Parameters.Add(parameter);
                        var reader = cmd.ExecuteReader();

                        res = GetTable(reader);
                        reader.Close();

                        xt.Commit();

                        this.CloseConnection();

                    }
                    catch(Exception exception)
                    {
                        xt.Rollback();
                        res = null;
                    }
                }
            }

            return res;
        }

        public DataTable ExecQP2(string command, MySqlParameter parameter, MySqlParameter parameter2)
        {
            DataTable res = null;
            if (this.OpenConnection() == true)
            {

                using (MySqlCommand cmd = connection.CreateCommand())
                using (MySqlTransaction xt = connection.BeginTransaction())
                {
                    cmd.CommandTimeout = connectiontimeout;
                    cmd.Connection = connection;
                    cmd.Transaction = xt;
                    try
                    {

                        cmd.CommandText = command;
                        cmd.Parameters.Add(parameter);
                        cmd.Parameters.Add(parameter2);
                        var reader = cmd.ExecuteReader();

                        res = GetTable(reader);
                        reader.Close();

                        xt.Commit();

                        this.CloseConnection();

                    }
                    catch
                    {
                        xt.Rollback();
                        res = null;
                    }
                }
            }

            return res;
        }


        private MySqlConnection connection;
        private bool OpenConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Closed)
                {
                    return true;
                }
               
                
                connection.ConnectionString = _connectionString;
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Closed)
                {

                    connection.Close();
                    return true;
                }else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
