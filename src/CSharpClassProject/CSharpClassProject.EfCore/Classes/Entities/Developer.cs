using System.Collections.Generic;

namespace CSharpClassProject.EfCore.Classes.Entities
{
    public class Developer : Employee
    {
        public List<DeveloperSkill> Skills { get; set; } = new List<DeveloperSkill>();
    }
}