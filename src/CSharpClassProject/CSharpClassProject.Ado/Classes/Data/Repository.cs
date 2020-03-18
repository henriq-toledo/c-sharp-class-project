using CSharpClassProject.Ado.Classes.Entities;
using System.Collections.Generic;

namespace CSharpClassProject.Ado.Classes.Data
{
    public abstract class Repository<TEntity>
        where TEntity : Employee
    {
        public abstract List<TEntity> Get { get; }
        public abstract SqlError Insert(TEntity entity);
        public abstract SqlError Update(TEntity entity);
        public abstract SqlError Delete(TEntity entity);
    }
}