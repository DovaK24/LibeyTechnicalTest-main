using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
	public interface IDocumentTypeService
	{
		IEnumerable<DocumentType> GetDocumentType();
	}
}
