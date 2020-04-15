namespace CSharpClassProject.Ado.Classes.Data
{
    public static class Context
    {        
        public static DeveloperRepository Developers = new DeveloperRepository();
        public static TesterRepository Testers = new TesterRepository();
    }
}