using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITProjectResourceManagement.Models
{
    public class ViewModelTrackProjEmpl
    {
        public List<Projects> allProj { get; set; }
        public List<Employees> allEmpl { get; set; }
        public List<Tracker> track { get; set; }

    }

    /*
    public class Trackers
    {
        public int ID { get; set; }
        public int value { get; set; }
        public int ProjID { get; set; }


    }
    */
   
}