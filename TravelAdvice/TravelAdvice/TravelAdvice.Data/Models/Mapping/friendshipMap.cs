using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TravelAdvice.Domaine.Entity;

namespace TravelAdvice.Data.Models.Mapping
{
    public class friendshipMap : EntityTypeConfiguration<friendship>
    {
        public friendshipMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("friendship", "traveladvice");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.accepted).HasColumnName("accepted");
            this.Property(t => t.idUser1).HasColumnName("idUser1");
            this.Property(t => t.idUser2).HasColumnName("idUser2");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.friendships)
                .HasForeignKey(d => d.idUser1);
            this.HasOptional(t => t.user1)
                .WithMany(t => t.friendships1)
                .HasForeignKey(d => d.idUser2);

        }
    }
}
