using System;
using System.Collections.Generic;

namespace TravelAdvice.Domaine.Entity
{
    public partial class destination
    {
        public destination()
        {
            this.offres = new List<offre>();
        }

        public int id { get; set; }
        public string pays { get; set; }
        public string ville { get; set; }
        public virtual ICollection<offre> offres { get; set; }
    }
}
