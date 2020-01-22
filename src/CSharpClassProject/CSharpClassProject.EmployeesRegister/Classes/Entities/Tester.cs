using System.Collections.Generic;
using CSharpClassProject.EmployeesRegister.Enums;

namespace CSharpClassProject.EmployeesRegister.Classes.Entities
{
    public class Tester : Employee
    {
        private List<TestFrameworksEnum> _frameworks;

        public Tester(string name, string companyName, int id) 
            : base(name, companyName, id)
        {
            _frameworks = new List<TestFrameworksEnum>();
        }

        public void AddFramework(TestFrameworksEnum framework) =>
            _frameworks.Add(framework);

        public void RemoveFramework(TestFrameworksEnum framework) => 
            _frameworks.Remove(framework);
        
        public override string Title => "Tester";

        public override string GetInformation()
        {
            var information = base.GetInformation();

            information += $"Frameworks: {string.Join(',', _frameworks)}.";

            return information;
        }
    }
}