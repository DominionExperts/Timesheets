using System;
using System.Linq;
using DE.Timesheets.Domain;
using DE.Timesheets.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DE.Timesheets.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<VerlofHistoriek> VerlofHistoriek { get; set; }
        public DbSet<TimesheetDag> TimesheetDagen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<VerlofHistoriek>(ConfigureVerlofHistoriek);
            modelBuilder.Entity<TimesheetDag>(ConfigureTimesheetDag);
        }

        public override int SaveChanges()
        {
            AddTimeStamp();
            return base.SaveChanges();
        }

        private static void ConfigureUser(EntityTypeBuilder<User> user)
        {
            user.Property(t => t.Naam).IsRequired();
            user.Property(t => t.JaarlijksVerlof).IsRequired().HasDefaultValue(0);
            user.ToTable("DE_User");
        }

        private static void ConfigureVerlofHistoriek(EntityTypeBuilder<VerlofHistoriek> historiek)
        {
            historiek.Property(t => t.UserId).IsRequired();
            historiek.Property(t => t.Type).IsRequired();
            historiek.Property(t => t.Datum).IsRequired();
            historiek.Property(t => t.EenheidsType).IsRequired();
            historiek.Property(t => t.Status).IsRequired();            
            historiek.ToTable("DE_VerlofHistoriek");
        }

        private void ConfigureTimesheetDag(EntityTypeBuilder<TimesheetDag> dag)
        {
            dag.Property(d => d.Id).IsRequired();
            dag.Property(d => d.UserId).IsRequired();
            dag.Property(d => d.Datum).IsRequired();
            dag.ToTable("DE_TimesheetDagen");
        }

        private void AddTimeStamp()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                var entity = entry.Entity as IEntity;
                if (entity != null) entity.ModificationDate = DateTime.UtcNow;
            }
        }
    }
}
