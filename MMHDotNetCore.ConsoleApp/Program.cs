// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
Console.ReadLine();

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
string connectionString = "Data Source=.;Initial Catalog=MMHDotNetCore;User ID=sa;Password=sapw@#123";
Console.WriteLine("connectionString: ", connectionString);
// connect to server
SqlConnection connection = new SqlConnection(connectionString);

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

Console.ReadKey();