using System.Text;

namespace CSharpClassProject.ReflectionSample
{
    public class Employee
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string CompanyName { get; set; }

        private Employee()
        {
            Name = string.Empty;
        }

        public Employee(string companyName) : this()
        {
            CompanyName = companyName;
        }

        public string ShowInformation()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("EMPLOYEE");
            stringBuilder.AppendLine(FormatInformation());

            return stringBuilder.ToString();
        }

        private string FormatInformation() => $"Company: {CompanyName}, Name: {Name}.";
    }
}