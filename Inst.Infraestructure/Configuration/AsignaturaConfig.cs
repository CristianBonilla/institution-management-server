using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Inst.Entities;

namespace Inst.Infrastructure
{
    class AsignaturaConfig : IEntityTypeConfiguration<AsignaturaEntity>
    {
        public void Configure(EntityTypeBuilder<AsignaturaEntity> builder)
        {
            builder.ToTable("Asignatura", "dbo")
                .HasKey(k => k.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();
            builder.Property(p => p.Nombre)
                .HasMaxLength(30)
                .IsUnicode(true)
                .IsRequired();
        }
    }
}
