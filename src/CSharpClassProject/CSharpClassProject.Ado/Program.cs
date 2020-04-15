using System;
using CSharpClassProject.Ado.Classes.Data;

namespace CSharpClassProject.Ado
{
    class Program
    {
        static void Main(string[] args)
        {
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
