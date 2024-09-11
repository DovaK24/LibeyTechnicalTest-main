using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LibeyTechnicalTestDomain.EFCore.Configuration
{
	internal class UbigeoConfiguration : IEntityTypeConfiguration<Ubigeo>
	{
		public void Configure(EntityTypeBuilder<Ubigeo> builder)
		{
			builder.ToTable("Ubigeo").HasKey(x => x.UbigeoCode);
			builder.Property(x => x.ProvinceCode).IsRequired();
			builder.Property(x => x.RegionCode).IsRequired();
			builder.Property(x => x.UbigeoDescription).IsRequired().HasMaxLength(100);
		}
	}
}
