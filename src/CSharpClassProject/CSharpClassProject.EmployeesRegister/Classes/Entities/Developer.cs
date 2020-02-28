using System.Collections.Generic;
using System.Runtime.Serialization;
using CSharpClassProject.EmployeesRegister.Enums;

namespace CSharpClassProject.EmployeesRegister.Classes.Entities
{
    [DataContract]
    public class Developer : Employee
    {
        [DataMember]
        public List<ProgrammingLanguagesEnum> Languages;

        public Developer(string name, string companyName, int id) 
            : base(name, companyName, id)
        {
            Languages = new List<ProgrammingLanguagesEnum>();
        }

        public override string Title => "Developer";

        public void AddLanguage(ProgrammingLanguagesEnum language) =>
            Languages.Add(language);

        public void RemoveLanguage(ProgrammingLanguagesEnum language) => 
            Languages.Remove(language);        
        
        public override string GetInformation()
        {
            var information = base.GetInformation();

            information += $"Languages: {string.Join(',', Languages)}.";

            return information;
        }
    }
}