using Entity.Model;
using Entity.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repositores.Constract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositores
{
    public sealed class ProjectRepository : RepositoryBase<Projects>, IProjectRespository
    {
        public ProjectRepository(RepositoryContext context) : base(context)
        {

        }

        public void createproduct(Projects projects)
        {
            create(projects);
        }

        public void DeleteOneProduct(Projects projects)
        {
            Remove(projects);
        }

        public IQueryable<Projects> GetAllProductwithDetails(ProductRequestParameters p)
        {
            if (p == null || p.CompanysId == null || p.CompanysId == 0)
            {
                return _context.Projects.Include(pr => pr.Companys);
            }
            else
            {
                return _context.Projects.Include(pr => pr.Companys).Where(pr => pr.CompanysId == p.CompanysId);
            }

        }

        public IQueryable<Projects> GetAllProject(bool trackChanges)
        {
            return FindAll(trackChanges);
        }

        public Projects? GetOneProject(int id, bool trackChangrs)
        {
            return FindByCondition(p => p.ProjectId.Equals(id), trackChangrs);
        }

        public void UpadateOneProduct(Projects projects)
        {
           Update(projects);
        }
    }
}
