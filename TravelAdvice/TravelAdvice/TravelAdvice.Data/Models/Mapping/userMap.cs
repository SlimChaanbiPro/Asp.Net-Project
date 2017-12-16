using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TravelAdvice.Domaine.Entity;

namespace TravelAdvice.Data.Models.Mapping
{
    public class userMap : EntityTypeConfiguration<user>
    {
        public userMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.adress)
                .HasMaxLength(255);

            this.Property(t => t.email)
                .HasMaxLength(255);

            this.Property(t => t.login)
                .HasMaxLength(255);

            this.Property(t => t.nom)
                .HasMaxLength(255);

            this.Property(t => t.password)
                .HasMaxLength(255);

            this.Property(t => t.prenom)
                .HasMaxLength(255);

            this.Property(t => t.type)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("user", "traveladvice");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.adress).HasColumnName("adress");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.login).HasColumnName("login");
            this.Property(t => t.nom).HasColumnName("nom");
            this.Property(t => t.password).HasColumnName("password");
            this.Property(t => t.prenom).HasColumnName("prenom");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.role_id).HasColumnName("role_id");

            // Relationships
            this.HasOptional(t => t.role)
                .WithMany(t => t.users)
                .HasForeignKey(d => d.role_id);

        }
    }
}
