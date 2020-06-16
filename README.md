# C# Class Project

## Employees Register

This project will list, create, update and delete an employee.

### Commands used to create the project:

- mkdir c-sharp-class-project
- cd c-sharp-class-project
- git init
- include the .gitignore, .gitattributes and the README.md files
- git config user.name "My User Name"
- git config user.email myemail@mail.com
- git config --list
- mkdir src
- cd src
- mkdir CSharpClassProject
- cd CSharpClassProject
- dotnet new sln
- mkdir CSharpClassProject.EmployeesRegister
- cd CSharpClassProject.EmployeesRegister
- dotnet new console
- cd ..
- dotnet sln add .\CSharpClassProject.EmployeesRegister\CSharpClassProject.EmployeesRegister.csproj
- cd ..
- cd ..
- git add .
- git status
- git commit -m "Initial commit."
- git log
- git remote add origin \<your repository url>
- git push -u origin master

## EF CORE

To install the Entity Framework Core, open the project folder in the terminal and run the command below:

<code>dotnet add package Microsoft.EntityFrameworkCore.SqlServer</code>

To execute the dotnet ef command, install the package below:

<code>dotnet add package Microsoft.EntityFrameworkCore.Design</code>
<br>
<code>dotnet add package Microsoft.EntityFrameworkCore.Tools</code>
<br>
<code>dotnet tool install --global dotnet-ef --version 2.2.6</code>

Create the Employee abstract class inside the Classes\Entities folder:

```
namespace CSharpClassProject.EfCore.Classes.Entities
{
    public abstract class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CompanyName { get; set; }
    }
}
```

Create the Developer class inheriting from the Employee class inside the Classes\Entities folder:

```
namespace CSharpClassProject.EfCore.Classes.Entities
{
    public class Developer : Employee
    {
        
    }
}
```

Create the IContext interface in the Interfaces folder:

```
using CSharpClassProject.EfCore.Classes.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSharpClassProject.EfCore.Interfaces
{
    public interface IContext
    {
        DbSet<Developer> Developers { get; set; }
    }
}
```

Then in the Classes\Entities folder, create the Context class inheriting from the DbContext class, responsible to the database context, and implements the IContext interface created above:

```
using CSharpClassProject.EfCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CSharpClassProject.EfCore.Classes.Entities
{
    public class Context : DbContext, IContext
    {
        public DbSet<Developer> Developers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configures the database connection string
            optionsBuilder.UseSqlServer("<connection string>");
        }
    }
}
```

Now, build the project and then create the initial migration:

<code>dotnet ef migrations add InitialMigration</code>

A Migration folder will be created with tree files (the 20200523165930 is the time when you ran the dotnet ef migrations command):

- 20200523165930_InitialMigration.cs: contains the migrations code to be executed in the database
- 20200523165930_InitialMigration.Designer.cs: contains the migration id and detail code to be executed in the database
- ContextModelSnapshot.cs: contains the entire database snapshot

Then, run the command below to update the database:

<code>dotnet ef database update</code>

To see the entire command that will be executed in the update, add the --verbose parameter:

<code>dotnet ef database update --verbose</code>

To revert some change, execute the comand below:

<code>dotnet ef database update \<migration name></code>

### References:

https://docs.microsoft.com/en-us/ef/core/get-started/install/
<br>
https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-strings
<br>
https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet