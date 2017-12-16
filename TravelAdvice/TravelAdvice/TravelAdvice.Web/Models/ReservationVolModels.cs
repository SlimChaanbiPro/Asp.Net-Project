using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TravelAdvice.Domaine;
using TravelAdvice.Domaine.Entity;

namespace TravelAdvice.Web.Models
{
    public class ReservationVolModels
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public DateTime? date_reservation { get; set; }

        public int? users_id { get; set; }

        public int? vole_id { get; set; }

        public virtual vole vole { get; set; }

        public virtual user user { get; set; }
    }
}