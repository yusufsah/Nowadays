using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public record CompanyDtos
    {

        public int CompanysId { get; init; }

        public String? CompanyName { get; init; } = String.Empty;
    }
}
