using ClassLibraryModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDal
{
    public class TodoDal
    {
        public static void Insert(TodoModel todo)
        {
            SqlConnection con = DBConn.GetConnection();
            Console.WriteLine("Connection Open\n");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert_Func", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@description", todo.Descript);
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Connection Closed\n");
        }
        public static void DeleteData(TodoModel todo)
        {
            SqlConnection con = DBConn.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete_Func", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@todoID", todo.TodoID);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static List<TodoModel> GetData()
        {
            SqlConnection con = DBConn.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Get_Func", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<TodoModel> listtodo = new List<TodoModel>();
            while (reader.Read())
            {
                TodoModel model = new TodoModel();
                model.TodoID = Convert.ToInt32(reader["TodoID"]);
                model.Descript = reader["Descript"].ToString();
                listtodo.Add(model);
            }
            con.Close();
            return listtodo;
        }
        public static void UpdateData(TodoModel todo)
        {
            SqlConnection con = DBConn.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Update_Func", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@description", todo.Descript);
            cmd.Parameters.AddWithValue("@todoID", todo.TodoID);
            cmd.ExecuteNonQuery();
            con.Close();
        }


    }
}
