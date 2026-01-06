
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

IProductRepository repo = new DapperProductRepository(conn);

IDepartmentRepository departmentRepo = new DapperDepartmentRepository(conn);

departmentRepo.InsertDepartment("NewDept");

var departments = departmentRepo.GetAllDepartments();

foreach (var dept in departments)
{
    Console.WriteLine($"Department Name: {dept.Name}");
}

repo.CreateProduct("newStuff", 20, 1);

var products = repo.GetAllProducts();

foreach (var product in products)
{
    Console.WriteLine($"{product.ProductID} {product.Name}");
}