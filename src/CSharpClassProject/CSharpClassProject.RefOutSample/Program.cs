using System;
using CSharpClassProject.RefOutSample.Extensions;

namespace CSharpClassProject.RefOutSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //string text = null;

            //SetText(text);
            //SetOutText(out text);
            //SetRefText(ref text);

            //Console.WriteLine(text);

            // var employee = new Employee();

            // SetEmployee(employee);

            // Console.WriteLine(employee.Name);

            // var developer = new Developer();

            // SetRefDeveloper(ref developer);

            // Console.WriteLine(developer.Name);

            //int value;
            Console.WriteLine("123abc13548".OnlyChars());

            Console.ReadLine();
        }

        static void SetRefDeveloper(ref Developer developer)
        {
            developer.Name = "John";
        }

        static void SetDeveloper(Developer developer)
        {
            developer.Name = "John";
        }

        static void SetEmployee(Employee employee)
        {
            employee.Name = "Josh";
        }

        static void SetText(string value)
        {
            value = "Without ref and out";
        }

        static void SetOutText(out string value)
        {
            value = "Out";
        }

        static void SetRefText(ref string value)
        {
            value = "Ref";
        }
    }

    class Employee
    {
        public string Name { get; set; }
    }

    struct Developer
    {
        public string Name { get; set; }
    }
}
