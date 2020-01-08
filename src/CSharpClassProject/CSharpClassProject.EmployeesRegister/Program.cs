using System;
using CSharpClassProject.EmployeesRegister.Classes.Data;
using CSharpClassProject.EmployeesRegister.Classes.Entities;

namespace CSharpClassProject.EmployeesRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository.InitializeData();

            foreach(var employee in Repository.Employees)
            {
                Console.WriteLine(employee.GetInformation());
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
