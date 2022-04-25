﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumITUDA.Models.Dto
{
    public class CreateScholasticDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int? SortOrder { get; set; }

        public bool? IsActive { get; set; }
    }
}