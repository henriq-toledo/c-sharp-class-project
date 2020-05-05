using System.Collections.Generic;
using CSharpClassProject.Ado.Classes.Entities;
using CSharpClassProject.Ado.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Text;

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
                        developer.Languages = GetLanguages(developer.Id);

                        developers.Add(developer);
                    }
                }

                return developers;
            }
        }

        public override SqlError Delete(Developer entity)
        {
            var sqlError = new SqlError();

            try
            {
                using(var sqlConnection = new SqlConnection(base.ConnectionString))
                using(var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlConnection.Open();

                    sqlCommand.CommandText = $"DELETE FROM DEVELOPERS WHERE ID = {entity.Id}";
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                sqlError.HasError = true;
                sqlError.Message = ex.Message;
            }

            return sqlError;
        }

        public override SqlError Insert(Developer entity)
        {
            var sqlError = new SqlError();

            try
            {
                using(var sqlConnection = new SqlConnection(base.ConnectionString))
                using(var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlConnection.Open();
                    sqlCommand.CommandText = $@"INSERT INTO [dbo].[DEVELOPERS]([NAME], [COMPANY_NAME]) 
                                                VALUES ('{entity.Name}', '{entity.CompanyName}');
                                                
                                                SELECT @@IDENTITY";

                    var id = sqlCommand.ExecuteScalar();
                    entity.Id = int.Parse(id.ToString());
                }

                //InsertProgrammingLanguages(entity.Id, entity.Languages);
                InsertProgrammingLanguages(entity);
            }
            catch (Exception ex)
            {
                sqlError.HasError = true;
                sqlError.Message = ex.Message;
            }

            return sqlError;
        }

        private void InsertProgrammingLanguages(
            int developerId, 
            List<ProgrammingLanguagesEnum> programmingLanguages)
        {
            if (programmingLanguages.Count == 0)
            {
                return;
            }

            using(var sqlConnection = new SqlConnection(base.ConnectionString))
            {
                sqlConnection.Open();

                foreach (var programmingLanguage in programmingLanguages)
                {
                    using(var sqlCommand = sqlConnection.CreateCommand())
                    {
                        sqlCommand.CommandText = $@"INSERT INTO DEVELOPERS_SKILLS(DEVELOPER_ID, SKILL)
                                                    VALUES({developerId}, {programmingLanguage.GetHashCode()})";

                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        private void InsertProgrammingLanguages(Developer developer)
        {
            if (developer.Languages.Count == 0)
            {
                return;
            }

            var sqlCommands = new StringBuilder();

            foreach (var language in developer.Languages)
            {
                sqlCommands.AppendLine($@"INSERT INTO DEVELOPERS_SKILLS(DEVELOPER_ID, SKILL)
                                          VALUES({developer.Id}, {language.GetHashCode()});");
            }

            using(var sqlConnection = new SqlConnection(base.ConnectionString))
            using(var sqlCommand = sqlConnection.CreateCommand())
            {
                sqlConnection.Open();

                sqlCommand.CommandText =  sqlCommands.ToString();
                sqlCommand.ExecuteNonQuery();
            }
        }

        public override SqlError Update(Developer entity)
        {
            throw new System.NotImplementedException();
        }

        private List<ProgrammingLanguagesEnum> GetLanguages(int developerId)
        {
            var languages = new List<ProgrammingLanguagesEnum>();

            using(var sqlConnection = new SqlConnection(base.ConnectionString))
            using(var sqlCommand = sqlConnection.CreateCommand())
            {
                sqlConnection.Open();

                sqlCommand.CommandText = $@"
                    SELECT SKILL FROM DEVELOPERS_SKILLS WHERE DEVELOPER_ID = {developerId}";

                var reader = sqlCommand.ExecuteReader();

                while(reader.Read())
                {
                    var skill = reader.GetByte(0);
                    var language = (ProgrammingLanguagesEnum)
                        Enum.Parse(typeof(ProgrammingLanguagesEnum), skill.ToString());

                    languages.Add(language);
                }
            }

            return languages;
        }
    }
}