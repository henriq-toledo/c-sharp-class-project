using System.Collections.Generic;
using System.Runtime.Serialization;
using CSharpClassProject.EmployeesRegister.Enums;

namespace CSharpClassProject.EmployeesRegister.Classes.Entities
{    
    [DataContract]
    public class Tester : Employee
    {        
        [DataMember]
        public List<TestFrameworksEnum> Frameworks;

        public Tester(string name, string companyName, int id) 
            : base(name, companyName, id)
        {
            Frameworks = new List<TestFrameworksEnum>();
        }

        public void AddFramework(TestFrameworksEnum framework) =>
            Frameworks.Add(framework);

        public void RemoveFramework(TestFrameworksEnum framework) => 
            Frameworks.Remove(framework);
        
        public override string Title => "Tester";

        public override string GetInformation()
        {
            var information = base.GetInformation();

            information += $"Frameworks: {string.Join(',', Frameworks)}.";

            return information;
        }
    }
}