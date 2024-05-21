using Entity.Model;
using Entity.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositores.Constract
{
    public interface IProjectRespository :IRepositoryBase<Projects>
    {
        IQueryable<Projects> GetAllProject(bool trackChanges);

        public Projects? GetOneProject(int id, bool trackChangrs);

        IQueryable<Projects> GetAllProductwithDetails(ProductRequestParameters p);


        void createproduct(Projects projects);

        void DeleteOneProduct(Projects projects );


        void UpadateOneProduct(Projects projects);
    }
}
