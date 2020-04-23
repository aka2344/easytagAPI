using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Npgsql;
using RoomApi.Models;

namespace RoomApi.Repository
{
    public class SurveyRepository : IRepository<Survey>
    {
        private string connectionString;
        public SurveyRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public void Add(Survey item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Survey (SurveyDate, SurveyResult, ETC, EquipNo) " +
                    "VALUES(@SurveyDate, @SurveyResult, @ETC, @EquipNo)", item);
            }

        }

        public IEnumerable<Survey> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Survey>("SELECT * FROM Survey");
            }
        }

        public Survey FindByID(int sno)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Survey>("SELECT * FROM Survey WHERE SurveyNo = @SurveyNo", new { SurveyNo = sno }).FirstOrDefault();
            }
        }

        public IEnumerable<Survey> FindByCond(Condtion condt)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Survey>("SELECT * FROM Survey WHERE " + condt.Condt);
            }
        }

        public void Remove(Survey item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM Survey WHERE SurveyNo = @SurveyNo", item);
            }
        }

        public void Update(Condtion condt)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE Survey " + condt.Condt);
            }
        }
    }
}
