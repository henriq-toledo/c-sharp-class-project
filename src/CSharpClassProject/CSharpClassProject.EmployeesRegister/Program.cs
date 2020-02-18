using System;
using System.Linq;
using CSharpClassProject.EmployeesRegister.Classes.Data;
using CSharpClassProject.EmployeesRegister.Classes.Entities;
using CSharpClassProject.EmployeesRegister.Enums;

namespace CSharpClassProject.EmployeesRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateTester();
            //CreateDeveloper();
            Repository.InitializeData();
            Repository.ShowData();
            Repository.SaveData();

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
            string input;

            var enumValues = Enum.GetValues(typeof(TestFrameworksEnum))
                    .OfType<TestFrameworksEnum>();

            do
            {
                Console.WriteLine("Type the framework (99 - to exit):");

                foreach (var item in enumValues)
                {
                    Console.WriteLine($"{item.GetHashCode()}-{item.ToString()}");
                }

                input = Console.ReadLine();
                TestFrameworksEnum testFramework;

                var existValue = enumValues
                    .Any(s => s.GetHashCode().ToString() == input);

                Console.Clear();

                if (existValue == false)
                {
                    Console.WriteLine("Invalid value, please type again.");
                    Console.WriteLine();
                }
                else
                {
                    testFramework = (TestFrameworksEnum)
                        Enum.Parse(typeof(TestFrameworksEnum), input);

                    if (input != "99")
                    {
                        tester.AddFramework(testFramework);
                    }
                }
            }
            while (input != "99");

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
            string input;

            var enumValues = Enum.GetValues(typeof(ProgrammingLanguagesEnum))
                    .OfType<ProgrammingLanguagesEnum>();

            do
            {
                Console.WriteLine("Type the languages (99 - to exit):");

                foreach (var item in enumValues)
                {
                    Console.WriteLine($"{item.GetHashCode()}-{item.ToString()}");
                }

                input = Console.ReadLine();
                ProgrammingLanguagesEnum language;

                var existValue = enumValues
                    .Any(s => s.GetHashCode().ToString() == input);

                Console.Clear();

                if (existValue == false)
                {
                    Console.WriteLine("Invalid value, please type again.");
                    Console.WriteLine();
                }
                else
                {
                    language = (ProgrammingLanguagesEnum)
                        Enum.Parse(typeof(ProgrammingLanguagesEnum), input);

                    if (input != "99")
                    {
                        developer.AddLanguage(language);
                    }
                }
            }
            while (input != "99");

            Repository.Employees.Add(developer);
        }
    }
}
