using System;
using System.Collections.Generic;
using System.Linq;
using CSharpClassProject.EmployeesRegister.Classes.Data.Serializers;
using CSharpClassProject.EmployeesRegister.Classes.Entities;
using CSharpClassProject.EmployeesRegister.Enums;

namespace CSharpClassProject.EmployeesRegister.Classes.Data
{
    public static class Repository
    {
        public static List<Employee> Employees = new List<Employee>();

        public static void InitializeData()
        {
            if (Employees.Count > 0)
            {
                return;
            }

            var tester = new Tester("John", "JJ Company", Employees.Count + 1);
            tester.AddFramework(TestFrameworksEnum.SeleniumIde);
            tester.AddFramework(TestFrameworksEnum.Cucumber);

            Repository.Employees.Add(tester);

            var developer = new Developer("Sarah", "JJ Company", Employees.Count + 1);
            developer.AddLanguage(ProgrammingLanguagesEnum.CSharp);
            developer.AddLanguage(ProgrammingLanguagesEnum.Python);
            
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

        public static void SaveData()
        {
            var testers = Employees.Where(e => e is Tester).Cast<Tester>().ToList();
            var testerSerializer = new TesterXmlSerializer();
            testerSerializer.Serialize(testers);
        }

        public static void LoadData()
        {
            var testerSerializer = new TesterXmlSerializer();
            var testers = testerSerializer.Deserialize();

            Employees = new List<Employee>();
            Employees.AddRange(testers);
        }
    }
}