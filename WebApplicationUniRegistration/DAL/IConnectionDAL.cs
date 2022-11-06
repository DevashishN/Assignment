using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationUniRegistration.DAL
{
    public interface IConnectionDAL
    {
        void OpenConnection();
        void CloseConnection();
        DataTable Query(string query, List<SqlParameter> parameters);
        int Insert(string query, List<SqlParameter> parameters);
    }
}
