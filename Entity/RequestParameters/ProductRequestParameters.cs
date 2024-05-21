using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.RequestParameters
{
    public class ProductRequestParameters : RequestParameters
    {
        public string? SearchTerm { get; set; }

        public int? CompanysId { get; set; }  //

        public int? ProjectId  { get; set; } //

        public int? EmployeeId { get; set; }

    }
}
