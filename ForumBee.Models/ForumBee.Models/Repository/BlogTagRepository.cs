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
    public class BlogTagRepository : IBlogTagRepository
    {
        private readonly IConfiguration configuration;
        public BlogTagRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<BlogTag> AddAsync(CreateBlogTagDto entity)
        {
            var procedureName = "spCreateBlogTags";
            var parameters = new DynamicParameters();
            parameters.Add("IdBlog", entity.IdBlog, DbType.Guid, ParameterDirection.Input);
            parameters.Add("IdTag", entity.IdTag, DbType.Guid, ParameterDirection.Input);
            parameters.Add("IsActive", entity.IsActive, DbType.Boolean, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<BlogTag>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                var blogTag = new BlogTag()
                {
                    IdBlog = entity.IdBlog,
                    IdTag = entity.IdTag,
                    IsActive = entity.IsActive,
                };
                return blogTag;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var procedureName = "spDeleteBlogTags";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<BlogTag>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<BlogTag>> GetAllAsync()
        {
            var procedureName = "EXECUTE spGetAllBlogTags";
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryAsync<BlogTag>(procedureName);
                return result.ToList();
            }
        }

        public async Task<BlogTag> GetByIdAsync(Guid id)
        {
            var procedureName = "spGetByIdBlogTags";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<BlogTag>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<BlogTag> UpdateAsync(UpdateBlogTagDto entity, Guid id)
        {
            var procedureName = "spCreateBlogTags";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("IdBlog", entity.IdBlog, DbType.Guid, ParameterDirection.Input);
            parameters.Add("IdTag", entity.IdTag, DbType.Guid, ParameterDirection.Input);
            parameters.Add("IsActive", entity.IsActive, DbType.Boolean, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<BlogTag>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                var blogTag = new BlogTag()
                {
                    Id = id,
                    IdBlog = entity.IdBlog,
                    IdTag = entity.IdTag,
                    IsActive = entity.IsActive,
                };
                return blogTag;
            }
        }
    }
}
