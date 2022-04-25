using Dapper;
using ForumITUDA.Models.Entities;
using ForumITUDA.Models.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumITUDA.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration configuration;
        public UserRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<User> checkLogin(string username, string password)
        {
            var procedureName = "spCheckLogin";
            var parameters = new DynamicParameters();
            parameters.Add("Username", username, DbType.String, ParameterDirection.Input);
            parameters.Add("Password", password, DbType.String, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<User>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<User> getProfile(Guid id)
        {
            var procedureName = "spGetProfile";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<User>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<User> RegisterUser(string email, string password, string firstname, string lastname)
        {
            var procedureName = "spCreateUser";
            var parameters = new DynamicParameters();
            parameters.Add("Email", email, DbType.String, ParameterDirection.Input);
            parameters.Add("Password", password, DbType.String, ParameterDirection.Input);
            parameters.Add("Firstname", firstname, DbType.String, ParameterDirection.Input);
            parameters.Add("Lastname", lastname, DbType.String, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<User>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<User> CheckRegister(string username)
        {
            var procedureName = "spCheckUserRegister";
            var parameters = new DynamicParameters();
            parameters.Add("Username", username, DbType.String, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<User>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
