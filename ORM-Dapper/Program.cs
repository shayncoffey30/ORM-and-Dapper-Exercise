
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_Dapper;
using System.Data;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

#region Department Section  
//var departmentRepo = new ORM_Dapper.DapperDepartmentRepository(conn);

//departmentRepo.InsertDepartment("Isaaks new Department");

//var departments = departmentRepo.GetAllDepartments();

//foreach (var department in departments)
//{
//    Console.WriteLine(department.DepartmentId);
//    Console.WriteLine(department.Name);
//    Console.WriteLine();
//    Console.WriteLine();
//}
#endregion

var productRepository = new DapperProductRepository(conn);
var products = productRepository.GetAllProducts();
foreach (var product in products)
{
    Console.WriteLine(product.ProductID);
    Console.WriteLine(product.Name);
    Console.WriteLine(product.Price);
    Console.WriteLine(product.CategoryID);
    Console.WriteLine(product.StockLevel);
    Console.WriteLine();
    Console.WriteLine();
}