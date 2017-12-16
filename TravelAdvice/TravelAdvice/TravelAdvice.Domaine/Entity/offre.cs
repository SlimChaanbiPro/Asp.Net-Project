using System;
using System.Collections.Generic;

namespace TravelAdvice.Domaine.Entity
{
    public partial class offre
    {
        public offre()
        {
            this.reservations = new List<reservation>();
        }

        public int id { get; set; }
        public Nullable<System.DateTime> dateFin { get; set; }
        public Nullable<System.DateTime> dateLancement { get; set; }
        public string description { get; set; }
        public Nullable<bool> disponibilite { get; set; }
        public string nomOffre { get; set; }
        public Nullable<int> nombrePlace { get; set; }
        public Nullable<float> prix { get; set; }
        public Nullable<int> destination_id { get; set; }
        public virtual destination destination { get; set; }
        public virtual ICollection<reservation> reservations { get; set; }
    }
}
