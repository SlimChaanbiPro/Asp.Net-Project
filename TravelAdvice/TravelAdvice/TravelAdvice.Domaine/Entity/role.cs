using System;
using System.Collections.Generic;

namespace TravelAdvice.Domaine.Entity
{
    public partial class role
    {
        public role()
        {
            this.users = new List<user>();
        }

        public int id { get; set; }
        public string type { get; set; }
        public virtual ICollection<user> users { get; set; }
    }
}
