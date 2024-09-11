using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LibeyTechnicalTestDomain.EFCore.Configuration
{
	internal class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
	{
		public void Configure(EntityTypeBuilder<DocumentType> builder)
		{
			builder.ToTable("DocumentType").HasKey(x => x.DocumentTypeId);
			builder.Property(x => x.DocumentTypeDescription).IsRequired().HasMaxLength(50);
		}
	}
}
