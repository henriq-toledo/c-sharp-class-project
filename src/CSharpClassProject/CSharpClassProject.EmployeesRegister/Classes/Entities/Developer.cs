using System.Collections.Generic;
using CSharpClassProject.EmployeesRegister.Enums;

namespace CSharpClassProject.EmployeesRegister.Classes.Entities
{
    public class Developer : Employee
    {
        private List<ProgrammingLanguagesEnum> _languages;

        public Developer(string name, string companyName, int id) 
            : base(name, companyName, id)
        {
            _languages = new List<ProgrammingLanguagesEnum>();
        }

        public override string Title => "Developer";

        public void AddLanguage(ProgrammingLanguagesEnum language) =>
            _languages.Add(language);

        public void RemoveLanguage(ProgrammingLanguagesEnum language) => 
            _languages.Remove(language);        
        
        public override string GetInformation()
        {
            var information = base.GetInformation();

            information += $"Languages: {string.Join(',', _languages)}.";

            return information;
        }
    }
}