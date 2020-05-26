namespace CSharpClassProject.EfCore.Classes.Entities
{
    public abstract class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CompanyName { get; set; }
    }
}