using Entity.Dtos;
using Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NowaDaysWebApi.Mapper;
using Repositores.Constract;
using Service.Contract;

namespace NowaDaysWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NowaDyasController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IRepositoryManger _repositoryManger;

        public NowaDyasController(IServiceManager manager, IRepositoryManger repositoryManger)
        {
            _manager = manager;
            _repositoryManger = repositoryManger;
        }

        [HttpGet("CompanyList")]
        public IActionResult CompanyList()
        {
            var companies = _manager.CompanyService.GetAllProducts(false);

            if (companies == null || !companies.Any())
            {
                return NotFound();
            }

            return Ok(companies);
        }

        [HttpGet("projectList")]
        public IActionResult projectList()
        {
            var projects = _manager.ProjectService.GetAllProducts(false);

            if (projects == null || !projects.Any())
            {
                return NotFound();
            }

            return Ok(projects);
        }

        //
        [HttpGet("EmployeeList")]
        public IActionResult EmployeeList()
        {
            var projects = _repositoryManger.employees.GetAllProject(false);

            if (projects == null || !projects.Any())
            {
                return NotFound();
            }

            return Ok(projects);
        }






        /// <summary>
        /// /////////////////////////////////////////////////////
        /// </summary>
       

        [HttpDelete("DeleteCompany/{id}")]
        public IActionResult DeleteCompany(int id)
        {
            var company = _manager.CompanyService.GetOneProduct(id, false);

            if (company == null)
            {
                return NotFound();
            }

            _manager.CompanyService.DeleteOneProduct(id);

            return NoContent();
        }

        [HttpDelete("DeleteProject/{id}")]
        public IActionResult DeleteProject(int id)
        {
            try
            {
                _manager.ProjectService.DeleteOneProduct(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //
        [HttpDelete("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                _manager.EmployeeService.DeleteOneProduct(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
