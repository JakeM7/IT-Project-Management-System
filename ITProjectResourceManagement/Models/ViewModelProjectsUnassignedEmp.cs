using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITProjectResourceManagement.Models
{
    public class ViewModelProjectsUnassignedEmp
    {
        public List<Projects> allProjects { get; set; }
        public List<Employees> allEmployees { get; set; }
    }
    
}