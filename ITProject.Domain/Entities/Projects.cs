﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITProject.Domain.Entities
{
    public class Projects
    {
        public int ProjectID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
