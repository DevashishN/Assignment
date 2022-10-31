using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationUniRegistration.DAL
{
    public class ConnectionDAL : IConnectionDAL
    {
        private const string connectionstring = @"server=localhost;database=StudentRegistration;uid=wbpoc;pwd=sql@tfs2008";

        private SqlConnection connection;

        public void OpenConnection()
        {
            try
            {
                connection = new SqlConnection(connectionstring);
                connection.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void CloseConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
        }

        public DataTable Query(string query, List<SqlParameter> parameters)
        {
            OpenConnection();
            DataTable data = new DataTable();
            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    if (parameters != null)
                    {
                        parameters.ForEach(parameter =>
                        {
                            command.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                        });
                    }
                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        sda.Fill(data);
                    }

                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            CloseConnection();
            return data;
        }

    }
}