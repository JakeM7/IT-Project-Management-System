using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITProjectResourceManagement.Models
{
    public class ViewModelProjectEmployee
    {
        public List<Projects> allProjects { get; set; }
        //public Projects allProjects { get; set; }
        public List<Employees> allEmployees { get; set; }
    }
        public class Projects
        {
            public int ProjectID { get; set; }
            public string Name { get; set; }
            public string Descrip { get; set; }
            public int CatID { get; set; }

        public virtual Category Category { get; set; }
    }

        public class Employees
        {
            public int EmployeeID { get; set; }
            public string FName { get; set; }
            public string LName { get; set; }
            public int Specialty { get; set; }

            public virtual Category Category { get; set; }
        }
    

}