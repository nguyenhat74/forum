using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumITUDA.Models.Dto
{
    public class CreateAnswerDto
    {
        public Guid? QuestionId { get; set; }
        public string? Content { get; set; }
        public bool? IsActive { get; set; }
    }
}
