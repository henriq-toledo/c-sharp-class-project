using System.Collections.Generic;
using System.Runtime.Serialization;
using CSharpClassProject.EmployeesRegister.Classes.Entities;

namespace CSharpClassProject.EmployeesRegister.Classes.Data.Serializers
{
   public class TesterXmlSerializer : XmlSerializer
    {
        protected override string FileName => @"C:\Temp\Testers.xml";

        public void Serialize(List<Tester> testers)
        {
            var dataContractSerializer = new DataContractSerializer(typeof(List<Tester>));

            using(var stream = base.Stream)
            {
                dataContractSerializer.WriteObject(stream, testers);
            }
        }

        public List<Tester> Deserialize()
        {
            var dataContractSerializer = 
                new DataContractSerializer(typeof(List<Tester>));

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