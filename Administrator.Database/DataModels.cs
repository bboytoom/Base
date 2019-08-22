using Microsoft.EntityFrameworkCore;

namespace Administrator.Database
{
    public class DataModels : DbContext
    {
        public DbSet<Tbl_Groups> Tbl_Groups { get; set; }

        public DbSet<Tbl_Permission_User> Tbl_Permission_User { get; set; }

        public DbSet<Tbl_Permission_Root> Tbl_Permission_Root { get; set; }

        public DbSet<Cat_Users> Cat_Users { get; set; }

        public DbSet<Tbl_Users> Tbl_Users { get; set; }

        public DbSet<Tbl_Entry> Tbl_Entry { get; set; }

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

            modelBuilder.Entity<Tbl_Groups>(entity =>
            {
                entity.HasOne(a => a.Permission_User)
                .WithOne(b => b.Tbl_Groups)
                .HasForeignKey<Tbl_Permission_User>(b => b.Id);
            });

            modelBuilder.Entity<Tbl_Groups>(entity =>
            {
                entity.HasOne(a => a.Permission_Root)
                .WithOne(b => b.Tbl_Groups)
                .HasForeignKey<Tbl_Permission_Root>(b => b.Id);
            });

            modelBuilder.Entity<Cat_Users>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Id_main).IsRequired();
                entity.Property(e => e.Name).IsRequired();
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

            modelBuilder.Entity<Tbl_Entry>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.FullName).IsRequired();
                entity.Property(e => e.IP_User).IsRequired();
                entity.Property(e => e.Browser).IsRequired();
            });

            //modelBuilder.Seed();
        }
    }
}
