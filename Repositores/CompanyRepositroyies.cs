using Entity.Model;
using Repositores.Constract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositores
{
    public sealed class CompanyRepositroyies : RepositoryBase<Companys>, ICompanyRepositroyies
    {
        public CompanyRepositroyies(RepositoryContext context) : base(context)
        {
        }

        public void createproduct(Companys companys)
        {
            create(companys);
        }

        public void DeleteOneProduct(Companys companys)
        {
           Remove(companys);
        }

        public IQueryable<Companys> GetAllProducts(bool trackChanges)
        {
            return FindAll(trackChanges);
        }

        public Companys? GetOneProduct(int id, bool trackChangrs)
        {
            return FindByCondition(p => p.CompanysId.Equals(id), trackChangrs);
        }

        public void UpadateOneProduct(Companys companys)
        {
            Update(companys);
        }
    }
}
