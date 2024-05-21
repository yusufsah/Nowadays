using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface IServiceManager
    {
        ICompanyService CompanyService { get; }

        IProjectService ProjectService { get; }


        IEmployeeService EmployeeService { get; }


        

       

        

      

        
    }
}
