using System.Collections.Generic;

namespace CSharpClassProject.EmployeesRegister.Classes.Entities
{
    public class Developer : Employee
    {
        public List<string> _languages;

        public Developer(string name, string companyName, int id) 
            : base(name, companyName, id)
        {
            _languages = new List<string>();
        }

        public override string Title => "Developer";

        public void AddLanguage(string language) =>
            _languages.Add(language);

        public void RemoveLanguage(string language) => 
            _languages.Remove(language);        
        
        public override string GetInformation()
        {
            var information = base.GetInformation();

            information += $"Languages: {string.Join(',', _languages)}.";

            return information;
        }
    }
}