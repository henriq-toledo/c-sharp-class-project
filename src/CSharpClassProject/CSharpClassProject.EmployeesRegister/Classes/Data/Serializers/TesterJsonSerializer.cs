using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using CSharpClassProject.EmployeesRegister.Classes.Entities;

namespace CSharpClassProject.EmployeesRegister.Classes.Data.Serializers
{
    public class TesterJsonSerializer : JsonSerializer
    {
        protected override string FileName => @"C:\Temp\Testers.json";

        public void Serialize(List<Tester> testers)
        {
            var dataContractSerializer = new DataContractJsonSerializer(typeof(List<Tester>));

            using(var stream = base.Stream)
            {
                dataContractSerializer.WriteObject(stream, testers);
            }
        }

        public List<Tester> Deserialize()
        {
            var dataContractSerializer = 
                new DataContractJsonSerializer(typeof(List<Tester>));

            using(var stream = base.Stream)
            {
                var testers = new List<Tester>();

                if(stream.Length > 0)
                {
                    testers = 
                        (List<Tester>)dataContractSerializer
                            .ReadObject(stream);
                }

                return testers;
            }
        }
    }
}