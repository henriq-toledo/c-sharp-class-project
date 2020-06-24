using System;
using CSharpClassProject.EfCore.Classes.Entities;

namespace CSharpClassProject.EfCore
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get
            using(var context = new Context())
            {
                foreach(var developer in context.Developers)
                {
                    Console.Write($"Id: {developer.Id}, Name: {developer.Name}, Company Name:{developer.CompanyName}");
                }
            }

            // Insert
            using(var context = new Context())
            {
                var developer = new Developer()
                {
                    Name = "Ash",
                    CompanyName = "Toei"
                };

                context.Developers.Add(developer);
                context.SaveChanges();
            }

            Console.ReadLine();
        }
    }
}
