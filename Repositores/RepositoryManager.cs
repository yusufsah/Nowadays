using Repositores.Constract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositores
{
    public class RepositoryManager : IRepositoryManger
    {
        private readonly ICompanyRepositroyies _company;
        private readonly IProjectRespository _project;
        private readonly IEmployeesRespository _employees;
       

        private readonly RepositoryContext _Context;

        public RepositoryManager(ICompanyRepositroyies company, IProjectRespository project, IEmployeesRespository employees, RepositoryContext context)
        {
            _company = company;
            _project = project;
            _employees = employees;
            _Context = context;
        }

        public ICompanyRepositroyies companys => _company;

        public IProjectRespository projects => _project;

        public IEmployeesRespository employees => _employees;




        /// <summary>
        /// 
        /// </summary>


        void IRepositoryManger.save()
        {
           _Context.SaveChanges();
        }


        ///////////////////////////////////////////
    }
}
