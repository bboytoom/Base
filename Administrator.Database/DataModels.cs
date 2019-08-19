using Microsoft.EntityFrameworkCore;

namespace Administrator.Database
{
    public class DataModels : DbContext
    {
        public DbSet<Tbl_Groups> Tbl_Groups { get; set; }
        public DbSet<Tbl_Users> Tbl_Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=DbSystem;user=root;password=bboytoom");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tbl_Groups>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Id_main).IsRequired();
                entity.Property(e => e.Group).IsRequired();
            });

            modelBuilder.Entity<Tbl_Users>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Id_main).IsRequired();
                entity.Property(e => e.Type).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.LnameP).IsRequired();
            });
        }
    }
}
