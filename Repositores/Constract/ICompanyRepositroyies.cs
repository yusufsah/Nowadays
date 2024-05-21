using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositores.Constract
{
    public interface ICompanyRepositroyies:IRepositoryBase<Companys>
    {
        IQueryable<Companys> GetAllProducts(bool trackChanges); 

        public Companys? GetOneProduct(int id, bool trackChangrs);


        void createproduct(Companys companys);

        void DeleteOneProduct(Companys companys);


        void UpadateOneProduct(Companys companys);

    }
}
