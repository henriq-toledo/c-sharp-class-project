using System.Collections.Generic;
using System.Runtime.Serialization;
using CSharpClassProject.EmployeesRegister.Classes.Entities;

namespace CSharpClassProject.EmployeesRegister.Classes.Data.Serializers
{
    public class DeveloperXmlSerializer: XmlSerializer
    {
        protected override string FileName => @"C:\Temp\Developers.xml";

        public void Serialize(List<Developer> developer)
        {
            var dataContractSerializer = new DataContractSerializer(typeof(List<Developer>));

            using(var stream = base.Stream)
            {
                dataContractSerializer.WriteObject(stream, developer);
            }
        }

        public List<Developer> Deserialize()
        {
            var dataContractSerializer = 
                new DataContractSerializer(typeof(List<Developer>));

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