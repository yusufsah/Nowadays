using Entity.Model;
using Entity.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repositores.Constract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositores
{
    public class EmployeesRepository : RepositoryBase<Employees>, IEmployeesRespository
    {
        public EmployeesRepository(RepositoryContext context) : base(context)
        {
        }

        public void createproduct(Employees employees)
        {
            create(employees);
        }

        public void DeleteOneProduct(Employees employees)
        {
           Remove(employees);
        }

        public IQueryable<Employees> GetAllProductwithDetails(ProductRequestParameters p)
        {
            if (p == null || p.ProjectId == null || p.ProjectId == 0)
            {
                return _context.Employees.Include(pr => pr.projects);
            }
            else
            {
                return _context.Employees.Include(pr => pr.projects).Where(pr => pr.ProjectId == p.ProjectId);
            }

        }

        public IQueryable<Employees> GetAllProject(bool trackChanges)
        {
            return FindAll(trackChanges); 
        }

        public IQueryable<Employees> GetEmployeesByProjectId(int projectId)
        {
            return _context.Employees.Include(e => e.projects).Where(e => e.ProjectId == projectId);
        }

        public Employees? GetOneProject(int id, bool trackChangrs)
        {
            return FindByCondition(p => p.EmployeeId.Equals(id), trackChangrs);
        }

        public void UpadateOneProduct(Employees employees)
        {
            Update(employees);
        }
    }
}
