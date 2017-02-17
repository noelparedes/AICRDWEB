using System.Data.Entity;


namespace AICRDWEB.Models
{
    public class AICRDWEBDbContext : DbContext
    {
        public DbSet<Asociacion> Asociaciones { get; set; }
        public DbSet<Cargos> Cargos { get; set; }
        public DbSet<Circuitos> Circuitos { get; set; }
        public DbSet<Iglesias> Iglesias { get; set; }
        public DbSet<ImagenesMiembro> ImagenMiembros { get; set; }
        public DbSet<Miembros> Miembros { get; set; }
        public DbSet<Region> Regiones { get; set; }
        public DbSet<RegistroConvencion> Registros { get; set; }




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
