using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Npgsql;
using RoomApi.Models;

namespace RoomApi.Repository
{
    public class MaintenanceRepository : IRepository<Maintenance>
    {
        private string connectionString;
        public MaintenanceRepository(IConfiguration configuration)
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

        public void Add(Maintenance item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Maintenance (ApplyDate, ApplyReason, IsApproval, ApprovalDate, StartDate, Details, Cost, EquipNo) VALUES(@ApplyDate, @ApplyReason, @IsApproval, @ApprovalDate, @StartDate, @Details, @Cost, @EquipNo)", item);
            }

        }

        public IEnumerable<Maintenance> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Maintenance>("SELECT * FROM Maintenance");
            }
        }

        public Maintenance FindByID(int mno)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Maintenance>("SELECT * FROM Maintenance WHERE M_No = @M_No", new { M_No = mno }).FirstOrDefault();
            }
        }

        public IEnumerable<Maintenance> FindByCond(Condtion condt)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Maintenance>("SELECT * FROM Maintenance WHERE " + condt.Condt);
            }
        }

        public void Remove(Maintenance item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM Maintenance WHERE M_No = @M_No", item);
            }
        }

        public void Update(Condtion condt)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE Maintenance " + condt.Condt); ;
            }
        }
    }
}
