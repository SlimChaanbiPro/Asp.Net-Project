using System;
using System.Collections.Generic;

namespace TravelAdvice.Domaine.Entity
{
    public partial class reservation
    {
        public int id { get; set; }
        public Nullable<int> nombre { get; set; }
        public Nullable<int> offreReserve_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public virtual offre offre { get; set; }
        public virtual user user { get; set; }
    }
}
