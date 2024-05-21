using Entity.Dtos;
using Entity.Model;
using Entity.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositores.Constract;
using Service.Contract;

namespace Presentation.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly IRepositoryManger _manager;
        private readonly IServiceManager _serviceManager;
        

        public EmployeesController(IRepositoryManger manager, IServiceManager serviceManager)
        {
            _manager = manager;
            _serviceManager = serviceManager;
        }




        ////////////////////////////////
        ///  

     
        public IActionResult Index(int projectId)
        {
            var requestParameters = new ProductRequestParameters { ProjectId = projectId };
            var model = _serviceManager.EmployeeService.GetAllProductwithDetails(requestParameters).ToList();
            return View(model);
        }




        /// <summary>
        /// /////////////////////////////////////////////////////////////

        [HttpGet]
        public IActionResult CreateEmployee()
        {   

            ViewBag.categores = new SelectList(_serviceManager.ProjectService.GetAllProducts(false), "ProjectId", "ProjectName", "1");


            return View();

        }

        //
        [HttpPost]
        public IActionResult CreateEmployee(Employees employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _manager.employees.createproduct(employee);
                    _manager.save();
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while creating the employee: " + ex.Message);
                }
            }

            
            return View(employee);
        

    }


        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _serviceManager.EmployeeService.DeleteOneProduct(id);

            return RedirectToAction("Index", "Home");
            
        }

        ////
        ///
        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
            var employee = _manager.employees.GetOneProject(id, trackChangrs: false);
            if (employee == null)
            {
                return NotFound();
            }

            ViewBag.Projects = new SelectList(_manager.projects.GetAllProject(false), "ProjectId", "ProjectName", employee.ProjectId);
            return View(employee);
        }

        [HttpPost]
        public IActionResult UpdateEmployee(Employees employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _manager.employees.UpadateOneProduct(employee);
                    _manager.save();
                    return RedirectToAction("Index", "Project", new { projectId = employee.ProjectId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while updating the employee: " + ex.Message);
                }
            }

            ViewBag.Projects = new SelectList(_manager.projects.GetAllProject(false), "ProjectId", "ProjectName", employee.ProjectId);
            return View(employee);
        }










    }
}
