using ForumITUDA.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumITUDA.Models.Interface
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IReportsRepository Reports { get; }
        IRolesRepository Roles { get; }
        IScholasticRepository Scholastics { get; }
        ITagsRepository Tags { get; }
        IUserGroupRoleRepository GroupRoles { get; }
        ICategoryRepository Categories { get; }
        IAnswerRepository Answers { get; }
        IAnswerVoteRepository AnswerVotes { get; }
        IBlogCategoryRepository BlogCategories { get; }
        IBlogRepository Blogs { get; }
        IBlogTagRepository BlogTags { get; }
    }
}
