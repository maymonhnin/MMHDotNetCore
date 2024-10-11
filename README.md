# MMHDotNetCore

## Day1 Notes

> Microsoft SQL Server Management Studio ကိုဖွင့် SQL Server connect လုပ်နည်း
>
>> - Server Type - Database Engine
>> - Server Name - .
>> - Authentication - SQL Server Authentication
>> - Login - sa
>> - Password - sa....
>> - Trust server certificate ကို check ခဲ့ 
ပြီးရင် connect လိုက်ရင် ရပြီ

### Day1 Lessons
C# .NET

C# => Language 

.NET => framework

C# 
- Console App
- Window Forms
- ASP.NET Core Web API 
- ASP.NET Core Web MVC
- Blazor Web Assembly
- Blazor Web Server


1. .NET framework (1, 2, 3, 3.5, 4, 4.5, 4.6, 4.7, 4.8) windows
2. .NET Core (1, 2, 2.2, 3, 3.1) vs2019, vs2022 - window, linux, macos
3. .NET (5 - vs2019, 6 - vs2022), 7, 8 - window, linux, macos

vscode

visual studio 2022



windows

**UI + Business Logic + Data Access => Database**

Eg; kpay

mobile no => transfer

mobile no check => 10000

SLH -> Collin

1. SLH (-10000)
2. Collin (+10000)
-------------------------------------------------------------------
## Day2 Lesson Notes

C# <=> Database

- ADO.NET
- Dapper (ORM) //Ado.net ရဲ့ upgrade version (code  တွေချုံသွားတယ် ရေးရတာရှင်းတယ် ခေါ်ရတာလွယ်တယ်)  
- EFCore //Entity Framework (ORM) //microsoft က ထုတ်သွားပေးတာ နောက်ဆုံး EFCore ကို သုံးပြီး CRUD လုပ်ကြတော့တယ်

>ORM (Object Relational Mapping)
>
>> Object-relational mapping (ORM) is a way to align programming code with database structures. ORM uses metadata descriptors to create a layer between the programming language and a relational database.


> ORM ဆိုတာ 
>
>> C# code နဲ့ Database table နဲ့ ကိုက်ညီအောင် mapping ချပေးထားတာမျိုး
(C# code နဲ့ CRUD code တွေလို ရေးသွားတာတွေကို sql query အဖြစ် map သွားလုပ်ပေးတာမျိုး)

-----------------------------------------------
frontend မှာလို package - npm လိုမျိုး

**C# မှာ package - nuget သုံးတယ်**

1. project အပေါ်မှာ right click ထောက် Manage NuGet packages...
2. Browse ထဲကနေ (System.Data.SqlClient) ကို Search လုပ် Install ဆွဲ
	- Project ထဲက Packages ထဲကနေ သွားကြည့်လို့ရ 
	 //(Remove လုပ်ချင်တယ်ဆိုရင် package ပေါ်ကနေ Remove လို့လဲရ, Manage nuget ကနေလဲ Uninstall လုပ်လို့ရ)

#### To connect Database connection
- create SqlConnection
- connection open
- connection close

> connection open ပြီးရင် ဘာကြောင့် close ဖို့လိုတာလဲ?
>
>> max connection 100 => 100 - 99
(101 ယောက်က သုံးချင်တယ်ဆိုရင် တစ်ယောက်ကတော့ connection close ဖြစ်နေမှ ဝင်လို့ရမယ်
မဟုတ်ရင် connection timeout ဆိုပြီး ဖြစ်နေမယ် အဲ့ကြောင့် connection open, close လုပ်ရတာမျိုးတွေ လုပ်ပေးရတယ်
နောက်ပိုင်း Dapper, EFCore တို့မှာကျ auto connection open, close လုပ်ပေးတာမျိုးပါလာပြီ)


#### connection open တာတော့ ဟုတ်ပြီ ဘယ် connection ကို open တာလဲ?
- ချိတ်မယ့် db connection ကို 
- အဲ့တော့ Microsoft SQL Server Management Studio ကိုဖွင့် SQL Server connect လုပ် 


**To check server name => ```select @@servername```**


#### connection create လုပ်တဲ့နေရာမှာ ကိုယ်ချိတ်ချင်တဲ့ connection ကို ဘယ်လို connect လုပ်မလဲ?
**connection string နဲ့ connect လုပ်မယ်**
- server name ကို Data Source နဲ့ခေါ် //```Data Source = .;```
- database name ကို Initial Catalog နဲ့ခေါ် //```Initial Catalog=databasename;```
- User ID က **server login username**
- Password က **server password**

*how to change password ?* 
(Server >> Security >> Login >> login username ရဲ့ right click > Properties ကနေ password ချိန်း)

// connectionstring
```
string connectionString = "Data Source=.;Initial Catalog=MMHDotNetCore;User ID=sa;Password=sapw@#123";
Console.WriteLine("connectionString: ", connectionString);
```

// connect to server
```SqlConnection connection = new SqlConnection(connectionString);```

// connection open
```
Console.WriteLine("Connection opening...");
connection.Open();
Console.WriteLine("Connection opened.");
```

// sql query ရေးရတော့မယ် 
```
string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where DeleteFlag = 0";
```
  *query ကို db server ထဲ query execute အရင်လုပ်ပြီးမှ ထည့်သုံးကြည့် (issue ကင်းအောင်)*

// sql command ဖွင့် (ကိုယ် open လုပ်မယ့် db connection, execute လုပ်မယ့် query တို့ကို သုံးပြီးတော့ )
```
SqlCommand cmd = new SqlCommand(query, connection);
```

// table ထည့်ဖို့အတွက် adapter ‌ဆောက်, အလုပ်လုပ်မယ့် command ထည့်, datatable ဆောက်, adapter ထဲကို datatable ထည့်
```
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
adapter.Fill(dt);
```

*connection မပိတ်ခင်မှာ data record တစ်ကြောင်းချင်းစီ (query တစ်ကြောင်းချင်းစီ) read လုပ်တာ ပိုပြီး performance ကောင်းတယ် ( အဲ့လို မဟုတ်ဘဲ connection ပိတ်ပြီးမှ data table တစ်ခုလုံး ထုတ်ပြရင် connection timeout issue ဖြစ်နိုင်)* 
```
SqlDataReader reader = cmd.ExecuteReader();
while (reader.Read())
{
    Console.WriteLine(reader["BlogID"]);
    Console.WriteLine(reader["BlogTitle"]);
    Console.WriteLine(reader["BlogAuthor"]);
    Console.WriteLine(reader["BlogContent"]);
}
```
// connection close
```
Console.WriteLine("Connection closing...");
connection.Close();
Console.WriteLine("Connection closed.");
```

> to show table result in console
>
>> Dataset (collection of table data) >> DataTable >> DataRow >> DataColumn
```
foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine(dr["BlogID"]);
    Console.WriteLine(dr["BlogTitle"]);
    Console.WriteLine(dr["BlogAuthor"]);
    Console.WriteLine(dr["BlogContent"]);
    //Console.WriteLine(dr["DeleteFlag"]);
}
```

-----------------------------------------------------------------------

##