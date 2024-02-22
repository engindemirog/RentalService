using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RentalBranchConfiguration : IEntityTypeConfiguration<RentalBranch>
{
    public void Configure(EntityTypeBuilder<RentalBranch> builder)
    {
        builder.ToTable("RentalBranches").HasKey(rb => rb.Id);

        builder.Property(rb => rb.Id).HasColumnName("Id").IsRequired();
        builder.Property(rb => rb.City).HasColumnName("City");
        builder.Property(rb => rb.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(rb => rb.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(rb => rb.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(rb => !rb.DeletedDate.HasValue);
    }
}