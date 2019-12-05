using System.Text;

namespace CSharpClassProject.EmployeesRegister.Classes.Entities
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public int CompanyId { get; set; }
        public abstract string Title { get; }

        public Employee(string name, string companyName, int companyId)
        {
            Name = name;
            CompanyName = companyName;
            CompanyId = companyId;
        }

        public virtual string GetInformation()
        {
            var information = new StringBuilder();

            information.AppendLine($"Name: {Name}");
            information.AppendLine($"Title: {Title}");
            information.AppendLine($"Company Id: {CompanyId}");
            information.AppendLine($"Company name: {CompanyName}");

            return information.ToString();
        }
    }
}