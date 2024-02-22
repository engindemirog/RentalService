using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RentalsAdditionalServiceConfiguration : IEntityTypeConfiguration<RentalsAdditionalService>
{
    public void Configure(EntityTypeBuilder<RentalsAdditionalService> builder)
    {
        builder.ToTable("RentalsAdditionalServices").HasKey(ras => ras.Id);

        builder.Property(ras => ras.Id).HasColumnName("Id").IsRequired();
        builder.Property(ras => ras.RentalId).HasColumnName("RentalId");
        builder.Property(ras => ras.AdditionalServiceId).HasColumnName("AdditionalServiceId");
        builder.Property(ras => ras.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ras => ras.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ras => ras.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ras => !ras.DeletedDate.HasValue);
    }
}