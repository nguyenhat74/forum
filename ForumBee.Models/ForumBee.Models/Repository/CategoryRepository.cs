using Dapper;
using ForumITUDA.Models.Dto;
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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IConfiguration configuration;
        public CategoryRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<Category> AddAsync(CreateCategoryDto entity)
        {
            var procedureName = "spCreateCategories";
            var parameters = new DynamicParameters();
            parameters.Add("Name", entity.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("Slug", entity.Slug, DbType.String, ParameterDirection.Input);
            parameters.Add("Description", entity.Description, DbType.String, ParameterDirection.Input);
            parameters.Add("Icon", entity.Icon, DbType.String, ParameterDirection.Input);
            parameters.Add("IsActive", entity.IsActive, DbType.Boolean, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Category>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                var category = new Category()
                {
                    Name = entity.Name,
                    Slug = entity.Slug,
                    Description = entity.Description,
                    Icon = entity.Icon,
                    IsActive = entity.IsActive,
                };
                return category;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var procedureName = "spDeleteCategories";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Category>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var procedureName = "EXECUTE spGetAllCategories";
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryAsync<Category>(procedureName);
                return result.ToList();
            }
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            var procedureName = "spGetByIdCategories";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Category>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);                
                return result;
            }
        }

        public async Task<Category> UpdateAsync(UpdateCategoryDto entity, Guid id)
        {
            var procedureName = "spUpdateCategories";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("Name", entity.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("Slug", entity.Slug, DbType.String, ParameterDirection.Input);
            parameters.Add("Description", entity.Description, DbType.String, ParameterDirection.Input);
            parameters.Add("Icon", entity.Icon, DbType.String, ParameterDirection.Input);
            parameters.Add("IsActive", entity.IsActive, DbType.Boolean, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Category>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                var category = new Category()
                {
                    Id = id,
                    Name = entity.Name,
                    Slug = entity.Slug,
                    Description = entity.Description,
                    Icon = entity.Icon,
                    IsActive = entity.IsActive,
                };
                return category;
            }
        }

    }
}
