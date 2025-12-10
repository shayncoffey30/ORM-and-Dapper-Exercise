
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

var departmentRepo = new ORM_Dapper.DapperDepartmentRepository(conn);

departmentRepo.InsertDepartment("Anthonys new Department");

var departments = departmentRepo.GetAllDepartments();

foreach (var department in departments)
{
    Console.WriteLine(department.DepartmentId);
    Console.WriteLine(department.Name);
    Console.WriteLine();
    Console.WriteLine();
}