using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }


        public string? Ad { get; set; }

        public string? Soyad { get; set; }

        public String? Duty { get; set; }

        public long? TCKimlikNo { get; set; } 

        public int? DogumYili { get; set; }

        public int? ProjectId { get; set; }

        public Projects? projects { get; set; }


    }
}
