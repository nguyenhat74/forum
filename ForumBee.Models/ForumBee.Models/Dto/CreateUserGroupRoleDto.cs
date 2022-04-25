using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumITUDA.Models.Dto
{
    public class CreateUserGroupRoleDto
    {
        public Guid UserId { get; set; }
        public Guid? GroupId { get; set; }
        public Guid RoleId { get; set; }
        public bool? IsActive { get; set; }
    }
}
