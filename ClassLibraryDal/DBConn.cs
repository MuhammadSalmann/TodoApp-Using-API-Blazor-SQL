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
            SqlConnection conn = new SqlConnection("Data Source=SALMAN\\SQLEXPRESS;Initial Catalog=db_todo;Integrated Security=True;");
            return conn;
        }
    }
}
