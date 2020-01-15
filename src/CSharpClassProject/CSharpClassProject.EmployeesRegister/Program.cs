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
            //CreateDeveloper();

            Repository.ShowData();
            
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
            string framework;

            do
            {
                Console.WriteLine("Type the framework:");
                framework = Console.ReadLine();

                tester.AddFramework(framework);
            }
            while(framework != "99");

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
