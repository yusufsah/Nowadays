using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositores.Constract
{
    public interface IRepositoryManger
    {
        ICompanyRepositroyies companys { get; }

        IProjectRespository projects { get; }


        IEmployeesRespository employees { get; }

      
       

        

        void save();
    }
}
