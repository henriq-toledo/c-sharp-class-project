using CSharpClassProject.EfCore.Enums;

namespace CSharpClassProject.EfCore.Classes.Entities
{
    public class TesterSkill
    {
        public int Id { get; set; }
        public int TesterId { get; set; }
        public TesterSkillEnum Skill { get; set; }
    }
}