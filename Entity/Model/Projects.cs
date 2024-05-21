using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Projects
    {

        [Key]
        public int ProjectId { get; set; }

        public String? ProjectName { get; set; } = String.Empty;

        public String? ProjectContent {  get; set; } 

        public String? City { get; set; }


        public ICollection<Employees> employees { get; set; }

        public int CompanysId { get; set; }

        public Companys Companys { get; set; }

       


    }
}
