using AutoMapper;
using Entity.Dtos;
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
    public class ProjectService : IProjectService
    {

        private readonly IRepositoryManger _manager;
        private readonly IMapper _mapper;

        public ProjectService(IRepositoryManger manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }
        /// <summary>
        /// ///////////////////////
        

        public void createproduct(ProjectsDtosForinsertion projectsDtosForinsertion)
        {
            Projects projects = _mapper.Map<Projects>(projectsDtosForinsertion); // buryı yukarda dto koyduk diye var yoksa  burayı yamaya gerek yoktu


            _manager.projects.createproduct(projects);
            _manager.save();
        }

        public void DeleteOneProduct(int id)
        {
            Projects company = GetOneProduct(id, false) ?? new Projects();  // 1 adet ürün aldık
            if (company is not null)
            {

                _manager.projects.DeleteOneProduct(company);
                _manager.save();
            }
        }

        public IQueryable<Projects> GetAllProducts(bool trackChanges)
        {
            return _manager.projects.GetAllProject(trackChanges);
        }

        public IEnumerable<Projects> GetAllProductwithDetails(ProductRequestParameters p)
        {
            return _manager.projects.GetAllProductwithDetails(p);
        }

        public Projects? GetOneProduct(int id, bool trackChangrs)
        {
            var project = _manager.projects.GetOneProject(id, trackChangrs);

            if (project is null)
            {
                throw new Exception("not found");     // burasyı istege bağlı yaptım 
            }
            else
            {
                return project;
            }
        }

        public ProjectsDtosForUpdate GetOneProductForUpdate(int id, bool truckChanges)
        {
            var product = _manager.projects.GetOneProject(id, truckChanges);
            var productdto = _mapper.Map<ProjectsDtosForUpdate>(product);

            return productdto;
        }

        public void UpadateOneProduct(ProjectsDtosForUpdate projectsDtosForUpdate)
        {
            Projects product = _mapper.Map<Projects>(projectsDtosForUpdate);
            _manager.projects.UpadateOneProduct(product);



            _manager.save();
        }
    }
}
