using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using CSharpClassProject.EmployeesRegister.Classes.Entities;
using CSharpClassProject.EmployeesRegister.Enums;

namespace CSharpClassProject.EmployeesRegister.Classes.Data.Serializers
{
    public class EntitySerializer<TEntity>
        where TEntity : Employee
    {
        private string FileName 
        {
            get
            {
                switch(_dataStoreOption)
                {
                    case StorageOptionEnum.Json:
                        return $@"C:\Temp\{typeof(TEntity).Name}.json";

                    case StorageOptionEnum.Xml:
                        return $@"C:\Temp\{typeof(TEntity).Name}.xml";

                    default: 
                        throw new NotImplementedException($"The data store option {_dataStoreOption} is not supported.");
                }
            }
        }

        protected Stream Stream => new FileStream(FileName, FileMode.OpenOrCreate);

        private XmlObjectSerializer ObjectSerializer
        {
            get
            {
                switch(_dataStoreOption)
                {
                    case StorageOptionEnum.Json:
                        return new DataContractJsonSerializer(typeof(List<TEntity>)); 

                    case StorageOptionEnum.Xml:
                        return new DataContractSerializer(typeof(List<TEntity>));

                    default: 
                        throw new NotImplementedException($"The data store option {_dataStoreOption} is not supported.");
                }
            }
        }

        private StorageOptionEnum _dataStoreOption;

        public EntitySerializer(StorageOptionEnum dataStoreOption)
        {
            _dataStoreOption = dataStoreOption;
        }

        public void Serialize(List<TEntity> developer)
        {
            var dataContractSerializer = ObjectSerializer;

            using(var stream = Stream)
            {
                dataContractSerializer.WriteObject(stream, developer);
            }
        }

        public List<TEntity> Deserialize()
        {
            var dataContractSerializer = ObjectSerializer;

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