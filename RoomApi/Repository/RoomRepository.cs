using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Npgsql;
using RoomApi.Models;

namespace RoomApi.Repository
{
    public class RoomRepository : IRepository<Room>
    {
        private string connectionString;
        public RoomRepository(IConfiguration configuration)
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

        public void Add(Room item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO room (RoomID,RoomName,Area,RoomNum,BuildingNo,DeptNo,Floor) " +
                    "VALUES(@roomID,@roomName,@area,@roomNum,@buildingNo,@deptNo,@floor)", item);
            }

        }

        public IEnumerable<Room> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Room>("SELECT * FROM room");
            }
        }

        public Room FindByID(int roomid)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Room>("SELECT * FROM room WHERE RoomID = @Roomid", new { Roomid = roomid }).FirstOrDefault();
            }
        }

        public IEnumerable<Room> FindByCond(Condtion condt)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Room>("SELECT * FROM Room WHERE " + condt.Condt);
            }
        }

        public void Remove(Room item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM room WHERE RoomID=@Roomid", item);
            }
        }

        public void Update(Condtion condt)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE room " + condt.Condt);
            }
        }
    }
}
