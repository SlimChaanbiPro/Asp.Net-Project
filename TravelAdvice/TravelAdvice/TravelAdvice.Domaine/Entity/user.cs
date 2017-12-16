using System;
using System.Collections.Generic;

namespace TravelAdvice.Domaine.Entity
{
    public partial class user
    {
        public user()
        {
            this.friendships = new List<friendship>();
            this.friendships1 = new List<friendship>();
            this.messages = new List<message>();
            this.messages1 = new List<message>();
            this.reservations = new List<reservation>();
            this.reservationvoles = new List<reservationvole>();
        }

        public int id { get; set; }
        public string adress { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string nom { get; set; }
        public string password { get; set; }
        public string prenom { get; set; }
        public string type { get; set; }
        public Nullable<int> role_id { get; set; }
        public virtual ICollection<friendship> friendships { get; set; }
        public virtual ICollection<friendship> friendships1 { get; set; }
        public virtual ICollection<message> messages { get; set; }
        public virtual ICollection<message> messages1 { get; set; }
        public virtual ICollection<reservation> reservations { get; set; }
        public virtual ICollection<reservationvole> reservationvoles { get; set; }
        public virtual role role { get; set; }
    }
}
