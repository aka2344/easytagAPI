using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Npgsql;
using RoomApi.Models;

namespace RoomApi.Repository
{
    public class BuildingRepository : IRepository<Building>
    {
        private string connectionString;
        public BuildingRepository(IConfiguration configuration)
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

        public void Add(Building item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Building (buildingno,buildingname,totalfloor) VALUES(@buildingno,@buildingname,@totalfloor)", item);
            }

        }

        public IEnumerable<Building> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Building>("SELECT buildingno,buildingname,totalfloor FROM Building");
            }
        }

        public Building FindByID(int buildingno)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Building>("SELECT buildingno,buildingname,totalfloor FROM building WHERE buildingno = @BuildingNo", new { Buildingno = buildingno }).FirstOrDefault();
            }
        }

        public IEnumerable<Building> FindByCond(Condtion condt)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Building>("SELECT * FROM Building WHERE " + condt.Condt);
            }
        }

        public void Remove(Building item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM Building WHERE buildingno=@BuildingNo", item);
            }
        }

        public void Update(Condtion condt)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE Building " + condt.Condt); ;
            }
        }
    }
}
