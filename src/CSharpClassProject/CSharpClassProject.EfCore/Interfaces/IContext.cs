using CSharpClassProject.EfCore.Classes.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSharpClassProject.EfCore.Interfaces
{
    public interface IContext
    {
        DbSet<Developer> Developers { get; set; }
    }
}