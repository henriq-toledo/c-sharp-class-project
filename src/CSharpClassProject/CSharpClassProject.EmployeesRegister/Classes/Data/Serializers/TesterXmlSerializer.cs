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
    }
}