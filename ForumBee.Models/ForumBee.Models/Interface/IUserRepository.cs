using ForumITUDA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumITUDA.Models.Interface
{
    public interface IUserRepository
    {
        Task<User> checkLogin(string username, string password);
        Task<User> getProfile(Guid id);
        Task<User> CheckRegister(string username);
        Task<User> RegisterUser(string email, string password,string firstname,string lastname);
        
        //Task<User> GetByIdAsync(Guid id);
    }
}
