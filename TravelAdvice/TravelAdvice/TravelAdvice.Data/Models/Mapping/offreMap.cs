using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TravelAdvice.Domaine.Entity;

namespace TravelAdvice.Data.Models.Mapping
{
    public class offreMap : EntityTypeConfiguration<offre>
    {
        public offreMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.nomOffre)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("offre", "traveladvice");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.dateFin).HasColumnName("dateFin");
            this.Property(t => t.dateLancement).HasColumnName("dateLancement");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.disponibilite).HasColumnName("disponibilite");
            this.Property(t => t.nomOffre).HasColumnName("nomOffre");
            this.Property(t => t.nombrePlace).HasColumnName("nombrePlace");
            this.Property(t => t.prix).HasColumnName("prix");
            this.Property(t => t.destination_id).HasColumnName("destination_id");

            // Relationships
            this.HasOptional(t => t.destination)
                .WithMany(t => t.offres)
                .HasForeignKey(d => d.destination_id);

        }
    }
}
