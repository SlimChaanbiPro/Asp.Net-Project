using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TravelAdvice.Domaine.Entity;

namespace TravelAdvice.Data.Models.Mapping
{
    public class reservationvoleMap : EntityTypeConfiguration<reservationvole>
    {
        public reservationvoleMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("reservationvole", "traveladvice");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.date_reservation).HasColumnName("date_reservation");
            this.Property(t => t.users_id).HasColumnName("users_id");
            this.Property(t => t.vole_id).HasColumnName("vole_id");

            // Relationships
            this.HasOptional(t => t.vole)
                .WithMany(t => t.reservationvoles)
                .HasForeignKey(d => d.vole_id);
            this.HasOptional(t => t.user)
                .WithMany(t => t.reservationvoles)
                .HasForeignKey(d => d.users_id);

        }
    }
}
