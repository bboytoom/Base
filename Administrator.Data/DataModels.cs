namespace Administrator.Data
{
    using System.Data.Entity;

    public partial class DataModels : DbContext
    {
        public DataModels()
            : base("name=DataModels")
        {
        }

        public virtual DbSet<Tbl_Emails> Tbl_Emails { get; set; }
        public virtual DbSet<Tbl_Groups> Tbl_Groups { get; set; }
        public virtual DbSet<Tbl_Permissions> Tbl_Permissions { get; set; }
        public virtual DbSet<Tbl_Users> Tbl_Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbl_Emails>()
                .Property(e => e.Email_email)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Emails>()
                .Property(e => e.Description_email)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Groups>()
                .Property(e => e.Name_group)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Groups>()
                .Property(e => e.Description_group)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Groups>()
                .HasOptional(e => e.Tbl_Permissions)
                .WithRequired(e => e.Tbl_Groups);

            modelBuilder.Entity<Tbl_Groups>()
                .HasMany(e => e.Tbl_Users)
                .WithRequired(e => e.Tbl_Groups)
                .HasForeignKey(e => e.Id_group);

            modelBuilder.Entity<Tbl_Users>()
                .Property(e => e.Photo_user)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Users>()
                .Property(e => e.Email_user)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Users>()
                .Property(e => e.Password_user)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Users>()
                .Property(e => e.Name_user)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Users>()
                .Property(e => e.LnameP_user)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Users>()
                .Property(e => e.LnameM_user)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Users>()
                .HasMany(e => e.Tbl_Emails)
                .WithRequired(e => e.Tbl_Users)
                .HasForeignKey(e => e.Id_user);
        }
    }
}
