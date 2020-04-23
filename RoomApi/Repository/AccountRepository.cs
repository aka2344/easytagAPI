using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Npgsql;
using RoomApi.Models;

namespace RoomApi.Repository
{
    public class AccountRepository : IRepository<Account>
    {
        private string connectionString;
        public AccountRepository(IConfiguration configuration)
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

        public void Add(Account item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Account (UserID, UserPW, UserName, PhoneNumber, Authority, DeptNo) VALUES(@userID, @userPW, @userName, @phoneNumber, @authority, @deptNo)", item);
            }

        }

        public IEnumerable<Account> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Account>("SELECT * FROM Account");
            }
        }

        public Account FindByID(string userid)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Account>("SELECT * FROM account WHERE UserID = @Userid", new { Userid = userid }).FirstOrDefault();
            }
        }

        public IEnumerable<Account> FindByCond(Condtion condt)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Account>("SELECT * FROM Account WHERE " + condt.Condt);
            }
        }

        public void Remove(Account item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM Account WHERE UserID=@Userid", item);
            }
        }

        public void Update(Condtion condt)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE Account " + condt.Condt); ;
            }
        }
    }
}
