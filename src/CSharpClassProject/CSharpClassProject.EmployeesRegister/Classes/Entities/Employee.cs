using System.Runtime.Serialization;
using System.Text;

namespace CSharpClassProject.EmployeesRegister.Classes.Entities
{    
    [DataContract]
    public abstract class Employee
    {        
        [DataMember]
        public string Name { get; set; } 
        [DataMember]    
        public string CompanyName { get; set; }        
        [DataMember]
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