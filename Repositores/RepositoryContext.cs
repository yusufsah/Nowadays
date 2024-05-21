
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositores
{
    public class RepositoryContext :DbContext
    {

       public DbSet<Companys> Companys { get; set; }

       

        public DbSet<Projects> Projects { get; set; }


        public DbSet<Employees> Employees { get; set; }

       


        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
       


    }
}
