using CSharpClassProject.EfCore.Enums;

namespace CSharpClassProject.EfCore.Classes.Entities
{
    public class DeveloperSkill
    {
        public int Id { get; set; }
        public int DeveloperId { get; set; }
        public DeveloperSkillEnum Skill { get; set; }
    }
}