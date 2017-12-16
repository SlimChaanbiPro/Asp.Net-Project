using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TravelAdvice.Domaine.Entity;

namespace TravelAdvice.Data.Models.Mapping
{
    public class voleMap : EntityTypeConfiguration<vole>
    {
        public voleMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.depart)
                .HasMaxLength(255);

            this.Property(t => t.destination)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("vole", "traveladvice");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.date_arrive).HasColumnName("date_arrive");
            this.Property(t => t.date_depart).HasColumnName("date_depart");
            this.Property(t => t.depart).HasColumnName("depart");
            this.Property(t => t.destination).HasColumnName("destination");
            this.Property(t => t.nb_place).HasColumnName("nb_place");
            this.Property(t => t.prix_unitaire).HasColumnName("prix_unitaire");
        }
    }
}
