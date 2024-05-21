using Entity.Dtos;
using Entity.Model;
using Entity.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface IProjectService
    {

        IQueryable<Projects> GetAllProducts(bool trackChanges);

        public Projects? GetOneProduct(int id, bool trackChangrs);
        IEnumerable<Projects> GetAllProductwithDetails(ProductRequestParameters p);


        void createproduct(ProjectsDtosForinsertion projectsDtosForinsertion);

        void DeleteOneProduct(int id);


        void UpadateOneProduct(ProjectsDtosForUpdate projectsDtosForUpdate);


        ProjectsDtosForUpdate GetOneProductForUpdate(int id, bool truckChanges);
    }
}
