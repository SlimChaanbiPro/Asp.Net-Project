using TravelAdvice.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TravelAdvice.Domaine.Repo;
using TravelAdvice.Data;
using TravelAdvice.Data.Repo;
using TravelAdvice.Data.Models;

namespace TravelAdvice.Domaine.infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        private traveladviceContext dataContext;

        IDatabaseFactory dbFactory;
        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
            dataContext = dbFactory.DataContext;
        }

          private IVoleRepository volerepository;
        private IReservationRepository reservationRepository;


        // private ISwapperRepository swapperrepository;



        /*   public ISwapperRepository SwapperRepository
           {
               get
               {
                   return swapperrepository = new SwapperRepository(dbFactory);
               }
           }*/

        public IVoleRepository VoleRepository
        {
              get
              {
                  return volerepository = new VoleRepository(dbFactory);
              }
          }
        public IReservationRepository ReservationRepository
        {
            get
            {
                return reservationRepository = new ReservationRepository(dbFactory);
            }
        }

        public void Commit()
        {
            dataContext.SaveChanges();
        }
        public void CommitAsync()
        {
            dataContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            dataContext.Dispose();
        }
        public IRepositoryBase<T> getRepository<T>() where T : class
        {
            IRepositoryBase<T> repo = new RepositoryBase<T>(dbFactory);
            return repo;
        }

    }
}
