using System.ComponentModel.DataAnnotations;

namespace CSharpClassProject.EfCore.Classes.Entities
{
    public abstract class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }
    }
}