using TravelAdvice.Domaine.infrastructure;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvice.Domaine;
using TravelAdvice.Domaine.Entity;

namespace TravelAdvice.Domaine.Repo
{
    public class VoleRepository : RepositoryBase<vole>, IVoleRepository
    {

        public VoleRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {

        }

    }     
       public interface IVoleRepository : IRepositoryBase<vole> { }
   
}

