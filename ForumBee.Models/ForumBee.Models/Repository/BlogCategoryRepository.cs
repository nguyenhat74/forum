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
    public class BlogCategoryRepository : IBlogCategoryRepository
    {
        private readonly IConfiguration configuration;
        public BlogCategoryRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<BlogCategory> AddAsync(CreateBlogCategoryDto entity)
        {
            var procedureName = "spCreateBlogCategories";
            var parameters = new DynamicParameters();
            parameters.Add("Name", entity.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("Slug", entity.Slug, DbType.String, ParameterDirection.Input);
            parameters.Add("Description", entity.Description, DbType.String, ParameterDirection.Input);
            parameters.Add("Icon", entity.Icon, DbType.String, ParameterDirection.Input);
            parameters.Add("IsActive", entity.IsActive, DbType.Boolean, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<BlogCategory>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                var blogCategory = new BlogCategory()
                {
                    Name = entity.Name,
                    Slug = entity.Slug,
                    Description = entity.Description,
                    Icon = entity.Icon,
                    IsActive = entity.IsActive,
                };
                return blogCategory;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var procedureName = "spDeleteBlogCategories";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<BlogCategory>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<BlogCategory>> GetAllAsync()
        {
            var procedureName = "EXECUTE spGetAllBlogCategories";
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryAsync<BlogCategory>(procedureName);
                return result.ToList();
            }
        }

        public async Task<BlogCategory> GetByIdAsync(Guid id)
        {
            var procedureName = "spGetByIdBlogCategories";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<BlogCategory>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<BlogCategory> UpdateAsync(UpdateBlogCategoryDto entity, Guid id)
        {
            var procedureName = "spUpdateBlogCategories";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("Name", entity.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("Slug", entity.Slug, DbType.String, ParameterDirection.Input);
            parameters.Add("Description", entity.Description, DbType.String, ParameterDirection.Input);
            parameters.Add("Icon", entity.Icon, DbType.String, ParameterDirection.Input);
            parameters.Add("IsActive", entity.IsActive, DbType.Boolean, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<BlogCategory>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                var blogCategory = new BlogCategory()
                {
                    Id = id,
                    Name = entity.Name,
                    Slug = entity.Slug,
                    Description = entity.Description,
                    Icon = entity.Icon,
                    IsActive = entity.IsActive,
                };
                return blogCategory;
            }
        }
    }
}
