using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Npgsql;
using RoomApi.Models;

namespace RoomApi.Repository
{
    public class DepartmentRepository : IRepository<Department>
    {
        private string connectionString;
        public DepartmentRepository(IConfiguration configuration)
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

        public void Add(Department item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Department (DeptNo, DeptName, DeptPhoneNum) VALUES(@DeptNo, @DeptName, @DeptPhoneNum)", item);
            }

        }

        public IEnumerable<Department> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Department>("SELECT * FROM Department");
            }
        }

        public Department FindByID(int deptno)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Department>("SELECT * FROM Department WHERE DeptNo = @Deptno", new { Deptno = deptno }).FirstOrDefault();
            }
        }

        public IEnumerable<Department> FindByCond(Condtion condt)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Department>("SELECT * FROM Department WHERE " + condt.Condt);
            }
        }

        public void Remove(Department item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM Department WHERE DeptNo = @Deptno", item);
            }
        }

        public void Update(Condtion condt)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE Department " + condt.Condt); ;
            }
        }
    }
}
