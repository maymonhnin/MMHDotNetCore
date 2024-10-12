# MMHDotNetCore

## Day1 Notes

#### Microsoft SQL Server Management Studio ကိုဖွင့် SQL Server connect လုပ်နည်း
> - Server Type - Database Engine
> - Server Name - .
> - Authentication - SQL Server Authentication
> - Login - sa
> - Password - sa....
> - Trust server certificate ကို check ခဲ့ 
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


**UI + Business Logic + Data Access => Database**

-------------------------------------------------------------------
## Day2 Lesson Notes

C# <=> Database

- ADO.NET
- Dapper (ORM)  
- EFCore //Entity Framework (ORM) 

------------------------------

frontend မှာလို package - npm လိုမျိုး

**C# မှာ package - nuget သုံးတယ်**
---------------------

### To connect Database connection
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

### Select Query

1. create connectionstring

2. create sqlconnection with connectionstring

3. connection open, close

4. create query for select query

*query ကို db server ထဲ query execute အရင်လုပ်ပြီးမှ ထည့်သုံးကြည့် (issue ကင်းအောင်)*

5. create sqlCommand with querySelect and connectionString


6. Data Display to console *(WayA)*
    1. create SqlDataAdapter with sqlcommand
    2. create DataTable and fill it to SqlDataAdapter

*table ထည့်ဖို့အတွက် adapter ‌ဆောက်, အလုပ်လုပ်မယ့် command ထည့်, datatable ဆောက်, adapter ထဲကို datatable ထည့်*

*connection မပိတ်ခင်မှာ data record တစ်ကြောင်းချင်းစီ (query တစ်ကြောင်းချင်းစီ) WayB နည်းအတိုင်း read လုပ်တာ ပိုပြီး performance ကောင်းတယ် ( အဲ့လို မဟုတ်ဘဲ connection ပိတ်ပြီးမှ data table တစ်ခုလုံး ထုတ်ပြရင် WayA နည်းအတိုင်း လုပ်ရင် connection timeout issue ဖြစ်နိုင်)* 

6. Data Display to console (record line by line) *(WayB)*
    1. sqlcommand အလိုက် SqlDataReader နဲ့ ExecuteReader() လုပ်
    2. reader.Read() ကို loop ပတ်ပြီး data result display ပြ 

6. Data Display to console *(WayA)*
    3. to show table result in console
> Dataset (collection of table data) >> DataTable >> DataRow >> DataColumn


-----------------------------------------------------------------------
## Day3 Lesson Notes

### Insert Query

1. parameter created

2. create connectionString, connection open and close
3. create queryInsert for insert query

4. create sqlCommand with queryInsert  and connectionString
5. add parameters with value to sql command

6. execute query (using ExecuteNonQuery()) as command

7. display result in console

------------------------------
### Select with ID Query


2. create connectionString, connection open and close
3. create query for select with ID 

4. create sqlCommand with query and connectionString
5. add parameters with value to sql command

6. create adapter and table to display in console
    1. create SqlDataAdapter with sqlcommand
    2. create DataTable and fill it to SqlDataAdapter

*table ထည့်ဖို့အတွက် adapter ‌ဆောက်, အလုပ်လုပ်မယ့် command ထည့်, datatable ဆောက်, adapter ထဲကို datatable ထည့်*


7. column data ရှိမရှိ စစ် 


8. display result as table in console
*column data ထုတ်ပြပေးဖို့ data row တစ်ခုဆောက်ပေး*
------------------------------
### Update Query

1. create parameters for ID that you want to update

2. create connectionString and open/close connection
3. create updateQuery for update with ID 

4. create sqlCommand with query  and connectionString
5. add parameters with value to sql command


6. execute query (using ExecuteNonQuery()) as command

7. display result in console (deleted_column ရှိမရှိစစ်ရှိမရှိစစ်)

------------------------------
### Delete Query

#### Delete Query
1. create parameter for ID that you want to delete


2. create connectionString and open/close connection
3. create deleteQuery for delete ID


4. create sqlCommand with query  and connectionString
5. add parameters with value to sql command

6. execute query in command

7. display result in console
    1. deleted column data ရှိမရှိ စစ်


#### Query for delete_flag
1. create parameter for ID that you want to delete


2. create connectionString and open/close connection
3. create deleteQuery for delete ID


4. create sqlCommand with query  and connectionString
5. add parameters with value to sql command


6. execute query in command

7. display result in console (deleted_column ရှိမရှိစစ်)
