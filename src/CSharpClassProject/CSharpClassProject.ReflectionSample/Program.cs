using System;
using System.Linq;
using System.Reflection;

namespace CSharpClassProject.ReflectionSample
{
    class Program
    {
        static void Main(string[] args)
        {            
            var type = typeof(Employee);

            var constructors = type.GetConstructors();

            foreach (var constructor in constructors)
            {
                Console.WriteLine();
                Console.WriteLine($"Constructor: {Array.IndexOf(constructors, constructor) + 1}");
                Console.WriteLine($"Parameters: {constructor.GetParameters().Length}");
            }

            var privateConstructor = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
            var employee = (Employee)privateConstructor.Invoke(new object[]{});
            employee.CompanyName = "JJ";
            employee.Name = "Josh";

            var nameType = type.GetField("_name", BindingFlags.NonPublic | BindingFlags.Instance);
            nameType.SetValue(employee, "Josh");

            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in fields)
            {
                Console.WriteLine();
                Console.WriteLine($"Field: {Array.IndexOf(fields, field) + 1}");
                Console.WriteLine($"Name: {field.Name}");
            }

            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(employee);

                Console.WriteLine();
                Console.WriteLine($"Property: {Array.IndexOf(properties, property) + 1}");
                Console.WriteLine($"Name: {property.Name}");
            }

            var methods = type.GetMethods();

            foreach (var method in methods)
            {
                Console.WriteLine();
                Console.WriteLine($"Method: {Array.IndexOf(methods, method) + 1}");
                Console.WriteLine($"Name: {method.Name}");
                Console.WriteLine($"Parameters: {method.GetParameters().Length}");
                Console.WriteLine($"Return type: {method.ReturnType.ToString()}");
            }

            var methodInfo = type.GetMethod("FormatInformation", BindingFlags.NonPublic | BindingFlags.Instance);
            var methodReturn = (string)methodInfo.Invoke(employee, new object[] { });
            Console.WriteLine(methodReturn);
            
            Console.ReadLine();
        }
    }
}
