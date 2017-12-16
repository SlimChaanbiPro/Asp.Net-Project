using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvice.Domaine;
using TravelAdvice.Domaine.Entity;
using TravelAdvice.Domaine.infrastructure;

namespace TravelAdvice.Data.Repo
{
    public class ReservationRepository : RepositoryBase<reservationvole>, IReservationRepository
    {
        //private IDatabaseFactory dbFactory;

        public ReservationRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {
            //this.dbFactory = dbFactory;
        }
         }
    public interface IReservationRepository : IRepositoryBase<reservationvole> { }

}
