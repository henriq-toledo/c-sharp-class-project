using System;
using System.Collections.Generic;
using CSharpClassProject.EmployeesRegister.Classes.Entities;
using CSharpClassProject.EmployeesRegister.Enums;

namespace CSharpClassProject.EmployeesRegister.Classes.Data
{
    public static class Repository
    {
        public static List<Employee> Employees = new List<Employee>();

        public static void InitializeData()
        {
            var tester = new Tester("John", "JJ Company", 1);
            tester.AddFramework(TestFrameworksEnum.SeleniumIde);
            tester.AddFramework(TestFrameworksEnum.Cucumber);

            var developer = new Developer("Sarah", "JJ Company", 2);
            developer.AddLanguage(ProgrammingLanguagesEnum.CSharp);
            developer.AddLanguage(ProgrammingLanguagesEnum.Python);

            Repository.Employees.Add(tester);
            Repository.Employees.Add(developer);
        }

        public static void ShowData()
        {
            Console.Clear();

            foreach(var employee in Repository.Employees)
            {
                Console.WriteLine(employee.GetInformation());
                Console.WriteLine();
            }
        }
    }
}