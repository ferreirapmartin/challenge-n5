using ChallengeN5.Domain.AggregateRoots.Permission;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChallengeN5.Infr.DataAccess.Configuration
{
    internal class PermissionETC : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permisos");
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                   .ValueGeneratedOnAdd()
                   .HasComment("Unique ID");
            
            builder.Property(i => i.Forename)
                   .HasColumnName("NombreEmpleado")
                   .IsRequired()
                   .HasComment("Employee Forename");

            builder.Property(i => i.Surname)
                   .HasColumnName("ApellidoEmpleado")
                   .IsRequired()
                   .HasComment("Employee Surname");

            builder.Property(i => i.TypeId)
                   .HasColumnName("TipoPermiso")
                   .IsRequired()
                   .HasComment("Permission Type");

            builder.Property(i => i.CreatedDate)
                   .HasColumnName("FechaPermiso")
                   .IsRequired()
                   .HasComment("Permission granted on Date");
            
            builder.HasOne(i => i.Type)
                   .WithMany()
                   .HasForeignKey(i => i.TypeId);

            builder.HasData(DababaseSeed.Permissions);
        }
    }
}
