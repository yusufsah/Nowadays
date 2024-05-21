using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Companys
    {

        [Key]
        public int CompanysId { get; set; }

        public String? CompanyName { get; set; } = String.Empty;



        public ICollection<Projects> projects { get; set; }
    }
}
