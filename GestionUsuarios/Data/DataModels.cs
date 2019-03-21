namespace GestionUsuarios.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModels : DbContext
    {
        public DataModels()
            : base("name=DataModels")
        {
        }

        public virtual DbSet<Tbl_Correos> Tbl_Correos { get; set; }
        public virtual DbSet<Tbl_Grupos> Tbl_Grupos { get; set; }
        public virtual DbSet<Tbl_Permisos> Tbl_Permisos { get; set; }
        public virtual DbSet<Tbl_Usuarios> Tbl_Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbl_Grupos>()
                .HasOptional(e => e.Tbl_Permisos)
                .WithRequired(e => e.Tbl_Grupos);

            modelBuilder.Entity<Tbl_Grupos>()
                .HasMany(e => e.Tbl_Usuarios)
                .WithRequired(e => e.Tbl_Grupos)
                .HasForeignKey(e => e.id_grupo);

            modelBuilder.Entity<Tbl_Usuarios>()
                .HasMany(e => e.Tbl_Correos)
                .WithRequired(e => e.Tbl_Usuarios)
                .HasForeignKey(e => e.id_usuario);
        }
    }
}
