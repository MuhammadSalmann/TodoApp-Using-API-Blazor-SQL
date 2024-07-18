using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDal
{
    public class DBConn
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection("Your Connection String");
            return conn;
        }
    }
}
