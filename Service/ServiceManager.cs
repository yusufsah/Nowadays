using AutoMapper;
using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly ICompanyService _companyService;
        private readonly IProjectService _projectService;
        private readonly IEmployeeService _employeeservice;

        public ServiceManager(ICompanyService companyService, IProjectService projectService, IEmployeeService employeeservice)
        {
            _companyService = companyService;
            _projectService = projectService;
            _employeeservice = employeeservice;
        }

        public ICompanyService CompanyService => _companyService;

        public IProjectService ProjectService => _projectService;

        public IEmployeeService EmployeeService => _employeeservice;
    }
}
