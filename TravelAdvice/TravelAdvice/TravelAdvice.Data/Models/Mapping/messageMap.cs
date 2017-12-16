using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TravelAdvice.Domaine.Entity;

namespace TravelAdvice.Data.Models.Mapping
{
    public class messageMap : EntityTypeConfiguration<message>
    {
        public messageMap()
        {
            // Primary Key
            this.HasKey(t => t.idMessage);

            // Properties
            this.Property(t => t.text)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("message", "traveladvice");
            this.Property(t => t.idMessage).HasColumnName("idMessage");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.text).HasColumnName("text");
            this.Property(t => t.idReceiver).HasColumnName("idReceiver");
            this.Property(t => t.idSender).HasColumnName("idSender");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.messages)
                .HasForeignKey(d => d.idSender);
            this.HasOptional(t => t.user1)
                .WithMany(t => t.messages1)
                .HasForeignKey(d => d.idReceiver);

        }
    }
}
