using ChallengeN5.Domain.AggregateRoots.Permission;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChallengeN5.Infr.DataAccess.Configuration
{
    internal class PermissionTypeETC : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.ToTable("TiposPermisos");
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                   .ValueGeneratedOnAdd()
                   .HasComment("Unique ID");
            
            builder.Property(i => i.Description)
                   .HasColumnName("Descripcion")
                   .IsRequired()
                   .HasComment("Permission description");

            builder.HasData(DababaseSeed.PermissionTypes);
        }
    }
}
