using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvice.Domaine;
using TravelAdvice.Domaine.Entity;
using TravelAdvice.Domaine.infrastructure;

namespace TravelAdvice.Service
{
    public class ReservationService : IReservation
    {
        IDatabaseFactory dbfactory = null;
        IUnitOfWork uow = null;

        public ReservationService()
        {
            dbfactory = new DatabaseFactory();
            uow = new UnitOfWork(dbfactory);
        }

        public void AddReservation(reservationvole r)
        {
            uow.getRepository<reservationvole>().Add(r);
        }

        public void DeleteReservation(int id)
        {
            reservationvole p = uow.getRepository<reservationvole>().GetById(id);
            uow.getRepository<reservationvole>().Delete(p);
            uow.Commit();
        }

        public void Dispose()
        {
            uow.Dispose();
        }

        public IEnumerable<reservationvole> GetAllReservation()
        {
            return uow.getRepository<reservationvole>().GetAll();
        }

        public IEnumerable<reservationvole> GetAllReservationByUser(int id)
        {
            return uow.getRepository<reservationvole>().GetMany(u => u.user.id == id);
        }

        public IEnumerable<reservationvole> GetAllReservationByVole(int id)
        {
            return uow.getRepository<reservationvole>().GetMany(v => v.vole.id == id);
        }

        public reservationvole GetReservationById(int id)
        {
            return uow.getRepository<reservationvole>().GetById(id);
        }

        public int NbreReservation( int id)
        {
            return GetAllReservationByUser( id).Count();
        }

        public int nbreRservationByVole(int id)
        {
            return GetAllReservationByVole(id).Count();
        }

        public void SaveChange()
        {
            uow.Commit();
        }

        public Dictionary<string, int> StatVole(int id )
        {
            {

                var ss = from reservationvole u in GetAllReservationByVole(id)
                         group u by u.date_reservation into g
                         select new { g.Key, Count = g.Count() };
                Dictionary<string, int> depart = new Dictionary<string, int>();
                foreach (var t in ss)
                {
                    depart.Add(t.Key.ToString(), t.Count);
                    Console.WriteLine(t.Key + "" + t.Count);
                }
                return depart;
            }
        }
    }
}
