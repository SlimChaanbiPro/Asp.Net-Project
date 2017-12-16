using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvice.Domaine;
using TravelAdvice.Domaine.Entity;

namespace TravelAdvice.Service
{
    public interface IReservation : IDisposable
    {
         

        void AddReservation(reservationvole r);
        void DeleteReservation(int id);
        IEnumerable<reservationvole> GetAllReservation();
        IEnumerable<reservationvole> GetAllReservationByUser(int id);
        reservationvole GetReservationById(int id);
       
        void SaveChange();
          Dictionary<string, int> StatVole(int id);
        int NbreReservation( int id);
        IEnumerable<reservationvole> GetAllReservationByVole(int id);
        int nbreRservationByVole(int id);
    
    }
}
