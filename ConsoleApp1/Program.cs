using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int DepId { get; set; }
}

class Department
{
    public int Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
}

class Program
{
    static void Main()
    {
        List<Department> departments = new List<Department>()
        {
            new Department(){ Id = 1, Country = "Ukraine", City = "Odesa" },
            new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
            new Department(){ Id = 3, Country = "France", City = "Paris" },
            new Department(){ Id = 4, Country = "Ukraine", City = "Lviv" }
        };

        List<Employee> employees = new List<Employee>()
        {
            new Employee() { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
            new Employee() { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
            new Employee() { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
            new Employee() { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
            new Employee() { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
            new Employee() { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
            new Employee() { Id = 7, FirstName = "Nikita", LastName = "Krotov", Age = 27, DepId = 4 }
        };

        // Сотрудники из Украины, отсортированные по имени и фамилии
        var ukrEmployees = (from e in employees
                            join d in departments on e.DepId equals d.Id
                            where d.Country.Trim() == "Ukraine"
                            orderby e.FirstName, e.LastName
                            select e).ToList();

        Console.WriteLine("Сотрудники в Украине (по алфавиту):");
        foreach (var emp in ukrEmployees)
            Console.WriteLine($"{emp.FirstName} {emp.LastName}");

        // Сортировка сотрудников по возрасту (по убыванию)
        var sortByAge = (from e in employees
                         orderby e.Age descending
                         select new { e.Id, e.FirstName, e.LastName, e.Age }).ToList();

        Console.WriteLine("\nСотрудники по возрастам (убывание):");
        foreach (var emp in sortByAge)
            Console.WriteLine($"Id: {emp.Id}, {emp.FirstName} {emp.LastName}, Age: {emp.Age}");

        // Группировка сотрудников по возрасту
        var groupByAge = (from e in employees
                          group e by e.Age into g
                          select new { Age = g.Key, Count = g.Count() }).ToList();

        Console.WriteLine("\nСотрудники, сгруппированные по возрасту:");
        foreach (var group in groupByAge)
            Console.WriteLine($"Age: {group.Age}, Count: {group.Count}");
    }
}
