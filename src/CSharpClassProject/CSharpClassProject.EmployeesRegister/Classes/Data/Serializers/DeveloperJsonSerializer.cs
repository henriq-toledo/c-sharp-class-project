using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using CSharpClassProject.EmployeesRegister.Classes.Entities;

namespace CSharpClassProject.EmployeesRegister.Classes.Data.Serializers
{
    public class DeveloperJsonSerializer: JsonSerializer
    {
        protected override string FileName => @"C:\Temp\Developers.json";

        public void Serialize(List<Developer> developer)
        {
            var dataContractSerializer = new DataContractJsonSerializer(typeof(List<Developer>));

            using(var stream = base.Stream)
            {
                dataContractSerializer.WriteObject(stream, developer);
            }
        }

        public List<Developer> Deserialize()
        {
            var dataContractSerializer = 
                new DataContractJsonSerializer(typeof(List<Developer>));

            using(var stream = base.Stream)
            {
                var testers = new List<Developer>();

                if(stream.Length > 0)
                {
                    testers = 
                        (List<Developer>)dataContractSerializer
                            .ReadObject(stream);
                }

                return testers;
            }
        }
    }
}