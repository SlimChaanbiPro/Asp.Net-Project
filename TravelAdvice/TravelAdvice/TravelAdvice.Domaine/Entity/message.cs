using System;
using System.Collections.Generic;

namespace TravelAdvice.Domaine.Entity
{
    public partial class message
    {
        public int idMessage { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string text { get; set; }
        public Nullable<int> idReceiver { get; set; }
        public Nullable<int> idSender { get; set; }
        public virtual user user { get; set; }
        public virtual user user1 { get; set; }
    }
}
