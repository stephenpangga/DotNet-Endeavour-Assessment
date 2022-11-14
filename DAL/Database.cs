using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class Database
    {
        private MySqlConnection conn;

        private MySqlDataAdapter adapter;


        public Database()
        {
            conn = new MySqlConnection("Server=localhost;User ID=root;Password='';Database=endeavour1;Convert Zero Datetime=True");

            adapter = new MySqlDataAdapter();

        }

        protected MySqlConnection OpenConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed || conn.State == System.Data.ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }

        private void CloseConnection()
        {
            conn.Close();
        }

        public DataTable ExecuteSelectQuery(string query, params MySqlParameter[] sqlParameters)
        {
            MySqlCommand command = new MySqlCommand();
            DataTable dataTable;
            DataSet dataSet = new DataSet();

            try
            {
                command.Connection = OpenConnection();
                command.CommandText = query;
                command.Parameters.AddRange(sqlParameters);
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                adapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];

            }
            catch (MySqlException e)
            {
                return null;
                throw e;
            }
            finally
            {
                CloseConnection();
            }
            return dataTable;
        }

        public void ExecuteEditQuery(string query, MySqlParameter[] sqlParameters)
        {
            MySqlCommand command = new MySqlCommand();

            try
            {
                command.Connection = OpenConnection();
                command.CommandText = query;
                command.Parameters.AddRange(sqlParameters);
                adapter.InsertCommand = command;
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                throw e;
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// This method is a special method where when a new credit card data is instert returns the id.
        /// so that this id can be placed with the user data credit card column.
        /// </summary>
        public int InsertCreditCard(string query, params MySqlParameter[] sqlParameters)
        {
            MySqlCommand command = new MySqlCommand();

            try
            {
                command.Connection = OpenConnection();
                command.CommandText = query;
                command.Parameters.AddRange(sqlParameters);
                adapter.InsertCommand = command;
                return Convert.ToInt32(command.ExecuteScalar());
            }
            catch (MySqlException e)
            {
                throw e;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
