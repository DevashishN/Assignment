﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationUniRegistration.DAL.DataAccessLayer
{
    public class ConnectionDAL : IConnectionDAL
    {
        private SqlConnection connection;

        public void OpenConnection()
        {
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                connection.Open();
            }
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                throw;
            }

            CloseConnection();
            return data;
        }
        public int Insert(string query, List<SqlParameter> parameters)
        {
            OpenConnection();
           

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

                    return command.ExecuteNonQuery();

                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();

            }
        }

    }
}