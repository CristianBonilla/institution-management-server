using Microsoft.EntityFrameworkCore;

namespace Institution.Domain
{
    public partial class InstitutionContext : DbContext
    {
        public DbSet<AsignaturaEntity> Asignaturas { get; set; }
        public DbSet<AlumnoEntity> Alumnos { get; set; }
        public DbSet<NotaEntity> Notas { get; set; }

        public InstitutionContext(DbContextOptions<InstitutionContext> contextOptions) : base(contextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AsignaturaConfig())
                .ApplyConfiguration(new AlumnoConfig())
                .ApplyConfiguration(new NotaConfig());
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
