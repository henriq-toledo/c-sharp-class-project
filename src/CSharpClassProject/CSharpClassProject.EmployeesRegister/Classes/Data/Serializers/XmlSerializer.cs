using System.IO;

namespace CSharpClassProject.EmployeesRegister.Classes.Data.Serializers
{
    public abstract class XmlSerializer
    {
        protected abstract string FileName { get; }
        protected Stream Stream => new FileStream(FileName, FileMode.OpenOrCreate);
    }
}