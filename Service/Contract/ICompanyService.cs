using Entity.Dtos;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface ICompanyService
    {
        IQueryable<Companys> GetAllProducts(bool trackChanges);

        public Companys? GetOneProduct(int id, bool trackChangrs);


        void createproduct(CompanyDtosForinsertion companyDtosForinsertion );



        void DeleteOneProduct(int id);


        void UpadateOneProduct(CompanyDtosForUpdate companyDtosForUpdate);


        CompanyDtosForUpdate GetOneProductForUpdate(int id, bool truckChanges);

    }
}
