using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LibeyTechnicalTestDomain.EFCore.Configuration
{
	internal class ProvinceConfiguration : IEntityTypeConfiguration<Province>
	{
		public void Configure(EntityTypeBuilder<Province> builder)
		{
			builder.ToTable("Province").HasKey(x => x.ProvinceCode);
			builder.Property(x => x.RegionCode).IsRequired();
			builder.Property(x => x.ProvinceDescription).IsRequired().HasMaxLength(100);
		}
	}
}
