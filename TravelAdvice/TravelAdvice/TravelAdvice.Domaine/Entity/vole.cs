using System;
using System.Collections.Generic;

namespace TravelAdvice.Domaine.Entity
{
    public partial class vole
    {
        public vole()
        {
            this.reservationvoles = new List<reservationvole>();
        }

        public int id { get; set; }
        public Nullable<System.DateTime> date_arrive { get; set; }
        public Nullable<System.DateTime> date_depart { get; set; }
        public string depart { get; set; }
        public string destination { get; set; }
        public Nullable<int> nb_place { get; set; }
        public float prix_unitaire { get; set; }
        public virtual ICollection<reservationvole> reservationvoles { get; set; }
    }
}
