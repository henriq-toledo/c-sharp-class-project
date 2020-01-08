using System.Text;

namespace CSharpClassProject.EmployeesRegister.Classes.Entities
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public int Id { get; set; }
        public abstract string Title { get; }

        public Employee(string name, string companyName, int id)
        {
            Name = name;
            CompanyName = companyName;
            Id = id;
        }

        public virtual string GetInformation()
        {
            var information = new StringBuilder();

            information.AppendLine($"Id: {Id}");
            information.AppendLine($"Name: {Name}");
            information.AppendLine($"Title: {Title}");            
            information.AppendLine($"Company name: {CompanyName}");

            return information.ToString();
        }
    }
}