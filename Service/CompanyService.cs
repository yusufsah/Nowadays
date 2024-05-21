using AutoMapper;
using Entity.Dtos;
using Entity.Model;
using Repositores.Constract;
using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepositoryManger _manager;
        private readonly IMapper _mapper;

        public CompanyService(IRepositoryManger manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void createproduct(CompanyDtosForinsertion companyDtosForinsertion)
        {
            Companys product = _mapper.Map<Companys>(companyDtosForinsertion); // buryı yukarda dto koyduk diye var yoksa  burayı yamaya gerek yoktu


            _manager.companys.createproduct(product);
            _manager.save();
        }

        public void DeleteOneProduct(int id)
        {
            Companys company = GetOneProduct(id, false) ?? new Companys();  // 1 adet ürün aldık
            if (company is not null)
            {

                _manager.companys.DeleteOneProduct(company);
                _manager.save();
            }
        }

        public IQueryable<Companys> GetAllProducts(bool trackChanges)
        {
            return _manager.companys.GetAllProducts(trackChanges);
        }

        public Companys? GetOneProduct(int id, bool trackChangrs)
        {
            var company = _manager.companys.GetOneProduct(id, trackChangrs);

            if (company is null)
            {
                throw new Exception("not found");     // burasyı istege bağlı yaptım 
            }
            else
            {
                return company;
            }

        }
        //
        public CompanyDtosForUpdate GetOneProductForUpdate(int id, bool truckChanges)
        {
            var product = _manager.companys.GetOneProduct(id, truckChanges);
            var productdto = _mapper.Map<CompanyDtosForUpdate>(product);

            return productdto;
        }
        //

        public void UpadateOneProduct(CompanyDtosForUpdate companyDtosForUpdate)
        {
            Companys product = _mapper.Map<Companys>(companyDtosForUpdate);
            _manager.companys.UpadateOneProduct(product);



            _manager.save();
        }
    }
}
