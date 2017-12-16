using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TravelAdvice.Domaine.Entity;

namespace TravelAdvice.Data.Models.Mapping
{
    public class destinationMap : EntityTypeConfiguration<destination>
    {
        public destinationMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.pays)
                .HasMaxLength(255);

            this.Property(t => t.ville)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("destination", "traveladvice");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.pays).HasColumnName("pays");
            this.Property(t => t.ville).HasColumnName("ville");
        }
    }
}
