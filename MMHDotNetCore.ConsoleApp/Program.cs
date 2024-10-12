// See https://aka.ms/new-console-template for more information
using MMHDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
Console.ReadLine();

// Day2, 3 (ADO.NET Select, Insert)

AdoDotNetService adoDotNetService = new AdoDotNetService();
//adoDotNetService.Read();

//adoDotNetService.Create();

//adoDotNetService.Edit();

//adoDotNetService.Update();

adoDotNetService.Delete();


Console.ReadKey();