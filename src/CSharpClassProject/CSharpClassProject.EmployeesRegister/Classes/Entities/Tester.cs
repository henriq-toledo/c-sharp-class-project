using System.Collections.Generic;

namespace CSharpClassProject.EmployeesRegister.Classes.Entities
{
    public class Tester : Employee
    {
        private List<string> _frameworks;

        public Tester(string name, string companyName, int id) 
            : base(name, companyName, id)
        {
            _frameworks = new List<string>();
        }

        public void AddFramework(string framework) =>
            _frameworks.Add(framework);

        public void RemoveFramework(string framework) => 
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