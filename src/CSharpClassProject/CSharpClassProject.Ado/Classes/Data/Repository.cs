using CSharpClassProject.Ado.Classes.Entities;
using System.Collections.Generic;

namespace CSharpClassProject.Ado.Classes.Data
{
    public abstract class Repository<TEntity>
        where TEntity : Employee
    {        
        protected string ConnectionString => "Server={serverName};Initial Catalog=Employees;Persist Security Info=False;User ID={userId};Password={userPassword};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public abstract List<TEntity> Get { get; }
        public abstract SqlError Insert(TEntity entity);
        public abstract SqlError Update(TEntity entity);
        public abstract SqlError Delete(TEntity entity);
    }
}