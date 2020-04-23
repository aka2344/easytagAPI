using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Npgsql;
using RoomApi.Models;

namespace RoomApi.Repository
{
    public class ComplaintRepository : IRepository<Complaint>
    {
        private string connectionString;
        public ComplaintRepository(IConfiguration configuration)
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

        public void Add(Complaint item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Complaint (Request, RegistDate, EquipNo, UserID) VALUES(@request, @registDate, @equipNo, @userID)", item);
            }

        }

        public IEnumerable<Complaint> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Complaint>("SELECT * FROM Complaint");
            }
        }

        public Complaint FindByID(int registno)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Complaint>("SELECT * FROM Complaint WHERE RegistNo = @Registno", new { Registno = registno }).FirstOrDefault();
            }
        }

        public IEnumerable<Complaint> FindByCond(Condtion condt)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Complaint>("SELECT * FROM Complaint WHERE " + condt.Condt);
            }
        }

        public void Remove(Complaint item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM Complaint WHERE RegistNo=@Registno", item);
            }
        }

        public void Update(Condtion condt)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE Complaint " + condt.Condt); ;
            }
        }
    }
}
