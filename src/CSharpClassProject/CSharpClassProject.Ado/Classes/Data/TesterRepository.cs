using System;
using System.Collections.Generic;
using System.Text;
using CSharpClassProject.Ado.Classes.Entities;
using CSharpClassProject.Ado.Enums;
using Microsoft.Data.SqlClient;

namespace CSharpClassProject.Ado.Classes.Data
{
    public class TesterRepository : Repository<Tester>
    {
        public override List<Tester> Get
        {
            get
            {
                var developers = new List<Tester>();

                using(var sqlConnection = new SqlConnection(base.ConnectionString))
                using(var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlConnection.Open();

                    sqlCommand.CommandText = "SELECT ID, NAME, COMPANY_NAME FROM TESTERS";

                    var reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var name = reader.GetString(1);
                        var companyName = reader.GetString(2);

                        var tester = new Tester(name, companyName, id);
                        tester.Frameworks = GetTestFrameworks(tester.Id);

                        developers.Add(tester);
                    }
                }

                return developers;
            }
        }

        public override SqlError Delete(Tester entity)
        {
            throw new System.NotImplementedException();
        }

       public override SqlError Insert(Tester entity)
        {
            var sqlError = new SqlError();

            try
            {
                using(var sqlConnection = new SqlConnection(base.ConnectionString))
                using(var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlConnection.Open();
                    sqlCommand.CommandText = $@"INSERT INTO [dbo].[TESTERS]([NAME], [COMPANY_NAME]) 
                                                VALUES ('{entity.Name}', '{entity.CompanyName}');
                                                
                                                SELECT @@IDENTITY";

                    var id = sqlCommand.ExecuteScalar();
                    entity.Id = int.Parse(id.ToString());
                }
                
                InsertTestFrameworks(entity);
            }
            catch (Exception ex)
            {
                sqlError.HasError = true;
                sqlError.Message = ex.Message;
            }

            return sqlError;
        }

        private void InsertTestFrameworks(Tester tester)
        {
            if (tester.Frameworks.Count == 0)
            {
                return;
            }

            var sqlCommands = new StringBuilder();

            foreach (var framework in tester.Frameworks)
            {
                sqlCommands.AppendLine($@"INSERT INTO TESTERS_SKILLS(TESTER_ID, SKILL)
                                          VALUES({tester.Id}, {framework.GetHashCode()});");
            }

            using(var sqlConnection = new SqlConnection(base.ConnectionString))
            using(var sqlCommand = sqlConnection.CreateCommand())
            {
                sqlConnection.Open();

                sqlCommand.CommandText =  sqlCommands.ToString();
                sqlCommand.ExecuteNonQuery();
            }
        }

        public override SqlError Update(Tester entity)
        {
            throw new System.NotImplementedException();
        }

        private List<TestFrameworksEnum> GetTestFrameworks(int testerId)
        {
            var frameworks = new List<TestFrameworksEnum>();

            using(var sqlConnection = new SqlConnection(base.ConnectionString))
            using(var sqlCommand = sqlConnection.CreateCommand())
            {
                sqlConnection.Open();

                sqlCommand.CommandText = $@"
                    SELECT SKILL FROM TESTERS_SKILLS WHERE TESTER_ID = {testerId}";

                var reader = sqlCommand.ExecuteReader();

                while(reader.Read())
                {
                    var skill = reader.GetByte(0);
                    var framework = (TestFrameworksEnum)
                        Enum.Parse(typeof(TestFrameworksEnum), skill.ToString());

                    frameworks.Add(framework);
                }
            }

            return frameworks;
        }
    }
}