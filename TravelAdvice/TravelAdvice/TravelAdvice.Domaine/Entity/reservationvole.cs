using System;
using System.Collections.Generic;

namespace TravelAdvice.Domaine.Entity
{
    public partial class reservationvole
    {
        public int id { get; set; }
        public Nullable<System.DateTime> date_reservation { get; set; }
        public Nullable<int> users_id { get; set; }
        public Nullable<int> vole_id { get; set; }
        public virtual vole vole { get; set; }
        public virtual user user { get; set; }
    }
}
