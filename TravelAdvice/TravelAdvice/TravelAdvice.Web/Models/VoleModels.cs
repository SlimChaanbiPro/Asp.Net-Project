using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TravelAdvice.Domaine;
using TravelAdvice.Domaine.Entity;

namespace TravelAdvice.Web.Models
{
    public class VoleModels
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? date_arrive { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? date_depart { get; set; }
      
      

        [StringLength(255)]
        public string depart { get; set; }

        [StringLength(255)]
        public string destination { get; set; }

        public int? nb_place { get; set; }

        public float prix_unitaire { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reservationvole> reservationvoles { get; set; }
    }
}