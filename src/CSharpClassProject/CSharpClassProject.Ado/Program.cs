using System;
using CSharpClassProject.Ado.Classes.Data;
using CSharpClassProject.Ado.Classes.Entities;
using CSharpClassProject.Ado.Enums;

namespace CSharpClassProject.Ado
{
    class Program
    {
        static void Main(string[] args)
        {
            var dev = new Developer(name: "Joy", companyName: "JJ Comp");
            dev.Languages.Add(ProgrammingLanguagesEnum.Python);
            dev.Languages.Add(ProgrammingLanguagesEnum.Pascal);

            var error = Context.Developers.Insert(dev);

            if (error.HasError)
            {
                Console.WriteLine("Insert error.");
                Console.ReadKey();
                return;
            }

            var developers = Context.Developers.Get;

            foreach(var developer in developers)
            {
                Console.WriteLine(developer.GetInformation());
            }

            var testers = Context.Testers.Get;

            foreach(var tester in testers)
            {
                Console.WriteLine(tester.GetInformation());
            }

            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}
