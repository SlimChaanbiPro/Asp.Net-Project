using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TravelAdvice.Domaine.Entity;

namespace TravelAdvice.Data.Models.Mapping
{
    public class reservationMap : EntityTypeConfiguration<reservation>
    {
        public reservationMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("reservation", "traveladvice");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.nombre).HasColumnName("nombre");
            this.Property(t => t.offreReserve_id).HasColumnName("offreReserve_id");
            this.Property(t => t.user_id).HasColumnName("user_id");

            // Relationships
            this.HasOptional(t => t.offre)
                .WithMany(t => t.reservations)
                .HasForeignKey(d => d.offreReserve_id);
            this.HasOptional(t => t.user)
                .WithMany(t => t.reservations)
                .HasForeignKey(d => d.user_id);

        }
    }
}
