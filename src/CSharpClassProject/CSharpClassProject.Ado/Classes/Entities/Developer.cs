namespace CSharpClassProject.Ado.Classes.Entities
{
    public class Developer : Employee
    {
        public List<ProgrammingLanguagesEnum> Languages;

        public Developer(string name, string companyName, int id) 
            : base(name, companyName, id)
        {
            Languages = new List<ProgrammingLanguagesEnum>();
        }

        public override string Title => "Developer";      
        
        public override string GetInformation()
        {
            var information = base.GetInformation();

            information += $"Languages: {string.Join(',', Languages)}.";

            return information;
        }
    }
}