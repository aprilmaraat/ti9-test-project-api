using Microsoft.EntityFrameworkCore;

namespace Ti9.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.EnableSensitiveDataLogging(false);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Client>(entity =>
        //    {
        //        entity.ToTable("enum.User.Type");

        //        entity.Property(e => e.ID)
        //            .HasColumnType("tinyint")
        //            .ValueGeneratedNever();

        //        entity.Property(e => e.Name)
        //            .HasColumnType("varchar(255)");
        //    });
        //}
    }
}
