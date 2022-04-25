using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumITUDA.Models.Dto
{
    public class UpdateReportDto
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int? WorkingStatus { get; set; }
        public Guid? QuestionId { get; set; }
        public Guid? CommentId { get; set; }
        public Guid? AnswerId { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
