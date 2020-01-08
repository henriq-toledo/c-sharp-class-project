using System;
using CSharpClassProject.EmployeesRegister.Classes.Data;
using CSharpClassProject.EmployeesRegister.Classes.Entities;

namespace CSharpClassProject.EmployeesRegister
{
    class Program
    {
        static void Main(string[] args)
        {            
            CreateTester();
            CreateDeveloper();
            
            // Repository.InitializeData();

            Console.Clear();

            foreach(var employee in Repository.Employees)
            {
                Console.WriteLine(employee.GetInformation());
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private static void CreateTester()
        {
            Console.Clear();

            Console.WriteLine("Add the tester");
            Console.WriteLine();
            Console.Write("Type the name:");
            var name = Console.ReadLine();
            
            Console.Write("Type the company name:");
            var companyName = Console.ReadLine();
            var id = Repository.Employees.Count + 1;

            Console.WriteLine();

            var tester = new Tester(name, companyName, id);
            Repository.Employees.Add(tester);
        }

        private static void CreateDeveloper()
        {
            Console.Clear();

            Console.WriteLine("Add the developer");
            Console.WriteLine();
            Console.Write("Type the name:");
            var name = Console.ReadLine();
            
            Console.Write("Type the company name:");
            var companyName = Console.ReadLine();
            var id = Repository.Employees.Count + 1;

            Console.WriteLine();

            var developer = new Developer(name, companyName, id);
            Repository.Employees.Add(developer);
        }
    }
}
