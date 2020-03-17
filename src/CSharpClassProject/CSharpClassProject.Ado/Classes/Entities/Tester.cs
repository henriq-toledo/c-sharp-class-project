namespace CSharpClassProject.Ado.Classes.Entities
{
    public class Tester : Employee
    {
        public List<TestFrameworksEnum> Frameworks;

        public Tester(string name, string companyName, int id) 
            : base(name, companyName, id)
        {
            Frameworks = new List<TestFrameworksEnum>();
        }
        
        public override string Title => "Tester";

        public override string GetInformation()
        {
            var information = base.GetInformation();

            information += $"Frameworks: {string.Join(',', Frameworks)}.";

            return information;
        }
    }
}