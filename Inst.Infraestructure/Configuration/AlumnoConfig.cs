using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Inst.Entities;

namespace Inst.Infrastructure
{
    class AlumnoConfig : IEntityTypeConfiguration<AlumnoEntity>
    {
        public void Configure(EntityTypeBuilder<AlumnoEntity> builder)
        {
            builder.ToTable("Alumno", "dbo")
                .HasKey(k => k.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();
            builder.Property(p => p.Identificacion)
                .IsRequired();
            builder.Property(p => p.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();
            builder.Property(p => p.Apellido)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}
