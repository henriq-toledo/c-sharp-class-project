using System.Collections.Generic;

namespace CSharpClassProject.EfCore.Classes.Entities
{
    public class Tester : Employee
    {
        public List<TesterSkill> Skills { get; set; } = new List<TesterSkill>();
    }
}