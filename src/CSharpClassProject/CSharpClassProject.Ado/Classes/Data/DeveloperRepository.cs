using System.Collections.Generic;
using CSharpClassProject.Ado.Classes.Entities;
using Microsoft.Data.SqlClient;

namespace CSharpClassProject.Ado.Classes.Data
{
    public class DeveloperRepository : Repository<Developer>
    {
        public override List<Developer> Get
        {
            get
            {
                var developers = new List<Developer>();

                using(var sqlConnection = new SqlConnection(base.ConnectionString))
                using(var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlConnection.Open();

                    sqlCommand.CommandText = "SELECT ID, NAME, COMPANY_NAME FROM DEVELOPERS";

                    var reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var name = reader.GetString(1);
                        var companyName = reader.GetString(2);

                        var developer = new Developer(name, companyName, id);

                        developers.Add(developer);
                    }
                }

                return developers;
            }
        }

        public override SqlError Delete(Developer entity)
        {
            throw new System.NotImplementedException();
        }

        public override SqlError Insert(Developer entity)
        {
            throw new System.NotImplementedException();
        }

        public override SqlError Update(Developer entity)
        {
            throw new System.NotImplementedException();
        }
    }
}