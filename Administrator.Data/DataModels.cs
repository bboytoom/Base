namespace Administrator.Data
{
    using System.Data.Entity;

    public partial class DataModels : DbContext
    {
        public DataModels()
            : base("name=DataModels")
        {
        }

        public virtual DbSet<Tbl_Groups> Tbl_Groups { get; set; }
        public virtual DbSet<Tbl_Users> Tbl_Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbl_Groups>()
                .Property(e => e.Group)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Groups>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Groups>()
                .HasMany(e => e.Tbl_Users)
                .WithRequired(e => e.Tbl_Groups)
                .HasForeignKey(e => e.Id_group);

            modelBuilder.Entity<Tbl_Users>()
                .Property(e => e.Photo)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Users>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Users>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Users>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Users>()
                .Property(e => e.LnameP)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Users>()
                .Property(e => e.LnameM)
                .IsUnicode(false);
        }
    }
}
