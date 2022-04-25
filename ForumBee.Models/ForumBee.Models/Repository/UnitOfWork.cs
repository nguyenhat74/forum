
using ForumITUDA.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumITUDA.Models.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUserRepository userRepository, IReportsRepository reportsRepository, 
            IRolesRepository rolesRepository, IScholasticRepository scholasticRepository,
            ICategoryRepository categoryRepository,
            IAnswerRepository answerRepository,
            IAnswerVoteRepository answerVoteRepository,
            IBlogCategoryRepository blogCategoryRepository,
            IBlogRepository blogRepository,
            IBlogTagRepository blogTagRepository)
        {
            Users = userRepository;
            Reports = reportsRepository;
            Roles = rolesRepository;
            Scholastics = scholasticRepository;
            Categories = categoryRepository;
            Answers = answerRepository;
            AnswerVotes = answerVoteRepository;
            BlogCategories = blogCategoryRepository;
            Blogs = blogRepository;
            BlogTags = blogTagRepository;
        }
        public IUserRepository Users { get; }

        public IReportsRepository Reports { get; }

        public IRolesRepository Roles { get; }

        public IScholasticRepository Scholastics { get; }
        public ITagsRepository Tags { get; }
        public IUserGroupRoleRepository GroupRoles { get; }
        public ICategoryRepository Categories { get; }
        public IAnswerRepository Answers { get; }
        public IAnswerVoteRepository AnswerVotes { get; }
        public IBlogCategoryRepository BlogCategories { get; }
        public IBlogRepository Blogs { get; }
        public IBlogTagRepository BlogTags { get; }


    }
}
