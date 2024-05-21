using Entity.Model;
using Entity.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositores.Constract
{
    public interface IEmployeesRespository: IRepositoryBase<Employees>
    {

        IQueryable<Employees> GetAllProject(bool trackChanges);

        public Employees? GetOneProject(int id, bool trackChangrs);

        IQueryable<Employees> GetAllProductwithDetails(ProductRequestParameters p);

        IQueryable<Employees> GetEmployeesByProjectId(int projectId);
        void createproduct(Employees employees);

        void DeleteOneProduct(Employees employees);


        void UpadateOneProduct(Employees employees);
    }
}
