using System.Data.Entity;


namespace AICRDWEB.Models
{
    public class AICRDWEBDbContext: DbContext
    {
        public DbSet<Asociacion> Asociacion { get; set; }
        public DbSet<Cargos> Cargo { get; set; }
        public DbSet<Circuitos> Circuito { get; set; }
        public DbSet<Iglesias> Iglesia { get; set; }
        public DbSet<ImagenesMiembro> ImagenMiembros { get; set; }
        public DbSet<Miembros> Miembro { get; set; }
        public DbSet<Region> Regiones { get; set; }
        public DbSet<RegistroConvencion> Registro { get; set; }




        public AICRDWEBDbContext()
            : base("AICRDBWEB")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegistroConvencion>()
               .HasOptional<Iglesias>(s => s.Iglesia)
               .WithMany()
               .WillCascadeOnDelete(false);

        }


    }
}
