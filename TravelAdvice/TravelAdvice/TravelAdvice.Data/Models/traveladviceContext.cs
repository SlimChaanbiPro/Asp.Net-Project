using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TravelAdvice.Data.Models.Mapping;
using TravelAdvice.Domaine.Entity;

namespace TravelAdvice.Data.Models
{
    public partial class traveladviceContext : DbContext
    {
        static traveladviceContext()
        {
            Database.SetInitializer<traveladviceContext>(null);
        }

        public traveladviceContext()
            : base("Name=traveladviceContext")
        {
        }

        public DbSet<destination> destinations { get; set; }
        public DbSet<friendship> friendships { get; set; }
        public DbSet<message> messages { get; set; }
        public DbSet<offre> offres { get; set; }
        public DbSet<reservation> reservations { get; set; }
        public DbSet<reservationvole> reservationvoles { get; set; }
        public DbSet<role> roles { get; set; }
        public DbSet<user> users { get; set; }
        public DbSet<vole> voles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new destinationMap());
            modelBuilder.Configurations.Add(new friendshipMap());
            modelBuilder.Configurations.Add(new messageMap());
            modelBuilder.Configurations.Add(new offreMap());
            modelBuilder.Configurations.Add(new reservationMap());
            modelBuilder.Configurations.Add(new reservationvoleMap());
            modelBuilder.Configurations.Add(new roleMap());
            modelBuilder.Configurations.Add(new userMap());
            modelBuilder.Configurations.Add(new voleMap());
        }
    }
}
