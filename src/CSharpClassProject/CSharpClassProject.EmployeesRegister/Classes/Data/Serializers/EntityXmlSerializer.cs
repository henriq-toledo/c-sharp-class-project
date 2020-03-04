using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using CSharpClassProject.EmployeesRegister.Classes.Entities;

namespace CSharpClassProject.EmployeesRegister.Classes.Data.Serializers
{
    public class EntityXmlSerializer<TEntity>
        where TEntity : Employee
    {
        public string FileName => $@"C:\Temp\{typeof(TEntity).Name}.xml";

        protected Stream Stream => new FileStream(FileName, FileMode.OpenOrCreate);

        public void Serialize(List<TEntity> developer)
        {
            var dataContractSerializer = new DataContractSerializer(typeof(List<TEntity>));

            using(var stream = Stream)
            {
                dataContractSerializer.WriteObject(stream, developer);
            }
        }

        public List<TEntity> Deserialize()
        {
            var dataContractSerializer = 
                new DataContractSerializer(typeof(List<TEntity>));

            using(var stream = Stream)
            {
                var entities = new List<TEntity>();

                if(stream.Length > 0)
                {
                    entities = 
                        (List<TEntity>)dataContractSerializer
                            .ReadObject(stream);
                }

                return entities;
            }
        }
    }
}