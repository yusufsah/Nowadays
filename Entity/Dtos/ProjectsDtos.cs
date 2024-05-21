using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public record ProjectsDtos
    {
        public int ProjectId { get; init; }

        public String? ProjectName { get; init; } = String.Empty;

        public String? ProjectContent { get; set; }

        public String? City { get; init; }

        public int CompanysId { get; init; }

       
    }
}
