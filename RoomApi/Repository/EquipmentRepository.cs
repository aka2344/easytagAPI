using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Npgsql;
using RoomApi.Models;

namespace RoomApi.Repository
{
    public class EquipmentRepository : IRepository<Equipment>
    {
        private string connectionString;
        public EquipmentRepository(IConfiguration configuration)
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

        public void Add(Equipment item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Equipment (EquipNo, CauseNo, Name_KR, Name_ENG, ItemName, IsDisuse, Indate, Price, Type, LifeYear, Status, QR_Date, ETC, RoomID, UserID, AdminID) " +
                    "VALUES(@equipNo, @causeNo, @name_KR, @name_ENG, @itemName, @isDisuse, @indate, @price, @type, @lifeYear, @status, @qr_Date, @eTC, @roomID, @userID, @adminID)", item);
            }

        }

        public IEnumerable<Equipment> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Equipment>("SELECT * FROM Equipment");
            }
        }

        public Equipment FindByID(double equipno)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Equipment>("SELECT * FROM equipment WHERE EquipNo = @Equipno", new { Equipno = equipno }).FirstOrDefault();
            }
        }

        public IEnumerable<Equipment> FindByCond(Condtion condt)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Equipment>("SELECT * FROM equipment WHERE " + condt.Condt);
            }
        }

        public void Remove(Equipment item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM Equipment WHERE EquipNo=@Equipno", item);
            }
        }

        public void Update(Condtion condt)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE Equipment " + condt.Condt); ;
            }
        }
    }
}
