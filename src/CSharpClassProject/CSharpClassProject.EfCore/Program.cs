using System;
using CSharpClassProject.EfCore.Classes.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CSharpClassProject.EfCore.Enums;

namespace CSharpClassProject.EfCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //DeveloperCRUD();
            //TesterCRUD();
            //DeveloperWithSkill();
            //TesterWithSkill();
            //AddTesterSkill();
            //IncludeTesterSkill();
            //CreateDuplicatedDeveloperSkill();
            CreateDuplicatedTesterSkill();

            Console.ReadLine();
        }

        static void CreateDuplicatedTesterSkill()
        {

            try
            {            
                using(var context = new Context())
                {
                    var tester = new Tester()
                    {
                        Name = "Jorge",
                        CompanyName = "App"
                    };

                    tester.Skills.Add(new TesterSkill()
                    {
                        Skill = TesterSkillEnum.Cucumber
                    });

                    tester.Skills.Add(new TesterSkill()
                    {
                        Skill = TesterSkillEnum.Cucumber
                    });

                    context.Testers.Add(tester);
                    context.SaveChanges();
                }
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Exception: {ex.InnerException.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }            
            finally
            {
                Console.WriteLine("Finish process.");
            }
        }

        static void CreateDuplicatedDeveloperSkill()
        {
            using(var context = new Context())
            {
                var developer = new Developer()
                {
                    Name = "Jorge",
                    CompanyName = "App"
                };

                developer.Skills.Add(new DeveloperSkill()
                {
                    Skill = DeveloperSkillEnum.CSharp
                });

                developer.Skills.Add(new DeveloperSkill()
                {
                    Skill = DeveloperSkillEnum.CSharp
                });

                context.Developers.Add(developer);
                context.SaveChanges();
            }
        }

        static void IncludeTesterSkill()
        {
            using(var context = new Context())
            {
                var tester = context.Testers.Include("Skills").FirstOrDefault();
            }

            using(var context = new Context())
            {
                var tester = context.Testers.Include(t => t.Skills).FirstOrDefault();
            }
        }

        static void AddTesterSkill()
        {
            using(var context = new Context())
            {
                var tester = context.Testers.FirstOrDefault();
                var testerSkill = new TesterSkill()
                {
                    TesterId = tester.Id,
                    Skill = TesterSkillEnum.JUnit  
                };

                context.TesterSkills.Add(testerSkill);
                context.SaveChanges();
            }
        }

        static void TesterWithSkill()
        {
            // Insert
            using (var context = new Context())
            {
                var tester = new Tester()
                {
                    Name = "Sara",
                    CompanyName = "Toei"
                };

                tester.Skills.Add(new TesterSkill()
                {
                    Skill = TesterSkillEnum.Selenium
                });

                tester.Skills.Add(new TesterSkill()
                {
                    Skill = TesterSkillEnum.MSTest
                });

                context.Testers.Add(tester);
                context.SaveChanges();
            }
        }

        static void DeveloperWithSkill()
        {
            // Insert
            using (var context = new Context())
            {
                var developer = new Developer()
                {
                    Name = "Myst",
                    CompanyName = "Toei"
                };

                developer.Skills.Add(new DeveloperSkill()
                {
                    Skill = DeveloperSkillEnum.CSharp
                });

                developer.Skills.Add(new DeveloperSkill()
                {
                    Skill = DeveloperSkillEnum.Css
                });

                context.Developers.Add(developer);
                context.SaveChanges();
            }
        }

        static void DeveloperCRUD()
        {
            // Insert
            using (var context = new Context())
            {
                var developer = new Developer()
                {
                    Name = "Ash",
                    CompanyName = "Toei"
                };

                context.Developers.Add(developer);
                context.SaveChanges();
            }

            // Get
            using (var context = new Context())
            {
                foreach (var developer in context.Developers)
                {
                    Console.Write($"Id: {developer.Id}, Name: {developer.Name}, Company Name:{developer.CompanyName}");
                }
            }

            // Update
            using (var context = new Context())
            {
                var developer = context.Developers.FirstOrDefault();

                developer.CompanyName = "CC Corp.";

                context.Entry(developer).State = EntityState.Modified;

                context.SaveChanges();
            }

            // Delete
            using (var context = new Context())
            {
                var developer = context.Developers.AsEnumerable().LastOrDefault();

                context.Developers.Remove(developer);

                context.SaveChanges();
            }
        }

        static void TesterCRUD()
        {
            // Insert
            using (var context = new Context())
            {
                var tester = new Tester()
                {
                    Name = "Ash",
                    CompanyName = "Toei"
                };

                context.Testers.Add(tester);
                context.SaveChanges();
            }

            // Get
            using (var context = new Context())
            {
                foreach (var tester in context.Testers)
                {
                    Console.Write($"Id: {tester.Id}, Name: {tester.Name}, Company Name:{tester.CompanyName}");
                }
            }

            // Update
            using (var context = new Context())
            {
                var tester = context.Testers.FirstOrDefault();

                tester.CompanyName = "CC Corp.";

                context.Entry(tester).State = EntityState.Modified;

                context.SaveChanges();
            }

            // Delete
            using (var context = new Context())
            {
                var tester = context.Testers.AsEnumerable().LastOrDefault();

                context.Testers.Remove(tester);

                context.SaveChanges();
            }
        }
    }
}
