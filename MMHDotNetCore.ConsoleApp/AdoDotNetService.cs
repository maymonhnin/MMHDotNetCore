using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMHDotNetCore.ConsoleApp
{
    public class AdoDotNetService
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=MMHDotNetCore;User ID=sa;Password=sapw@#123";

        public void Read()
        {
            // max connection 100 => 100 - 99
            // (101 ယောက်က သုံးချင်တယ်ဆိုရင် တစ်ယောက်ကတော့ connection close ဖြစ်နေမှ ဝင်လို့ရမယ်
            // မဟုတ်ရင် connection timeout ဆိုပြီး ဖြစ်နေမယ် အဲ့ကြောင့် connection open, close လုပ်ရတာမျိုးတွေ လုပ်ပေးရတယ်
            // နောက်ပိုင်း Dapper, EFCore တို့မှာကျ auto connection open, close လုပ်ပေးတာမျိုးပါလာပြီ)


            // connection open တာတော့ ဟုတ်ပြီ ဘယ် connection ကို open တာလဲ?
            // ချိတ်မယ့် db connection ကို 
            // အဲ့တော့ Microsoft SQL Server Management Studio ကိုဖွင့် SQL Server connect လုပ် 


            // to check server name => select @@servername


            // connection create လုပ်တဲ့နေရာမှာ ကိုယ်ချိတ်ချင်တဲ့ connection ကို ဘယ်လို connect လုပ်မလဲ?
            // server name ကို Data Source နဲ့ခေါ် Data Source = .;
            // database name ကို Initial Catalog နဲ့ခေါ် 

            // connectionstring
            Console.WriteLine("connectionString: ", _connectionString);
            // connect to server
            SqlConnection connection = new SqlConnection(_connectionString);

            // connection open
            Console.WriteLine("Connection opening...");
            connection.Open();
            Console.WriteLine("Connection opened.");

            // sql query ရေးရတော့မယ် 
            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where DeleteFlag = 0";
            SqlCommand cmd = new SqlCommand(query, connection);
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["BlogID"]);
                Console.WriteLine(reader["BlogTitle"]);
                Console.WriteLine(reader["BlogAuthor"]);
                Console.WriteLine(reader["BlogContent"]);
            }


            // connection close
            Console.WriteLine("Connection closing...");
            connection.Close();
            Console.WriteLine("Connection closed.");

            // to show table result in console
            // Dataset => collection of table data
            // Dataset >> DataTable >> DataRow >> DataColumn
            //foreach (DataRow dr in dt.Rows)
            //{
            //    Console.WriteLine(dr["BlogID"]);
            //    Console.WriteLine(dr["BlogTitle"]);
            //    Console.WriteLine(dr["BlogAuthor"]);
            //    Console.WriteLine(dr["BlogContent"]);
            //    //Console.WriteLine(dr["DeleteFlag"]);
            //}
        }

        public void Create () {
            // parameter created
            Console.Write("Blog Title: ");
            string title = Console.ReadLine();

            Console.Write("Blog Author: ");
            string author = Console.ReadLine();


            Console.Write("Blog Content: ");
            string content = Console.ReadLine();


            // connectionString
            SqlConnection connection = new SqlConnection(_connectionString);

            // connection open
            connection.Open();

            // insert query
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent
           ,'0')";

            // sql command
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            // add parameters with value to sql command
            sqlCommand.Parameters.AddWithValue("@BlogTitle", title);
            sqlCommand.Parameters.AddWithValue("@BlogAuthor", author);
            sqlCommand.Parameters.AddWithValue("@BlogContent", content);

            // query execute in command
            int result = sqlCommand.ExecuteNonQuery();


            //SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);

            Console.WriteLine(result == 1 ? result + " row affected." : "Error in inserting row.");

            // connection close
            connection.Close();
        }

        public void Edit()
        {
            Console.Write("Blog Id: ");
            string id = Console.ReadLine();

            // connectionString
            SqlConnection connection = new SqlConnection(_connectionString);
            // connection open
            connection.Open();

            // edit query
            string query = @"SELECT [BlogId]
                  ,[BlogTitle]
                  ,[BlogAuthor]
                  ,[BlogContent]
                  ,[DeleteFlag]
              FROM [dbo].[Tbl_Blog] 
              where BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection); 

            cmd.Parameters.AddWithValue("@BlogId", id);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);  


            // connection close
            connection.Close();

            // column data ရှိမရှိ စစ် 
            if(dt.Rows.Count == 0)
            {
                Console.WriteLine("No Data Found!");
                return;
            }

            // column data ထုတ်ပြပေးဖို့ data row တစ်ခုဆောက်ပေး
            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["BlogID"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogAuthor"]);
            Console.WriteLine(dr["BlogContent"]);
        }

        public void Update()
        {
            // parameter created
            Console.Write("Blog Id that you want to update: ");
            string id = Console.ReadLine();

            Console.Write("Blog Title: ");
            string title = Console.ReadLine();

            Console.Write("Blog Author: ");
            string author = Console.ReadLine();


            Console.Write("Blog Content: ");
            string content = Console.ReadLine();

            Console.Write("Delete Flag: ");
            string delete_flag = Console.ReadLine();


            // connectionString
            SqlConnection connection = new SqlConnection(_connectionString);

            // connection open
            connection.Open();

            // update query
            string query = $@"UPDATE [dbo].[Tbl_Blog]
                               SET [BlogTitle] = @BlogTitle
                                  ,[BlogAuthor] = @BlogAuthor
                                  ,[BlogContent] = @BlogContent
                                  ,[DeleteFlag] = @DeleteFlag
                             WHERE BlogId = @BlogId";

            // sql command
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            // add parameters with value to sql command
            sqlCommand.Parameters.AddWithValue("@BlogId", id);

            sqlCommand.Parameters.AddWithValue("@BlogTitle", title);
            sqlCommand.Parameters.AddWithValue("@BlogAuthor", author);
            sqlCommand.Parameters.AddWithValue("@BlogContent", content);
            sqlCommand.Parameters.AddWithValue("@DeleteFlag", delete_flag);

            
            // query execute in command
            int result = sqlCommand.ExecuteNonQuery();


            Console.WriteLine(result == 1 ? result + " row affected." : "Error in updating data.");

            // connection close
            connection.Close();
        }

        public void Delete()
        {
            Console.Write("Blog Id that you want to delete: ");
            string id = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            // query for delete_flag
            string query = $@"UPDATE [dbo].[Tbl_Blog]
                               SET [DeleteFlag] = @DeleteFlag
                             WHERE BlogId = @BlogId";

            // delete query
            //string query = @"DELETE FROM [dbo].[Tbl_Blog]
            //                WHERE BlogID= @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);

            Console.Write("Delete Flag: ");
            string delete_flag = Console.ReadLine();
            // add parameter to delete flag with value
            cmd.Parameters.AddWithValue("@DeleteFlag", delete_flag);

            // query execute in command
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine(result);

            // connection close
            connection.Close();

            // deleted column data ရှိမရှိ စစ် 
            Console.WriteLine(result == 0 ? "Delete process failed!" : "BlogID " + id + " is deleted successfully!");
            
        }
    }
}
