using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Npgsql;
using RoomApi.Models;

namespace RoomApi.Repository
{
    public class HistoryRepository : IRepository<History>
    {
        private string connectionString;
        public HistoryRepository(IConfiguration configuration)
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

        public void Add(History item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                //미구현
            }

        }

        public IEnumerable<History> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<History>("SELECT * FROM history");
            }
        }

        public IEnumerable<History> FindByCond(Condtion condt)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<History>("SELECT * FROM History WHERE " + condt.Condt);
            }
        }

        public void Remove(History item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                //미구현
            }
        }

        public void Update(Condtion condt)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                //미구현
            }
        }
    }
}
