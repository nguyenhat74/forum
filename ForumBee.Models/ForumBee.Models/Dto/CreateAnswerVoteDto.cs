using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumITUDA.Models.Dto
{
    public class CreateAnswerVoteDto
    {
        
        public Guid? IdAnswer { get; set; }
        public Guid? IdUser { get; set; }
        public bool? Type { get; set; }
        public bool? IsActive { get; set; }
    }
}
