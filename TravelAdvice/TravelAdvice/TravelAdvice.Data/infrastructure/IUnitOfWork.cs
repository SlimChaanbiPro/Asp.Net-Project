using TravelAdvice.Domaine.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TravelAdvice.Domaine.infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryBase<T> getRepository<T>() where T : class;

        void Commit();

      //  ISwapperRepository SwapperRepository { get; }
       IVoleRepository VoleRepository { get; }

  
    }
}
