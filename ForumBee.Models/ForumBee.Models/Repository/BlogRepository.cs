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
    public class BlogRepository : IBlogRepository
    {
        private readonly IConfiguration configuration;
        public BlogRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<Blog> AddAsync(CreateBlogDto entity)
        {
            var procedureName = "spCreateBlogs";
            var parameters = new DynamicParameters();
            parameters.Add("Title", entity.Title, DbType.String, ParameterDirection.Input);
            parameters.Add("Slug", entity.Slug, DbType.String, ParameterDirection.Input);
            parameters.Add("Content", entity.Content, DbType.String, ParameterDirection.Input);
            parameters.Add("Description", entity.Description, DbType.String, ParameterDirection.Input);
            parameters.Add("ViewCount", entity.ViewCount, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Thumbnail", entity.Thumbnail, DbType.String, ParameterDirection.Input);
            parameters.Add("IdCategory", entity.IdCategory, DbType.Guid, ParameterDirection.Input);
            parameters.Add("CreatedBy", entity.CreatedBy, DbType.Guid, ParameterDirection.Input);
            parameters.Add("UpdatedBy", entity.UpdatedBy, DbType.Guid, ParameterDirection.Input);
            parameters.Add("IsLocked", entity.IsLocked, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("IsActive", entity.IsActive, DbType.Boolean, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Blog>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                var blog = new Blog()
                {
                    Title = entity.Title,
                    Slug = entity.Slug,
                    Content = entity.Content,
                    Description = entity.Description,
                    ViewCount = entity.ViewCount,
                    Thumbnail = entity.Thumbnail,
                    IdCategory = entity.IdCategory,
                    CreatedBy = entity.CreatedBy,
                    UpdatedBy = entity.UpdatedBy,
                    IsLocked = entity.IsLocked,
                    IsActive = entity.IsActive,

                };
                return blog;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var procedureName = "spDeleteBlogs";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Blog>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            var procedureName = "EXECUTE spGetAllBlogs";
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryAsync<Blog>(procedureName);
                return result.ToList();
            }
        }

        public async Task<Blog> GetByIdAsync(Guid id)
        {
            var procedureName = "spGetByIdBlogs";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Blog>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<Blog> UpdateAsync(UpdateBlogDto entity, Guid id)
        {
            var procedureName = "spCreateBlogs";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("Title", entity.Title, DbType.String, ParameterDirection.Input);
            parameters.Add("Slug", entity.Slug, DbType.String, ParameterDirection.Input);
            parameters.Add("Content", entity.Content, DbType.String, ParameterDirection.Input);
            parameters.Add("Description", entity.Description, DbType.String, ParameterDirection.Input);
            parameters.Add("ViewCount", entity.ViewCount, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Thumbnail", entity.Thumbnail, DbType.String, ParameterDirection.Input);
            parameters.Add("IdCategory", entity.IdCategory, DbType.Guid, ParameterDirection.Input);
            parameters.Add("CreatedBy", entity.CreatedBy, DbType.Guid, ParameterDirection.Input);
            parameters.Add("UpdatedBy", entity.UpdatedBy, DbType.Guid, ParameterDirection.Input);
            parameters.Add("IsLocked", entity.IsLocked, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("IsActive", entity.IsActive, DbType.Boolean, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Blog>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                var blog = new Blog()
                {
                    Id = id,
                    Title = entity.Title,
                    Slug = entity.Slug,
                    Content = entity.Content,
                    Description = entity.Description,
                    ViewCount = entity.ViewCount,
                    Thumbnail = entity.Thumbnail,
                    IdCategory = entity.IdCategory,
                    CreatedBy = entity.CreatedBy,
                    UpdatedBy = entity.UpdatedBy,
                    IsLocked = entity.IsLocked,
                    IsActive = entity.IsActive,

                };
                return blog;
            }
        }
    }
}
