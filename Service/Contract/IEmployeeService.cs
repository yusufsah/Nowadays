using Entity.Model;
using Entity.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface IEmployeeService
    {

        IEnumerable<Employees> GetAllProductwithDetails(ProductRequestParameters p);

        void DeleteOneProduct(int id);

        public Employees? GetOneProduct(int id, bool trackChangrs);

    }
}
