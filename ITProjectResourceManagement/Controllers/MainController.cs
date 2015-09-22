using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITProjectResourceManagement.Models;

namespace ITProjectResourceManagement.Controllers
{
    public class MainController : Controller
    {
        [HttpGet]       //Get Main Welcome
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]       //Get Projects Page
        public ActionResult projectsPage()
        {
            ITProject1Entities IT = new ITProject1Entities();

            //create projects
            var vmUE = new ViewModelProjectsUnassignedEmp();
            var showProject = new List<Projects>();  //yet now not it vm but this doesn't error out

            foreach(var item in IT.Projects)
            {
                showProject.Add(new Projects
                {
                    ProjectID = item.ProjectID,
                    Name = item.Name,
                    Descrip = item.Descrip,
                    CatID = item.CatID,
                    Category = item.Category

                });
            }
            vmUE.allProjects = showProject;


            var showEmployees = new List<Employees>();
            var query = IT.Employees;

            //create employees
            foreach (var item in query)
            {
                if(item.ProjectsAssigned==0)
                {
                    showEmployees.Add(new Employees
                    {
                        EmployeeID = item.EmployeeID,
                        FName = item.FName,
                        LName = item.LName,
                        Specialty = item.Specialty,
                    });
                }   
            }
            vmUE.allEmployees = showEmployees;

            return View(vmUE);


            //return View(IT.Projects.ToList());
        }

        [HttpPost]       //Post Projects Page
        [ValidateAntiForgeryToken]
        public ActionResult projectsPage(string userN, string passW, string passC)
        {
            ITProject1Entities IT = new ITProject1Entities();
          
            return View(IT.Projects.ToList());
        }

        [HttpGet]       //Get Employees and Projects
        public ActionResult employeesPage()
        {
            ITProject1Entities IT = new ITProject1Entities();
            //if (User.IsInRole(""))

            int projectIdSel = int.Parse(RouteData.Values["id"].ToString());
            var displayProject = (from p in IT.Projects where p.ProjectID == projectIdSel select p).FirstOrDefault();

            //create projects
            var vm = new ViewModelProjectEmployee();
            var showProject = new List<Projects>();  //yet now not it vm but this doesn't error out

           
            showProject.Add(new Projects
            {
                ProjectID = displayProject.ProjectID,
                Name = displayProject.Name,
                Descrip = displayProject.Descrip,
                CatID = displayProject.CatID,
                Category = displayProject.Category

            });
            vm.allProjects = showProject;


            var showEmployees = new List<Employees>();
            var query = IT.Employees;

            //create employees
            foreach (var item in query)
            {
                showEmployees.Add(new Employees
                {
                    EmployeeID = item.EmployeeID,
                    FName = item.FName,
                    LName = item.LName,
                    Specialty = item.Specialty,
                });
            }
            vm.allEmployees = showEmployees;
            
            return View(vm);
            
        }

        [HttpGet]       //Get Employees and Projects
        public ActionResult addEmployees()
        {
            ITProject1Entities IT = new ITProject1Entities();
            int empIdSel = int.Parse(RouteData.Values["id"].ToString());
            //int projIdSel = int.Parse(RouteData.Values["pID"].ToString());
            var addEmp = (from e in IT.Employees where e.EmployeeID == empIdSel select e).FirstOrDefault();
            //addEmp.ProjectsAssigned = new[] { 0, 1, 2, 3, 4, 5, 6 };
            // = new SelectList(addEmp.ProjectsAssigned);

            if (addEmp != null)
            {
                return View(addEmp);
            }
            else
            {
                return View("projectsPage");
            }
        }

        [HttpPost]  //post project edit
        [ValidateAntiForgeryToken]
        public ActionResult addEmployees(int id, string Fname, int? ProjectsAssigned)
        {
            ITProject1Entities IT = new ITProject1Entities();
           
            var addEmp = (from e in IT.Employees where e.EmployeeID == id select e).FirstOrDefault();

            addEmp.FName = Fname;
            addEmp.ProjectsAssigned = ProjectsAssigned;
            IT.SaveChanges();

            return RedirectToAction("projectsPage");
            
        }
            
        [HttpGet]       //Get Tracker Page
        public ActionResult Tracker()
        {
            ITProject1Entities IT = new ITProject1Entities();
            //if (User.IsInRole(""))

            int projectIdSel = int.Parse(RouteData.Values["id"].ToString());
            var displayProject = (from p in IT.Projects where p.ProjectID == projectIdSel select p).FirstOrDefault();

            var vmT = new ViewModelTrackProjEmpl();

            //create projects
            var showProject = new List<Projects>();
            showProject.Add(new Projects
            {
                ProjectID = displayProject.ProjectID,
                Name = displayProject.Name,
                Descrip = displayProject.Descrip,
                CatID = displayProject.CatID,
                Category = displayProject.Category

            });
            vmT.allProj = showProject;

            //create employees
            var showEmployees = new List<Employees>();
            //var query = IT.Employees;

            var emplOnProj = (from t in IT.Employees where t.ProjectsAssigned == projectIdSel select t).ToList();
            foreach (var item in emplOnProj)
            {
                showEmployees.Add(new Employees
                {
                    EmployeeID = item.EmployeeID,
                    FName = item.FName,
                    LName = item.LName,
                    Specialty = item.Specialty,
                });
            }
            vmT.allEmpl = showEmployees;

            //create tracker
            var showTracker = new List<Tracker>();
            var displayTracker = (from t in IT.Trackers where t.ProjectID_FK == projectIdSel select t).FirstOrDefault();
            showTracker.Add(new Models.Tracker
            {
                ID = displayTracker.ID,
                Value = displayTracker.Value,
                ProjectID_FK = displayTracker.ProjectID_FK,
            });
            vmT.track = showTracker;

            return View(vmT);
        }
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult progressPage(int id, int value)
        {
            ITProject1Entities IT = new ITProject1Entities();
            var displayTracker = (from t in IT.Trackers where t.ID == id select t).FirstOrDefault();

            displayTracker.Value = value;
            IT.SaveChanges();

            return RedirectToAction("Tracker", new { id = displayTracker.ID });

        }
        */
        
        [HttpGet]
        public ActionResult progressPage()
        {
            ITProject1Entities IT = new ITProject1Entities();

            int trackIdSel = int.Parse(RouteData.Values["id"].ToString());
            var displayTracker = (from t in IT.Trackers where t.ID == trackIdSel select t).FirstOrDefault();

            if (displayTracker != null)
            {
                return View(displayTracker);
            }
            else
            {
                return View("projectsPage");
            }
        }

        [HttpPost]
        public ActionResult progressPage(int id, int value)
        {
            ITProject1Entities IT = new ITProject1Entities();
            var displayTracker = (from t in IT.Trackers where t.ID == id select t).FirstOrDefault();

            displayTracker.Value = value;
            IT.SaveChanges();

            return RedirectToAction("progressPage");
        }
        
    }
}