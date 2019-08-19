using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Institution.Domain
{
    class NotaConfig : IEntityTypeConfiguration<NotaEntity>
    {
        public void Configure(EntityTypeBuilder<NotaEntity> builder)
        {
            builder.ToTable("Nota", "dbo")
                .HasKey(k => k.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();
            builder.HasOne(o => o.Asignatura)
                .WithMany()
                .HasForeignKey(f => f.IdAsignatura)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(o => o.Alumno)
                .WithMany()
                .HasForeignKey(f => f.IdAlumno)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
