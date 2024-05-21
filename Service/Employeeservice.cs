using Entity.Model;
using Entity.RequestParameters;
using Repositores.Constract;
using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Employeeservice : IEmployeeService
    {

        private readonly IRepositoryManger _manager;

        public Employeeservice(IRepositoryManger manager)
        {
            _manager = manager;
        }

        public void DeleteOneProduct(int id)
        {
            Employees company = GetOneProduct(id, false) ?? new Employees();  //
            if (company is not null)
            {

                _manager.employees.DeleteOneProduct(company);
                _manager.save();
            }
        }

        public IEnumerable<Employees> GetAllProductwithDetails(ProductRequestParameters p)
        {
            return _manager.employees.GetAllProductwithDetails(p);
        }

        public Employees? GetOneProduct(int id, bool trackChangrs)
        {
            var project = _manager.employees.GetOneProject(id, trackChangrs);

            if (project is null)
            {
                throw new Exception("not found");     // burasyı istege bağlı yaptım 
            }
            else
            {
                return project;
            }
        }
    }
}
