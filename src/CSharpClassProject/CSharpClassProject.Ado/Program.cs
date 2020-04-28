using System;
using CSharpClassProject.Ado.Classes.Data;
using CSharpClassProject.Ado.Classes.Entities;
using CSharpClassProject.Ado.Enums;
using CSharpClassProject.Ado.Classes.Extensions;

namespace CSharpClassProject.Ado
{
    class Program
    {
        static void Main(string[] args)
        {
            var dev = new Developer(name: "Joy", companyName: "JJ Comp");
            dev.Languages.Add(ProgrammingLanguagesEnum.Python);
            dev.Languages.Add(ProgrammingLanguagesEnum.Pascal);

            var devInsertError = Context.Developers.Insert(dev);

            if (devInsertError.HasError)
            {
                Console.WriteLine("Insert error.");
                Console.WriteLine(devInsertError.Message);
                Console.ReadKey();
                return;
            }

            var tester = new Tester(name: "John", "JJ Comp");
            tester.Frameworks.Add(TestFrameworksEnum.MSTest);
            tester.Frameworks.Add(TestFrameworksEnum.NUnit);

            var insertTesterError = Context.Testers.Insert(tester);

            if (insertTesterError.HasError)
            {
                Console.WriteLine("Insert error.");
                Console.WriteLine(insertTesterError.Message);
                Console.ReadKey();
                return;
            }

            ShowData();

            Console.ReadLine();
        }
    
        static void ShowData()
        {
            var width = 89;

            Console.WriteLine("DEVELOPERS");
            Console.WriteLine();

            Console.WriteLine(string.Empty.Format(width, '-'));
            Console.WriteLine($"|{"Id".Format(3)}|{"Title".Format(10)}|{"Name".Format(20)}|{"Company Name".Format(20)}|{"Skills".Format(30)}|");
            Console.WriteLine(string.Empty.Format(width, '-'));

            foreach(var developer in Context.Developers.Get)
            {
                var line = $"|{developer.Id.ToString().Format(3)}|{developer.Title.Format(10)}|{developer.Name.Format(20)}|{developer.CompanyName.Format(20)}|{string.Join(',', developer.Languages).Format(30)}|";

                Console.WriteLine(line);
            }

            Console.WriteLine(string.Empty.Format(width, '-'));

            Console.WriteLine();
            Console.WriteLine("TESTERS");
            Console.WriteLine();

            Console.WriteLine(string.Empty.Format(width, '-'));
            Console.WriteLine($"|{"Id".Format(3)}|{"Title".Format(10)}|{"Name".Format(20)}|{"Company Name".Format(20)}|{"Skills".Format(30)}|");
            Console.WriteLine(string.Empty.Format(width, '-'));

            foreach(var tester in Context.Testers.Get)
            {
                var line = $"|{tester.Id.ToString().Format(3)}|{tester.Title.Format(10)}|{tester.Name.Format(20)}|{tester.CompanyName.Format(20)}|{string.Join(',', tester.Frameworks).Format(30)}|";

                Console.WriteLine(line);
            }

            Console.WriteLine(string.Empty.Format(width, '-'));
        }
    }
}
